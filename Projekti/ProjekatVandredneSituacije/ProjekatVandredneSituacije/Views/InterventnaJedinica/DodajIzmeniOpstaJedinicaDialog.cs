using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniOpstaJedinicaDialog : Form
{
    private Label lblJedinstveniBroj, lblNaziv, lblBrojClanova, lblBaza;
    private TextBox txtJedinstveniBroj, txtNaziv, txtBrojClanova, txtBaza;
    private Button btnSacuvaj, btnOdustani;

    public OpstaIntervetnaJed Jedinica { get; private set; }

    public DodajIzmeniOpstaJedinicaDialog(OpstaIntervetnaJed jedinica = null)
    {
        InitializeComponent();
        this.Jedinica = jedinica ?? new OpstaIntervetnaJed();
        if (jedinica != null)
        {
            this.Text = "Izmeni Opštu Interventnu Jedinicu";
            PopulateFields();
        }
        else
        {
            this.Text = "Dodaj Opštu Interventnu Jedinicu";
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

        lblJedinstveniBroj = new Label { Text = "Jedinstveni Broj:", TextAlign = ContentAlignment.MiddleLeft };
        txtJedinstveniBroj = new TextBox();
        lblNaziv = new Label { Text = "Naziv:", TextAlign = ContentAlignment.MiddleLeft };
        txtNaziv = new TextBox();
        lblBrojClanova = new Label { Text = "Broj članova:", TextAlign = ContentAlignment.MiddleLeft };
        txtBrojClanova = new TextBox();
        lblBaza = new Label { Text = "Baza:", TextAlign = ContentAlignment.MiddleLeft };
        txtBaza = new TextBox();

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblJedinstveniBroj, 0, 0); tlpMain.Controls.Add(txtJedinstveniBroj, 1, 0);
        tlpMain.Controls.Add(lblNaziv, 0, 1); tlpMain.Controls.Add(txtNaziv, 1, 1);
        tlpMain.Controls.Add(lblBrojClanova, 0, 2); tlpMain.Controls.Add(txtBrojClanova, 1, 2);
        tlpMain.Controls.Add(lblBaza, 0, 3); tlpMain.Controls.Add(txtBaza, 1, 3);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 4); tlpMain.SetColumnSpan(pnlButtons, 2);
        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += BtnSacuvaj_Click;
    }

    private void PopulateFields()
    {
        if (Jedinica != null)
        {
            txtJedinstveniBroj.Text = Jedinica.Jedinstveni_Broj.ToString();
            txtNaziv.Text = Jedinica.Naziv;
            txtBrojClanova.Text = Jedinica.BrojClanova.ToString();
            txtBaza.Text = Jedinica.Baza;
        }
    }

    private void BtnSacuvaj_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            if (int.TryParse(txtJedinstveniBroj.Text, out int jedinstveniBroj)) Jedinica.Jedinstveni_Broj = jedinstveniBroj;
            Jedinica.Naziv = txtNaziv.Text;
            if (int.TryParse(txtBrojClanova.Text, out int brojClanova)) Jedinica.BrojClanova = brojClanova;
            Jedinica.Baza = txtBaza.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            this.DialogResult = DialogResult.None;
        }
    }

    private bool ValidateInput()
    {
        if (!int.TryParse(txtJedinstveniBroj.Text, out _) || string.IsNullOrWhiteSpace(txtNaziv.Text) ||
            !int.TryParse(txtBrojClanova.Text, out _) || string.IsNullOrWhiteSpace(txtBaza.Text))
        {
            MessageBox.Show("Sva polja moraju biti popunjena ispravno.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}