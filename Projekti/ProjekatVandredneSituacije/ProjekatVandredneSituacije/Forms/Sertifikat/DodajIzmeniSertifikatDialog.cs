using ProjekatVanredneSituacije;
using ProjekatVanredneSituacije.DTOs;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VanrednaSituacijaLibrary;

public class DodajIzmeniSertifikatDialog : Form
{
    private SertifikatView _selectedSertifikat;
    private OperativniRadnikBasic _operativniRadnik;

    private Label lblDatumIzdavanja, lblDatumVazenja, lblNaziv, lblInstitucija;
    private DateTimePicker dtpDatumIzdavanja, dtpDatumVazenja;
    private TextBox txtNaziv, txtInstitucija;
    private Button btnDodajIzmeni, btnObrisi, btnZatvori;
    private DataGridView dgvSertifikati;
    private TableLayoutPanel tlpMain;
    private Panel pnlButtons;
    private IList<SertifikatView> _listaSertifikata;

    public DodajIzmeniSertifikatDialog(OperativniRadnikBasic operativniRadnik)
    {
        _operativniRadnik = operativniRadnik;
        InitializeComponent();
        RefreshDataGrid();
    }

    private void InitializeComponent()
    {
        this.Text = $"Sertifikati za radnika: {_operativniRadnik.Ime} {_operativniRadnik.Prezime}";
        this.Size = new Size(600, 450);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        tlpMain = new TableLayoutPanel();
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Padding = new Padding(10);
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

        lblNaziv = new Label { Text = "Naziv:", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill };
        txtNaziv = new TextBox { Dock = DockStyle.Fill };

        lblInstitucija = new Label { Text = "Institucija:", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill };
        txtInstitucija = new TextBox { Dock = DockStyle.Fill };

        lblDatumIzdavanja = new Label { Text = "Datum izdavanja:", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill };
        dtpDatumIzdavanja = new DateTimePicker { Dock = DockStyle.Fill };

        lblDatumVazenja = new Label { Text = "Datum važenja:", TextAlign = ContentAlignment.MiddleLeft, Dock = DockStyle.Fill };
        dtpDatumVazenja = new DateTimePicker { Dock = DockStyle.Fill };

        pnlButtons = new Panel { Dock = DockStyle.Fill };
        btnDodajIzmeni = new Button { Text = "Dodaj", Size = new Size(100, 30), Location = new Point(10, 10) };
        btnObrisi = new Button { Text = "Obriši", Size = new Size(100, 30), Location = new Point(120, 10) };
        btnZatvori = new Button { Text = "Zatvori", Size = new Size(100, 30), Location = new Point(460, 10) };
        pnlButtons.Controls.Add(btnDodajIzmeni);
        pnlButtons.Controls.Add(btnObrisi);
        pnlButtons.Controls.Add(btnZatvori);

        dgvSertifikati = new DataGridView
        {
            Dock = DockStyle.Fill,
            ReadOnly = true,
            AutoGenerateColumns = false,
            AllowUserToAddRows = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        dgvSertifikati.Columns.Add(new DataGridViewTextBoxColumn { Name = "Naziv", HeaderText = "Naziv", DataPropertyName = "Id.Naziv" });
        dgvSertifikati.Columns.Add(new DataGridViewTextBoxColumn { Name = "Institucija", HeaderText = "Institucija", DataPropertyName = "Id.Institucija" });
        dgvSertifikati.Columns.Add(new DataGridViewTextBoxColumn { Name = "DatumIzdavanja", HeaderText = "Datum izdavanja", DataPropertyName = "DatumIzdavanja" });
        dgvSertifikati.Columns.Add(new DataGridViewTextBoxColumn { Name = "DatumVazenja", HeaderText = "Datum važenja", DataPropertyName = "DatumVazenja" });

        tlpMain.Controls.Add(lblNaziv, 0, 0);
        tlpMain.Controls.Add(txtNaziv, 1, 0);
        tlpMain.Controls.Add(lblInstitucija, 0, 1);
        tlpMain.Controls.Add(txtInstitucija, 1, 1);
        tlpMain.Controls.Add(lblDatumIzdavanja, 0, 2);
        tlpMain.Controls.Add(dtpDatumIzdavanja, 1, 2);
        tlpMain.Controls.Add(lblDatumVazenja, 0, 3);
        tlpMain.Controls.Add(dtpDatumVazenja, 1, 3);
        tlpMain.Controls.Add(pnlButtons, 0, 4);
        tlpMain.SetColumnSpan(pnlButtons, 2);
        tlpMain.Controls.Add(dgvSertifikati, 0, 5);
        tlpMain.SetColumnSpan(dgvSertifikati, 2);

        this.Controls.Add(tlpMain);

        btnDodajIzmeni.Click += BtnDodajIzmeni_Click;
        btnObrisi.Click += BtnObrisi_Click;
        btnZatvori.Click += (sender, e) => this.Close();
        dgvSertifikati.CellDoubleClick += DgvSertifikati_CellDoubleClick;
    }

    private async void RefreshDataGrid()
    {
        try
        {
            _listaSertifikata = await DTOManager.VratiSertifikateZaposlenog(_operativniRadnik.JMBG);
            dgvSertifikati.DataSource = _listaSertifikata;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Greška pri učitavanju sertifikata: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnDodajIzmeni_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            if (_selectedSertifikat != null)
            { 
                _selectedSertifikat.DatumIzdavanja = dtpDatumIzdavanja.Value;
                _selectedSertifikat.DatumVazenja = dtpDatumVazenja.Value;
                _selectedSertifikat.Id.Naziv = txtNaziv.Text;
                _selectedSertifikat.Id.Institucija = txtInstitucija.Text;
                DTOManager.IzmeniSertifikat(_selectedSertifikat);
                MessageBox.Show("Sertifikat uspešno izmenjen.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            { 
                var noviSertifikat = new SertifikatView();
                var id = new SertifikatIdBasic();
                id.OperativniRadnik = _operativniRadnik;
                id.Naziv = txtNaziv.Text;
                id.Institucija = txtInstitucija.Text;

                noviSertifikat.Id = new SertifikatIdView { id };
                noviSertifikat.DatumIzdavanja = dtpDatumIzdavanja.Value;
                noviSertifikat.DatumVazenja = dtpDatumVazenja.Value;

                DTOManager.DodajSertifikat(noviSertifikat);
                MessageBox.Show("Sertifikat uspešno dodat.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ClearFields();
            RefreshDataGrid();
        }
    }

    private void BtnObrisi_Click(object sender, EventArgs e)
    {
        if (dgvSertifikati.SelectedRows.Count > 0)
        {
            var result = MessageBox.Show("Da li ste sigurni da želite da obrišete odabrani sertifikat?", "Potvrda brisanja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var selectedSertifikat = dgvSertifikati.SelectedRows[0].DataBoundItem as SertifikatView;
                if (selectedSertifikat != null)
                {
                    DTOManager.ObrisiSertifikat(selectedSertifikat);
                    MessageBox.Show("Sertifikat uspešno obrisan.", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshDataGrid();
                    ClearFields();
                }
            }
        }
        else
        {
            MessageBox.Show("Molimo odaberite sertifikat za brisanje.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void DgvSertifikati_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        _selectedSertifikat = dgvSertifikati.Rows[e.RowIndex].DataBoundItem as SertifikatView;
        if (_selectedSertifikat != null)
        {
            PopulateFields();
            btnDodajIzmeni.Text = "Izmeni";
            txtNaziv.Enabled = false;
            txtInstitucija.Enabled = false;
        }
    }

    private void PopulateFields()
    {
        txtNaziv.Text = _selectedSertifikat.Id.Naziv;
        txtInstitucija.Text = _selectedSertifikat.Id.Institucija;
        dtpDatumIzdavanja.Value = _selectedSertifikat.DatumIzdavanja;
        dtpDatumVazenja.Value = _selectedSertifikat.DatumVazenja;
    }

    private void ClearFields()
    {
        _selectedSertifikat = null;
        txtNaziv.Text = "";
        txtInstitucija.Text = "";
        dtpDatumIzdavanja.Value = DateTime.Now;
        dtpDatumVazenja.Value = DateTime.Now;
        btnDodajIzmeni.Text = "Dodaj";
        txtNaziv.Enabled = true;
        txtInstitucija.Enabled = true;
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrEmpty(txtNaziv.Text) || string.IsNullOrEmpty(txtInstitucija.Text))
        {
            MessageBox.Show("Naziv i institucija su obavezna polja.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        return true;
    }
}