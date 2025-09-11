using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;
using System.Collections.Generic;

public class DodajIzmeniZaposlenogDialog : Form
{
    private Zaposlen _zaposlen;
    private bool _isUpdate = false;

    private Label lblJMBG, lblIme, lblPrezime, lblDatumRodjenja, lblPol, lblTip, lblDatumZaposlenja, lblTelefon, lblEmail, lblAdresaStanovanja;
    private TextBox txtJMBG, txtIme, txtPrezime, txtTelefon, txtEmail, txtAdresaStanovanja;
    private ComboBox cmbPol, cmbTip;
    private DateTimePicker dtpDatumRodjenja, dtpDatumZaposlenja; // Promenjeno u DateTimePicker
    private Button btnSacuvaj, btnOdustani, btnSertifikati, btnSpecijalizacije;
    private TableLayoutPanel tlpMain;

    private Label lblBrojTimova, lblBrojSati, lblFizickaSpremnost;
    private TextBox txtBrojTimova, txtBrojSati, txtFizickaSpremnost;

    public Zaposlen Zaposlen { get; private set; }

    public DodajIzmeniZaposlenogDialog()
    {
        InitializeComponent();
        this.Text = "Dodaj novog zaposlenog";
        Zaposlen = new Zaposlen();
    }

    public DodajIzmeniZaposlenogDialog(Zaposlen zaposlen)
    {
        InitializeComponent();
        this.Text = "Izmeni zaposlenog";
        _zaposlen = zaposlen;
        _isUpdate = true;
        PopulateFields();
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(450, 600);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        tlpMain = new TableLayoutPanel();
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Padding = new Padding(10);
        tlpMain.ColumnCount = 2;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

        lblJMBG = new Label { Text = "JMBG:", TextAlign = ContentAlignment.MiddleLeft };
        txtJMBG = new TextBox();
        lblIme = new Label { Text = "Ime:", TextAlign = ContentAlignment.MiddleLeft };
        txtIme = new TextBox();
        lblPrezime = new Label { Text = "Prezime:", TextAlign = ContentAlignment.MiddleLeft };
        txtPrezime = new TextBox();
        lblDatumRodjenja = new Label { Text = "Datum rođenja:", TextAlign = ContentAlignment.MiddleLeft };
        dtpDatumRodjenja = new DateTimePicker { Format = DateTimePickerFormat.Short };
        lblPol = new Label { Text = "Pol:", TextAlign = ContentAlignment.MiddleLeft };
        cmbPol = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cmbPol.Items.AddRange(new string[] { "M", "Z" });
        lblTip = new Label { Text = "Tip pozicije:", TextAlign = ContentAlignment.MiddleLeft };
        cmbTip = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cmbTip.Items.AddRange(new string[] { "Analiticar", "Koordinator", "OperativniRadnik" });
        cmbTip.SelectedIndexChanged += new EventHandler(CmbTip_SelectedIndexChanged);
        lblTelefon = new Label { Text = "Kontakt Telefon:", TextAlign = ContentAlignment.MiddleLeft };
        txtTelefon = new TextBox();
        lblEmail = new Label { Text = "Email:", TextAlign = ContentAlignment.MiddleLeft };
        txtEmail = new TextBox();
        lblAdresaStanovanja = new Label { Text = "Adresa Stanovanja:", TextAlign = ContentAlignment.MiddleLeft };
        txtAdresaStanovanja = new TextBox();
        lblDatumZaposlenja = new Label { Text = "Datum Zaposlenja:", TextAlign = ContentAlignment.MiddleLeft };
        dtpDatumZaposlenja = new DateTimePicker { Format = DateTimePickerFormat.Short }; // Promenjeno u DateTimePicker

        lblBrojTimova = new Label { Text = "Broj timova:", TextAlign = ContentAlignment.MiddleLeft, Visible = false };
        txtBrojTimova = new TextBox { Visible = false };
        btnSpecijalizacije = new Button { Text = "Specijalizacije", Visible = false };
        btnSpecijalizacije.Click += new EventHandler(BtnSpecijalizacije_Click);

        lblBrojSati = new Label { Text = "Broj sati:", TextAlign = ContentAlignment.MiddleLeft, Visible = false };
        txtBrojSati = new TextBox { Visible = false };
        lblFizickaSpremnost = new Label { Text = "Fizička spremnost:", TextAlign = ContentAlignment.MiddleLeft, Visible = false };
        txtFizickaSpremnost = new TextBox { Visible = false };
        btnSertifikati = new Button { Text = "Sertifikati", Visible = false };
        btnSertifikati.Click += new EventHandler(BtnSertifikati_Click);

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblJMBG, 0, 0); tlpMain.Controls.Add(txtJMBG, 1, 0);
        tlpMain.Controls.Add(lblIme, 0, 1); tlpMain.Controls.Add(txtIme, 1, 1);
        tlpMain.Controls.Add(lblPrezime, 0, 2); tlpMain.Controls.Add(txtPrezime, 1, 2);
        tlpMain.Controls.Add(lblDatumRodjenja, 0, 3); tlpMain.Controls.Add(dtpDatumRodjenja, 1, 3);
        tlpMain.Controls.Add(lblPol, 0, 4); tlpMain.Controls.Add(cmbPol, 1, 4);
        tlpMain.Controls.Add(lblTelefon, 0, 5); tlpMain.Controls.Add(txtTelefon, 1, 5);
        tlpMain.Controls.Add(lblEmail, 0, 6); tlpMain.Controls.Add(txtEmail, 1, 6);
        tlpMain.Controls.Add(lblAdresaStanovanja, 0, 7); tlpMain.Controls.Add(txtAdresaStanovanja, 1, 7);
        tlpMain.Controls.Add(lblDatumZaposlenja, 0, 8); tlpMain.Controls.Add(dtpDatumZaposlenja, 1, 8); // Dodato u tlpMain
        tlpMain.Controls.Add(lblTip, 0, 9); tlpMain.Controls.Add(cmbTip, 1, 9);

        tlpMain.Controls.Add(lblBrojTimova, 0, 10); tlpMain.Controls.Add(txtBrojTimova, 1, 10);
        tlpMain.Controls.Add(btnSpecijalizacije, 0, 11); tlpMain.SetColumnSpan(btnSpecijalizacije, 2);
        tlpMain.Controls.Add(lblBrojSati, 0, 12); tlpMain.Controls.Add(txtBrojSati, 1, 12);
        tlpMain.Controls.Add(lblFizickaSpremnost, 0, 13); tlpMain.Controls.Add(txtFizickaSpremnost, 1, 13);
        tlpMain.Controls.Add(btnSertifikati, 0, 14); tlpMain.SetColumnSpan(btnSertifikati, 2);

        Panel pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(100, 10);
        btnOdustani.Location = new Point(210, 10);
        tlpMain.Controls.Add(pnlButtons, 0, 15);
        tlpMain.SetColumnSpan(pnlButtons, 2);

        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += new EventHandler(BtnSacuvaj_Click);
    }

    private void CmbTip_SelectedIndexChanged(object sender, EventArgs e)
    {
        HideAllDerivedFields();

        string selectedTip = cmbTip.SelectedItem.ToString();
        if (selectedTip == "Koordinator")
        {
            lblBrojTimova.Visible = true;
            txtBrojTimova.Visible = true;
            btnSpecijalizacije.Visible = true;
        }
        else if (selectedTip == "OperativniRadnik")
        {
            lblBrojSati.Visible = true;
            txtBrojSati.Visible = true;
            lblFizickaSpremnost.Visible = true;
            txtFizickaSpremnost.Visible = true;
            btnSertifikati.Visible = true;
        }
    }

    private void HideAllDerivedFields()
    {
        lblBrojTimova.Visible = false;
        txtBrojTimova.Visible = false;
        btnSpecijalizacije.Visible = false;
        lblBrojSati.Visible = false;
        txtBrojSati.Visible = false;
        lblFizickaSpremnost.Visible = false;
        txtFizickaSpremnost.Visible = false;
        btnSertifikati.Visible = false;
    }

    private void PopulateFields()
    {
        if (_zaposlen != null)
        {
            txtJMBG.Text = _zaposlen.JMBG.ToString();
            txtIme.Text = _zaposlen.Ime;
            txtPrezime.Text = _zaposlen.Prezime;
            dtpDatumRodjenja.Value = _zaposlen.Datum_Rodjenja;
            cmbPol.SelectedItem = _zaposlen.Pol;
            txtTelefon.Text = _zaposlen.Kontakt_Telefon;
            txtEmail.Text = _zaposlen.Email;
            txtAdresaStanovanja.Text = _zaposlen.AdresaStanovanja;
            dtpDatumZaposlenja.Value = _zaposlen.Datum_Zaposlenja; // Ažurirano

            if (_zaposlen is Analiticar)
            {
                cmbTip.SelectedItem = "Analiticar";
            }
            else if (_zaposlen is Kordinator)
            {
                cmbTip.SelectedItem = "Koordinator";
                Kordinator k = _zaposlen as Kordinator;
                txtBrojTimova.Text = k.BrojTimova.ToString();
            }
            else if (_zaposlen is OperativniRadnik)
            {
                cmbTip.SelectedItem = "OperativniRadnik";
                OperativniRadnik o = _zaposlen as OperativniRadnik;
                txtBrojSati.Text = o.Broj_Sati.ToString();
                txtFizickaSpremnost.Text = o.Fizicka_Spremnost;
            }
            CmbTip_SelectedIndexChanged(null, null);
        }
    }

    private void BtnSacuvaj_Click(object sender, EventArgs e)
    {
        if (ValidateInput())
        {
            if (!_isUpdate)
            {
                // Kreiranje novog objekta u zavisnosti od izabranog tipa
                string selectedTip = cmbTip.SelectedItem.ToString();
                if (selectedTip == "Analiticar") Zaposlen = new Analiticar();
                else if (selectedTip == "Koordinator") Zaposlen = new Kordinator();
                else if (selectedTip == "OperativniRadnik") Zaposlen = new OperativniRadnik();
                else Zaposlen = new Zaposlen();
            }

            Zaposlen.JMBG = long.Parse(txtJMBG.Text);
            Zaposlen.Ime = txtIme.Text;
            Zaposlen.Prezime = txtPrezime.Text;
            Zaposlen.Datum_Rodjenja = dtpDatumRodjenja.Value;
            Zaposlen.Pol = cmbPol.SelectedItem.ToString();
            Zaposlen.Tip = cmbTip.SelectedItem.ToString();
            Zaposlen.Kontakt_Telefon = txtTelefon.Text;
            Zaposlen.Email = txtEmail.Text;
            Zaposlen.AdresaStanovanja = txtAdresaStanovanja.Text;
            Zaposlen.Datum_Zaposlenja = dtpDatumZaposlenja.Value; // Ažurirano

            if (Zaposlen is Kordinator k)
            {
                if (int.TryParse(txtBrojTimova.Text, out int brojTimova))
                {
                    k.BrojTimova = brojTimova;
                }
            }
            else if (Zaposlen is OperativniRadnik o)
            {
                if (int.TryParse(txtBrojSati.Text, out int brojSati))
                {
                    o.Broj_Sati = brojSati;
                }
                o.Fizicka_Spremnost = txtFizickaSpremnost.Text;
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
        long jmbg;
        if (!long.TryParse(txtJMBG.Text, out jmbg) || txtJMBG.Text.Length != 13)
        {
            MessageBox.Show("JMBG mora biti numerička vrednost sa tačno 13 cifara.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtIme.Text) || string.IsNullOrWhiteSpace(txtPrezime.Text) ||
            cmbPol.SelectedItem == null || cmbTip.SelectedItem == null ||
            string.IsNullOrWhiteSpace(txtTelefon.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
            string.IsNullOrWhiteSpace(txtAdresaStanovanja.Text))
        {
            MessageBox.Show("Molimo popunite sva obavezna polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        string selectedTip = cmbTip.SelectedItem.ToString();
        if (selectedTip == "Koordinator")
        {
            if (!int.TryParse(txtBrojTimova.Text, out _))
            {
                MessageBox.Show("Broj timova mora biti numerička vrednost.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        else if (selectedTip == "OperativniRadnik")
        {
            if (!int.TryParse(txtBrojSati.Text, out _))
            {
                MessageBox.Show("Broj sati mora biti numerička vrednost.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        return true;
    }

    private void BtnSertifikati_Click(object sender, EventArgs e)
    {
        // Ova provera je ispravna, jer se dugme ne prikazuje dok se tip ne odabere
        if (_zaposlen is OperativniRadnik oradnik)
        {
            var sertifikatDialog = new DodajIzmeniSertifikatDialog(oradnik.Sertifikats);
            sertifikatDialog.ShowDialog();
        }
        else
        {
            MessageBox.Show("Niste izabrali Operativnog radnika. Ne možete dodati sertifikate.");
        }
    }

    private void BtnSpecijalizacije_Click(object sender, EventArgs e)
    {
        if (_zaposlen is Kordinator kordinator)
        {
            var specijalizacijaDialog = new DodajIzmeniSpecijalizacijaDialog(kordinator.Specijalizacija);
            specijalizacijaDialog.ShowDialog();
        }
        else if (cmbTip.SelectedItem.ToString() == "Koordinator" && !_isUpdate)
        {
            // Ako je novi zaposleni Koordinator, kreirajmo objekat pre pozivanja dijaloga
            _zaposlen = new Kordinator();
            var specijalizacijaDialog = new DodajIzmeniSpecijalizacijaDialog((_zaposlen as Kordinator).Specijalizacija);
            specijalizacijaDialog.ShowDialog();
        }
        else
        {
            MessageBox.Show("Niste izabrali Koordinatora. Ne možete dodati specijalizacije.");
        }
    }
}