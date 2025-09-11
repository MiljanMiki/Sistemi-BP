using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniVanrednuSituacijuDialog : Form
{
    private Label lblDatumOd, lblDatumDo, lblTip, lblBrojUgrozenih, lblNivoOpasnosti, lblOpstina, lblLokacija, lblOpis;
    private DateTimePicker dtpDatumOd, dtpDatumDo;
    private TextBox txtTip, txtBrojUgrozenih, txtOpstina, txtLokacija, txtOpis;
    private ComboBox cmbNivoOpasnosti;
    private Button btnSacuvaj, btnOdustani;

    private VanrednaSituacija _situacija; // Privatno polje za objekat koji se menja

    public VanrednaSituacija NovaSituacija { get; private set; } // Samo za dodavanje

    // Konstruktor za DODAVANJE
    public DodajIzmeniVanrednuSituacijuDialog()
    {
        InitializeComponent();
        this.btnSacuvaj.Click += new EventHandler(BtnSacuvaj_Click);
        this.btnOdustani.DialogResult = DialogResult.Cancel;
    }

    // NOVI KONSTRUKTOR za IZMENU
    public DodajIzmeniVanrednuSituacijuDialog(VanrednaSituacija situacija) : this()
    {
        _situacija = situacija;
        this.Text = "Izmeni Vanrednu Situaciju";
        PopulateFields();
    }

    private void InitializeComponent()
    {
        this.Text = "Dodaj Vanrednu Situaciju";
        this.Size = new Size(450, 600);
        this.StartPosition = FormStartPosition.CenterParent;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        int yPos = 20;
        int spacing = 40;
        int labelX = 20;
        int controlX = 170;

        lblDatumOd = new Label { Text = "Datum od:", Location = new Point(labelX, yPos), AutoSize = true };
        dtpDatumOd = new DateTimePicker { Location = new Point(controlX, yPos), Width = 200, Format = DateTimePickerFormat.Short };
        yPos += spacing;

        lblDatumDo = new Label { Text = "Datum do:", Location = new Point(labelX, yPos), AutoSize = true };
        dtpDatumDo = new DateTimePicker { Location = new Point(controlX, yPos), Width = 200, Format = DateTimePickerFormat.Short };
        yPos += spacing;

        lblTip = new Label { Text = "Tip:", Location = new Point(labelX, yPos), AutoSize = true };
        txtTip = new TextBox { Location = new Point(controlX, yPos), Width = 200 };
        yPos += spacing;

        lblBrojUgrozenih = new Label { Text = "Broj ugroženih:", Location = new Point(labelX, yPos), AutoSize = true };
        txtBrojUgrozenih = new TextBox { Location = new Point(controlX, yPos), Width = 200 };
        yPos += spacing;

        lblNivoOpasnosti = new Label { Text = "Nivo opasnosti:", Location = new Point(labelX, yPos), AutoSize = true };
        cmbNivoOpasnosti = new ComboBox { Location = new Point(controlX, yPos), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbNivoOpasnosti.Items.AddRange(Enum.GetNames(typeof(NivoOpasnosti)));
        yPos += spacing;

        lblOpstina = new Label { Text = "Opština:", Location = new Point(labelX, yPos), AutoSize = true };
        txtOpstina = new TextBox { Location = new Point(controlX, yPos), Width = 200 };
        yPos += spacing;

        lblLokacija = new Label { Text = "Lokacija:", Location = new Point(labelX, yPos), AutoSize = true };
        txtLokacija = new TextBox { Location = new Point(controlX, yPos), Width = 200 };
        yPos += spacing;

        lblOpis = new Label { Text = "Opis:", Location = new Point(labelX, yPos), AutoSize = true };
        txtOpis = new TextBox { Location = new Point(controlX, yPos), Width = 200, Multiline = true, Height = 100 };
        yPos += 110;

        btnSacuvaj = new Button { Text = "Sačuvaj", Location = new Point(controlX, yPos), DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", Location = new Point(controlX + 105, yPos) };

        this.Controls.AddRange(new Control[]
        {
            lblDatumOd, dtpDatumOd,
            lblDatumDo, dtpDatumDo,
            lblTip, txtTip,
            lblBrojUgrozenih, txtBrojUgrozenih,
            lblNivoOpasnosti, cmbNivoOpasnosti,
            lblOpstina, txtOpstina,
            lblLokacija, txtLokacija,
            lblOpis, txtOpis,
            btnSacuvaj, btnOdustani
        });
    }

    // Metoda koja popunjava polja forme sa podacima
    private void PopulateFields()
    {
        if (_situacija != null)
        {
            dtpDatumOd.Value = _situacija.Datum_Od;
            dtpDatumDo.Value = _situacija.Datum_Do;
            txtTip.Text = _situacija.Tip;
            txtBrojUgrozenih.Text = _situacija.Broj_Ugrozenih_Osoba.ToString();
            cmbNivoOpasnosti.SelectedItem = _situacija.Nivo_Opasnosti.ToString();
            txtOpstina.Text = _situacija.Opstina;
            txtLokacija.Text = _situacija.Lokacija;
            txtOpis.Text = _situacija.Opis;
        }
    }

    private void BtnSacuvaj_Click(object sender, EventArgs e)
    {
        if (dtpDatumDo.Value < dtpDatumOd.Value)
        {
            MessageBox.Show("Datum završetka ne može biti pre datuma početka.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.None;
            return;
        }
        if (string.IsNullOrWhiteSpace(txtTip.Text) || string.IsNullOrWhiteSpace(txtOpstina.Text) || cmbNivoOpasnosti.SelectedItem == null)
        {
            MessageBox.Show("Polja 'Tip', 'Opština' i 'Nivo Opasnosti' su obavezna.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.None;
            return;
        }
        if (!int.TryParse(txtBrojUgrozenih.Text, out int brojUgrozenih))
        {
            MessageBox.Show("Broj ugroženih mora biti numerička vrednost.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.None;
            return;
        }

        if (_situacija == null)
        {
            // Logika za DODAVANJE
            NovaSituacija = new VanrednaSituacija
            {
                Datum_Od = dtpDatumOd.Value,
                Datum_Do = dtpDatumDo.Value,
                Tip = txtTip.Text,
                Broj_Ugrozenih_Osoba = brojUgrozenih,
                Nivo_Opasnosti = (NivoOpasnosti)Enum.Parse(typeof(NivoOpasnosti), cmbNivoOpasnosti.SelectedItem.ToString()),
                Opstina = txtOpstina.Text,
                Lokacija = txtLokacija.Text,
                Opis = txtOpis.Text
            };
        }
        else
        {
            // Logika za IZMENU
            _situacija.Datum_Od = dtpDatumOd.Value;
            _situacija.Datum_Do = dtpDatumDo.Value;
            _situacija.Tip = txtTip.Text;
            _situacija.Broj_Ugrozenih_Osoba = brojUgrozenih;
            _situacija.Nivo_Opasnosti = (NivoOpasnosti)Enum.Parse(typeof(NivoOpasnosti), cmbNivoOpasnosti.SelectedItem.ToString());
            _situacija.Opstina = txtOpstina.Text;
            _situacija.Lokacija = txtLokacija.Text;
            _situacija.Opis = txtOpis.Text;
        }

        this.DialogResult = DialogResult.OK;
    }
}