using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniSpecijalizacijaDialog : Form
{
    private Label lblTip;
    private TextBox txtTip;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;
    private Panel pnlButtons;

    public Specijalizacija Specijalizacija { get; private set; }

    public DodajIzmeniSpecijalizacijaDialog(Specijalizacija specijalizacija = null)
    {
        InitializeComponent();
        this.Text = "Izmena specijalizacije";

        // Ako postoji specijalizacija, popuni polja
        this.Specijalizacija = specijalizacija ?? new Specijalizacija();
        txtTip.Text = this.Specijalizacija.Tip;
    }

    private void InitializeComponent()
    {
        tlpMain = new TableLayoutPanel();
        lblTip = new Label();
        txtTip = new TextBox();
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
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        tlpMain.Controls.Add(lblTip, 0, 0);
        tlpMain.Controls.Add(txtTip, 1, 0);
        tlpMain.Controls.Add(pnlButtons, 0, 1);
        tlpMain.Location = new Point(0, 0);
        tlpMain.Name = "tlpMain";
        tlpMain.RowCount = 2;
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tlpMain.Size = new Size(200, 100);
        tlpMain.TabIndex = 0;
        // 
        // lblTip
        // 
        lblTip.Location = new Point(3, 0);
        lblTip.Name = "lblTip";
        lblTip.Size = new Size(74, 20);
        lblTip.TabIndex = 0;
        // 
        // txtTip
        // 
        txtTip.Location = new Point(83, 3);
        txtTip.Name = "txtTip";
        txtTip.Size = new Size(100, 27);
        txtTip.TabIndex = 1;
        // 
        // pnlButtons
        // 
        tlpMain.SetColumnSpan(pnlButtons, 2);
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        pnlButtons.Location = new Point(3, 23);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(194, 74);
        pnlButtons.TabIndex = 2;
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
        // DodajIzmeniSpecijalizacijaDialog
        // 
        ClientSize = new Size(350, 150);
        Controls.Add(tlpMain);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "DodajIzmeniSpecijalizacijaDialog";
        StartPosition = FormStartPosition.CenterParent;
        tlpMain.ResumeLayout(false);
        tlpMain.PerformLayout();
        pnlButtons.ResumeLayout(false);
        ResumeLayout(false);
    }

    private void BtnSacuvaj_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTip.Text))
        {
            MessageBox.Show("Tip specijalizacije mora biti popunjen.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.None;
            return;
        }

        this.Specijalizacija.Tip = txtTip.Text;
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}