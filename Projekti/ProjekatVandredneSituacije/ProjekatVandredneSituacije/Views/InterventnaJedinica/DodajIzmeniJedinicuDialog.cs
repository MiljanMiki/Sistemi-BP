using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;
using System.Linq;

public class DodajIzmeniJedinicuDialog : Form
{
    private Label lblNaziv, lblBrojClanova, lblBaza, lblKomandir, lblTipSpecijalne;
    private TextBox txtNaziv, txtBrojClanova, txtBaza, txtTipSpecijalne;
    private ComboBox cmbKomandir;
    private Button btnSacuvaj, btnOdustani;
    private bool isSpecialniTip;

    public InterventnaJedinica Jedinica { get; private set; }

    // Konstruktor za dodavanje nove jedinice
    public DodajIzmeniJedinicuDialog(bool isSpecialni = false)
    {
        isSpecialniTip = isSpecialni;
        Jedinica = isSpecialni ? new SpecijalnaInterventna() : new OpstaIntervetnaJed();
        InitializeComponent();
        this.Text = "Dodaj novu jedinicu";
    }

    // Konstruktor za izmenu postojeće jedinice
    public DodajIzmeniJedinicuDialog(InterventnaJedinica jedinica)
    {
        Jedinica = jedinica;
        isSpecialniTip = jedinica is SpecijalnaInterventna;
        InitializeComponent();
        this.Text = "Izmeni jedinicu";
        PopulateFields();
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(400, 350);
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
        txtBrojClanova = new TextBox();
        lblBaza = new Label { Text = "Baza:", TextAlign = ContentAlignment.MiddleLeft };
        txtBaza = new TextBox();
        lblKomandir = new Label { Text = "Komandir:", TextAlign = ContentAlignment.MiddleLeft };
        cmbKomandir = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };

        lblTipSpecijalne = new Label { Text = "Tip specijalne jedinice:", TextAlign = ContentAlignment.MiddleLeft, Visible = isSpecialniTip };
        txtTipSpecijalne = new TextBox { Visible = isSpecialniTip };

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        // Mock podaci za komandire, u stvarnoj aplikaciji bi se dobijali iz baze
        var mockKomandiri = ListaInterventnihJedinicaForm.mockRadnici.Select(r => new { r.Ime, r.Prezime, r.JMBG }).ToList();
        cmbKomandir.DataSource = mockKomandiri;
        cmbKomandir.DisplayMember = "Ime"; // Prikazuje samo ime

        tlpMain.Controls.Add(lblNaziv, 0, 0); tlpMain.Controls.Add(txtNaziv, 1, 0);
        tlpMain.Controls.Add(lblBrojClanova, 0, 1); tlpMain.Controls.Add(txtBrojClanova, 1, 1);
        tlpMain.Controls.Add(lblBaza, 0, 2); tlpMain.Controls.Add(txtBaza, 1, 2);
        tlpMain.Controls.Add(lblKomandir, 0, 3); tlpMain.Controls.Add(cmbKomandir, 1, 3);

        tlpMain.Controls.Add(lblTipSpecijalne, 0, 4); tlpMain.Controls.Add(txtTipSpecijalne, 1, 4);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 5); tlpMain.SetColumnSpan(pnlButtons, 2);
        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += BtnSacuvaj_Click;
    }

    private void PopulateFields()
    {
        txtNaziv.Text = Jedinica.Naziv;
        txtBrojClanova.Text = Jedinica.BrojClanova.ToString();
        txtBaza.Text = Jedinica.Baza;

        if (Jedinica.Komandir != null)
        {
            var komandir = ListaInterventnihJedinicaForm.mockRadnici.FirstOrDefault(r => r.JMBG == Jedinica.Komandir.JMBG);
            if (komandir != null)
            {
                cmbKomandir.SelectedItem = new { komandir.Ime, komandir.Prezime, komandir.JMBG };
            }
        }

        if (isSpecialniTip && Jedinica is SpecijalnaInterventna specijalna)
        {
            txtTipSpecijalne.Text = specijalna.TipSpecijalneJedinice;
        }
    }

    private void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (ValidateInput())
        {
            Jedinica.Naziv = txtNaziv.Text;
            Jedinica.BrojClanova = int.Parse(txtBrojClanova.Text);
            Jedinica.Baza = txtBaza.Text;

            var selectedKomandir = cmbKomandir.SelectedItem as dynamic;
            Jedinica.Komandir = ListaInterventnihJedinicaForm.mockRadnici.FirstOrDefault(r => r.JMBG == selectedKomandir.JMBG)!;

            if (isSpecialniTip && Jedinica is SpecijalnaInterventna specijalna)
            {
                specijalna.TipSpecijalneJedinice = txtTipSpecijalne.Text;
            }

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
        if (string.IsNullOrWhiteSpace(txtNaziv.Text) || !int.TryParse(txtBrojClanova.Text, out _) || string.IsNullOrWhiteSpace(txtBaza.Text) || cmbKomandir.SelectedItem == null)
        {
            MessageBox.Show("Molimo popunite sva obavezna polja ispravno. Broj članova mora biti broj.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (isSpecialniTip && string.IsNullOrWhiteSpace(txtTipSpecijalne.Text))
        {
            MessageBox.Show("Molimo unesite tip specijalne jedinice.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}