using System;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniSektorDialog : Form
{
    private Sluzba _sektor;
    private bool _isUpdate = false;

    private Label lblTipSektora, lblUloga;
    private TextBox txtTipSektora, txtUloga;
    private Button btnSacuvaj, btnOdustani;
    private Panel pnlButtons;
    private TableLayoutPanel tlpMain;

    public Sluzba Sektor { get; private set; }

    // Konstruktor za dodavanje novog sektora
    public DodajIzmeniSektorDialog()
    {
        InitializeComponent();
        this.Text = "Dodaj novi sektor";
        Sektor = new Sluzba();
    }

    // Konstruktor za izmenu postojećeg sektora
    public DodajIzmeniSektorDialog(Sluzba sektor)
    {
        InitializeComponent();
        this.Text = "Izmeni sektor";
        _sektor = sektor;
        _isUpdate = true;
        PopulateFields();
    }

    private void InitializeComponent()
    {
        tlpMain = new TableLayoutPanel();
        lblTipSektora = new Label();
        txtTipSektora = new TextBox();
        lblUloga = new Label();
        txtUloga = new TextBox();
        pnlButtons = new Panel();
        btnSacuvaj = new Button();
        btnOdustani = new Button();
        tlpMain.SuspendLayout();
        pnlButtons.SuspendLayout();
        SuspendLayout();
        // 
        // tlpMain
        // 
        tlpMain.ColumnCount = 2;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        tlpMain.Controls.Add(lblTipSektora, 0, 0);
        tlpMain.Controls.Add(txtTipSektora, 1, 0);
        tlpMain.Controls.Add(lblUloga, 0, 1);
        tlpMain.Controls.Add(txtUloga, 1, 1);
        tlpMain.Controls.Add(pnlButtons, 0, 2);
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Location = new Point(0, 0);
        tlpMain.Name = "tlpMain";
        tlpMain.Padding = new Padding(10);
        tlpMain.RowCount = 3;
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tlpMain.Size = new Size(400, 200);
        tlpMain.TabIndex = 0;
        // 
        // lblTipSektora
        // 
        lblTipSektora.Location = new Point(13, 10);
        lblTipSektora.Name = "lblTipSektora";
        lblTipSektora.Size = new Size(100, 23);
        lblTipSektora.TabIndex = 0;
        // 
        // txtTipSektora
        // 
        txtTipSektora.Location = new Point(127, 13);
        txtTipSektora.Name = "txtTipSektora";
        txtTipSektora.Size = new Size(100, 27);
        txtTipSektora.TabIndex = 1;
        // 
        // lblUloga
        // 
        lblUloga.Location = new Point(13, 40);
        lblUloga.Name = "lblUloga";
        lblUloga.Size = new Size(100, 23);
        lblUloga.TabIndex = 2;
        // 
        // txtUloga
        // 
        txtUloga.Location = new Point(127, 43);
        txtUloga.Name = "txtUloga";
        txtUloga.Size = new Size(100, 27);
        txtUloga.TabIndex = 3;
        // 
        // pnlButtons
        // 
        tlpMain.SetColumnSpan(pnlButtons, 2);
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        pnlButtons.Location = new Point(13, 73);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(200, 100);
        pnlButtons.TabIndex = 4;
        // 
        // btnSacuvaj
        // 
        btnSacuvaj.Location = new Point(100, 10);
        btnSacuvaj.Name = "btnSacuvaj";
        btnSacuvaj.Size = new Size(75, 23);
        btnSacuvaj.TabIndex = 0;
        btnSacuvaj.Click += BtnSacuvaj_Click;
        // 
        // btnOdustani
        // 
        btnOdustani.Location = new Point(210, 10);
        btnOdustani.Name = "btnOdustani";
        btnOdustani.Size = new Size(75, 23);
        btnOdustani.TabIndex = 1;
        // 
        // DodajIzmeniSektorDialog
        // 
        ClientSize = new Size(400, 200);
        Controls.Add(tlpMain);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "DodajIzmeniSektorDialog";
        StartPosition = FormStartPosition.CenterParent;
        tlpMain.ResumeLayout(false);
        tlpMain.PerformLayout();
        pnlButtons.ResumeLayout(false);
        ResumeLayout(false);
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
                Sektor = new Sluzba();
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