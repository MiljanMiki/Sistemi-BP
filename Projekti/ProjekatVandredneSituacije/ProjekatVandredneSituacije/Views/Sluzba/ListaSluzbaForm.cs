using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class ListaSluzbaForm : Form
{
    private DataGridView dgvSluzbe;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    // Lista koja sadrži mock podatke o službama
    public static List<Sluzba> mockSluzbe = new List<Sluzba>();
    public static Predstavnik mockPredstavnik1 = new Predstavnik { JMBG = "1111111111111", Ime = "Petar", Prezime = "Petrovic" };
    public static Predstavnik mockPredstavnik2 = new Predstavnik { JMBG = "2222222222222", Ime = "Ana", Prezime = "Anic" };

    public ListaSluzbaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(ListaSluzbaForm_Load);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Službi";
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

        dgvSluzbe = new DataGridView();
        dgvSluzbe.Dock = DockStyle.Fill;
        dgvSluzbe.ReadOnly = true;
        dgvSluzbe.AutoGenerateColumns = false; // Isključena automatska generacija
        dgvSluzbe.AllowUserToAddRows = false;
        dgvSluzbe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        dgvSluzbe.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id_Sektora", HeaderText = "ID Sektora", DataPropertyName = "Id_Sektora" });
        dgvSluzbe.Columns.Add(new DataGridViewTextBoxColumn { Name = "TipSektora", HeaderText = "Tip Sektora", DataPropertyName = "TipSektora" });
        dgvSluzbe.Columns.Add(new DataGridViewTextBoxColumn { Name = "Predstavnik", HeaderText = "Predstavnik", DataPropertyName = "Predstavnik.JMBG" });

        pnlContent.Controls.Add(dgvSluzbe);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;

        dgvSluzbe.DataBindingComplete += DgvSluzbe_DataBindingComplete;
    }

    private void ListaSluzbaForm_Load(object? sender, EventArgs e)
    {
        if (mockSluzbe.Count == 0)
        {
            mockSluzbe.Add(new Sluzba { Id_Sektora = 1, TipSektora = "Vatrogasna služba", Predstavnik = mockPredstavnik1 });
            mockSluzbe.Add(new Sluzba { Id_Sektora = 2, TipSektora = "Civilna zaštita", Predstavnik = mockPredstavnik2 });
            mockSluzbe.Add(new Sluzba { Id_Sektora = 3, TipSektora = "Sektor za vanredne situacije" });
        }

        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        dgvSluzbe.DataSource = null;
        dgvSluzbe.DataSource = mockSluzbe;
        dgvSluzbe.Refresh();
    }

    private void DgvSluzbe_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
    {
        // Ova petlja osigurava da se Predstavnik pravilno prikaže
        foreach (DataGridViewRow row in dgvSluzbe.Rows)
        {
            var sluzba = row.DataBoundItem as Sluzba;
            if (sluzba != null)
            {
                if (sluzba.Predstavnik != null)
                {
                    row.Cells["Predstavnik"].Value = sluzba.Predstavnik.JMBG;
                }
                else
                {
                    row.Cells["Predstavnik"].Value = "Nema";
                }
            }
        }
    }

    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        var dialog = new DodajIzmeniSluzbuDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            dialog.Sluzba.Id_Sektora = mockSluzbe.Any() ? mockSluzbe.Max(s => s.Id_Sektora) + 1 : 1;
            mockSluzbe.Add(dialog.Sluzba);
            RefreshDataGrid();
            MessageBox.Show("Služba je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvSluzbe.SelectedRows.Count > 0)
        {
            var selectedSluzba = dgvSluzbe.SelectedRows[0].DataBoundItem as Sluzba;
            var dialog = new DodajIzmeniSluzbuDialog(selectedSluzba);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Služba je uspešno izmenjena.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite službu za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnObrisi_Click(object? sender, EventArgs e)
    {
        if (dgvSluzbe.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabranu službu?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedSluzba = dgvSluzbe.SelectedRows[0].DataBoundItem as Sluzba;
                mockSluzbe.Remove(selectedSluzba!);
                RefreshDataGrid();
                MessageBox.Show("Služba je uspešno obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite službu za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}