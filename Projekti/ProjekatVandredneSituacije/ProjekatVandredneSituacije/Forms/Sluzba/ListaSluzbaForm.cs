using ProjekatVanredneSituacije;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VanrednaSituacijaLibrary;

public class ListaSluzbaForm : Form
{
    private DataGridView dgvSluzbe;
    private Button btnDodaj, btnIzmeni, btnObrisi;
    private Panel pnlButtons, pnlContent;

    public ListaSluzbaForm()
    {
        InitializeComponent();
        this.Load += new EventHandler(ListaSluzbaForm_Load);
    }

    private void InitializeComponent()
    {
        this.Text = "Lista Službi";
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

        dgvSluzbe = new DataGridView();
        dgvSluzbe.Dock = DockStyle.Fill;
        dgvSluzbe.ReadOnly = true;
        dgvSluzbe.AutoGenerateColumns = false;
        dgvSluzbe.AllowUserToAddRows = false;
        dgvSluzbe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         
        dgvSluzbe.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id_Sektora", HeaderText = "ID Sektora", DataPropertyName = "Id_Sektora" });
        dgvSluzbe.Columns.Add(new DataGridViewTextBoxColumn { Name = "TipSektora", HeaderText = "Tip Sektora", DataPropertyName = "TipSektora" });
        dgvSluzbe.Columns.Add(new DataGridViewTextBoxColumn { Name = "Predstavnik", HeaderText = "Predstavnik (JMBG)", DataPropertyName = "Predstavnik.JMBG" });

        pnlContent.Controls.Add(dgvSluzbe);

        this.Controls.Add(pnlContent);
        this.Controls.Add(pnlButtons);

        btnDodaj.Click += BtnDodaj_Click;
        btnIzmeni.Click += BtnIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
    }

    private void ListaSluzbaForm_Load(object? sender, EventArgs e)
    {
        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        try
        {
            dgvSluzbe.DataSource = null; 
            dgvSluzbe.DataSource = DTOManager.VratiSluzbe();
            dgvSluzbe.Refresh();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Greška pri učitavanju službi: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnDodaj_Click(object? sender, EventArgs e)
    {
        var dialog = new DodajIzmeniSluzbuDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            { 
                DTOManager.DodajSluzbu(dialog.SluzbaBasic);
                RefreshDataGrid();
                MessageBox.Show("Služba je uspešno dodata.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri dodavanju službe: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void BtnIzmeni_Click(object? sender, EventArgs e)
    {
        if (dgvSluzbe.SelectedRows.Count > 0)
        { 
            var selectedSluzba = dgvSluzbe.SelectedRows[0].DataBoundItem as SluzbaPregled;
            var dialog = new DodajIzmeniSluzbuDialog(selectedSluzba);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                { 
                    DTOManager.IzmeniSluzbu(dialog.SluzbaBasic);
                    RefreshDataGrid();
                    MessageBox.Show("Služba je uspešno izmenjena.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri izmeni službe: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite službu za izmenu.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void BtnObrisi_Click(object? sender, EventArgs e)
    {
        if (dgvSluzbe.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabranu službu?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            { 
                var selectedSluzba = dgvSluzbe.SelectedRows[0].DataBoundItem as SluzbaPregled;
                try
                { 
                    DTOManager.ObrisiSluzbu(selectedSluzba.Id_Sektora);
                    RefreshDataGrid();
                    MessageBox.Show("Služba je uspešno obrisana.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greška pri brisanju službe: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite službu za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}