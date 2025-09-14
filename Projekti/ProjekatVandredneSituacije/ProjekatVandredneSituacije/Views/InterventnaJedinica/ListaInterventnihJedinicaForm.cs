using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class ListaInterventnihJedinicaForm : Form
{
    private DataGridView dgvJedinice;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    // Mock lista za testiranje
    public static List<InterventnaJedinica> mockJedinice = new List<InterventnaJedinica>();
    public static List<OperativniRadnik> mockRadnici = new List<OperativniRadnik>();

    public ListaInterventnihJedinicaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(ListaInterventnihJedinicaForm_Load);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Interventnih Jedinica";
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

        dgvJedinice = new DataGridView();
        dgvJedinice.Dock = DockStyle.Fill;
        dgvJedinice.ReadOnly = true;
        dgvJedinice.AllowUserToAddRows = false;
        dgvJedinice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        dgvJedinice.AutoGenerateColumns = false;

        dgvJedinice.Columns.Add(new DataGridViewTextBoxColumn { Name = "JedinstveniBroj", HeaderText = "Jedinstveni broj", DataPropertyName = "Jedinstveni_Broj" });
        dgvJedinice.Columns.Add(new DataGridViewTextBoxColumn { Name = "Naziv", HeaderText = "Naziv", DataPropertyName = "Naziv" });
        dgvJedinice.Columns.Add(new DataGridViewTextBoxColumn { Name = "BrojClanova", HeaderText = "Broj članova", DataPropertyName = "BrojClanova" });
        dgvJedinice.Columns.Add(new DataGridViewTextBoxColumn { Name = "Baza", HeaderText = "Baza", DataPropertyName = "Baza" });

        var komandirColumn = new DataGridViewTextBoxColumn { Name = "Komandir", HeaderText = "Komandir" };
        dgvJedinice.Columns.Add(komandirColumn);

        var tipJediniceColumn = new DataGridViewTextBoxColumn { Name = "TipSpecijalneJedinice", HeaderText = "Tip specijalne jedinice" };
        dgvJedinice.Columns.Add(tipJediniceColumn);

        pnlContent.Controls.Add(dgvJedinice);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;

        dgvJedinice.DataBindingComplete += DgvJedinice_DataBindingComplete;
    }

    private void DgvJedinice_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
    {
        foreach (DataGridViewRow row in dgvJedinice.Rows)
        {
            var jedinica = row.DataBoundItem as InterventnaJedinica;
            if (jedinica != null)
            {
                if (jedinica.Komandir != null)
                {
                    row.Cells["Komandir"].Value = $"{jedinica.Komandir.Ime} {jedinica.Komandir.Prezime}";
                }

                if (jedinica is SpecijalnaInterventna specijalna)
                {
                    row.Cells["TipSpecijalneJedinice"].Value = specijalna.TipSpecijalneJedinice;
                }
            }
        }
    }

    private void ListaInterventnihJedinicaForm_Load(object? sender, EventArgs e)
    {
        if (mockJedinice.Count == 0)
        {
            if (mockRadnici.Count == 0)
            {
                mockRadnici.Add(new OperativniRadnik { JMBG = "1111111111111", Ime = "Marko", Prezime = "Marković", Fizicka_Spremnost = "Odlična" });
                mockRadnici.Add(new OperativniRadnik { JMBG = "2222222222222", Ime = "Jelena", Prezime = "Jovanović", Fizicka_Spremnost = "Dobra" });
            }

            mockJedinice.Add(new OpstaIntervetnaJed
            {
                Jedinstveni_Broj = 1,
                Naziv = "Jedinica A",
                BrojClanova = 10,
                Baza = "Beograd",
                Komandir = mockRadnici[0]
            });
            mockJedinice.Add(new SpecijalnaInterventna
            {
                Jedinstveni_Broj = 2,
                Naziv = "Jedinica B",
                BrojClanova = 5,
                Baza = "Novi Sad",
                Komandir = mockRadnici[1],
                TipSpecijalneJedinice = "Specijalne operacije"
            });
        }

        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        dgvJedinice.DataSource = null;
        dgvJedinice.DataSource = mockJedinice;
    }

    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        var tipDialog = new Form
        {
            Text = "Izaberite tip",
            Size = new Size(250, 150),
            StartPosition = FormStartPosition.CenterParent
        };
        var cmbTip = new ComboBox { Location = new Point(20, 20), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbTip.Items.AddRange(new string[] { "Opšta", "Specijalna" });
        var btnIzaberi = new Button { Text = "Dalje", Location = new Point(70, 60), DialogResult = DialogResult.OK };

        tipDialog.Controls.Add(cmbTip);
        tipDialog.Controls.Add(btnIzaberi);

        if (tipDialog.ShowDialog() == DialogResult.OK && cmbTip.SelectedItem != null)
        {
            Form? dialog = null;
            string selectedTip = cmbTip.SelectedItem.ToString() ?? string.Empty;

            if (selectedTip == "Opšta")
                dialog = new DodajIzmeniJedinicuDialog();
            else if (selectedTip == "Specijalna")
                dialog = new DodajIzmeniJedinicuDialog(true);

            if (dialog?.ShowDialog() == DialogResult.OK)
            {
                if (dialog is DodajIzmeniJedinicuDialog jedinicaDialog)
                {
                    jedinicaDialog.Jedinica.Jedinstveni_Broj = mockJedinice.Any() ? mockJedinice.Max(j => j.Jedinstveni_Broj) + 1 : 1;
                    mockJedinice.Add(jedinicaDialog.Jedinica);
                    RefreshDataGrid();
                    MessageBox.Show("Interventna jedinica je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvJedinice.SelectedRows.Count > 0)
        {
            var selectedJedinica = dgvJedinice.SelectedRows[0].DataBoundItem as InterventnaJedinica;
            Form? dialog = null;

            if (selectedJedinica is OpstaIntervetnaJed)
                dialog = new DodajIzmeniJedinicuDialog(selectedJedinica as OpstaIntervetnaJed);
            else if (selectedJedinica is SpecijalnaInterventna)
                dialog = new DodajIzmeniJedinicuDialog(selectedJedinica as SpecijalnaInterventna);

            if (dialog?.ShowDialog() == DialogResult.OK)
            {
                RefreshDataGrid();
                MessageBox.Show("Interventna jedinica je uspešno izmenjena.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite interventnu jedinicu za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnObrisi_Click(object? sender, EventArgs e)
    {
        if (dgvJedinice.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabranu jedinicu?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedJedinica = dgvJedinice.SelectedRows[0].DataBoundItem as InterventnaJedinica;
                mockJedinice.Remove(selectedJedinica!);
                RefreshDataGrid();
                MessageBox.Show("Interventna jedinica je uspešno obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite interventnu jedinicu za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}