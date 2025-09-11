using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class ListaZaposlenihForm : Form
{
    private DataGridView dgvZaposleni;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    private static List<Zaposlen> mockZaposleni = new List<Zaposlen>();

    public ListaZaposlenihForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(ListaZaposlenihForm_Load);
        this.btnDodaj.Click += new EventHandler(BtnDodaj_Click);
        this.btnIzmeni.Click += new EventHandler(BtnIzmeni_Click);
        this.btnObrisi.Click += new EventHandler(BtnObrisi_Click);
        this.dgvZaposleni.CellDoubleClick += new DataGridViewCellEventHandler(DgvZaposleni_CellDoubleClick);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Zaposlenih";
        this.BackColor = SystemColors.Control;

        // Kreiranje panela za dugmad na vrhu
        pnlButtons = new Panel();
        pnlButtons.Dock = DockStyle.Top;
        pnlButtons.Height = 50;
        pnlButtons.BackColor = SystemColors.Control;

        // Dugmad unutar panela
        btnDodaj = new Button { Text = "Dodaj", Location = new Point(10, 10), Width = 100 };
        btnIzmeni = new Button { Text = "Izmeni", Location = new Point(120, 10), Width = 100 };
        btnObrisi = new Button { Text = "Obriši", Location = new Point(230, 10), Width = 100 };

        pnlButtons.Controls.Add(btnDodaj);
        pnlButtons.Controls.Add(btnIzmeni);
        pnlButtons.Controls.Add(btnObrisi);

        // Kreiranje panela za sadržaj (DataGridView)
        pnlContent = new Panel();
        pnlContent.Dock = DockStyle.Fill;

        // DataGridView unutar panela
        dgvZaposleni = new DataGridView();
        dgvZaposleni.Dock = DockStyle.Fill;
        dgvZaposleni.ReadOnly = true;
        dgvZaposleni.AutoGenerateColumns = true;
        dgvZaposleni.AllowUserToAddRows = false;
        dgvZaposleni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvZaposleni);

        // Dodavanje panela na formu
        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);
    }

    private void ListaZaposlenihForm_Load(object sender, EventArgs e)
    {
        if (mockZaposleni.Count == 0)
        {
            // Analitičar
            mockZaposleni.Add(new Analiticar
            {
                JMBG = 1234567890123,
                Ime = "Petar",
                Prezime = "Petrović",
                Datum_Rodjenja = new DateTime(1990, 5, 15),
                Pol = "M",
                Tip = "Analiticar",
                Kontakt_Telefon = "060-123-456",
                Email = "petar.p@firma.com",
                AdresaStanovanja = "Ulica Analitičara 5",
                Datum_Zaposlenja = new DateTime(2018, 1, 10) // Promenjeno u DateTime
            });

            // Koordinator
            mockZaposleni.Add(new Kordinator
            {
                JMBG = 9876543210987,
                Ime = "Marija",
                Prezime = "Ilić",
                Datum_Rodjenja = new DateTime(1985, 8, 20),
                Pol = "Z",
                Tip = "Koordinator",
                BrojTimova = 3,
                Specijalizacija = new Specijalizacija { Tip = "Operacije" },
                Kontakt_Telefon = "064-987-654",
                Email = "marija.i@firma.com",
                AdresaStanovanja = "Ulica Koordinatora 10",
                Datum_Zaposlenja = new DateTime(2015, 5, 25) // Promenjeno u DateTime
            });

            // Operativni radnik
            var opRadnik = new OperativniRadnik
            {
                JMBG = 1122334455667,
                Ime = "Ivan",
                Prezime = "Kovačević",
                Datum_Rodjenja = new DateTime(1992, 3, 10),
                Pol = "M",
                Tip = "OperativniRadnik",
                Broj_Sati = 160,
                Fizicka_Spremnost = "Odlična",
                Kontakt_Telefon = "063-112-233",
                Email = "ivan.k@firma.com",
                AdresaStanovanja = "Ulica Operativnih 20",
                Datum_Zaposlenja = new DateTime(2020, 9, 1) // Promenjeno u DateTime
            };

            opRadnik.Sertifikats.Add(new Sertifikat
            {
                Naziv = "Prva pomoć",
                Institucija = "Crveni Krst",
                DatumIzdavanja = new DateTime(2021, 6, 1),
                DatumVazenja = new DateTime(2024, 6, 1)
            });
            mockZaposleni.Add(opRadnik);
        }
        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        dgvZaposleni.DataSource = null;
        dgvZaposleni.DataSource = mockZaposleni;
    }

    private void BtnDodaj_Click(object sender, EventArgs e)
    {
        var dodajZaposlenogDialog = new DodajIzmeniZaposlenogDialog();
        if (dodajZaposlenogDialog.ShowDialog() == DialogResult.OK)
        {
            var noviZaposlen = dodajZaposlenogDialog.Zaposlen;
            mockZaposleni.Add(noviZaposlen);
            RefreshDataGrid();
            MessageBox.Show("Zaposleni je uspešno dodat!");
        }
    }

    private void BtnIzmeni_Click(object sender, EventArgs e)
    {
        if (dgvZaposleni.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite zaposlenog za izmenu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedZaposlen = dgvZaposleni.SelectedRows[0].DataBoundItem as Zaposlen;
        if (selectedZaposlen != null)
        {
            var izmenaDialog = new DodajIzmeniZaposlenogDialog(selectedZaposlen);
            if (izmenaDialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Zaposleni je uspešno izmenjen!");
            }
        }
    }

    private void BtnObrisi_Click(object sender, EventArgs e)
    {
        if (dgvZaposleni.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite zaposlenog za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedZaposlen = dgvZaposleni.SelectedRows[0].DataBoundItem as Zaposlen;
        if (selectedZaposlen != null)
        {
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete zaposlenog '{selectedZaposlen.Ime} {selectedZaposlen.Prezime}'?",
                                           "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.Yes)
            {
                mockZaposleni.Remove(selectedZaposlen);
                RefreshDataGrid();
                MessageBox.Show("Zaposleni je uspešno obrisan.");
            }
        }
    }

    private void DgvZaposleni_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var selectedItem = dgvZaposleni.Rows[e.RowIndex].DataBoundItem as Zaposlen;
        if (selectedItem != null)
        {
            var izmenaDialog = new DodajIzmeniZaposlenogDialog(selectedItem);
            izmenaDialog.ShowDialog();
        }
    }
}