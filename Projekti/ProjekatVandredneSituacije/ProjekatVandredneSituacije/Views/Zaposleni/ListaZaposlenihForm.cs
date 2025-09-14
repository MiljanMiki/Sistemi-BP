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
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Zaposlenih";
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

        dgvZaposleni = new DataGridView();
        dgvZaposleni.Dock = DockStyle.Fill;
        dgvZaposleni.ReadOnly = true;
        dgvZaposleni.AutoGenerateColumns = true;
        dgvZaposleni.AllowUserToAddRows = false;
        dgvZaposleni.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvZaposleni);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
    }

    private void ListaZaposlenihForm_Load(object sender, EventArgs e)
    {
        if (mockZaposleni.Count == 0)
        {
            mockZaposleni.Add(new Analiticar
            {
                JMBG = "1234567890123",
                Ime = "Petar",
                Prezime = "Petrović",
                Datum_Rodjenja = new DateTime(1990, 5, 15),
                Pol = "M",
                Kontakt_Telefon = "060-123-456",
                Email = "petar.p@firma.com",
                AdresaStanovanja = "Ulica Analitičara 5",
                Datum_Zaposlenja = new DateTime(2018, 1, 10)
            });
            mockZaposleni.Add(new Kordinator
            {
                JMBG = "9876543210987",
                Ime = "Marija",
                Prezime = "Ilić",
                Datum_Rodjenja = new DateTime(1985, 8, 20),
                Pol = "Z",
                Kontakt_Telefon = "064-987-654",
                Email = "marija.i@firma.com",
                AdresaStanovanja = "Ulica Koordinatora 10",
                Datum_Zaposlenja = new DateTime(2015, 5, 25),
                BrojTimova = 3
            });
            mockZaposleni.Add(new OperativniRadnik
            {
                JMBG = "1122334455667",
                Ime = "Ivan",
                Prezime = "Kovačević",
                Datum_Rodjenja = new DateTime(1992, 3, 10),
                Pol = "M",
                Kontakt_Telefon = "063-112-233",
                Email = "ivan.k@firma.com",
                AdresaStanovanja = "Ulica Operativnih 20",
                Datum_Zaposlenja = new DateTime(2020, 9, 1),
                Broj_Sati = 160,
                Fizicka_Spremnost = "Odlična"
            });
        }

        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        dgvZaposleni.DataSource = null;
        dgvZaposleni.DataSource = mockZaposleni;
    }

    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        // Otvaramo dijalog koji omogućava odabir tipa zaposlenog
        var tipDialog = new Form
        {
            Text = "Izaberite tip",
            Size = new Size(250, 150),
            StartPosition = FormStartPosition.CenterParent
        };
        var cmbTip = new ComboBox { Location = new Point(20, 20), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbTip.Items.AddRange(new string[] { "Analitičar", "Koordinator", "Operativni Radnik" });
        var btnIzaberi = new Button { Text = "Dalje", Location = new Point(70, 60), DialogResult = DialogResult.OK };

        tipDialog.Controls.Add(cmbTip);
        tipDialog.Controls.Add(btnIzaberi);

        if (tipDialog.ShowDialog() == DialogResult.OK && cmbTip.SelectedItem != null)
        {
            Form? dialog = null;
            string selectedTip = cmbTip.SelectedItem.ToString() ?? string.Empty;

            if (selectedTip == "Analitičar")
                dialog = new DodajIzmeniAnaliticaraDialog();
            else if (selectedTip == "Koordinator")
                dialog = new DodajIzmeniKoordinatoraDialog();
            else if (selectedTip == "Operativni Radnik")
                dialog = new DodajIzmeniOperativnogRadnikaDialog();

            if (dialog?.ShowDialog() == DialogResult.OK)
            {
                if (dialog is DodajIzmeniAnaliticaraDialog analiticarDialog)
                    mockZaposleni.Add(analiticarDialog.Zaposlen!);
                else if (dialog is DodajIzmeniKoordinatoraDialog koordinatorDialog)
                    mockZaposleni.Add(koordinatorDialog.Zaposlen!);
                else if (dialog is DodajIzmeniOperativnogRadnikaDialog operativniDialog)
                    mockZaposleni.Add(operativniDialog.Zaposlen!);

                RefreshDataGrid();
                MessageBox.Show("Zaposleni je uspešno dodat.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvZaposleni.SelectedRows.Count > 0)
        {
            var selectedZaposlen = dgvZaposleni.SelectedRows[0].DataBoundItem as Zaposlen;
            Form? dialog = null;

            if (selectedZaposlen is Analiticar)
                dialog = new DodajIzmeniAnaliticaraDialog(selectedZaposlen as Analiticar);
            else if (selectedZaposlen is Kordinator)
                dialog = new DodajIzmeniKoordinatoraDialog(selectedZaposlen as Kordinator);
            else if (selectedZaposlen is OperativniRadnik)
                dialog = new DodajIzmeniOperativnogRadnikaDialog(selectedZaposlen as OperativniRadnik);

            if (dialog?.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Podaci o zaposlenom su uspešno izmenjeni.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite zaposlenog za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnObrisi_Click(object? sender, EventArgs e)
    {
        if (dgvZaposleni.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabranog zaposlenog?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedZaposlen = dgvZaposleni.SelectedRows[0].DataBoundItem as Zaposlen;
                mockZaposleni.Remove(selectedZaposlen!);
                RefreshDataGrid();
                MessageBox.Show("Zaposleni je uspešno obrisan.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite zaposlenog za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}