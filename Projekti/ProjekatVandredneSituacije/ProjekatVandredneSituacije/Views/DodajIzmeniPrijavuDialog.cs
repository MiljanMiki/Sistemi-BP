using System;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniPrijavuDialog : Form
{
    private Prijava _prijava;
    private bool _isUpdate = false;

    private Label lblDatumVreme, lblTip, lblIme, lblKontakt, lblLokacija, lblOpis, lblJMBGDispecer, lblPrioritet;
    private DateTimePicker dtpDatumVreme;
    private TextBox txtTip, txtIme, txtKontakt, txtLokacija, txtOpis, txtJMBGDispecer;
    private NumericUpDown nudPrioritet;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;

    public Prijava Prijava { get; private set; }

    // Konstruktor za dodavanje nove prijave
    public DodajIzmeniPrijavuDialog()
    {
        InitializeComponent();
        this.Text = "Dodaj novu prijavu";
        Prijava = new Prijava();
    }

    // Konstruktor za izmenu postojeće prijave
    public DodajIzmeniPrijavuDialog(Prijava prijava)
    {
        InitializeComponent();
        this.Text = "Izmeni prijavu";
        _prijava = prijava;
        _isUpdate = true;
        PopulateFields();
    }

    private void InitializeComponent()
    {
        this.ClientSize = new System.Drawing.Size(450, 400);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // Glavni TableLayoutPanel
        tlpMain = new TableLayoutPanel();
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Padding = new Padding(10);
        tlpMain.ColumnCount = 2;
        tlpMain.RowCount = 9;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        for (int i = 0; i < tlpMain.RowCount - 1; i++)
        {
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        }
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

        // Kontrole
        lblDatumVreme = new Label { Text = "Datum i Vreme:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        dtpDatumVreme = new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd.MM.yyyy HH:mm:ss" };
        lblTip = new Label { Text = "Tip:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtTip = new TextBox();
        lblIme = new Label { Text = "Ime:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtIme = new TextBox();
        lblKontakt = new Label { Text = "Kontakt:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtKontakt = new TextBox();
        lblLokacija = new Label { Text = "Lokacija:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtLokacija = new TextBox();
        lblOpis = new Label { Text = "Opis:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtOpis = new TextBox();
        lblJMBGDispecer = new Label { Text = "JMBG Dispečera:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtJMBGDispecer = new TextBox();
        lblPrioritet = new Label { Text = "Prioritet:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        nudPrioritet = new NumericUpDown { Minimum = 1, Maximum = 5 };

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        // Dodavanje kontrola u TableLayoutPanel
        tlpMain.Controls.Add(lblDatumVreme, 0, 0);
        tlpMain.Controls.Add(dtpDatumVreme, 1, 0);
        tlpMain.Controls.Add(lblTip, 0, 1);
        tlpMain.Controls.Add(txtTip, 1, 1);
        tlpMain.Controls.Add(lblIme, 0, 2);
        tlpMain.Controls.Add(txtIme, 1, 2);
        tlpMain.Controls.Add(lblKontakt, 0, 3);
        tlpMain.Controls.Add(txtKontakt, 1, 3);
        tlpMain.Controls.Add(lblLokacija, 0, 4);
        tlpMain.Controls.Add(txtLokacija, 1, 4);
        tlpMain.Controls.Add(lblOpis, 0, 5);
        tlpMain.Controls.Add(txtOpis, 1, 5);
        tlpMain.Controls.Add(lblJMBGDispecer, 0, 6);
        tlpMain.Controls.Add(txtJMBGDispecer, 1, 6);
        tlpMain.Controls.Add(lblPrioritet, 0, 7);
        tlpMain.Controls.Add(nudPrioritet, 1, 7);

        Panel pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new System.Drawing.Point(130, 10);
        btnOdustani.Location = new System.Drawing.Point(240, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 8);
        tlpMain.SetColumnSpan(pnlButtons, 2);

        this.Controls.Add(tlpMain);

        // Vezivanje događaja
        btnSacuvaj.Click += new EventHandler(BtnSacuvaj_Click);
    }

    private void PopulateFields()
    {
        if (_prijava != null)
        {
            dtpDatumVreme.Value = _prijava.Datum_I_Vreme;
            txtTip.Text = _prijava.Tip;
            txtIme.Text = _prijava.Ime;
            txtKontakt.Text = _prijava.Kontakt;
            txtLokacija.Text = _prijava.Lokacija;
            txtOpis.Text = _prijava.Opis;
            txtJMBGDispecer.Text = _prijava.JMBG_Dispecer;
            nudPrioritet.Value = _prijava.Prioritet;
        }
    }

    private void BtnSacuvaj_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            if (_isUpdate)
            {
                Prijava = _prijava;
            }
            else
            {
                Prijava = new Prijava();
            }

            Prijava.Datum_I_Vreme = dtpDatumVreme.Value;
            Prijava.Tip = txtTip.Text;
            Prijava.Ime = txtIme.Text;
            Prijava.Kontakt = txtKontakt.Text;
            Prijava.Lokacija = txtLokacija.Text;
            Prijava.Opis = txtOpis.Text;
            Prijava.JMBG_Dispecer = txtJMBGDispecer.Text;
            Prijava.Prioritet = (int)nudPrioritet.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            this.DialogResult = DialogResult.None; // Sprečava zatvaranje forme
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtTip.Text) ||
            string.IsNullOrWhiteSpace(txtIme.Text) ||
            string.IsNullOrWhiteSpace(txtKontakt.Text) ||
            string.IsNullOrWhiteSpace(txtLokacija.Text) ||
            string.IsNullOrWhiteSpace(txtJMBGDispecer.Text))
        {
            MessageBox.Show("Molimo popunite sva obavezna polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (txtJMBGDispecer.Text.Length != 13 || !txtJMBGDispecer.Text.All(char.IsDigit))
        {
            MessageBox.Show("JMBG mora sadržati tačno 13 cifara.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}