using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class ListaPrijavaForm : Form
{
    private DataGridView dgvPrijave;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    // Mock lista za testiranje
    private static List<Prijava> mockPrijave = new List<Prijava>();

    public ListaPrijavaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(ListaPrijavaForm_Load);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Prijava";
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

        dgvPrijave = new DataGridView();
        dgvPrijave.Dock = DockStyle.Fill;
        dgvPrijave.ReadOnly = true;
        dgvPrijave.AutoGenerateColumns = true;
        dgvPrijave.AllowUserToAddRows = false;
        dgvPrijave.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvPrijave);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
    }

    private void ListaPrijavaForm_Load(object? sender, EventArgs e)
    {
        if (mockPrijave.Count == 0)
        {
            mockPrijave.Add(new Prijava
            {
                Id = 1,
                Datum_I_Vreme = new DateTime(2025, 9, 14, 10, 30, 0),
                Tip = "Požar",
                Ime_Prijavioca = "Marko Petrović",
                Kontakt = "060-111-222",
                Lokacija = "Ulica Kneza Miloša 5",
                Opis = "Veliki požar u napuštenoj zgradi.",
                JMBG_Dispecer = "1234567890123",
                Prioritet = 5
            });
            mockPrijave.Add(new Prijava
            {
                Id = 2,
                Datum_I_Vreme = new DateTime(2025, 9, 14, 11, 45, 0),
                Tip = "Poplava",
                Ime_Prijavioca = "Ana Kovačević",
                Kontakt = "064-333-444",
                Lokacija = "Trg Republike 10",
                Opis = "Poplavljen podrum zbog obilnih padavina.",
                JMBG_Dispecer = "9876543210987",
                Prioritet = 3
            });
        }

        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        dgvPrijave.DataSource = null;
        dgvPrijave.DataSource = mockPrijave;
    }

    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        var dialog = new DodajIzmeniPrijavuDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (dialog.Prijava != null)
            {
                // Dodela ID-a (za mock podatke, u stvarnoj aplikaciji bi baza to radila)
                dialog.Prijava.Id = mockPrijave.Any() ? mockPrijave.Max(p => p.Id) + 1 : 1;
                mockPrijave.Add(dialog.Prijava);
                RefreshDataGrid();
                MessageBox.Show("Prijava je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvPrijave.SelectedRows.Count > 0)
        {
            var selectedPrijava = dgvPrijave.SelectedRows[0].DataBoundItem as Prijava;
            var dialog = new DodajIzmeniPrijavuDialog(selectedPrijava!);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Prijava je uspešno izmenjena.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite prijavu za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnObrisi_Click(object? sender, EventArgs e)
    {
        if (dgvPrijave.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabranu prijavu?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedPrijava = dgvPrijave.SelectedRows[0].DataBoundItem as Prijava;
                mockPrijave.Remove(selectedPrijava!);
                RefreshDataGrid();
                MessageBox.Show("Prijava je uspešno obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite prijavu za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}