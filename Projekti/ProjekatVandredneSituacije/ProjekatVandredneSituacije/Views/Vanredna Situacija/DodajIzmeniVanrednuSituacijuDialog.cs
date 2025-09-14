using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniVanrednuSituacijuDialog : Form
{
    private Label lblDatumOd, lblDatumDo, lblTip, lblBrojUgrozenih, lblNivoOpasnosti, lblOpstina, lblLokacija, lblOpis;
    private TextBox txtTip, txtBrojUgrozenih, txtOpstina, txtLokacija, txtOpis;
    private ComboBox cmbNivoOpasnosti;
    private DateTimePicker dtpDatumOd, dtpDatumDo;
    private CheckBox chbZavrsena;
    private Button btnSacuvaj, btnOdustani;

    public VanrednaSituacija? Situacija { get; private set; }

    public DodajIzmeniVanrednuSituacijuDialog(VanrednaSituacija? situacija = null)
    {
        InitializeComponent();
        this.Situacija = situacija ?? new VanrednaSituacija();
        this.Text = situacija != null ? "Izmeni vanrednu situaciju" : "Dodaj novu vanrednu situaciju";

        if (situacija != null)
        {
            PopulateFields();
        }

        chbZavrsena.CheckedChanged += ChbZavrsena_CheckedChanged;
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(400, 500);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        var tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 2 };
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

        lblDatumOd = new Label { Text = "Datum Od:", TextAlign = ContentAlignment.MiddleLeft };
        dtpDatumOd = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Now };
        lblDatumDo = new Label { Text = "Datum Do:", TextAlign = ContentAlignment.MiddleLeft };
        dtpDatumDo = new DateTimePicker { Format = DateTimePickerFormat.Short, Value = DateTime.Now };
        chbZavrsena = new CheckBox { Text = "Situacija završena" };

        lblTip = new Label { Text = "Tip:", TextAlign = ContentAlignment.MiddleLeft };
        txtTip = new TextBox();
        lblBrojUgrozenih = new Label { Text = "Broj ugroženih osoba:", TextAlign = ContentAlignment.MiddleLeft };
        txtBrojUgrozenih = new TextBox();
        lblNivoOpasnosti = new Label { Text = "Nivo opasnosti:", TextAlign = ContentAlignment.MiddleLeft };
        cmbNivoOpasnosti = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cmbNivoOpasnosti.Items.AddRange(Enum.GetNames(typeof(NivoOpasnosti)));
        lblOpstina = new Label { Text = "Opština:", TextAlign = ContentAlignment.MiddleLeft };
        txtOpstina = new TextBox();
        lblLokacija = new Label { Text = "Lokacija:", TextAlign = ContentAlignment.MiddleLeft };
        txtLokacija = new TextBox();
        lblOpis = new Label { Text = "Opis:", TextAlign = ContentAlignment.MiddleLeft };
        txtOpis = new TextBox { Multiline = true, Height = 80 };

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblDatumOd, 0, 0); tlpMain.Controls.Add(dtpDatumOd, 1, 0);
        tlpMain.Controls.Add(lblDatumDo, 0, 1); tlpMain.Controls.Add(dtpDatumDo, 1, 1);
        tlpMain.Controls.Add(chbZavrsena, 0, 2); tlpMain.SetColumnSpan(chbZavrsena, 2);
        tlpMain.Controls.Add(lblTip, 0, 3); tlpMain.Controls.Add(txtTip, 1, 3);
        tlpMain.Controls.Add(lblBrojUgrozenih, 0, 4); tlpMain.Controls.Add(txtBrojUgrozenih, 1, 4);
        tlpMain.Controls.Add(lblNivoOpasnosti, 0, 5); tlpMain.Controls.Add(cmbNivoOpasnosti, 1, 5);
        tlpMain.Controls.Add(lblOpstina, 0, 6); tlpMain.Controls.Add(txtOpstina, 1, 6);
        tlpMain.Controls.Add(lblLokacija, 0, 7); tlpMain.Controls.Add(txtLokacija, 1, 7);
        tlpMain.Controls.Add(lblOpis, 0, 8); tlpMain.Controls.Add(txtOpis, 1, 8);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 9); tlpMain.SetColumnSpan(pnlButtons, 2);
        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += BtnSacuvaj_Click;
    }

    private void PopulateFields()
    {
        if (Situacija != null)
        {
            dtpDatumOd.Value = Situacija.Datum_Od;

            if (Situacija.Datum_Do != DateTime.MinValue)
            {
                dtpDatumDo.Value = Situacija.Datum_Do;
                chbZavrsena.Checked = true;
            }
            else
            {
                dtpDatumDo.Value = DateTime.Now;
                chbZavrsena.Checked = false;
            }
            dtpDatumDo.Enabled = chbZavrsena.Checked;

            txtTip.Text = Situacija.Tip;
            txtBrojUgrozenih.Text = Situacija.Broj_Ugrozenih_Osoba.ToString();
            cmbNivoOpasnosti.SelectedItem = Situacija.Nivo_Opasnosti.ToString();
            txtOpstina.Text = Situacija.Opstina;
            txtLokacija.Text = Situacija.Lokacija;
            txtOpis.Text = Situacija.Opis;
        }
    }

    private void ChbZavrsena_CheckedChanged(object? sender, EventArgs e)
    {
        dtpDatumDo.Enabled = chbZavrsena.Checked;
    }

    private void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (ValidateInput())
        {
            Situacija!.Datum_Od = dtpDatumOd.Value;
            Situacija.Datum_Do = chbZavrsena.Checked ? dtpDatumDo.Value : DateTime.MinValue;
            Situacija.Tip = txtTip.Text;
            Situacija.Broj_Ugrozenih_Osoba = int.Parse(txtBrojUgrozenih.Text);
            Situacija.Nivo_Opasnosti = (NivoOpasnosti)Enum.Parse(typeof(NivoOpasnosti), cmbNivoOpasnosti.SelectedItem!.ToString()!);
            Situacija.Opstina = txtOpstina.Text;
            Situacija.Lokacija = txtLokacija.Text;
            Situacija.Opis = txtOpis.Text;

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
        if (string.IsNullOrWhiteSpace(txtTip.Text) || !int.TryParse(txtBrojUgrozenih.Text, out _) || cmbNivoOpasnosti.SelectedItem == null ||
            string.IsNullOrWhiteSpace(txtOpstina.Text) || string.IsNullOrWhiteSpace(txtLokacija.Text) || string.IsNullOrWhiteSpace(txtOpis.Text))
        {
            MessageBox.Show("Molimo popunite sva polja ispravno. Broj ugroženih osoba mora biti broj.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}