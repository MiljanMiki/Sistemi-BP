using System;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniSektorDialog : Form
{
    private Sektor _sektor;
    private bool _isUpdate = false;

    private Label lblTipSektora, lblUloga;
    private TextBox txtTipSektora, txtUloga;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;

    public Sektor Sektor { get; private set; }

    // Konstruktor za dodavanje novog sektora
    public DodajIzmeniSektorDialog()
    {
        InitializeComponent();
        this.Text = "Dodaj novi sektor";
        Sektor = new Sektor();
    }

    // Konstruktor za izmenu postojećeg sektora
    public DodajIzmeniSektorDialog(Sektor sektor)
    {
        InitializeComponent();
        this.Text = "Izmeni sektor";
        _sektor = sektor;
        _isUpdate = true;
        PopulateFields();
    }

    private void InitializeComponent()
    {
        this.ClientSize = new System.Drawing.Size(400, 200);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // Glavni TableLayoutPanel
        tlpMain = new TableLayoutPanel();
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Padding = new Padding(10);
        tlpMain.ColumnCount = 2;
        tlpMain.RowCount = 3;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

        // Kontrole
        lblTipSektora = new Label { Text = "Tip Sektora:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtTipSektora = new TextBox();
        lblUloga = new Label { Text = "Uloga:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtUloga = new TextBox();

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        // Dodavanje kontrola u TableLayoutPanel
        tlpMain.Controls.Add(lblTipSektora, 0, 0);
        tlpMain.Controls.Add(txtTipSektora, 1, 0);
        tlpMain.Controls.Add(lblUloga, 0, 1);
        tlpMain.Controls.Add(txtUloga, 1, 1);

        Panel pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new System.Drawing.Point(100, 10);
        btnOdustani.Location = new System.Drawing.Point(210, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 2);
        tlpMain.SetColumnSpan(pnlButtons, 2);

        this.Controls.Add(tlpMain);

        // Vezivanje događaja
        btnSacuvaj.Click += new EventHandler(BtnSacuvaj_Click);
    }

    private void PopulateFields()
    {
        if (_sektor != null)
        {
            txtTipSektora.Text = _sektor.TipSektora;
            txtUloga.Text = _sektor.Uloga;
        }
    }

    private void BtnSacuvaj_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            if (_isUpdate)
            {
                Sektor = _sektor;
            }
            else
            {
                Sektor = new Sektor();
            }

            Sektor.TipSektora = txtTipSektora.Text;
            Sektor.Uloga = txtUloga.Text;

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
        if (string.IsNullOrWhiteSpace(txtTipSektora.Text) ||
            string.IsNullOrWhiteSpace(txtUloga.Text))
        {
            MessageBox.Show("Molimo popunite sva obavezna polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}