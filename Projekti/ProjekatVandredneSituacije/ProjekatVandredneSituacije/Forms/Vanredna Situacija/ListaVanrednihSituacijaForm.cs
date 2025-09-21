using ProjekatVanredneSituacije;
using ProjekatVanredneSituacije.DTOs;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VanrednaSituacijaLibrary;

public class ListaVanrednihSituacijaForm : Form
{
    private DataGridView dgvVanredneSituacije;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    public ListaVanrednihSituacijaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(ListaVanrednihSituacijaForm_Load);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Vanrednih Situacija";
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

        dgvVanredneSituacije = new DataGridView();
        dgvVanredneSituacije.Dock = DockStyle.Fill;
        dgvVanredneSituacije.ReadOnly = true;
        dgvVanredneSituacije.AutoGenerateColumns = false; 
        dgvVanredneSituacije.AllowUserToAddRows = false;
        dgvVanredneSituacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", DataPropertyName = "Id" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tip", HeaderText = "Tip", DataPropertyName = "Tip" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "DatumOd", HeaderText = "Datum Od", DataPropertyName = "Datum_Od" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "DatumDo", HeaderText = "Datum Do", DataPropertyName = "Datum_Do" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "BrojUgrozenihOsoba", HeaderText = "Broj ugroženih osoba", DataPropertyName = "Broj_Ugrozenih_Osoba" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "NivoOpasnosti", HeaderText = "Nivo opasnosti", DataPropertyName = "Nivo_Opasnosti" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "Opstina", HeaderText = "Opština", DataPropertyName = "Opstina" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "Lokacija", HeaderText = "Lokacija", DataPropertyName = "Lokacija" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "Opis", HeaderText = "Opis", DataPropertyName = "Opis" });
        dgvVanredneSituacije.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdPrijava", HeaderText = "Id Prijave", DataPropertyName = "IdPrijava" });

        pnlContent.Controls.Add(dgvVanredneSituacije);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
    }

    private void ListaVanrednihSituacijaForm_Load(object? sender, EventArgs e)
    {
        RefreshDataGrid();
    }

    private async void RefreshDataGrid()
    {
        try
        {
            dgvVanredneSituacije.DataSource = null; 

            IList<VanrednaSituacijaView> VanredneBasic = await DTOManager.VratiVanredneSituacije();
            List<VanrednaSituacijaPregled> VanrednePregled = new List<VanrednaSituacijaPregled>();
            foreach (var vsb in VanredneBasic)
            {
                VanrednePregled.Add(new VanrednaSituacijaPregled
                (vsb.Id, vsb.Datum_Od, vsb.Datum_Do, vsb.Tip, vsb.Broj_Ugrozenih_Osoba, vsb.Nivo_Opasnosti, vsb.Opstina, vsb.Lokacija, vsb.Opis, vsb.Prijava.Id));
            }
            dgvVanredneSituacije.DataSource = VanrednePregled;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Greška pri učitavanju vanrednih situacija: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        var dialog = new DodajIzmeniVanrednuSituacijuDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (dialog.SituacijaBasic != null)
            {
                try
                {
                    DTOManager.DodajVanrednuSituaciju(dialog.SituacijaBasic);
                    RefreshDataGrid();
                    MessageBox.Show("Vanredna situacija je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri dodavanju vanredne situacije: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvVanredneSituacije.SelectedRows.Count > 0)
        {
            var selectedSituacijaPregled = dgvVanredneSituacije.SelectedRows[0].DataBoundItem as VanrednaSituacijaPregled;
            var dialog = new DodajIzmeniVanrednuSituacijuDialog(selectedSituacijaPregled);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.SituacijaBasic != null)
                {
                    try
                    {
                        DTOManager.IzmeniVandrednuSituaciju(dialog.SituacijaBasic);
                        RefreshDataGrid();
                        MessageBox.Show("Vanredna situacija je uspešno izmenjena.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška pri izmeni vanredne situacije: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite vanrednu situaciju za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnObrisi_Click(object? sender, EventArgs e)
    {
        if (dgvVanredneSituacije.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabranu vanrednu situaciju?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedSituacija = dgvVanredneSituacije.SelectedRows[0].DataBoundItem as VanrednaSituacijaPregled;
                try
                {
                    DTOManager.obrisiVandrednuSituaciju(selectedSituacija.Id);
                    RefreshDataGrid();
                    MessageBox.Show("Vanredna situacija je uspešno obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri brisanju vanredne situacije: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite vanrednu situaciju za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}