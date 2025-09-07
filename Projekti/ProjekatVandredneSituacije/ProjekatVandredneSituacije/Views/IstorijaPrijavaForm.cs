using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class IstorijaPrijavaForm : Form
{
    private DataGridView dgvPrijave;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    private static List<Prijava> mockPrijave = new List<Prijava>();

    public IstorijaPrijavaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(Form_Load);
        this.btnDodaj.Click += new EventHandler(BtnDodaj_Click);
        this.btnIzmeni.Click += new EventHandler(BtnIzmeni_Click);
        this.btnObrisi.Click += new EventHandler(BtnObrisi_Click);
        this.dgvPrijave.CellDoubleClick += new DataGridViewCellEventHandler(DgvPrijave_CellDoubleClick);
    }

    private void InitializeComponent()
    {
        this.Text = "Istorija Prijava";
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

        // Kreiranje panela za sadržaj (DataGridView)
        pnlContent = new Panel();
        pnlContent.Dock = DockStyle.Fill;

        // DataGridView unutar panela
        dgvPrijave = new DataGridView();
        dgvPrijave.Dock = DockStyle.Fill;
        dgvPrijave.ReadOnly = true;
        dgvPrijave.AutoGenerateColumns = true;
        dgvPrijave.AllowUserToAddRows = false;
        dgvPrijave.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvPrijave);

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
        if (mockPrijave.Count == 0)
        {
            mockPrijave.Add(new Prijava { Id = 1, Datum_I_Vreme = DateTime.Now, Tip = "Požar", Lokacija = "Novi Sad", Prioritet = 1, Ime = "Petar Petrović", Kontakt = "0641234567", Opis = "Šumski požar", JMBG_Dispecer = "1234567890123" });
            mockPrijave.Add(new Prijava { Id = 2, Datum_I_Vreme = DateTime.Now.AddHours(-2), Tip = "Poplava", Lokacija = "Beograd", Prioritet = 2, Ime = "Marko Marković", Kontakt = "0637654321", Opis = "Izlivanje reke", JMBG_Dispecer = "3210987654321" });
        }
    }

    private void RefreshDataGrid()
    {
        dgvPrijave.DataSource = null;
        dgvPrijave.DataSource = mockPrijave;
    }

    private void BtnDodaj_Click(object sender, EventArgs e)
    {
        var dodajPrijavuDialog = new DodajIzmeniPrijavuDialog();
        if (dodajPrijavuDialog.ShowDialog() == DialogResult.OK)
        {
            var novaPrijava = dodajPrijavuDialog.Prijava;
            novaPrijava.Id = mockPrijave.Count > 0 ? mockPrijave.Max(p => p.Id) + 1 : 1;
            mockPrijave.Add(novaPrijava);
            RefreshDataGrid();
            MessageBox.Show("Prijava je uspešno dodata!");
        }
    }

    private void BtnIzmeni_Click(object sender, EventArgs e)
    {
        if (dgvPrijave.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite prijavu za izmenu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedPrijava = dgvPrijave.SelectedRows[0].DataBoundItem as Prijava;
        if (selectedPrijava != null)
        {
            var izmenaDialog = new DodajIzmeniPrijavuDialog(selectedPrijava);
            if (izmenaDialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Prijava je uspešno izmenjena!");
            }
        }
    }

    private void BtnObrisi_Click(object sender, EventArgs e)
    {
        if (dgvPrijave.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite prijavu za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedPrijava = dgvPrijave.SelectedRows[0].DataBoundItem as Prijava;
        if (selectedPrijava != null)
        {
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete prijavu '{selectedPrijava.Tip}'?",
                                           "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.Yes)
            {
                mockPrijave.Remove(selectedPrijava);
                RefreshDataGrid();
                MessageBox.Show("Prijava je uspešno obrisana.");
            }
        }
    }

    private void DgvPrijave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var selectedItem = dgvPrijave.Rows[e.RowIndex].DataBoundItem as Prijava;
        if (selectedItem != null)
        {
            MessageBox.Show($"Dvoklik na prijavu: {selectedItem.Tip}. Ovde će se otvoriti forma sa detaljima prijave.");
        }
    }
}