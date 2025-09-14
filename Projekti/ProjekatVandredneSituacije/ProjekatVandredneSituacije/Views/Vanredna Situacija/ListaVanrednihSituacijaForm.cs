using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class ListaVanrednihSituacijaForm : Form
{
    private DataGridView dgvVanredneSituacije;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    // Mock lista za testiranje
    private static List<VanrednaSituacija> mockSituacije = new List<VanrednaSituacija>();

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
        dgvVanredneSituacije.AutoGenerateColumns = true;
        dgvVanredneSituacije.AllowUserToAddRows = false;
        dgvVanredneSituacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvVanredneSituacije);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
    }

    private void ListaVanrednihSituacijaForm_Load(object? sender, EventArgs e)
    {
        if (mockSituacije.Count == 0)
        {
            mockSituacije.Add(new VanrednaSituacija
            {
                Id = 1,
                Datum_Od = new DateTime(2025, 9, 10, 8, 0, 0),
                Datum_Do = new DateTime(2025, 9, 12, 18, 30, 0),
                Tip = "Poplava",
                Broj_Ugrozenih_Osoba = 50,
                Nivo_Opasnosti = NivoOpasnosti.visoka,
                Opstina = "Novi Beograd",
                Lokacija = "Trg Republike",
                Opis = "Izlivanje reke zbog obilnih kiša."
            });
            mockSituacije.Add(new VanrednaSituacija
            {
                Id = 2,
                Datum_Od = new DateTime(2025, 9, 15, 14, 0, 0),
                Datum_Do = DateTime.MinValue, // Simulišemo situaciju koja je u toku
                Tip = "Šumski požar",
                Broj_Ugrozenih_Osoba = 10,
                Nivo_Opasnosti = NivoOpasnosti.srednja,
                Opstina = "Zlatibor",
                Lokacija = "Planina Zlatibor",
                Opis = "Veliki požar šume usled suše."
            });
        }

        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        dgvVanredneSituacije.DataSource = null;
        dgvVanredneSituacije.DataSource = mockSituacije;
    }

    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        var dialog = new DodajIzmeniVanrednuSituacijuDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (dialog.Situacija != null)
            {
                dialog.Situacija.Id = mockSituacije.Any() ? mockSituacije.Max(vs => vs.Id) + 1 : 1;
                mockSituacije.Add(dialog.Situacija);
                RefreshDataGrid();
                MessageBox.Show("Vanredna situacija je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvVanredneSituacije.SelectedRows.Count > 0)
        {
            var selectedSituacija = dgvVanredneSituacije.SelectedRows[0].DataBoundItem as VanrednaSituacija;
            var dialog = new DodajIzmeniVanrednuSituacijuDialog(selectedSituacija!);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Vanredna situacija je uspešno izmenjena.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                var selectedSituacija = dgvVanredneSituacije.SelectedRows[0].DataBoundItem as VanrednaSituacija;
                mockSituacije.Remove(selectedSituacija!);
                RefreshDataGrid();
                MessageBox.Show("Vanredna situacija je uspešno obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite vanrednu situaciju za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}