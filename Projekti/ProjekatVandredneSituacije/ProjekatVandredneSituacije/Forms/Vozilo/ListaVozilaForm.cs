using ProjekatVanredneSituacije;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VanrednaSituacijaLibrary;
using VanrednaSituacijaLibrary.DTOs;

public class ListaVozilaForm : Form
{
    private DataGridView dgvVozila;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    public ListaVozilaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(ListaVozilaForm_Load);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Vozila";
        this.BackColor = SystemColors.Control;
        this.Size = new Size(1000, 600);

        pnlButtons = new Panel();
        pnlButtons.Dock = DockStyle.Top;
        pnlButtons.Height = 50;
        pnlButtons.BackColor = SystemColors.Control;

        btnDodaj = new Button { Text = "Dodaj", Location = new Point(10, 10), Width = 100 };
        btnIzmeni = new Button { Text = "Izmeni", Location = new Point(120, 10), Width = 100 };
        btnObrisi = new Button { Text = "Obriši", Location = new Point(230, 10), Width = 100 };

        pnlButtons.Controls.Add(btnDodaj);
        pnlButtons.Controls.Add(btnIzmeni);
        pnlButtons.Controls.Add(btnObrisi);

        pnlContent = new Panel();
        pnlContent.Dock = DockStyle.Fill;

        dgvVozila = new DataGridView();
        dgvVozila.Dock = DockStyle.Fill;
        dgvVozila.ReadOnly = true;
        dgvVozila.AutoGenerateColumns = false;
        dgvVozila.AllowUserToAddRows = false;
        dgvVozila.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        dgvVozila.Columns.Add(new DataGridViewTextBoxColumn { Name = "RegistarskaOznaka", HeaderText = "Registarska Oznaka", DataPropertyName = "Registarska_Oznaka" });
        dgvVozila.Columns.Add(new DataGridViewTextBoxColumn { Name = "Proizvodjac", HeaderText = "Proizvođač", DataPropertyName = "Proizvodjac" });
        dgvVozila.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", HeaderText = "Status", DataPropertyName = "Status" });
        dgvVozila.Columns.Add(new DataGridViewTextBoxColumn { Name = "Lokacija", HeaderText = "Lokacija", DataPropertyName = "Lokacija" });

        pnlContent.Controls.Add(dgvVozila);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
    }

    private void ListaVozilaForm_Load(object sender, EventArgs e)
    {
        RefreshDataGridAsync();
    }

    private async Task RefreshDataGridAsync()
    {
        try
        {
            dgvVozila.DataSource = null;
            var vozilaBasic = await DataProvider.VratiSvaVozila();
            var vozilaPregled = new List<VoziloAddView>();

            foreach (var vb in vozilaBasic)
            {
                if (vb is SpecijalnaVozilaView svb)
                {
                    vozilaPregled.Add(new SpecijalizacijaAddView(svb.Registarska_Oznaka, svb.Proizvodjac, svb.Status, svb.Lokacija, svb.Namena));
                }
                else
                {
                    vozilaPregled.Add(new VoziloAddView(vb.Registarska_Oznaka, vb.Proizvodjac, vb.Status, vb.Lokacija));
                }
            }
            dgvVozila.DataSource = vozilaPregled;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Greška pri učitavanju vozila: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnDodaj_Click(object sender, EventArgs e)
    {
        var tipDialog = new Form
        {
            Text = "Izaberite tip vozila",
            Size = new Size(250, 180),
            StartPosition = FormStartPosition.CenterParent
        };
        var lblInfo = new Label { Text = "Izaberite tip vozila:", Location = new Point(20, 10), AutoSize = true };
        var cmbTip = new ComboBox { Location = new Point(20, 30), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbTip.Items.AddRange(new string[] { "Vozilo", "Sanitetska", "Džip", "Kamion", "Specijalno Vozilo" });
        var btnIzaberi = new Button { Text = "Dalje", Location = new Point(70, 80), DialogResult = DialogResult.OK };

        tipDialog.Controls.Add(lblInfo);
        tipDialog.Controls.Add(cmbTip);
        tipDialog.Controls.Add(btnIzaberi);

        if (tipDialog.ShowDialog() == DialogResult.OK && cmbTip.SelectedItem != null)
        {
            DodajIzmeniVoziloDialog dialog;
            string selectedTip = cmbTip.SelectedItem.ToString() ?? string.Empty;

            if (selectedTip == "Sanitetska")
                dialog = new DodajIzmeniVoziloDialog(new SanitetskaAddView());
            else if (selectedTip == "Džip")
                dialog = new DodajIzmeniVoziloDialog(new DzipoviAddView());
            else if (selectedTip == "Kamion")
                dialog = new DodajIzmeniVoziloDialog(new KamioniAddView());
            else if (selectedTip == "Specijalno Vozilo")
                dialog = new DodajIzmeniVoziloDialog(new SpecijalnaVozilaAddView());
            else
                dialog = new DodajIzmeniVoziloDialog(new VoziloAddView());

            if (dialog?.ShowDialog() == DialogResult.OK && dialog.VoziloBasic != null)
            {
                try
                { 
                    MessageBox.Show("Trenutno ne postoji metoda za dodavanje vozila. Molimo kreirajte je u DTOManager-u.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RefreshDataGridAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri dodavanju vozila: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void BtnIzmeni_Click(object sender, EventArgs e)
    {
        if (dgvVozila.SelectedRows.Count > 0)
        {
            var selectedVozilo = dgvVozila.SelectedRows[0].DataBoundItem as VoziloAddView;
            if (selectedVozilo == null) return;
             
            VoziloAddView basicVozilo;
            if (selectedVozilo is SpecijalnaVozilaAddView spec)
            {
                basicVozilo = new SpecijalnaVozilaAddView(spec.Registarska_Oznaka, spec.Proizvodjac, spec.Status, spec.Lokacija, spec.Namena);
            }
            else
            {
                basicVozilo = new VoziloAddView(selectedVozilo.Registarska_Oznaka, selectedVozilo.Proizvodjac, selectedVozilo.Status, selectedVozilo.Lokacija);
            }

            var dialog = new DodajIzmeniVoziloDialog(basicVozilo);

            if (dialog?.ShowDialog() == DialogResult.OK && dialog.VoziloBasic != null)
            {
                try
                { 
                    MessageBox.Show("Trenutno ne postoji metoda za izmenu vozila. Molimo kreirajte je u DTOManager-u.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RefreshDataGridAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri izmeni vozila: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite vozilo za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnObrisi_Click(object sender, EventArgs e)
    {
        if (dgvVozila.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabrano vozilo?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedVozilo = dgvVozila.SelectedRows[0].DataBoundItem as VoziloAddView;
                if (selectedVozilo == null) return;
                try
                { 
                    MessageBox.Show("Trenutno ne postoji metoda za brisanje vozila. Molimo kreirajte je u DTOManager-u.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    RefreshDataGridAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri brisanju vozila: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite vozilo za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}