using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class ListaVozilaForm : Form
{
    private DataGridView dgvVozila;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    private static List<Vozilo> mockVozila = new List<Vozilo>();

    public ListaVozilaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(Form_Load);
        this.btnDodaj.Click += new EventHandler(BtnDodaj_Click);
        this.btnIzmeni.Click += new EventHandler(BtnIzmeni_Click);
        this.btnObrisi.Click += new EventHandler(BtnObrisi_Click);
        this.dgvVozila.CellDoubleClick += new DataGridViewCellEventHandler(DgvVozila_CellDoubleClick);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Vozila";
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
        dgvVozila = new DataGridView();
        dgvVozila.Dock = DockStyle.Fill;
        dgvVozila.ReadOnly = true;
        dgvVozila.AutoGenerateColumns = true;
        dgvVozila.AllowUserToAddRows = false;
        dgvVozila.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvVozila);

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
        if (mockVozila.Count == 0)
        {
            mockVozila.Add(new Kamioni { Registarska_Oznaka = 1, Proizvodjac = "FAP", Tip = "Kamion", Status = StatusVozila.operativno, Lokacija = "Nis" });
            mockVozila.Add(new Dzipovi { Registarska_Oznaka = 2, Proizvodjac = "Jeep", Tip = "Dzip", Status = StatusVozila.u_kvaru, Lokacija = "Beograd" });
            mockVozila.Add(new Sanitetska { Registarska_Oznaka = 3, Proizvodjac = "VW", Tip = "Sanitetsko vozilo", Status = StatusVozila.operativno, Lokacija = "Novi Sad" });
        }
    }

    private void RefreshDataGrid()
    {
        dgvVozila.DataSource = null;
        dgvVozila.DataSource = mockVozila;
    }

    private void BtnDodaj_Click(object sender, EventArgs e)
    {
        var dodajVoziloDialog = new DodajIzmeniVoziloDialog();
        if (dodajVoziloDialog.ShowDialog() == DialogResult.OK)
        {
            var novoVozilo = dodajVoziloDialog.Vozilo;
            novoVozilo.Registarska_Oznaka = mockVozila.Count > 0 ? mockVozila.Max(v => v.Registarska_Oznaka) + 1 : 1;
            mockVozila.Add(novoVozilo);
            RefreshDataGrid();
            MessageBox.Show("Vozilo je uspešno dodato!");
        }
    }

    private void BtnIzmeni_Click(object sender, EventArgs e)
    {
        if (dgvVozila.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite vozilo za izmenu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedVozilo = dgvVozila.SelectedRows[0].DataBoundItem as Vozilo;
        if (selectedVozilo != null)
        {
            var izmenaDialog = new DodajIzmeniVoziloDialog(selectedVozilo);
            if (izmenaDialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Vozilo je uspešno izmenjeno!");
            }
        }
    }

    private void BtnObrisi_Click(object sender, EventArgs e)
    {
        if (dgvVozila.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite vozilo za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedVozilo = dgvVozila.SelectedRows[0].DataBoundItem as Vozilo;
        if (selectedVozilo != null)
        {
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete vozilo '{selectedVozilo.Registarska_Oznaka}'?",
                                           "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.Yes)
            {
                mockVozila.Remove(selectedVozilo);
                RefreshDataGrid();
                MessageBox.Show("Vozilo je uspešno obrisano.");
            }
        }
    }

    private void DgvVozila_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var selectedItem = dgvVozila.Rows[e.RowIndex].DataBoundItem as Vozilo;
        if (selectedItem != null)
        {
            MessageBox.Show($"Dvoklik na vozilo: {selectedItem.Proizvodjac}. Ovde će se otvoriti forma sa detaljima o vozilu.");
        }
    }
}