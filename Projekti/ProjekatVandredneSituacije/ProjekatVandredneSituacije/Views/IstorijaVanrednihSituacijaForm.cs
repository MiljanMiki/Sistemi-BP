using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class IstorijaVanrednihSituacijaForm : Form
{
    private DataGridView dgvVanredneSituacije;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    private static List<VanrednaSituacija> mockSituacije = new List<VanrednaSituacija>();

    public IstorijaVanrednihSituacijaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(Form_Load);
        this.btnDodaj.Click += new EventHandler(BtnDodaj_Click);
        this.btnIzmeni.Click += new EventHandler(BtnIzmeni_Click);
        this.btnObrisi.Click += new EventHandler(BtnObrisi_Click);
        this.dgvVanredneSituacije.CellDoubleClick += new DataGridViewCellEventHandler(DgvSituacije_CellDoubleClick);
    }

    private void InitializeComponent()
    {
        this.Text = "Istorija Vanrednih Situacija";
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
        dgvVanredneSituacije = new DataGridView();
        dgvVanredneSituacije.Dock = DockStyle.Fill;
        dgvVanredneSituacije.ReadOnly = true;
        dgvVanredneSituacije.AutoGenerateColumns = true;
        dgvVanredneSituacije.AllowUserToAddRows = false;
        dgvVanredneSituacije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvVanredneSituacije);

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
        if (mockSituacije.Count == 0)
        {
            mockSituacije.Add(new VanrednaSituacija { Id = 1, Tip = "Poplava", Opstina = "Leskovac", Datum_Od = new DateTime(2023, 5, 10) });
            mockSituacije.Add(new VanrednaSituacija { Id = 2, Tip = "Zemljotres", Opstina = "Kragujevac", Datum_Od = new DateTime(2024, 2, 15) });
        }
    }

    private void RefreshDataGrid()
    {
        dgvVanredneSituacije.DataSource = null;
        dgvVanredneSituacije.DataSource = mockSituacije;
    }

    private void BtnDodaj_Click(object sender, EventArgs e)
    {
        var dodajSituacijuDialog = new DodajIzmeniVanrednuSituacijuDialog();
        if (dodajSituacijuDialog.ShowDialog() == DialogResult.OK)
        {
            var novaSituacija = dodajSituacijuDialog.NovaSituacija;
            novaSituacija.Id = mockSituacije.Count > 0 ? mockSituacije.Max(s => s.Id) + 1 : 1;
            mockSituacije.Add(novaSituacija);
            RefreshDataGrid();
            MessageBox.Show("Vanredna situacija je uspešno dodata!");
        }
    }

    private void BtnIzmeni_Click(object sender, EventArgs e)
    {
        if (dgvVanredneSituacije.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite vanrednu situaciju za izmenu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedSituacija = dgvVanredneSituacije.SelectedRows[0].DataBoundItem as VanrednaSituacija;
        if (selectedSituacija != null)
        {
            var izmenaDialog = new DodajIzmeniVanrednuSituacijuDialog(selectedSituacija);
            if (izmenaDialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Vanredna situacija je uspešno izmenjena!");
            }
        }
    }

    private void BtnObrisi_Click(object sender, EventArgs e)
    {
        if (dgvVanredneSituacije.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite vanrednu situaciju za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedSituacija = dgvVanredneSituacije.SelectedRows[0].DataBoundItem as VanrednaSituacija;
        if (selectedSituacija != null)
        {
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete vanrednu situaciju '{selectedSituacija.Tip}'?",
                                           "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.Yes)
            {
                mockSituacije.Remove(selectedSituacija);
                RefreshDataGrid();
                MessageBox.Show("Vanredna situacija je uspešno obrisana.");
            }
        }
    }

    private void DgvSituacije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var selectedItem = dgvVanredneSituacije.Rows[e.RowIndex].DataBoundItem as VanrednaSituacija;
        if (selectedItem != null)
        {
            MessageBox.Show($"Dvoklik na vanrednu situaciju: {selectedItem.Tip}. Ovde će se otvoriti 'Istorija Prijava' za ovu situaciju.", "Istorija Prijava");
        }
    }
}