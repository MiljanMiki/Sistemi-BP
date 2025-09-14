using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniSluzbuDialog : Form
{
    private Label lblTipSektora, lblPredstavnikJMBG;
    private TextBox txtTipSektora, txtPredstavnikJMBG;
    private Button btnSacuvaj, btnOdustani;

    public Sluzba Sluzba { get; private set; }

    public DodajIzmeniSluzbuDialog(Sluzba? sluzba = null)
    {
        InitializeComponent();

        if (sluzba != null)
        {
            this.Sluzba = sluzba;
            this.Text = "Izmeni službu";
            PopulateFields();
        }
        else
        {
            this.Sluzba = new Sluzba();
            this.Text = "Dodaj službu";
        }
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(400, 250);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        var tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 2 };
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

        lblTipSektora = new Label { Text = "Tip Sektora:", TextAlign = ContentAlignment.MiddleLeft };
        txtTipSektora = new TextBox();
        lblPredstavnikJMBG = new Label { Text = "JMBG Predstavnika:", TextAlign = ContentAlignment.MiddleLeft };
        txtPredstavnikJMBG = new TextBox();

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblTipSektora, 0, 0); tlpMain.Controls.Add(txtTipSektora, 1, 0);
        tlpMain.Controls.Add(lblPredstavnikJMBG, 0, 1); tlpMain.Controls.Add(txtPredstavnikJMBG, 1, 1);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 2); tlpMain.SetColumnSpan(pnlButtons, 2);
        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += BtnSacuvaj_Click;
    }

    private void PopulateFields()
    {
        txtTipSektora.Text = this.Sluzba.TipSektora;
        if (this.Sluzba.Predstavnik != null)
        {
            txtPredstavnikJMBG.Text = this.Sluzba.Predstavnik.JMBG;
        }
    }

    private void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTipSektora.Text))
        {
            MessageBox.Show("Tip sektora ne može biti prazan.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.None;
            return;
        }

        this.Sluzba.TipSektora = txtTipSektora.Text;

        // Dodato za predstavnika
        if (!string.IsNullOrWhiteSpace(txtPredstavnikJMBG.Text))
        {
            // Ovdje bi se trebala uraditi validacija JMBG-a i pretraga predstavnika iz baze
            this.Sluzba.Predstavnik = new Predstavnik { JMBG = txtPredstavnikJMBG.Text };
        }
        else
        {
            this.Sluzba.Predstavnik = null;
        }

        this.DialogResult = DialogResult.OK;
    }
}