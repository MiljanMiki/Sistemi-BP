using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVanredneSituacije;
using VanrednaSituacijaLibrary;

public class ListaPrijavaForm : Form
{
    private DataGridView dgvPrijave;
    private Button btnDodaj, btnIzmeni, btnObrisi, btnOsvezi;
    private Panel pnlButtons, pnlContent;

    public ListaPrijavaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(ListaPrijavaForm_Load);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Prijava";
        this.BackColor = SystemColors.Control;
        this.Size = new Size(1000, 600);

        pnlButtons = new Panel();
        pnlButtons.Dock = DockStyle.Top;
        pnlButtons.Height = 50;
        pnlButtons.BackColor = SystemColors.Control;

        btnDodaj = new Button { Text = "Dodaj", Location = new Point(10, 10), Width = 100 };
        btnIzmeni = new Button { Text = "Izmeni", Location = new Point(120, 10), Width = 100 };
        btnObrisi = new Button { Text = "Obriši", Location = new Point(230, 10), Width = 100 };
        btnOsvezi = new Button { Text = "Osveži", Location = new Point(340, 10), Width = 100 };

        pnlButtons.Controls.Add(btnDodaj);
        pnlButtons.Controls.Add(btnIzmeni);
        pnlButtons.Controls.Add(btnObrisi);
        pnlButtons.Controls.Add(btnOsvezi);

        pnlContent = new Panel();
        pnlContent.Dock = DockStyle.Fill;

        dgvPrijave = new DataGridView();
        dgvPrijave.Dock = DockStyle.Fill;
        dgvPrijave.ReadOnly = true;
        dgvPrijave.AutoGenerateColumns = true;
        dgvPrijave.AllowUserToAddRows = false;
        dgvPrijave.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        pnlContent.Controls.Add(dgvPrijave);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
        btnOsvezi.Click += BtnOsvezi_Click;
    }

    private void ListaPrijavaForm_Load(object? sender, EventArgs e)
    {
        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        dgvPrijave.DataSource = null;
        dgvPrijave.DataSource = DTOManager.VratiPrijave();
    }

    private void BtnOsvezi_Click(object? sender, EventArgs e)
    {
        RefreshDataGrid();
        MessageBox.Show("Podaci su osveženi.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        var dialog = new DodajIzmeniPrijavuDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (dialog.Prijava != null)
            {
                DTOManager.DodajPrijavu(dialog.Prijava);
                RefreshDataGrid();
                MessageBox.Show("Prijava je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvPrijave.SelectedRows.Count > 0)
        {
            var selectedPrijava = dgvPrijave.SelectedRows[0].DataBoundItem as PrijavaBasic;
            var dialog = new DodajIzmeniPrijavuDialog(selectedPrijava!);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DTOManager.IzmeniPrijavu(dialog.Prijava!);
                RefreshDataGrid();
                MessageBox.Show("Prijava je uspešno izmenjena.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite prijavu za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnObrisi_Click(object? sender, EventArgs e)
    {
        if (dgvPrijave.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabranu prijavu?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedPrijava = dgvPrijave.SelectedRows[0].DataBoundItem as PrijavaBasic;
                DTOManager.ObrisiPrijavu(selectedPrijava!.Id);
                RefreshDataGrid();
                MessageBox.Show("Prijava je uspešno obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite prijavu za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}