using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class ListaIntervencijaForm : Form
{
    private DataGridView dgvIntervencije;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    private static List<Intervencija> mockIntervencije = new List<Intervencija>();

    public ListaIntervencijaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(Form_Load);
        this.btnDodaj.Click += new EventHandler(BtnDodaj_Click);
        this.btnIzmeni.Click += new EventHandler(BtnIzmeni_Click);
        this.btnObrisi.Click += new EventHandler(BtnObrisi_Click);
        this.dgvIntervencije.CellDoubleClick += new DataGridViewCellEventHandler(DgvIntervencije_CellDoubleClick);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Intervencija";
        this.BackColor = SystemColors.Control;

        // Kreiranje panela za dugmad na vrhu
        pnlButtons = new Panel();
        pnlButtons.Dock = DockStyle.Top;
        pnlButtons.Height = 50;
        pnlButtons.BackColor = SystemColors.Control;

        // Dugmad unutar panela
        btnDodaj = new Button { Text = "Dodaj", Location = new Point(10, 10), Width = 100 };
        btnIzmeni = new Button { Text = "Izmeni", Location = new Point(120, 10), Width = 100 };
        btnObrisi = new Button { Text = "Obrisi", Location = new Point(230, 10), Width = 100 };

        pnlButtons.Controls.Add(btnDodaj);
        pnlButtons.Controls.Add(btnIzmeni);
        pnlButtons.Controls.Add(btnObrisi);

        // Kreiranje panela za sadrzaj (DataGridView)
        pnlContent = new Panel();
        pnlContent.Dock = DockStyle.Fill;

        // DataGridView unutar panela
        dgvIntervencije = new DataGridView();
        dgvIntervencije.Dock = DockStyle.Fill;
        dgvIntervencije.ReadOnly = true;
        dgvIntervencije.AutoGenerateColumns = true;
        dgvIntervencije.AllowUserToAddRows = false;
        dgvIntervencije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvIntervencije);

        // Dodavanje panela na formu
        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);
    }

    private void Form_Load(object sender, EventArgs e)
    {
        PopulateMockData();
        RefreshDataGrid();
    }

    private void PopulateMockData()
    {
        if (mockIntervencije.Count == 0)
        {
            mockIntervencije.Add(new Intervencija { Id = 1, Datum_I_Vreme = DateTime.Now, Lokacija = "Beograd", Status = Status.Uspesna, Resursi = "Vatrogasci", Broj_Spasenih = 5, Broj_Povredjenih = 1, Uspesnost = 90 });
            mockIntervencije.Add(new Intervencija { Id = 2, Datum_I_Vreme = DateTime.Now.AddDays(-1), Lokacija = "Nis", Status = Status.Neuspesna, Resursi = "Policija", Broj_Spasenih = 0, Broj_Povredjenih = 3, Uspesnost = 45 });
        }
    }

    private void RefreshDataGrid()
    {
        dgvIntervencije.DataSource = null;
        dgvIntervencije.DataSource = mockIntervencije;
    }

    private void BtnDodaj_Click(object sender, EventArgs e)
    {
        var dodajIntervencijuDialog = new DodajIzmeniIntervencijuDialog();
        if (dodajIntervencijuDialog.ShowDialog() == DialogResult.OK)
        {
            var novaIntervencija = dodajIntervencijuDialog.Intervencija;
            novaIntervencija.Id = mockIntervencije.Count > 0 ? mockIntervencije.Max(i => i.Id) + 1 : 1;
            mockIntervencije.Add(novaIntervencija);
            RefreshDataGrid();
            MessageBox.Show("Intervencija je uspesno dodata!");
        }
    }

    private void BtnIzmeni_Click(object sender, EventArgs e)
    {
        if (dgvIntervencije.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite intervenciju za izmenu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedIntervencija = dgvIntervencije.SelectedRows[0].DataBoundItem as Intervencija;
        if (selectedIntervencija != null)
        {
            var izmenaDialog = new DodajIzmeniIntervencijuDialog(selectedIntervencija);
            if (izmenaDialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Intervencija je uspesno izmenjena!");
            }
        }
    }

    private void BtnObrisi_Click(object sender, EventArgs e)
    {
        if (dgvIntervencije.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite intervenciju za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedIntervencija = dgvIntervencije.SelectedRows[0].DataBoundItem as Intervencija;
        if (selectedIntervencija != null)
        {
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete intervenciju na lokaciji '{selectedIntervencija.Lokacija}'?",
                                           "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.Yes)
            {
                mockIntervencije.Remove(selectedIntervencija);
                RefreshDataGrid();
                MessageBox.Show("Intervencija je uspesno obrisana.");
            }
        }
    }

    private void DgvIntervencije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var selectedItem = dgvIntervencije.Rows[e.RowIndex].DataBoundItem as Intervencija;
        if (selectedItem != null)
        {
            MessageBox.Show($"Dvoklik na intervenciju: {selectedItem.Lokacija}. Ovde ce se otvoriti forma sa detaljima intervencije.");
        }
    }
}