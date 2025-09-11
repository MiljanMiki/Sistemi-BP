using System;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniIntervencijuDialog : Form
{
    private Intervencija _intervencija;
    private bool _isUpdate = false;

    private Label lblDatumVreme, lblLokacija, lblStatus, lblResursi, lblBrojSpasenih, lblBrojPovredjenih, lblUspesnost;
    private DateTimePicker dtpDatumVreme;
    private TextBox txtLokacija, txtResursi, txtBrojSpasenih, txtBrojPovredjenih, txtUspesnost;
    private ComboBox cmbStatus;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;

    public Intervencija Intervencija { get; private set; }

    // Konstruktor za dodavanje nove intervencije
    public DodajIzmeniIntervencijuDialog()
    {
        InitializeComponent();
        this.Text = "Dodaj novu intervenciju";
        Intervencija = new Intervencija();
    }

    // Konstruktor za izmenu postojece intervencije
    public DodajIzmeniIntervencijuDialog(Intervencija intervencija)
    {
        InitializeComponent();
        this.Text = "Izmeni intervenciju";
        _intervencija = intervencija;
        _isUpdate = true;
        PopulateFields();
    }

    private void InitializeComponent()
    {
        this.ClientSize = new System.Drawing.Size(450, 350);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // Glavni TableLayoutPanel
        tlpMain = new TableLayoutPanel();
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Padding = new Padding(10);
        tlpMain.ColumnCount = 2;
        tlpMain.RowCount = 8;
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
        lblLokacija = new Label { Text = "Lokacija:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtLokacija = new TextBox();
        lblStatus = new Label { Text = "Status:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        cmbStatus = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cmbStatus.Items.AddRange(Enum.GetNames(typeof(Status)));
        lblResursi = new Label { Text = "Resursi:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtResursi = new TextBox();
        lblBrojSpasenih = new Label { Text = "Broj Spasenih:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtBrojSpasenih = new TextBox();
        lblBrojPovredjenih = new Label { Text = "Broj Povredjenih:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtBrojPovredjenih = new TextBox();
        lblUspesnost = new Label { Text = "Uspešnost:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtUspesnost = new TextBox();

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        // Dodavanje kontrola u TableLayoutPanel
        tlpMain.Controls.Add(lblDatumVreme, 0, 0);
        tlpMain.Controls.Add(dtpDatumVreme, 1, 0);
        tlpMain.Controls.Add(lblLokacija, 0, 1);
        tlpMain.Controls.Add(txtLokacija, 1, 1);
        tlpMain.Controls.Add(lblStatus, 0, 2);
        tlpMain.Controls.Add(cmbStatus, 1, 2);
        tlpMain.Controls.Add(lblResursi, 0, 3);
        tlpMain.Controls.Add(txtResursi, 1, 3);
        tlpMain.Controls.Add(lblBrojSpasenih, 0, 4);
        tlpMain.Controls.Add(txtBrojSpasenih, 1, 4);
        tlpMain.Controls.Add(lblBrojPovredjenih, 0, 5);
        tlpMain.Controls.Add(txtBrojPovredjenih, 1, 5);
        tlpMain.Controls.Add(lblUspesnost, 0, 6);
        tlpMain.Controls.Add(txtUspesnost, 1, 6);

        Panel pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new System.Drawing.Point(130, 10);
        btnOdustani.Location = new System.Drawing.Point(240, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 7);
        tlpMain.SetColumnSpan(pnlButtons, 2);

        this.Controls.Add(tlpMain);

        // Vezivanje dogadjaja
        btnSacuvaj.Click += new EventHandler(BtnSacuvaj_Click);
    }

    private void PopulateFields()
    {
        if (_intervencija != null)
        {
            dtpDatumVreme.Value = _intervencija.Datum_I_Vreme;
            txtLokacija.Text = _intervencija.Lokacija;
            cmbStatus.SelectedItem = _intervencija.Status.ToString();
            txtResursi.Text = _intervencija.Resursi;
            txtBrojSpasenih.Text = _intervencija.Broj_Spasenih.ToString();
            txtBrojPovredjenih.Text = _intervencija.Broj_Povredjenih.ToString();
            txtUspesnost.Text = _intervencija.Uspesnost.ToString();
        }
    }

    private void BtnSacuvaj_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            if (_isUpdate)
            {
                Intervencija = _intervencija;
            }
            else
            {
                Intervencija = new Intervencija();
            }

            Intervencija.Datum_I_Vreme = dtpDatumVreme.Value;
            Intervencija.Lokacija = txtLokacija.Text;
            Intervencija.Status = (Status)Enum.Parse(typeof(Status), cmbStatus.SelectedItem.ToString());
            Intervencija.Resursi = txtResursi.Text;
            Intervencija.Broj_Spasenih = int.Parse(txtBrojSpasenih.Text);
            Intervencija.Broj_Povredjenih = int.Parse(txtBrojPovredjenih.Text);
            Intervencija.Uspesnost = int.Parse(txtUspesnost.Text);

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
        if (string.IsNullOrWhiteSpace(txtLokacija.Text))
        {
            MessageBox.Show("Molimo popunite sva obavezna polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        int brojSpasenih, brojPovredjenih, uspesnost;
        if (!int.TryParse(txtBrojSpasenih.Text, out brojSpasenih) ||
            !int.TryParse(txtBrojPovredjenih.Text, out brojPovredjenih) ||
            !int.TryParse(txtUspesnost.Text, out uspesnost))
        {
            MessageBox.Show("Broj spasenih, povređenih i uspešnost moraju biti numeričke vrednosti.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}