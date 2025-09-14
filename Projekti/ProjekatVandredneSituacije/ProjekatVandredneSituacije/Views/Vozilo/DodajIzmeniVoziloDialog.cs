using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;
using System.Collections.Generic;

public class DodajIzmeniVoziloDialog : Form
{
    private Label lblRegistarskaOznaka, lblProizvodjac, lblStatus, lblLokacija, lblNamena;
    private TextBox txtRegistarskaOznaka, txtProizvodjac, txtLokacija;
    private ComboBox cmbStatus, cmbNamena;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;

    public VoziloBasic? VoziloBasic { get; private set; }
    private readonly Type _vehicleType;

    public DodajIzmeniVoziloDialog(VoziloBasic? vozilo = null)
    {
        InitializeComponent();
        this.Text = vozilo != null ? "Izmeni vozilo" : "Dodaj novo vozilo";
        _vehicleType = vozilo?.GetType() ?? typeof(VoziloBasic);

        if (vozilo != null)
        {
            VoziloBasic = vozilo;
            PopulateFields();
        }

        // Prilagođavanje forme za SpecijalnaVozila
        if (_vehicleType == typeof(SpecijalnaVozilaBasic))
        {
            lblNamena.Visible = true;
            cmbNamena.Visible = true;
            this.ClientSize = new Size(400, 350);
        }
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(400, 300);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 2 };
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

        lblRegistarskaOznaka = new Label { Text = "Registarska Oznaka:", TextAlign = ContentAlignment.MiddleLeft };
        txtRegistarskaOznaka = new TextBox();
        lblProizvodjac = new Label { Text = "Proizvođač:", TextAlign = ContentAlignment.MiddleLeft };
        txtProizvodjac = new TextBox();
        lblStatus = new Label { Text = "Status:", TextAlign = ContentAlignment.MiddleLeft };
        cmbStatus = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cmbStatus.Items.AddRange(Enum.GetNames(typeof(StatusVozila)));
        lblLokacija = new Label { Text = "Lokacija:", TextAlign = ContentAlignment.MiddleLeft };
        txtLokacija = new TextBox();
        lblNamena = new Label { Text = "Namena:", TextAlign = ContentAlignment.MiddleLeft, Visible = false };
        cmbNamena = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Visible = false };
        cmbNamena.Items.AddRange(Enum.GetNames(typeof(Namena)));

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblRegistarskaOznaka, 0, 0); tlpMain.Controls.Add(txtRegistarskaOznaka, 1, 0);
        tlpMain.Controls.Add(lblProizvodjac, 0, 1); tlpMain.Controls.Add(txtProizvodjac, 1, 1);
        tlpMain.Controls.Add(lblStatus, 0, 2); tlpMain.Controls.Add(cmbStatus, 1, 2);
        tlpMain.Controls.Add(lblLokacija, 0, 3); tlpMain.Controls.Add(txtLokacija, 1, 3);
        tlpMain.Controls.Add(lblNamena, 0, 4); tlpMain.Controls.Add(cmbNamena, 1, 4);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 5); tlpMain.SetColumnSpan(pnlButtons, 2);
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
            if (VoziloBasic is SpecijalnaVozilaBasic spec)
            {
                cmbNamena.SelectedItem = spec.Namena.ToString();
            }
        }
    }

    protected void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (ValidateInput())
        {
            if (_vehicleType == typeof(SpecijalnaVozilaBasic))
            {
                VoziloBasic = new SpecijalnaVozilaBasic
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
                VoziloBasic = new SanitetskaBasic
               (
                   txtRegistarskaOznaka.Text,
                   txtProizvodjac.Text,
                   (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!),
                   txtLokacija.Text
               );
            }
            else if (_vehicleType == typeof(DzipoviBasic))
            {
                VoziloBasic = new DzipoviBasic
               (
                   txtRegistarskaOznaka.Text,
                   txtProizvodjac.Text,
                   (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!),
                   txtLokacija.Text
               );
            }
            else if (_vehicleType == typeof(KamioniBasic))
            {
                VoziloBasic = new KamioniBasic
               (
                   txtRegistarskaOznaka.Text,
                   txtProizvodjac.Text,
                   (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!),
                   txtLokacija.Text
               );
            }
            else
            {
                VoziloBasic = new VoziloBasic
                (
                    txtRegistarskaOznaka.Text,
                    txtProizvodjac.Text,
                    (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!),
                    txtLokacija.Text
                );
            }

            this.DialogResult = DialogResult.OK;
        }
        else
        {
            this.DialogResult = DialogResult.None;
        }
    }

    protected virtual bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtRegistarskaOznaka.Text) || string.IsNullOrWhiteSpace(txtProizvodjac.Text) ||
            cmbStatus.SelectedItem == null || string.IsNullOrWhiteSpace(txtLokacija.Text))
        {
            MessageBox.Show("Molimo popunite sva obavezna polja ispravno.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        if (_vehicleType == typeof(SpecijalnaVozilaBasic) && cmbNamena.SelectedItem == null)
        {
            MessageBox.Show("Molimo popunite polje za namenu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}