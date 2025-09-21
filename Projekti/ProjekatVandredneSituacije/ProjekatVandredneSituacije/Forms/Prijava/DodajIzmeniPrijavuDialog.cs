using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVanredneSituacije.Entiteti;
using ProjekatVanredneSituacije.DTOs;
using System.Collections.Generic;
using VanrednaSituacijaLibrary;

public class DodajIzmeniPrijavuDialog : Form
{
    private Label lblDatum, lblIdVanredne, lblTip, lblIme, lblKontakt, lblLokacija, lblOpis, lblJMBGDispecer, lblPrioritet;
    private TextBox txtTip, txtIme, txtKontakt, txtLokacija, txtOpis, txtJMBGDispecer;
    private DateTimePicker dtpDatum;
    private ComboBox cmbIdVanredne;
    private NumericUpDown numPrioritet;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;

    public PrijavaAddView? Prijava { get; private set; }

    public DodajIzmeniPrijavuDialog(PrijavaAddView? prijava = null)
    {
        InitializeComponent();
        this.Prijava = prijava ?? new PrijavaAddView();
        this.Text = prijava != null ? "Izmeni prijavu" : "Dodaj novu prijavu";

        LoadComboBoxes(); 

        if (prijava != null)
        {
            PopulateFields();
        }
    }

    private async void LoadComboBoxes()
    {
        try
        {
            var vanredneSituacije = await DTOManager.VratiVanredneSituacije();
            cmbIdVanredne.DataSource = vanredneSituacije;
            cmbIdVanredne.DisplayMember = "NazivIliOpis";
            cmbIdVanredne.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška pri učitavanju vanrednih situacija: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(400, 500);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 2 };
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

        lblDatum = new Label { Text = "Datum i vreme:", TextAlign = ContentAlignment.MiddleLeft };
        dtpDatum = new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd.MM.yyyy HH:mm:ss" };
        lblIdVanredne = new Label { Text = "Vanredna situacija:", TextAlign = ContentAlignment.MiddleLeft };
        cmbIdVanredne = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList }; // Promenjeno
        lblTip = new Label { Text = "Tip:", TextAlign = ContentAlignment.MiddleLeft };
        txtTip = new TextBox();
        lblIme = new Label { Text = "Ime prijavioca:", TextAlign = ContentAlignment.MiddleLeft };
        txtIme = new TextBox();
        lblKontakt = new Label { Text = "Kontakt:", TextAlign = ContentAlignment.MiddleLeft };
        txtKontakt = new TextBox();
        lblLokacija = new Label { Text = "Lokacija:", TextAlign = ContentAlignment.MiddleLeft };
        txtLokacija = new TextBox();
        lblOpis = new Label { Text = "Opis:", TextAlign = ContentAlignment.MiddleLeft };
        txtOpis = new TextBox();
        txtOpis.Multiline = true;
        txtOpis.Height = 80;
        lblJMBGDispecer = new Label { Text = "JMBG Dispečera:", TextAlign = ContentAlignment.MiddleLeft };
        txtJMBGDispecer = new TextBox();
        lblPrioritet = new Label { Text = "Prioritet (1-5):", TextAlign = ContentAlignment.MiddleLeft };
        numPrioritet = new NumericUpDown { Minimum = 1, Maximum = 5 };

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblDatum, 0, 0); tlpMain.Controls.Add(dtpDatum, 1, 0);
        tlpMain.Controls.Add(lblIdVanredne, 0, 1); tlpMain.Controls.Add(cmbIdVanredne, 1, 1); // Promenjeno
        tlpMain.Controls.Add(lblTip, 0, 2); tlpMain.Controls.Add(txtTip, 1, 2);
        tlpMain.Controls.Add(lblIme, 0, 3); tlpMain.Controls.Add(txtIme, 1, 3);
        tlpMain.Controls.Add(lblKontakt, 0, 4); tlpMain.Controls.Add(txtKontakt, 1, 4);
        tlpMain.Controls.Add(lblLokacija, 0, 5); tlpMain.Controls.Add(txtLokacija, 1, 5);
        tlpMain.Controls.Add(lblOpis, 0, 6); tlpMain.Controls.Add(txtOpis, 1, 6);
        tlpMain.Controls.Add(lblJMBGDispecer, 0, 7); tlpMain.Controls.Add(txtJMBGDispecer, 1, 7);
        tlpMain.Controls.Add(lblPrioritet, 0, 8); tlpMain.Controls.Add(numPrioritet, 1, 8);

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
        dtpDatum.Value = Prijava?.Datum_I_Vreme ?? DateTime.Now;
        if (Prijava?.Id_VanrednaSituacija != null)
        {
            cmbIdVanredne.SelectedValue = Prijava.Id_VanrednaSituacija;
        }
        txtTip.Text = Prijava?.Tip;
        txtIme.Text = Prijava?.Ime_Prijavioca;
        txtKontakt.Text = Prijava?.Kontakt;
        txtLokacija.Text = Prijava?.Lokacija;
        txtOpis.Text = Prijava?.Opis;
        txtJMBGDispecer.Text = Prijava?.JMBG_Dispecer;
        numPrioritet.Value = Prijava?.Prioritet ?? 1;
    }

    private void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (ValidateInput())
        {
            Prijava!.Datum_I_Vreme = dtpDatum.Value;
            Prijava.Id_VanrednaSituacija = (int?)cmbIdVanredne.SelectedValue; 
            Prijava.Tip = txtTip.Text;
            Prijava.Ime_Prijavioca = txtIme.Text;
            Prijava.Kontakt = txtKontakt.Text;
            Prijava.Lokacija = txtLokacija.Text;
            Prijava.Opis = txtOpis.Text;
            Prijava.JMBG_Dispecer = txtJMBGDispecer.Text;
            Prijava.Prioritet = (int)numPrioritet.Value;

            this.DialogResult = DialogResult.OK;
        }
        else
        {
            this.DialogResult = DialogResult.None;
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtTip.Text) || string.IsNullOrWhiteSpace(txtIme.Text) ||
            string.IsNullOrWhiteSpace(txtKontakt.Text) || string.IsNullOrWhiteSpace(txtLokacija.Text) ||
            string.IsNullOrWhiteSpace(txtOpis.Text) || string.IsNullOrWhiteSpace(txtJMBGDispecer.Text) ||
            cmbIdVanredne.SelectedValue == null)
        {
            MessageBox.Show("Molimo popunite sva polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}