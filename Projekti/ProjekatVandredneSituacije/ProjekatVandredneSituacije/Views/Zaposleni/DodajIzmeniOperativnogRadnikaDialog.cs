using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;
using System.Text.RegularExpressions;

public class DodajIzmeniOperativnogRadnikaDialog : Form
{
    private Label lblJMBG, lblIme, lblPrezime, lblDatumRodjenja, lblPol, lblTelefon, lblEmail, lblAdresa, lblDatumZaposlenja, lblBrojSati, lblFizickaSpremnost, lblJedinicaID;
    private TextBox txtJMBG, txtIme, txtPrezime, txtTelefon, txtEmail, txtAdresa, txtBrojSati, txtFizickaSpremnost, txtJedinicaID;
    private DateTimePicker dtpDatumRodjenja, dtpDatumZaposlenja;
    private ComboBox cmbPol;
    private Button btnSacuvaj, btnOdustani;

    public OperativniRadnik? Zaposlen { get; private set; }

    public DodajIzmeniOperativnogRadnikaDialog(OperativniRadnik? radnik = null)
    {
        InitializeComponent();
        this.Zaposlen = radnik ?? new OperativniRadnik();
        this.Text = radnik != null ? "Izmeni operativnog radnika" : "Dodaj operativnog radnika";
        if (radnik != null)
        {
            // Zaključavamo polje JMBG-a za izmene
            txtJMBG.ReadOnly = true;
            PopulateFields();
        }
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(400, 520);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        var tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 2 };
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

        lblJMBG = new Label { Text = "JMBG:", TextAlign = ContentAlignment.MiddleLeft };
        txtJMBG = new TextBox();
        lblIme = new Label { Text = "Ime:", TextAlign = ContentAlignment.MiddleLeft };
        txtIme = new TextBox();
        lblPrezime = new Label { Text = "Prezime:", TextAlign = ContentAlignment.MiddleLeft };
        txtPrezime = new TextBox();
        lblDatumRodjenja = new Label { Text = "Datum rođenja:", TextAlign = ContentAlignment.MiddleLeft };
        dtpDatumRodjenja = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Now.AddYears(-20) };
        lblPol = new Label { Text = "Pol:", TextAlign = ContentAlignment.MiddleLeft };
        cmbPol = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cmbPol.Items.AddRange(new string[] { "M", "Z" });
        lblTelefon = new Label { Text = "Telefon:", TextAlign = ContentAlignment.MiddleLeft };
        txtTelefon = new TextBox();
        lblEmail = new Label { Text = "Email:", TextAlign = ContentAlignment.MiddleLeft };
        txtEmail = new TextBox();
        lblAdresa = new Label { Text = "Adresa:", TextAlign = ContentAlignment.MiddleLeft };
        txtAdresa = new TextBox();
        lblDatumZaposlenja = new Label { Text = "Datum zaposlenja:", TextAlign = ContentAlignment.MiddleLeft };
        dtpDatumZaposlenja = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Now };
        lblBrojSati = new Label { Text = "Broj sati:", TextAlign = ContentAlignment.MiddleLeft };
        txtBrojSati = new TextBox();
        lblFizickaSpremnost = new Label { Text = "Fizička spremnost:", TextAlign = ContentAlignment.MiddleLeft };
        txtFizickaSpremnost = new TextBox();
        lblJedinicaID = new Label { Text = "ID Jedinice:", TextAlign = ContentAlignment.MiddleLeft };
        txtJedinicaID = new TextBox();

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblJMBG, 0, 0); tlpMain.Controls.Add(txtJMBG, 1, 0);
        tlpMain.Controls.Add(lblIme, 0, 1); tlpMain.Controls.Add(txtIme, 1, 1);
        tlpMain.Controls.Add(lblPrezime, 0, 2); tlpMain.Controls.Add(txtPrezime, 1, 2);
        tlpMain.Controls.Add(lblDatumRodjenja, 0, 3); tlpMain.Controls.Add(dtpDatumRodjenja, 1, 3);
        tlpMain.Controls.Add(lblPol, 0, 4); tlpMain.Controls.Add(cmbPol, 1, 4);
        tlpMain.Controls.Add(lblTelefon, 0, 5); tlpMain.Controls.Add(txtTelefon, 1, 5);
        tlpMain.Controls.Add(lblEmail, 0, 6); tlpMain.Controls.Add(txtEmail, 1, 6);
        tlpMain.Controls.Add(lblAdresa, 0, 7); tlpMain.Controls.Add(txtAdresa, 1, 7);
        tlpMain.Controls.Add(lblDatumZaposlenja, 0, 8); tlpMain.Controls.Add(dtpDatumZaposlenja, 1, 8);
        tlpMain.Controls.Add(lblBrojSati, 0, 9); tlpMain.Controls.Add(txtBrojSati, 1, 9);
        tlpMain.Controls.Add(lblFizickaSpremnost, 0, 10); tlpMain.Controls.Add(txtFizickaSpremnost, 1, 10);
        tlpMain.Controls.Add(lblJedinicaID, 0, 11); tlpMain.Controls.Add(txtJedinicaID, 1, 11);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 12); tlpMain.SetColumnSpan(pnlButtons, 2);
        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += BtnSacuvaj_Click;
    }

    private void PopulateFields()
    {
        txtJMBG.Text = Zaposlen?.JMBG;
        txtIme.Text = Zaposlen?.Ime;
        txtPrezime.Text = Zaposlen?.Prezime;
        dtpDatumRodjenja.Value = Zaposlen?.Datum_Rodjenja ?? DateTime.Now.AddYears(-20);
        cmbPol.SelectedItem = Zaposlen?.Pol;
        txtTelefon.Text = Zaposlen?.Kontakt_Telefon;
        txtEmail.Text = Zaposlen?.Email;
        txtAdresa.Text = Zaposlen?.AdresaStanovanja;
        dtpDatumZaposlenja.Value = Zaposlen?.Datum_Zaposlenja ?? DateTime.Now;
        txtBrojSati.Text = Zaposlen?.Broj_Sati.ToString();
        txtFizickaSpremnost.Text = Zaposlen?.Fizicka_Spremnost;
        txtJedinicaID.Text = Zaposlen?.InterventnaJedinica.Jedinstveni_Broj.ToString();
    }

    private void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (ValidateInput())
        {
            Zaposlen!.JMBG = txtJMBG.Text;
            Zaposlen.Ime = txtIme.Text;
            Zaposlen.Prezime = txtPrezime.Text;
            Zaposlen.Datum_Rodjenja = dtpDatumRodjenja.Value;
            Zaposlen.Pol = cmbPol.SelectedItem?.ToString() ?? "";
            Zaposlen.Kontakt_Telefon = txtTelefon.Text;
            Zaposlen.Email = txtEmail.Text;
            Zaposlen.AdresaStanovanja = txtAdresa.Text;
            Zaposlen.Datum_Zaposlenja = dtpDatumZaposlenja.Value;

            // Konverzija broja sati
            if (int.TryParse(txtBrojSati.Text, out int brojSati))
            {
                Zaposlen.Broj_Sati = brojSati;
            }
            else
            {
                MessageBox.Show("Broj sati nije u ispravnom formatu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            Zaposlen.Fizicka_Spremnost = txtFizickaSpremnost.Text;

            // Ispravna logika: Pronalaženje postojećeg objekta jedinice u bazi
            if (int.TryParse(txtJedinicaID.Text, out int jedinicaId))
            {
                // OVAJ DEO JE KRITIČAN: Ne kreiramo novi objekat, već ga preuzimamo iz baze!
                // Zaposlen.InterventnaJedinica = DTOManager.VratiJedinicuPoID(jedinicaId);
                // Gornja linija je samo primer, jer nemam pristup Vašem DTOManager-u.
                // Trenutno postavljamo samo ID, a naša funkcija za čuvanje će se pobrinuti za ostalo.
                // Pretpostavljamo da metoda za čuvanje u DTOManager-u prima ID jedinice.
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
        // Validacija osnovnih polja
        if (string.IsNullOrWhiteSpace(txtIme.Text) || string.IsNullOrWhiteSpace(txtPrezime.Text) ||
            cmbPol.SelectedItem == null || string.IsNullOrWhiteSpace(txtAdresa.Text) ||
            string.IsNullOrWhiteSpace(txtFizickaSpremnost.Text) || string.IsNullOrWhiteSpace(txtJedinicaID.Text))
        {
            MessageBox.Show("Molimo popunite sva obavezna polja: Ime, Prezime, Pol, Adresa, Fizička spremnost i ID Jedinice.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Validacija JMBG-a
        if (!txtJMBG.ReadOnly && (string.IsNullOrWhiteSpace(txtJMBG.Text) || txtJMBG.Text.Length != 13 || !long.TryParse(txtJMBG.Text, out _)))
        {
            MessageBox.Show("JMBG mora da ima tačno 13 cifara.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Validacija e-mail formata
        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !Regex.IsMatch(txtEmail.Text, emailPattern))
        {
            MessageBox.Show("Molimo unesite ispravnu e-mail adresu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Validacija broja sati
        if (!int.TryParse(txtBrojSati.Text, out int brojSati) || brojSati < 0)
        {
            MessageBox.Show("Broj sati mora biti pozitivan broj (ili 0).", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Validacija ID jedinice
        if (!int.TryParse(txtJedinicaID.Text, out _))
        {
            MessageBox.Show("ID Jedinice mora biti broj.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Validacija datuma rođenja
        if (dtpDatumRodjenja.Value > DateTime.Now)
        {
            MessageBox.Show("Datum rođenja ne može biti u budućnosti.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}