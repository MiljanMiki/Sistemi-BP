using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class ListaIntJedinicaForm : Form
{
    private DataGridView dgvInterventneJedinice;
    private Button btnDodaj, btnIzmeni, btnObrisi;

    private static List<InterventnaJedinica> mockJedinice = new List<InterventnaJedinica>();

    public ListaIntJedinicaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(Form_Load);
        this.btnDodaj.Click += new EventHandler(BtnDodaj_Click);
        this.btnIzmeni.Click += new EventHandler(BtnIzmeni_Click);
        this.btnObrisi.Click += new EventHandler(BtnObrisi_Click);
        this.dgvInterventneJedinice.CellDoubleClick += new DataGridViewCellEventHandler(DgvJedinice_CellDoubleClick);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Interventnih Jedinica";
        this.BackColor = SystemColors.Control;
        this.ClientSize = new Size(800, 600); // Početna veličina prozora

        // Dugmad na vrhu forme, usidrena za gornju i levu ivicu
        btnDodaj = new Button { Text = "Dodaj", Location = new Point(10, 10), Width = 100, Anchor = AnchorStyles.Top | AnchorStyles.Left };
        btnIzmeni = new Button { Text = "Izmeni", Location = new Point(120, 10), Width = 100, Anchor = AnchorStyles.Top | AnchorStyles.Left };
        btnObrisi = new Button { Text = "Obrisi", Location = new Point(230, 10), Width = 100, Anchor = AnchorStyles.Top | AnchorStyles.Left };

        // DataGridView, usidren za sve cetiri ivice
        dgvInterventneJedinice = new DataGridView();
        dgvInterventneJedinice.Location = new Point(10, 60); // Ostavlja prostor za dugmad
        dgvInterventneJedinice.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 70);
        dgvInterventneJedinice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvInterventneJedinice.ReadOnly = true;
        dgvInterventneJedinice.AutoGenerateColumns = true;
        dgvInterventneJedinice.AllowUserToAddRows = false;
        dgvInterventneJedinice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        // Dodavanje kontrola na formu
        this.Controls.Add(btnDodaj);
        this.Controls.Add(btnIzmeni);
        this.Controls.Add(btnObrisi);
        this.Controls.Add(dgvInterventneJedinice);
    }

    private void Form_Load(object sender, EventArgs e)
    {
        PopulateMockData();
        RefreshDataGrid();
    }

    private void PopulateMockData()
    {
        if (mockJedinice.Count == 0)
        {
            mockJedinice.Add(new OpstaIntervetnaJed { Jedinstveni_Broj = 1, Naziv = "Jedinica Alfa", BrojClanova = 15, Baza = "Nis" });
            mockJedinice.Add(new SpecijalnaInterventna { Jedinstveni_Broj = 2, Naziv = "Specijalna Jedinica", BrojClanova = 10, Baza = "Beograd", TipSpecijalneJedinice = "RTS" });
        }
    }

    private void RefreshDataGrid()
    {
        dgvInterventneJedinice.DataSource = null;
        dgvInterventneJedinice.DataSource = mockJedinice;
    }
    private void BtnDodaj_Click(object sender, EventArgs e)
    {
        var dodajJedinicuDialog = new DodajIzmeniIntJedinicuDialog();
        if (dodajJedinicuDialog.ShowDialog() == DialogResult.OK)
        {
            var novaJedinica = dodajJedinicuDialog.Jedinica;
            novaJedinica.Jedinstveni_Broj = mockJedinice.Count > 0 ? mockJedinice.Max(j => j.Jedinstveni_Broj) + 1 : 1;
            mockJedinice.Add(novaJedinica);
            RefreshDataGrid();
            MessageBox.Show("Interventna jedinica je uspešno dodata!");
        }
    }

    private void BtnIzmeni_Click(object sender, EventArgs e)
    {
        if (dgvInterventneJedinice.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite interventnu jedinicu za izmenu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedJedinica = dgvInterventneJedinice.SelectedRows[0].DataBoundItem as InterventnaJedinica;
        if (selectedJedinica != null)
        {
            var izmenaDialog = new DodajIzmeniIntJedinicuDialog(selectedJedinica);
            if (izmenaDialog.ShowDialog() == DialogResult.OK)
            {
                // Izmena se automatski reflektuje, jer se radi o referenci na objekat
                RefreshDataGrid();
                MessageBox.Show("Interventna jedinica je uspešno izmenjena!");
            }
        }
    }

    private void BtnObrisi_Click(object sender, EventArgs e)
    {
        if (dgvInterventneJedinice.SelectedRows.Count == 0)
        {
            MessageBox.Show("Molimo izaberite interventnu jedinicu za brisanje.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var selectedJedinica = dgvInterventneJedinice.SelectedRows[0].DataBoundItem as InterventnaJedinica;
        if (selectedJedinica != null)
        {
            var rezultat = MessageBox.Show($"Da li ste sigurni da želite da obrišete interventnu jedinicu '{selectedJedinica.Naziv}'?",
                                           "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezultat == DialogResult.Yes)
            {
                mockJedinice.Remove(selectedJedinica);
                RefreshDataGrid();
                MessageBox.Show("Interventna jedinica je uspešno obrisana.");
            }
        }
    }

    private void DgvJedinice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var selectedItem = dgvInterventneJedinice.Rows[e.RowIndex].DataBoundItem as InterventnaJedinica;
        if (selectedItem != null)
        {
            MessageBox.Show($"Dvoklik na interventnu jedinicu: {selectedItem.Naziv}. Ovde će se otvoriti forma sa detaljima jedinice.");
        }
    }
}