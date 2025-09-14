using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class ListaVozilaForm : Form
{
    private DataGridView dgvVozila;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    public static List<Vozilo> mockVozila = new List<Vozilo>();

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
        dgvVozila.AutoGenerateColumns = true;
        dgvVozila.AllowUserToAddRows = false;
        dgvVozila.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvVozila);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
    }

    private void ListaVozilaForm_Load(object sender, EventArgs e)
    {
        if (mockVozila.Count == 0)
        {
            mockVozila.Add(new Vozilo
            {
                Registarska_Oznaka = "NS-001-VA",
                Proizvodjac = "Renault",
                Status = StatusVozila.operativno,
                Lokacija = "Glavna baza"
            });
            mockVozila.Add(new Sanitetska
            {
                Registarska_Oznaka = "BG-123-HI",
                Proizvodjac = "Mercedes",
                Status = StatusVozila.operativno,
                Lokacija = "Bolnica"
            });
            mockVozila.Add(new Vozilo
            {
                Registarska_Oznaka = "SU-456-KO",
                Proizvodjac = "Iveco",
                Status = StatusVozila.u_kvaru,
                Lokacija = "Servis"
            });
        }

        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        dgvVozila.DataSource = null;
        dgvVozila.DataSource = mockVozila;
    }

    private void BtnDodaj_Click(object sender, EventArgs e)
    {
        var tipDialog = new Form
        {
            Text = "Izaberite tip vozila",
            Size = new Size(250, 150),
            StartPosition = FormStartPosition.CenterParent
        };
        var cmbTip = new ComboBox { Location = new Point(20, 20), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbTip.Items.AddRange(new string[] { "Vozilo", "Sanitetska" });
        var btnIzaberi = new Button { Text = "Dalje", Location = new Point(70, 60), DialogResult = DialogResult.OK };

        tipDialog.Controls.Add(cmbTip);
        tipDialog.Controls.Add(btnIzaberi);

        if (tipDialog.ShowDialog() == DialogResult.OK && cmbTip.SelectedItem != null)
        {
            Form? dialog = null;
            string selectedTip = cmbTip.SelectedItem.ToString() ?? string.Empty;

            if (selectedTip == "Vozilo")
                dialog = new DodajIzmeniVoziloDialog();
            else if (selectedTip == "Sanitetska")
                dialog = new DodajIzmeniVoziloDialog(new Sanitetska());

            if (dialog?.ShowDialog() == DialogResult.OK)
            {
                if (dialog is DodajIzmeniVoziloDialog voziloDialog)
                {
                    mockVozila.Add(voziloDialog.Vozilo!);
                    RefreshDataGrid();
                    MessageBox.Show("Vozilo je uspešno dodato.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    private void BtnIzmeni_Click(object sender, EventArgs e)
    {
        if (dgvVozila.SelectedRows.Count > 0)
        {
            var selectedVozilo = dgvVozila.SelectedRows[0].DataBoundItem as Vozilo;
            Form? dialog = null;

            if (selectedVozilo is Sanitetska sanitetska)
                dialog = new DodajIzmeniVoziloDialog(sanitetska);
            else
                dialog = new DodajIzmeniVoziloDialog(selectedVozilo);

            if (dialog?.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Vozilo je uspešno izmenjeno.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var selectedVozilo = dgvVozila.SelectedRows[0].DataBoundItem as Vozilo;
                mockVozila.Remove(selectedVozilo!);
                RefreshDataGrid();
                MessageBox.Show("Vozilo je uspešno obrisano.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite vozilo za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}