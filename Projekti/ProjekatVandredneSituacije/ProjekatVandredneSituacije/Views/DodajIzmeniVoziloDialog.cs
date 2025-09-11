using System;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniVoziloDialog : Form
{
    private Vozilo _vozilo;
    private bool _isUpdate = false;

    private Label lblProizvodjac, lblTip, lblStatus, lblLokacija, lblTipVozila;
    private TextBox txtProizvodjac, txtTip, txtLokacija;
    private ComboBox cmbStatus, cmbTipVozila;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;

    public Vozilo Vozilo { get; private set; }

    // Konstruktor za dodavanje novog vozila
    public DodajIzmeniVoziloDialog()
    {
        InitializeComponent();
        this.Text = "Dodaj novo vozilo";
        Vozilo = new Vozilo();
    }

    // Konstruktor za izmenu postojećeg vozila
    public DodajIzmeniVoziloDialog(Vozilo vozilo)
    {
        InitializeComponent();
        this.Text = "Izmeni vozilo";
        _vozilo = vozilo;
        _isUpdate = true;
        PopulateFields();
    }

    private void InitializeComponent()
    {
        this.ClientSize = new System.Drawing.Size(400, 300);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // Glavni TableLayoutPanel
        tlpMain = new TableLayoutPanel();
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Padding = new Padding(10);
        tlpMain.ColumnCount = 2;
        tlpMain.RowCount = 6;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        for (int i = 0; i < tlpMain.RowCount - 1; i++)
        {
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        }
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

        // Kontrole
        lblProizvodjac = new Label { Text = "Proizvodjač:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtProizvodjac = new TextBox();
        lblTip = new Label { Text = "Tip (model):", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtTip = new TextBox();
        lblStatus = new Label { Text = "Status:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        cmbStatus = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cmbStatus.Items.AddRange(Enum.GetNames(typeof(StatusVozila)));
        lblLokacija = new Label { Text = "Lokacija:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtLokacija = new TextBox();
        lblTipVozila = new Label { Text = "Vrsta vozila:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        cmbTipVozila = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cmbTipVozila.Items.Add("Kamion");
        cmbTipVozila.Items.Add("Dzip");
        cmbTipVozila.Items.Add("Sanitetsko");

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        // Dodavanje kontrola u TableLayoutPanel
        tlpMain.Controls.Add(lblProizvodjac, 0, 0);
        tlpMain.Controls.Add(txtProizvodjac, 1, 0);
        tlpMain.Controls.Add(lblTip, 0, 1);
        tlpMain.Controls.Add(txtTip, 1, 1);
        tlpMain.Controls.Add(lblStatus, 0, 2);
        tlpMain.Controls.Add(cmbStatus, 1, 2);
        tlpMain.Controls.Add(lblLokacija, 0, 3);
        tlpMain.Controls.Add(txtLokacija, 1, 3);
        tlpMain.Controls.Add(lblTipVozila, 0, 4);
        tlpMain.Controls.Add(cmbTipVozila, 1, 4);

        Panel pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new System.Drawing.Point(100, 10);
        btnOdustani.Location = new System.Drawing.Point(210, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 5);
        tlpMain.SetColumnSpan(pnlButtons, 2);

        this.Controls.Add(tlpMain);

        // Vezivanje događaja
        btnSacuvaj.Click += new EventHandler(BtnSacuvaj_Click);
    }

    private void PopulateFields()
    {
        if (_vozilo != null)
        {
            txtProizvodjac.Text = _vozilo.Proizvodjac;
            txtTip.Text = _vozilo.Tip;
            cmbStatus.SelectedItem = _vozilo.Status.ToString();
            txtLokacija.Text = _vozilo.Lokacija;

            // Popunjavanje vrste vozila na osnovu tipa
            if (_vozilo is Kamioni)
                cmbTipVozila.SelectedItem = "Kamion";
            else if (_vozilo is Dzipovi)
                cmbTipVozila.SelectedItem = "Dzip";
            else if (_vozilo is Sanitetska)
                cmbTipVozila.SelectedItem = "Sanitetsko";
        }
    }

    private void BtnSacuvaj_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            if (_isUpdate)
            {
                Vozilo = _vozilo;
            }
            else
            {
                // Kreiraj novu instancu na osnovu izabranog tipa
                if (cmbTipVozila.SelectedItem.ToString() == "Kamion")
                    Vozilo = new Kamioni();
                else if (cmbTipVozila.SelectedItem.ToString() == "Dzip")
                    Vozilo = new Dzipovi();
                else if (cmbTipVozila.SelectedItem.ToString() == "Sanitetsko")
                    Vozilo = new Sanitetska();
                else
                    Vozilo = new Vozilo();
            }

            Vozilo.Proizvodjac = txtProizvodjac.Text;
            Vozilo.Tip = txtTip.Text;
            Vozilo.Status = (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem.ToString());
            Vozilo.Lokacija = txtLokacija.Text;

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
        if (string.IsNullOrWhiteSpace(txtProizvodjac.Text) ||
            string.IsNullOrWhiteSpace(txtTip.Text) ||
            cmbStatus.SelectedItem == null ||
            string.IsNullOrWhiteSpace(txtLokacija.Text) ||
            cmbTipVozila.SelectedItem == null)
        {
            MessageBox.Show("Molimo popunite sva obavezna polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}