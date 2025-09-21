using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniVoziloDialog : Form
{
    private Label lblRegistarskaOznaka, lblProizvodjac, lblStatus, lblLokacija;
    private TextBox txtRegistarskaOznaka, txtProizvodjac, txtLokacija;
    private ComboBox cmbStatus;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;
    private Panel pnlButtons;

    public Vozilo? Vozilo { get; private set; }

    public DodajIzmeniVoziloDialog(Vozilo? vozilo = null)
    {
        InitializeComponent();
        this.Vozilo = vozilo ?? new Vozilo();
        this.Text = vozilo != null ? "Izmeni vozilo" : "Dodaj novo vozilo";

        if (vozilo != null)
        {
            PopulateFields();
        }
    }

    private void InitializeComponent()
    {
        tlpMain = new TableLayoutPanel();
        lblRegistarskaOznaka = new Label();
        txtRegistarskaOznaka = new TextBox();
        lblProizvodjac = new Label();
        txtProizvodjac = new TextBox();
        lblStatus = new Label();
        cmbStatus = new ComboBox();
        lblLokacija = new Label();
        txtLokacija = new TextBox();
        pnlButtons = new Panel();
        btnSacuvaj = new Button();
        btnOdustani = new Button();
        tlpMain.SuspendLayout();
        pnlButtons.SuspendLayout();
        SuspendLayout();
        // 
        // tlpMain
        // 
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        tlpMain.Controls.Add(lblRegistarskaOznaka, 0, 0);
        tlpMain.Controls.Add(txtRegistarskaOznaka, 1, 0);
        tlpMain.Controls.Add(lblProizvodjac, 0, 1);
        tlpMain.Controls.Add(txtProizvodjac, 1, 1);
        tlpMain.Controls.Add(lblStatus, 0, 2);
        tlpMain.Controls.Add(cmbStatus, 1, 2);
        tlpMain.Controls.Add(lblLokacija, 0, 3);
        tlpMain.Controls.Add(txtLokacija, 1, 3);
        tlpMain.Controls.Add(pnlButtons, 0, 4);
        tlpMain.Location = new Point(0, 0);
        tlpMain.Name = "tlpMain";
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.Size = new Size(200, 100);
        tlpMain.TabIndex = 0;
        // 
        // lblRegistarskaOznaka
        // 
        lblRegistarskaOznaka.Location = new Point(3, 0);
        lblRegistarskaOznaka.Name = "lblRegistarskaOznaka";
        lblRegistarskaOznaka.Size = new Size(74, 20);
        lblRegistarskaOznaka.TabIndex = 0;
        // 
        // txtRegistarskaOznaka
        // 
        txtRegistarskaOznaka.Location = new Point(83, 3);
        txtRegistarskaOznaka.Name = "txtRegistarskaOznaka";
        txtRegistarskaOznaka.Size = new Size(100, 27);
        txtRegistarskaOznaka.TabIndex = 1;
        // 
        // lblProizvodjac
        // 
        lblProizvodjac.Location = new Point(3, 20);
        lblProizvodjac.Name = "lblProizvodjac";
        lblProizvodjac.Size = new Size(74, 20);
        lblProizvodjac.TabIndex = 2;
        // 
        // txtProizvodjac
        // 
        txtProizvodjac.Location = new Point(83, 23);
        txtProizvodjac.Name = "txtProizvodjac";
        txtProizvodjac.Size = new Size(100, 27);
        txtProizvodjac.TabIndex = 3;
        // 
        // lblStatus
        // 
        lblStatus.Location = new Point(3, 40);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(74, 20);
        lblStatus.TabIndex = 4;
        // 
        // cmbStatus
        // 
        cmbStatus.Items.AddRange(new object[] { "operativno", "u_kvaru" });
        cmbStatus.Location = new Point(83, 43);
        cmbStatus.Name = "cmbStatus";
        cmbStatus.Size = new Size(114, 28);
        cmbStatus.TabIndex = 5;
        // 
        // lblLokacija
        // 
        lblLokacija.Location = new Point(3, 60);
        lblLokacija.Name = "lblLokacija";
        lblLokacija.Size = new Size(74, 20);
        lblLokacija.TabIndex = 6;
        // 
        // txtLokacija
        // 
        txtLokacija.Location = new Point(83, 63);
        txtLokacija.Name = "txtLokacija";
        txtLokacija.Size = new Size(100, 27);
        txtLokacija.TabIndex = 7;
        // 
        // pnlButtons
        // 
        tlpMain.SetColumnSpan(pnlButtons, 2);
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        pnlButtons.Location = new Point(3, 83);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(194, 14);
        pnlButtons.TabIndex = 8;
        // 
        // btnSacuvaj
        // 
        btnSacuvaj.Location = new Point(50, 10);
        btnSacuvaj.Name = "btnSacuvaj";
        btnSacuvaj.Size = new Size(75, 23);
        btnSacuvaj.TabIndex = 0;
        btnSacuvaj.Click += BtnSacuvaj_Click;
        // 
        // btnOdustani
        // 
        btnOdustani.Location = new Point(160, 10);
        btnOdustani.Name = "btnOdustani";
        btnOdustani.Size = new Size(75, 23);
        btnOdustani.TabIndex = 1;
        // 
        // DodajIzmeniVoziloDialog
        // 
        ClientSize = new Size(400, 300);
        Controls.Add(tlpMain);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "DodajIzmeniVoziloDialog";
        StartPosition = FormStartPosition.CenterParent;
        tlpMain.ResumeLayout(false);
        tlpMain.PerformLayout();
        pnlButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    protected void PopulateFields()
    {
        if (Vozilo != null)
        {
            txtRegistarskaOznaka.Text = Vozilo.Registarska_Oznaka;
            txtProizvodjac.Text = Vozilo.Proizvodjac;
            cmbStatus.SelectedItem = Vozilo.Status.ToString();
            txtLokacija.Text = Vozilo.Lokacija;
        }
    }

    protected void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (ValidateInput())
        {
            Vozilo!.Registarska_Oznaka = txtRegistarskaOznaka.Text;
            Vozilo.Proizvodjac = txtProizvodjac.Text;
            Vozilo.Status = (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!);
            Vozilo.Lokacija = txtLokacija.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            this.DialogResult = DialogResult.None;
        }
    }

    protected virtual bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtRegistarskaOznaka.Text) || string.IsNullOrWhiteSpace(txtProizvodjac.Text) ||
            cmbStatus.SelectedItem == null || string.IsNullOrWhiteSpace(txtLokacija.Text))
        {
            MessageBox.Show("Molimo popunite sva obavezna polja ispravno.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}