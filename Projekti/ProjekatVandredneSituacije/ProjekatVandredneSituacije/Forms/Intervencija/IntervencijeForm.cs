using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVanredneSituacije;
using ProjekatVanredneSituacije.Entiteti;
using VanrednaSituacijaLibrary;

public class IntervencijeForm : Form
{
    private DataGridView dgvIntervencije;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    public IntervencijeForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(IntervencijeForm_Load);
        this.btnDodaj.Click += new EventHandler(BtnDodaj_Click);
        this.btnIzmeni.Click += new EventHandler(BtnIzmeni_Click);
        this.btnObrisi.Click += new EventHandler(BtnObrisi_Click);
        this.dgvIntervencije.CellDoubleClick += new DataGridViewCellEventHandler(DgvIntervencije_CellDoubleClick);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Intervencija";
        this.BackColor = SystemColors.Control;
        this.Size = new Size(1000, 600);

        pnlButtons = new Panel();
        pnlButtons.Dock = DockStyle.Top;
        pnlButtons.Height = 50;
        pnlButtons.BackColor = SystemColors.Control;

        btnDodaj = new Button { Text = "Dodaj", Location = new Point(10, 10), Width = 100 };
        btnIzmeni = new Button { Text = "Izmeni", Location = new Point(120, 10), Width = 100 };
        btnObrisi = new Button { Text = "Obrisi", Location = new Point(230, 10), Width = 100 };

        pnlButtons.Controls.Add(btnDodaj);
        pnlButtons.Controls.Add(btnIzmeni);
        pnlButtons.Controls.Add(btnObrisi);

        pnlContent = new Panel();
        pnlContent.Dock = DockStyle.Fill;

        dgvIntervencije = new DataGridView();
        dgvIntervencije.Dock = DockStyle.Fill;
        dgvIntervencije.ReadOnly = true;
        dgvIntervencije.AutoGenerateColumns = true;
        dgvIntervencije.AllowUserToAddRows = false;
        dgvIntervencije.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvIntervencije);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);
    }

    private void IntervencijeForm_Load(object? sender, EventArgs e)
    {
        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        try
        {
            var intervencije = DTOManager.VratiIntervencije();
            dgvIntervencije.DataSource = intervencije;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Došlo je do greške prilikom učitavanja podataka: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        var dodajIntervencijuDialog = new IntervencijaDialog();
        if (dodajIntervencijuDialog.ShowDialog() == DialogResult.OK)
        {
            RefreshDataGrid();
            MessageBox.Show("Intervencija je uspesno dodata!");
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvIntervencije.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite intervenciju za izmenu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedIntervencija = dgvIntervencije.SelectedRows[0].DataBoundItem as IntervencijaBasic;
        if (selectedIntervencija != null)
        {
            var izmenaDialog = new IntervencijaDialog(selectedIntervencija);
            if (izmenaDialog.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Intervencija je uspesno izmenjena!");
            }
        }
    }

    private void BtnObrisi_Click(object? sender, EventArgs e)
    {
        if (dgvIntervencije.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite intervenciju za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedIntervencija = dgvIntervencije.SelectedRows[0].DataBoundItem as IntervencijaBasic;
        if (selectedIntervencija != null)
        {
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete intervenciju na lokaciji '{selectedIntervencija.Lokacija}'?",
                                           "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.Yes)
            {
                try
                {
                    DTOManager.ObrisiIntervenciju(selectedIntervencija.ID);
                    RefreshDataGrid();
                    MessageBox.Show("Intervencija je uspesno obrisana.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Došlo je do greške prilikom brisanja: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void DgvIntervencije_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var selectedItem = dgvIntervencije.Rows[e.RowIndex].DataBoundItem as IntervencijaBasic;
        if (selectedItem != null)
        {
            MessageBox.Show($"Dvoklik na intervenciju sa ID: {selectedItem.ID}. Ovde ce se otvoriti forma sa detaljima intervencije.");
        }
    }
}