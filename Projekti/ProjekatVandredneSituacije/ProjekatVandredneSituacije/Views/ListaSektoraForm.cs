using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class ListaSektoraForm : Form
{
    private DataGridView dgvSektori;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    private static List<Sluzba> mockSektori = new List<Sluzba>();

    public ListaSektoraForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(Form_Load);
        this.btnDodaj.Click += new EventHandler(BtnDodaj_Click);
        this.btnIzmeni.Click += new EventHandler(BtnIzmeni_Click);
        this.btnObrisi.Click += new EventHandler(BtnObrisi_Click);
        this.dgvSektori.CellDoubleClick += new DataGridViewCellEventHandler(DgvSektori_CellDoubleClick);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Sektora";
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
        dgvSektori = new DataGridView();
        dgvSektori.Dock = DockStyle.Fill;
        dgvSektori.ReadOnly = true;
        dgvSektori.AutoGenerateColumns = true;
        dgvSektori.AllowUserToAddRows = false;
        dgvSektori.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvSektori);

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
        if (mockSektori.Count == 0)
        {
            mockSektori.Add(new Sluzba { Id_Sektora = 1, TipSektora = "Sektor za vanredne situacije", Uloga = "Koordinacija i rukovođenje" });
            mockSektori.Add(new Sluzba { Id_Sektora = 2, TipSektora = "Zdravstveni sektor", Uloga = "Pružanje medicinske pomoći" });
        }
    }

    private void RefreshDataGrid()
    {
        dgvSektori.DataSource = null;
        dgvSektori.DataSource = mockSektori;
    }

    private void BtnDodaj_Click(object sender, EventArgs e)
    {
        var dodajSektorDialog = new DodajIzmeniSektorDialog();
        if (dodajSektorDialog.ShowDialog() == DialogResult.OK)
        {
            var noviSektor = dodajSektorDialog.Sektor;
            noviSektor.Id_Sektora = mockSektori.Count > 0 ? mockSektori.Max(s => s.Id_Sektora) + 1 : 1;
            mockSektori.Add(noviSektor);
            RefreshDataGrid();
            MessageBox.Show("Sektor je uspešno dodat!");
        }
    }

    private void BtnIzmeni_Click(object sender, EventArgs e)
    {
        if (dgvSektori.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite sektor za izmenu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedSektor = dgvSektori.SelectedRows[0].DataBoundItem as Sluzba;
        if (selectedSektor != null)
        {
            var izmenaDialog = new DodajIzmeniSektorDialog(selectedSektor);
            if (izmenaDialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Sektor je uspešno izmenjen!");
            }
        }
    }

    private void BtnObrisi_Click(object sender, EventArgs e)
    {
        if (dgvSektori.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite sektor za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedSektor = dgvSektori.SelectedRows[0].DataBoundItem as Sluzba;
        if (selectedSektor != null)
        {
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete sektor '{selectedSektor.TipSektora}'?",
                                           "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.Yes)
            {
                mockSektori.Remove(selectedSektor);
                RefreshDataGrid();
                MessageBox.Show("Sektor je uspešno obrisan.");
            }
        }
    }

    private void DgvSektori_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var selectedItem = dgvSektori.Rows[e.RowIndex].DataBoundItem as Sluzba;
        if (selectedItem != null)
        {
            MessageBox.Show($"Dvoklik na sektor: {selectedItem.TipSektora}. Ovde će se otvoriti forma sa detaljima o sektoru.");
        }
    }
}