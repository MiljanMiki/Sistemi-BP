using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVanredneSituacije.Entiteti;
using ProjekatVanredneSituacije.DTOs;
using System.Collections.Generic;
using System.Linq;
using VanrednaSituacijaLibrary;

public class DodajIzmeniVoziloDialog : Form
{
    private Label lblRegistarskaOznaka, lblProizvodjac, lblStatus, lblLokacija, lblNamena;
    private Label lblJedinica, lblPojedinac, lblDatumOd, lblDatumDo;

    private TextBox txtRegistarskaOznaka, txtProizvodjac, txtLokacija;
    private ComboBox cmbStatus, cmbNamena, cmbJedinica, cmbPojedinac;
    private DateTimePicker dtpDatumOd, dtpDatumDo;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;

    public VoziloView? VoziloBasic { get; private set; }
    private readonly Type _vehicleType;

    public DodajIzmeniVoziloDialog(VoziloView? vozilo = null)
    {
        InitializeComponent();
        this.Text = vozilo != null ? "Izmeni vozilo" : "Dodaj novo vozilo";
        _vehicleType = vozilo?.GetType() ?? typeof(VoziloBasic);

        LoadComboBoxes();

        if (vozilo != null)
        {
            VoziloBasic = vozilo;
            PopulateFields();
        }
         
        if (_vehicleType == typeof(SpecijalnaVozilaBasic))
        {
            lblNamena.Visible = true;
            cmbNamena.Visible = true;
            this.ClientSize = new Size(450, 450);  
        }
    }

    private async void LoadComboBoxes()
    {
        try
        { 
            cmbStatus.Items.AddRange(Enum.GetNames(typeof(StatusVozila)));
            cmbNamena.Items.AddRange(Enum.GetNames(typeof(Namena)));
             
            var jedinice = await DTOManager.VratiSveJedinice();
            cmbJedinica.DataSource = jedinice;
            cmbJedinica.DisplayMember = "Naziv";
            cmbJedinica.ValueMember = "Id";
             
            var radnici = await DTOManager.VratiOperativneRadnike();
            cmbPojedinac.DataSource = radnici;
            cmbPojedinac.DisplayMember = "ImePrezime"; 
            cmbPojedinac.ValueMember = "JMBG";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška pri učitavanju podataka: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(450, 390); 
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 2, RowCount = 9 };
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

        for (int i = 0; i < tlpMain.RowCount - 1; i++)
        {
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        }
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

        lblRegistarskaOznaka = new Label { Text = "Registarska Oznaka:", TextAlign = ContentAlignment.MiddleLeft };
        txtRegistarskaOznaka = new TextBox();
        lblProizvodjac = new Label { Text = "Proizvođač:", TextAlign = ContentAlignment.MiddleLeft };
        txtProizvodjac = new TextBox();
        lblStatus = new Label { Text = "Status:", TextAlign = ContentAlignment.MiddleLeft };
        cmbStatus = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        lblLokacija = new Label { Text = "Lokacija:", TextAlign = ContentAlignment.MiddleLeft };
        txtLokacija = new TextBox();
        lblNamena = new Label { Text = "Namena:", TextAlign = ContentAlignment.MiddleLeft, Visible = false };
        cmbNamena = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Visible = false };

        // Nova polja za dodeljivanje
        lblJedinica = new Label { Text = "Dodeljeno jedinici:", TextAlign = ContentAlignment.MiddleLeft };
        cmbJedinica = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        lblPojedinac = new Label { Text = "Dodeljeno pojedincu:", TextAlign = ContentAlignment.MiddleLeft };
        cmbPojedinac = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        lblDatumOd = new Label { Text = "Datum od:", TextAlign = ContentAlignment.MiddleLeft };
        dtpDatumOd = new DateTimePicker { Format = DateTimePickerFormat.Short };
        lblDatumDo = new Label { Text = "Datum do:", TextAlign = ContentAlignment.MiddleLeft };
        dtpDatumDo = new DateTimePicker { Format = DateTimePickerFormat.Short };

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        // Dodavanje kontrola u TableLayoutPanel
        tlpMain.Controls.Add(lblRegistarskaOznaka, 0, 0); tlpMain.Controls.Add(txtRegistarskaOznaka, 1, 0);
        tlpMain.Controls.Add(lblProizvodjac, 0, 1); tlpMain.Controls.Add(txtProizvodjac, 1, 1);
        tlpMain.Controls.Add(lblStatus, 0, 2); tlpMain.Controls.Add(cmbStatus, 1, 2);
        tlpMain.Controls.Add(lblLokacija, 0, 3); tlpMain.Controls.Add(txtLokacija, 1, 3);
        tlpMain.Controls.Add(lblNamena, 0, 4); tlpMain.Controls.Add(cmbNamena, 1, 4);

        tlpMain.Controls.Add(lblJedinica, 0, 5); tlpMain.Controls.Add(cmbJedinica, 1, 5);
        tlpMain.Controls.Add(lblPojedinac, 0, 6); tlpMain.Controls.Add(cmbPojedinac, 1, 6);
        tlpMain.Controls.Add(lblDatumOd, 0, 7); tlpMain.Controls.Add(dtpDatumOd, 1, 7);
        tlpMain.Controls.Add(lblDatumDo, 0, 8); tlpMain.Controls.Add(dtpDatumDo, 1, 8);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 9); tlpMain.SetColumnSpan(pnlButtons, 2);
        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += BtnSacuvaj_Click;
    }

    protected void PopulateFields()
    {
        if (VoziloBasic != null)
        {
            txtRegistarskaOznaka.Text = VoziloBasic.Registarska_Oznaka;
            txtProizvodjac.Text = VoziloBasic.Proizvodjac;
            cmbStatus.SelectedItem = VoziloBasic.Status.ToString();
            txtLokacija.Text = VoziloBasic.Lokacija;
            if (VoziloBasic is SpecijalnaVozilaView spec)
            {
                cmbNamena.SelectedItem = spec.Namena.ToString();
            }

            // Popunjavanje polja za dodeljivanje
            if (VoziloBasic.Dodeljuje != null && VoziloBasic.Dodeljuje.Count > 0)
            {
                var dodeljivanje = VoziloBasic.Dodeljuje[0];
                cmbJedinica.SelectedValue = dodeljivanje.Jedinica.Naziv;
                cmbPojedinac.SelectedValue = dodeljivanje.Radnik.Ime;
                dtpDatumOd.Value = dodeljivanje.DatumOd;
                dtpDatumDo.Value = dodeljivanje.DatumDo;
            }
        }
    }

    protected async void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (ValidateInput())
        {
            try
            {
                VoziloBasic = VoziloView();
                 
                if (cmbJedinica.SelectedValue != null && cmbPojedinac.SelectedValue != null)
                {
                    VoziloBasic.Dodeljuje.Clear();
                    VoziloBasic.Dodeljuje.Add(new DodeljujeSePregled
                    {
                        RegVozilo = VoziloBasic.Registarska_Oznaka,
                        idJedinica = (int)cmbJedinica.SelectedValue,
                        JMBGPojedinac = (string)cmbPojedinac.SelectedValue,
                        datumod = dtpDatumOd.Value,
                        datumDo = dtpDatumDo.Value
                    });
                }
                else
                {
                    MessageBox.Show("Morate odabrati i jedinicu i pojedinca za dodelu vozila.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                if (_vehicleType == typeof(SpecijalnaVozilaView))
                {
                    await DTOManager.DodajSpecijalnoVozilo(VoziloBasic as SpecijalnaVozilaView);
                }
                else if (_vehicleType == typeof(SanitetskaBasic))
                {
                    await DTOManager.DodajSanitetskaVozilo(VoziloBasic as SanitetskaView);
                }
                else if (_vehicleType == typeof(DzipoviBasic))
                {
                    await DTOManager.DodajDzip(VoziloBasic as DzipoviView);
                }
                else if (_vehicleType == typeof(KamioniBasic))
                {
                    await DTOManager.DodajKamion(VoziloBasic as KamioniView);
                }
                else
                { 
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom čuvanja vozila: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
        else
        {
            this.DialogResult = DialogResult.None;
        }
    }

    private VoziloBasic CreateVoziloBasic()
    {
        if (_vehicleType == typeof(SpecijalnaVozilaBasic))
        {
            return new SpecijalnaVozilaBasic
            (
                txtRegistarskaOznaka.Text,
                txtProizvodjac.Text,
                (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!),
                txtLokacija.Text,
                (Namena)Enum.Parse(typeof(Namena), cmbNamena.SelectedItem!.ToString()!)
            );
        }
        else if (_vehicleType == typeof(SanitetskaBasic))
        {
            return new SanitetskaBasic
           (
                txtRegistarskaOznaka.Text,
                txtProizvodjac.Text,
                (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!),
                txtLokacija.Text
            );
        }
        else if (_vehicleType == typeof(DzipoviBasic))
        {
            return new DzipoviBasic
           (
                txtRegistarskaOznaka.Text,
                txtProizvodjac.Text,
                (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!),
                txtLokacija.Text
            );
        }
        else if (_vehicleType == typeof(KamioniBasic))
        {
            return new KamioniBasic
           (
                txtRegistarskaOznaka.Text,
                txtProizvodjac.Text,
                (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!),
                txtLokacija.Text
            );
        }
        else
        {
            return new VoziloBasic
            (
                txtRegistarskaOznaka.Text,
                txtProizvodjac.Text,
                (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!),
                txtLokacija.Text
            );
        }
    }

    protected virtual bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtRegistarskaOznaka.Text) || string.IsNullOrWhiteSpace(txtProizvodjac.Text) ||
            cmbStatus.SelectedItem == null || string.IsNullOrWhiteSpace(txtLokacija.Text) ||
            cmbJedinica.SelectedItem == null || cmbPojedinac.SelectedItem == null)
        {
            MessageBox.Show("Molimo popunite sva obavezna polja ispravno.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        if (_vehicleType == typeof(SpecijalnaVozilaBasic) && cmbNamena.SelectedItem == null)
        {
            MessageBox.Show("Molimo popunite polje za namenu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        if (dtpDatumOd.Value > dtpDatumDo.Value)
        {
            MessageBox.Show("Datum do ne može biti pre datuma od.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}