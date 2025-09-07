using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniSertifikatDialog : Form
{
    private Sertifikat _sertifikat;

    private Label lblNaziv, lblInstitucija, lblDatumIzdavanja, lblDatumVazenja;
    private TextBox txtNaziv, txtInstitucija;
    private DateTimePicker dtpDatumIzdavanja, dtpDatumVazenja;
    private Button btnDodajIzmeni, btnObrisi, btnZatvori;
    private DataGridView dgvSertifikati;
    private TableLayoutPanel tlpMain;
    private Panel pnlButtons;
    private IList<Sertifikat> _listaSertifikata;

    public DodajIzmeniSertifikatDialog(IList<Sertifikat> sertifikati)
    {
        _listaSertifikata = sertifikati ?? new List<Sertifikat>();
        InitializeComponent();
        RefreshDataGrid();
    }

    private void InitializeComponent()
    {
        tlpMain = new TableLayoutPanel();
        lblNaziv = new Label();
        txtNaziv = new TextBox();
        lblInstitucija = new Label();
        txtInstitucija = new TextBox();
        lblDatumIzdavanja = new Label();
        dtpDatumIzdavanja = new DateTimePicker();
        lblDatumVazenja = new Label();
        dtpDatumVazenja = new DateTimePicker();
        pnlButtons = new Panel();
        btnDodajIzmeni = new Button();
        btnObrisi = new Button();
        btnZatvori = new Button();
        dgvSertifikati = new DataGridView();
        tlpMain.SuspendLayout();
        pnlButtons.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvSertifikati).BeginInit();
        SuspendLayout();
        // 
        // tlpMain
        // 
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        tlpMain.Controls.Add(lblNaziv, 0, 0);
        tlpMain.Controls.Add(txtNaziv, 1, 0);
        tlpMain.Controls.Add(lblInstitucija, 0, 1);
        tlpMain.Controls.Add(txtInstitucija, 1, 1);
        tlpMain.Controls.Add(lblDatumIzdavanja, 0, 2);
        tlpMain.Controls.Add(dtpDatumIzdavanja, 1, 2);
        tlpMain.Controls.Add(lblDatumVazenja, 0, 3);
        tlpMain.Controls.Add(dtpDatumVazenja, 1, 3);
        tlpMain.Controls.Add(pnlButtons, 0, 4);
        tlpMain.Controls.Add(dgvSertifikati, 0, 5);
        tlpMain.Location = new Point(0, 0);
        tlpMain.Name = "tlpMain";
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.Size = new Size(200, 100);
        tlpMain.TabIndex = 0;
        // 
        // lblNaziv
        // 
        lblNaziv.Location = new Point(3, 0);
        lblNaziv.Name = "lblNaziv";
        lblNaziv.Size = new Size(54, 20);
        lblNaziv.TabIndex = 0;
        // 
        // txtNaziv
        // 
        txtNaziv.Location = new Point(63, 3);
        txtNaziv.Name = "txtNaziv";
        txtNaziv.Size = new Size(100, 23);
        txtNaziv.TabIndex = 1;
        // 
        // lblInstitucija
        // 
        lblInstitucija.Location = new Point(3, 20);
        lblInstitucija.Name = "lblInstitucija";
        lblInstitucija.Size = new Size(54, 20);
        lblInstitucija.TabIndex = 2;
        // 
        // txtInstitucija
        // 
        txtInstitucija.Location = new Point(63, 23);
        txtInstitucija.Name = "txtInstitucija";
        txtInstitucija.Size = new Size(100, 23);
        txtInstitucija.TabIndex = 3;
        // 
        // lblDatumIzdavanja
        // 
        lblDatumIzdavanja.Location = new Point(3, 40);
        lblDatumIzdavanja.Name = "lblDatumIzdavanja";
        lblDatumIzdavanja.Size = new Size(54, 20);
        lblDatumIzdavanja.TabIndex = 4;
        // 
        // dtpDatumIzdavanja
        // 
        dtpDatumIzdavanja.Location = new Point(63, 43);
        dtpDatumIzdavanja.Name = "dtpDatumIzdavanja";
        dtpDatumIzdavanja.Size = new Size(134, 23);
        dtpDatumIzdavanja.TabIndex = 5;
        // 
        // lblDatumVazenja
        // 
        lblDatumVazenja.Location = new Point(3, 60);
        lblDatumVazenja.Name = "lblDatumVazenja";
        lblDatumVazenja.Size = new Size(54, 20);
        lblDatumVazenja.TabIndex = 6;
        // 
        // dtpDatumVazenja
        // 
        dtpDatumVazenja.Location = new Point(63, 63);
        dtpDatumVazenja.Name = "dtpDatumVazenja";
        dtpDatumVazenja.Size = new Size(134, 23);
        dtpDatumVazenja.TabIndex = 7;
        // 
        // pnlButtons
        // 
        tlpMain.SetColumnSpan(pnlButtons, 2);
        pnlButtons.Controls.Add(btnDodajIzmeni);
        pnlButtons.Controls.Add(btnObrisi);
        pnlButtons.Controls.Add(btnZatvori);
        pnlButtons.Dock = DockStyle.Bottom;
        pnlButtons.Location = new Point(3, 83);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(194, 14);
        pnlButtons.TabIndex = 8;
        // 
        // btnDodajIzmeni
        // 
        btnDodajIzmeni.Location = new Point(10, 10);
        btnDodajIzmeni.Name = "btnDodajIzmeni";
        btnDodajIzmeni.Size = new Size(75, 23);
        btnDodajIzmeni.TabIndex = 0;
        btnDodajIzmeni.Click += BtnDodajIzmeni_Click;
        // 
        // btnObrisi
        // 
        btnObrisi.Location = new Point(120, 10);
        btnObrisi.Name = "btnObrisi";
        btnObrisi.Size = new Size(75, 23);
        btnObrisi.TabIndex = 1;
        btnObrisi.Click += BtnObrisi_Click;
        // 
        // btnZatvori
        // 
        btnZatvori.Location = new Point(480, 10);
        btnZatvori.Name = "btnZatvori";
        btnZatvori.Size = new Size(75, 23);
        btnZatvori.TabIndex = 2;
        // 
        // dgvSertifikati
        // 
        tlpMain.SetColumnSpan(dgvSertifikati, 2);
        dgvSertifikati.Location = new Point(3, 103);
        dgvSertifikati.Name = "dgvSertifikati";
        dgvSertifikati.Size = new Size(194, 14);
        dgvSertifikati.TabIndex = 9;
        dgvSertifikati.CellDoubleClick += DgvSertifikati_CellDoubleClick;
        dgvSertifikati.SelectionChanged += DgvSertifikati_SelectionChanged;
        // 
        // DodajIzmeniSertifikatDialog
        // 
        ClientSize = new Size(600, 450);
        Controls.Add(tlpMain);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "DodajIzmeniSertifikatDialog";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Sertifikati operativnog radnika";
        tlpMain.ResumeLayout(false);
        tlpMain.PerformLayout();
        pnlButtons.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvSertifikati).EndInit();
        ResumeLayout(false);
    }

    private void RefreshDataGrid()
    {
        dgvSertifikati.DataSource = null;
        dgvSertifikati.DataSource = _listaSertifikata.ToList();
    }

    private void BtnDodajIzmeni_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            if (_sertifikat != null)
            {
                _sertifikat.Naziv = txtNaziv.Text;
                _sertifikat.Institucija = txtInstitucija.Text;
                _sertifikat.DatumIzdavanja = dtpDatumIzdavanja.Value;
                _sertifikat.DatumVazenja = dtpDatumVazenja.Checked ? dtpDatumVazenja.Value : DateTime.MinValue;
            }
            else
            {
                var noviSertifikat = new Sertifikat
                {
                    Naziv = txtNaziv.Text,
                    Institucija = txtInstitucija.Text,
                    DatumIzdavanja = dtpDatumIzdavanja.Value,
                    DatumVazenja = dtpDatumVazenja.Checked ? dtpDatumVazenja.Value : DateTime.MinValue
                };
                _listaSertifikata.Add(noviSertifikat);
            }
            ClearFields();
            RefreshDataGrid();
        }
    }

    private void BtnObrisi_Click(object sender, EventArgs e)
    {
        if (dgvSertifikati.SelectedRows.Count > 0)
        {
            var selectedSertifikat = dgvSertifikati.SelectedRows[0].DataBoundItem as Sertifikat;
            if (selectedSertifikat != null)
            {
                _listaSertifikata.Remove(selectedSertifikat);
                RefreshDataGrid();
                ClearFields();
            }
        }
    }

    private void DgvSertifikati_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        _sertifikat = dgvSertifikati.Rows[e.RowIndex].DataBoundItem as Sertifikat;
        if (_sertifikat != null)
        {
            PopulateFields();
            btnDodajIzmeni.Text = "Izmeni";
        }
    }

    private void DgvSertifikati_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvSertifikati.SelectedRows.Count > 0)
        {
            btnObrisi.Enabled = true;
        }
        else
        {
            btnObrisi.Enabled = false;
        }
    }

    private void PopulateFields()
    {
        txtNaziv.Text = _sertifikat.Naziv;
        txtInstitucija.Text = _sertifikat.Institucija;
        dtpDatumIzdavanja.Value = _sertifikat.DatumIzdavanja;
        dtpDatumVazenja.Checked = (_sertifikat.DatumVazenja != DateTime.MinValue);
        if (dtpDatumVazenja.Checked)
        {
            dtpDatumVazenja.Value = _sertifikat.DatumVazenja;
        }
    }

    private void ClearFields()
    {
        _sertifikat = null;
        txtNaziv.Clear();
        txtInstitucija.Clear();
        dtpDatumIzdavanja.Value = DateTime.Now;
        dtpDatumVazenja.Checked = false;
        btnDodajIzmeni.Text = "Dodaj";
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtNaziv.Text) || string.IsNullOrWhiteSpace(txtInstitucija.Text))
        {
            MessageBox.Show("Naziv i Institucija sertifikata moraju biti popunjeni.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}