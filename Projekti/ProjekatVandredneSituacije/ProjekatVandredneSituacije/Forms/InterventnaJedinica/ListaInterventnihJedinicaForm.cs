using ProjekatVanredneSituacije;
using ProjekatVanredneSituacije.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VanrednaSituacijaLibrary;

public class ListaInterventnihJedinicaForm : Form
{
    private DataGridView dgvJedinice;
    private Button btnDodajOpstu, btnDodajSpecijalnu, btnIzmeni, btnObrisi, btnOsvezi;
    private Panel pnlButtons, pnlContent;
    private IList<InterventnaJedinicaGetView> interventneJedinice;

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

        btnDodajOpstu = new Button { Text = "Dodaj Opštu", Location = new Point(10, 10), Width = 110 };
        btnDodajSpecijalnu = new Button { Text = "Dodaj Specijalnu", Location = new Point(130, 10), Width = 120 };
        btnIzmeni = new Button { Text = "Izmeni", Location = new Point(260, 10), Width = 100 };
        btnObrisi = new Button { Text = "Obriši", Location = new Point(370, 10), Width = 100 };
        btnOsvezi = new Button { Text = "Osveži", Location = new Point(480, 10), Width = 100 };

        pnlButtons.Controls.Add(btnDodajOpstu);
        pnlButtons.Controls.Add(btnDodajSpecijalnu);
        pnlButtons.Controls.Add(btnIzmeni);
        pnlButtons.Controls.Add(btnObrisi);
        pnlButtons.Controls.Add(btnOsvezi);

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
        dgvJedinice.Columns.Add(new DataGridViewTextBoxColumn { Name = "TipSpecijalneJedinice", HeaderText = "Tip specijalne jedinice", DataPropertyName = "TipSpecijalneJed" });

        pnlContent.Controls.Add(dgvJedinice);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodajOpstu.Click += BtnDodajOpstu_Click;
        btnDodajSpecijalnu.Click += BtnDodajSpecijalnu_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
        btnOsvezi.Click += BtnOsvezi_Click;
    }

    private void PopuniTabelu()
    {
        dgvJedinice.DataSource = null;
        dgvJedinice.DataSource = interventneJedinice;
    }

    private void ListaInterventnihJedinicaForm_Load(object? sender, EventArgs e)
    {
        RefreshDataGrid();
    }

    private async void RefreshDataGrid()
    {
        try
        { 
            interventneJedinice = await DTOManager.VratiSveJedinice();
            PopuniTabelu();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Došlo je do greške prilikom učitavanja liste interventnih jedinica: " + ex.Message);
        }
    }

    private void BtnOsvezi_Click(object? sender, EventArgs e)
    {
        RefreshDataGrid();
        MessageBox.Show("Podaci su osveženi.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnDodajOpstu_Click(object? sender, EventArgs e)
    {
        var dialog = new DodajIzmeniOpstaJedinicaDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (dialog.Jedinica != null)
            {
                DTOManager.DodajOpstuIntervetnuJedinicu(dialog.Jedinica);
                RefreshDataGrid();
                MessageBox.Show("Opšta interventna jedinica je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void BtnDodajSpecijalnu_Click(object? sender, EventArgs e)
    {
        var dialog = new DodajIzmeniSpecijalnaJedinicaDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (dialog.Jedinica != null)
            {
                DTOManager.DodajSpecijalnuIntervetnuJedinicu(dialog.Jedinica);
                RefreshDataGrid();
                MessageBox.Show("Specijalna interventna jedinica je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvJedinice.SelectedRows.Count > 0)
        {
            var selectedJedinica = dgvJedinice.SelectedRows[0].DataBoundItem as InterventnaJedinicaBasic;
            Form? dialog = null;

            if (selectedJedinica is OpstaInterventnaJedBasic opstaJedinica)
            {
                dialog = new DodajIzmeniOpstaJedinicaDialog(opstaJedinica);
            }
            else if (selectedJedinica is SpecijalnaInterventnaJedinicaBasic specijalnaJedinica)
            {
                dialog = new DodajIzmeniSpecijalnaJedinicaDialog(specijalnaJedinica);
            }

            if (dialog?.ShowDialog() == DialogResult.OK)
            {
                if (selectedJedinica is OpstaInterventnaJedBasic opstaJedinicaToUpdate)
                {
                    DTOManager.izmeniOpstuInterventnuJedinicu(opstaJedinicaToUpdate);
                }
                else if (selectedJedinica is SpecijalnaInterventnaJedinicaBasic specijalnaJedinicaToUpdate)
                {
                    DTOManager.izmeniSpecijalnuInterventnuJedinicu(specijalnaJedinicaToUpdate);
                }

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
                var selectedJedinica = dgvJedinice.SelectedRows[0].DataBoundItem as InterventnaJedinicaBasic;
                try
                {
                    if (selectedJedinica is OpstaInterventnaJedBasic)
                    {
                        DTOManager.ObrisiOpstuInterventnuJedinicu(selectedJedinica!.Jedinstveni_Broj);
                    }
                    else if (selectedJedinica is SpecijalnaInterventnaJedinicaBasic)
                    {
                        DTOManager.ObrisiSpecijalnuInterventnuJedinicu(selectedJedinica!.Jedinstveni_Broj);
                    }
                    RefreshDataGrid();
                    MessageBox.Show("Interventna jedinica je uspešno obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške prilikom brisanja: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite interventnu jedinicu za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}