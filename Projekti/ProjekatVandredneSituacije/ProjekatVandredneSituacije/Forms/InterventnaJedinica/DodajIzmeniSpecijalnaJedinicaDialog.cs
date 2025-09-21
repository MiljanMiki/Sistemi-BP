using System;
using System.Drawing;
using System.Windows.Forms;

public class DodajIzmeniSpecijalnaJedinicaDialog : Form
{
    private Label lblNaziv, lblBrojClanova, lblBaza, lblTipSpecijalneJedinice;
    private TextBox txtNaziv, txtBaza, txtTipSpecijalneJedinice;
    private NumericUpDown numBrojClanova;
    private Button btnSacuvaj, btnOdustani;

    public SpecijalnaInterventnaJedinicaBasic Jedinica { get; private set; }
     
    public DodajIzmeniSpecijalnaJedinicaDialog()
    {
        Jedinica = new SpecijalnaInterventnaJedinicaBasic();
        InitializeComponent();
        this.Text = "Dodaj Specijalnu Interventnu Jedinicu";
    }
     
    public DodajIzmeniSpecijalnaJedinicaDialog(SpecijalnaInterventnaJedinicaBasic jedinica)
    {
        Jedinica = jedinica;
        InitializeComponent();
        this.Text = "Izmeni Specijalnu Interventnu Jedinicu";
        PopuniPolja();
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(400, 280);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        var tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 2 };
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

        lblNaziv = new Label { Text = "Naziv:", TextAlign = ContentAlignment.MiddleLeft };
        txtNaziv = new TextBox();
        lblBrojClanova = new Label { Text = "Broj članova:", TextAlign = ContentAlignment.MiddleLeft };
        numBrojClanova = new NumericUpDown { Minimum = 1, Maximum = 1000 };
        lblBaza = new Label { Text = "Baza:", TextAlign = ContentAlignment.MiddleLeft };
        txtBaza = new TextBox();
        lblTipSpecijalneJedinice = new Label { Text = "Tip specijalne jedinice:", TextAlign = ContentAlignment.MiddleLeft };
        txtTipSpecijalneJedinice = new TextBox();

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblNaziv, 0, 0); tlpMain.Controls.Add(txtNaziv, 1, 0);
        tlpMain.Controls.Add(lblBrojClanova, 0, 1); tlpMain.Controls.Add(numBrojClanova, 1, 1);
        tlpMain.Controls.Add(lblBaza, 0, 2); tlpMain.Controls.Add(txtBaza, 1, 2);
        tlpMain.Controls.Add(lblTipSpecijalneJedinice, 0, 3); tlpMain.Controls.Add(txtTipSpecijalneJedinice, 1, 3);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 4); tlpMain.SetColumnSpan(pnlButtons, 2);
        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += BtnSacuvaj_Click;
    }

    private void PopuniPolja()
    {
        if (Jedinica != null)
        {
            txtNaziv.Text = Jedinica.Naziv;
            numBrojClanova.Value = Jedinica.BrojClanova;
            txtBaza.Text = Jedinica.Baza;
            txtTipSpecijalneJedinice.Text = Jedinica.TipSpecijalneJed;
        }
    }

    private void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (ValidateInput())
        {
            Jedinica.Naziv = txtNaziv.Text;
            Jedinica.BrojClanova = (int)numBrojClanova.Value;
            Jedinica.Baza = txtBaza.Text;
            Jedinica.TipSpecijalneJed = txtTipSpecijalneJedinice.Text;
            this.DialogResult = DialogResult.OK;
        }
        else
        {
            this.DialogResult = DialogResult.None;
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtNaziv.Text) || string.IsNullOrWhiteSpace(txtBaza.Text) ||
            string.IsNullOrWhiteSpace(txtTipSpecijalneJedinice.Text))
        {
            MessageBox.Show("Sva polja moraju biti popunjena.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}