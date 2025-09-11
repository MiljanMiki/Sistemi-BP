using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniIntJedinicuDialog : Form
{
    private InterventnaJedinica _jedinica;
    private bool _isUpdate = false;

    private Label lblNaziv, lblBrojClanova, lblBaza, lblTip;
    private TextBox txtNaziv, txtBrojClanova, txtBaza;
    private ComboBox cmbTipJedinice;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;

    public InterventnaJedinica Jedinica { get; private set; }

    // Konstruktor za dodavanje nove jedinice
    public DodajIzmeniIntJedinicuDialog()
    {
        InitializeComponent();
        this.Text = "Dodaj novu interventnu jedinicu";
        Jedinica = new InterventnaJedinica();
    }

    // Konstruktor za izmenu postojeće jedinice
    public DodajIzmeniIntJedinicuDialog(InterventnaJedinica jedinica)
    {
        InitializeComponent();
        this.Text = "Izmeni interventnu jedinicu";
        _jedinica = jedinica;
        _isUpdate = true;
        PopulateFields();
    }

    private void InitializeComponent()
    {
        this.ClientSize = new System.Drawing.Size(400, 250);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // Glavni TableLayoutPanel
        tlpMain = new TableLayoutPanel();
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Padding = new Padding(10);
        tlpMain.ColumnCount = 2;
        tlpMain.RowCount = 5;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

        // Kontrole
        lblNaziv = new Label { Text = "Naziv:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtNaziv = new TextBox();
        lblBrojClanova = new Label { Text = "Broj članova:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtBrojClanova = new TextBox();
        lblBaza = new Label { Text = "Baza:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        txtBaza = new TextBox();
        lblTip = new Label { Text = "Tip jedinice:", TextAlign = System.Drawing.ContentAlignment.MiddleLeft };
        cmbTipJedinice = new ComboBox();
        cmbTipJedinice.Items.Add("Opšta");
        cmbTipJedinice.Items.Add("Specijalna");
        cmbTipJedinice.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTipJedinice.SelectedIndex = 0; // Podrazumevana vrednost

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        // Dodavanje kontrola u TableLayoutPanel
        tlpMain.Controls.Add(lblNaziv, 0, 0);
        tlpMain.Controls.Add(txtNaziv, 1, 0);
        tlpMain.Controls.Add(lblBrojClanova, 0, 1);
        tlpMain.Controls.Add(txtBrojClanova, 1, 1);
        tlpMain.Controls.Add(lblBaza, 0, 2);
        tlpMain.Controls.Add(txtBaza, 1, 2);
        tlpMain.Controls.Add(lblTip, 0, 3);
        tlpMain.Controls.Add(cmbTipJedinice, 1, 3);

        Panel pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new System.Drawing.Point(100, 10);
        btnOdustani.Location = new System.Drawing.Point(210, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 4);
        tlpMain.SetColumnSpan(pnlButtons, 2);

        this.Controls.Add(tlpMain);

        // Vezivanje događaja
        btnSacuvaj.Click += new EventHandler(BtnSacuvaj_Click);
    }

    private void PopulateFields()
    {
        if (_jedinica != null)
        {
            txtNaziv.Text = _jedinica.Naziv;
            txtBrojClanova.Text = _jedinica.BrojClanova.ToString();
            txtBaza.Text = _jedinica.Baza;
            // Popunjavanje tipa jedinice
            if (_jedinica is SpecijalnaInterventna)
            {
                cmbTipJedinice.SelectedItem = "Specijalna";
                // Dodati polje za tip specijalne jedinice ako je potrebno
            }
            else
            {
                cmbTipJedinice.SelectedItem = "Opšta";
            }
        }
    }

    private void BtnSacuvaj_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            if (_isUpdate)
            {
                Jedinica = _jedinica;
            }
            else
            {
                // Kreiraj novu instancu na osnovu izabranog tipa
                if (cmbTipJedinice.SelectedItem.ToString() == "Specijalna")
                {
                    Jedinica = new SpecijalnaInterventna();
                }
                else
                {
                    Jedinica = new OpstaIntervetnaJed();
                }
            }

            Jedinica.Naziv = txtNaziv.Text;
            Jedinica.BrojClanova = int.Parse(txtBrojClanova.Text);
            Jedinica.Baza = txtBaza.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            this.DialogResult = DialogResult.None; // Spriječava zatvaranje forme
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtNaziv.Text) || string.IsNullOrWhiteSpace(txtBaza.Text))
        {
            MessageBox.Show("Molimo popunite sva obavezna polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        int brojClanova;
        if (!int.TryParse(txtBrojClanova.Text, out brojClanova))
        {
            MessageBox.Show("Broj članova mora biti numerička vrednost.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}