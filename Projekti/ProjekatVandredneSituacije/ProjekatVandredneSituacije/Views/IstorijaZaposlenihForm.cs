using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class IstorijaZaposlenihForm : Form
{
    private DataGridView dgvZaposleni;
    private static List<Zaposlen> mockZaposleni = new List<Zaposlen>();

    public IstorijaZaposlenihForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(IstorijaZaposlenihForm_Load);
    }

    private void InitializeComponent()
    {
        this.Text = "Istorija Zaposlenih";
        this.BackColor = SystemColors.Control;
        this.Size = new Size(800, 600);

        dgvZaposleni = new DataGridView();
        dgvZaposleni.Dock = DockStyle.Fill;
        dgvZaposleni.ReadOnly = true;
        dgvZaposleni.AutoGenerateColumns = true;
        dgvZaposleni.AllowUserToAddRows = false;
        dgvZaposleni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        this.Controls.Add(dgvZaposleni);
    }

    private void IstorijaZaposlenihForm_Load(object sender, EventArgs e)
    {
        if (mockZaposleni.Count == 0)
        {
            // Dodavanje mock podataka
            mockZaposleni.Add(new Zaposlen
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

            mockZaposleni.Add(new Zaposlen
            {
                JMBG = 9876543210987,
                Ime = "Marija",
                Prezime = "Ilić",
                Datum_Rodjenja = new DateTime(1985, 8, 20),
                Pol = "Z",
                Tip = "Koordinator",
                Kontakt_Telefon = "064-987-654",
                Email = "marija.i@firma.com",
                AdresaStanovanja = "Ulica Koordinatora 10",
                Datum_Zaposlenja = new DateTime(2015, 5, 25) // Promenjeno u DateTime
            });
        }

        dgvZaposleni.DataSource = mockZaposleni;
    }
}