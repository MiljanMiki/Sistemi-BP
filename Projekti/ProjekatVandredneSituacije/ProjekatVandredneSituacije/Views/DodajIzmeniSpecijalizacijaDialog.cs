using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniSpecijalizacijaDialog : Form
{
    private Label lblTip;
    private TextBox txtTip;
    private Button btnSacuvaj, btnOdustani;

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
        this.ClientSize = new Size(350, 150);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        var tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10) };
        tlpMain.ColumnCount = 2;
        tlpMain.RowCount = 2;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

        lblTip = new Label { Text = "Tip specijalizacije:", TextAlign = ContentAlignment.MiddleLeft };
        txtTip = new TextBox();

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblTip, 0, 0);
        tlpMain.Controls.Add(txtTip, 1, 0);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 1);
        tlpMain.SetColumnSpan(pnlButtons, 2);

        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += new EventHandler(BtnSacuvaj_Click);
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