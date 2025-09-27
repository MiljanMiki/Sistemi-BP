using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVanredneSituacije;
using ProjekatVanredneSituacije.DTOs;
using ProjekatVanredneSituacije.Entiteti;
using VanrednaSituacijaLibrary;

public class IntervencijaDialog : Form
{
    private IntervencijaBasic _intervencija;
    private bool _isUpdate = false;

    private Label lblDatumVreme, lblLokacija, lblStatus, lblBrojSpasenih, lblBrojPovredjenih, lblUspesnost;
    private Label lblSituacija, lblJedinica;

    private DateTimePicker dtpDatumVreme;
    private TextBox txtLokacija, txtBrojSpasenih, txtBrojPovredjenih, txtUspesnost;
    private ComboBox cmbStatus;
    private ComboBox cmbVanrednaSituacija, cmbInterventnaJedinica;

    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;

    public IntervencijaBasic Intervencija { get; private set; }

    public IntervencijaDialog()
    {
        InitializeComponent();
        this.Text = "Dodaj novu intervenciju";
        Intervencija = new IntervencijaBasic();
        LoadComboBoxes();
    }

    public IntervencijaDialog(IntervencijaBasic intervencija)
    {
        InitializeComponent();
        this.Text = "Izmeni intervenciju";
        _intervencija = intervencija;
        _isUpdate = true;
        LoadComboBoxes();
        PopulateFields();
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(450, 420);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        tlpMain = new TableLayoutPanel();
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Padding = new Padding(10);
        tlpMain.ColumnCount = 2;
        tlpMain.RowCount = 9;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
        for (int i = 0; i < tlpMain.RowCount - 1; i++)
        {
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        }
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));

        lblDatumVreme = new Label { Text = "Datum i Vreme:", TextAlign = ContentAlignment.MiddleLeft };
        dtpDatumVreme = new DateTimePicker { Format = DateTimePickerFormat.Custom, CustomFormat = "dd.MM.yyyy HH:mm:ss" };
        lblLokacija = new Label { Text = "Lokacija:", TextAlign = ContentAlignment.MiddleLeft };
        txtLokacija = new TextBox();
        lblStatus = new Label { Text = "Status:", TextAlign = ContentAlignment.MiddleLeft };
        cmbStatus = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        cmbStatus.Items.AddRange(Enum.GetNames(typeof(ProjekatVanredneSituacije.Entiteti.Status)));

        lblSituacija = new Label { Text = "Vanredna Situacija:", TextAlign = ContentAlignment.MiddleLeft };
        cmbVanrednaSituacija = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };
        lblJedinica = new Label { Text = "Interventna Jedinica:", TextAlign = ContentAlignment.MiddleLeft };
        cmbInterventnaJedinica = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };

        lblBrojSpasenih = new Label { Text = "Broj Spasenih:", TextAlign = ContentAlignment.MiddleLeft };
        txtBrojSpasenih = new TextBox();
        lblBrojPovredjenih = new Label { Text = "Broj Povredjenih:", TextAlign = ContentAlignment.MiddleLeft };
        txtBrojPovredjenih = new TextBox();
        lblUspesnost = new Label { Text = "Uspešnost:", TextAlign = ContentAlignment.MiddleLeft };
        txtUspesnost = new TextBox();

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblDatumVreme, 0, 0);
        tlpMain.Controls.Add(dtpDatumVreme, 1, 0);
        tlpMain.Controls.Add(lblLokacija, 0, 1);
        tlpMain.Controls.Add(txtLokacija, 1, 1);
        tlpMain.Controls.Add(lblStatus, 0, 2);
        tlpMain.Controls.Add(cmbStatus, 1, 2);
        tlpMain.Controls.Add(lblSituacija, 0, 3);
        tlpMain.Controls.Add(cmbVanrednaSituacija, 1, 3);
        tlpMain.Controls.Add(lblJedinica, 0, 4);
        tlpMain.Controls.Add(cmbInterventnaJedinica, 1, 4);
        tlpMain.Controls.Add(lblBrojSpasenih, 0, 5);
        tlpMain.Controls.Add(txtBrojSpasenih, 1, 5);
        tlpMain.Controls.Add(lblBrojPovredjenih, 0, 6);
        tlpMain.Controls.Add(txtBrojPovredjenih, 1, 6);
        tlpMain.Controls.Add(lblUspesnost, 0, 7);
        tlpMain.Controls.Add(txtUspesnost, 1, 7);

        Panel pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(130, 10);
        btnOdustani.Location = new Point(240, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 8);
        tlpMain.SetColumnSpan(pnlButtons, 2);

        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += new EventHandler(BtnSacuvaj_Click);
    }

    private async void LoadComboBoxes()
    {
        try
        {
            var jedinice = await DTOManager.VratiSveJedinice();
            cmbInterventnaJedinica.DataSource = jedinice;
            cmbInterventnaJedinica.DisplayMember = "Naziv";
            cmbInterventnaJedinica.ValueMember = "Jedinstveni_Broj";

            var situacije = await DTOManager.VratiVanredneSituacije();
            cmbVanrednaSituacija.DataSource = situacije;
            cmbVanrednaSituacija.DisplayMember = "Naziv";
            cmbVanrednaSituacija.ValueMember = "Id";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Greška pri učitavanju podataka: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void PopulateFields()
    {
        if (_intervencija != null)
        {
            dtpDatumVreme.Value = _intervencija.Datum_I_Vreme;
            txtLokacija.Text = _intervencija.Lokacija;
            cmbStatus.SelectedItem = _intervencija.Status.ToString();
            txtBrojSpasenih.Text = _intervencija.Broj_Spasenih.ToString();
            txtBrojPovredjenih.Text = _intervencija.Broj_Povredjenih.ToString();
            txtUspesnost.Text = _intervencija.Uspesnost.ToString();

            if (_intervencija.Ucestvuje != null && _intervencija.Ucestvuje.Count > 0)
            {
                var prvaUcestvuje = _intervencija.Ucestvuje[0];
                cmbVanrednaSituacija.SelectedValue = prvaUcestvuje.IdVanredneSituacije;
                cmbInterventnaJedinica.SelectedValue = prvaUcestvuje.IdInterventneJed;
            }
        }
    }

    private async void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (ValidateInput())
        {
            try
            {
                // Kreiramo IntervencijaView DTO za slanje na server
                IntervencijaView novaIntervencija = new IntervencijaView();
                novaIntervencija.Datum_I_Vreme = dtpDatumVreme.Value;
                novaIntervencija.Lokacija = txtLokacija.Text;
                novaIntervencija.Status = (ProjekatVanredneSituacije.Entiteti.Status)Enum.Parse(typeof(ProjekatVanredneSituacije.Entiteti.Status), cmbStatus.SelectedItem!.ToString()!);
                novaIntervencija.Broj_Spasenih = int.Parse(txtBrojSpasenih.Text);
                novaIntervencija.Broj_Povredjenih = int.Parse(txtBrojPovredjenih.Text);
                novaIntervencija.Uspesnost = int.Parse(txtUspesnost.Text);

                // DTOManager metoda DodajIntervenciju mora da bude modifikovana
                // tako da vrati ID novokreiranog entiteta.
                int noviIdIntervencije = await DTOManager.DodajIntervenciju(novaIntervencija);

                // Kreiramo UcestvujeBasic DTO da bismo kreirali vezu
                if (cmbVanrednaSituacija.SelectedValue != null && cmbInterventnaJedinica.SelectedValue != null)
                {
                    UcestvujeView ucestvuje = new UcestvujeView
                    {
                        IdIntervencije = noviIdIntervencije,
                        IdVanredneSituacije = (int)cmbVanrednaSituacija.SelectedValue,
                        IdInterventneJed = (int)cmbInterventnaJedinica.SelectedValue
                    };

                    // Pozivamo DTOManager metodu za dodavanje 'ucestvuje' veze
                    await DTOManager.DodajUcestvuje(ucestvuje);
                }
                else
                {
                    MessageBox.Show("Morate odabrati i vanrednu situaciju i interventnu jedinicu.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None;
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo je do greške prilikom čuvanja intervencije: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }
        else
        {
            this.DialogResult = DialogResult.None;
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtLokacija.Text) || cmbStatus.SelectedItem == null ||
            cmbVanrednaSituacija.SelectedItem == null || cmbInterventnaJedinica.SelectedItem == null)
        {
            MessageBox.Show("Molimo popunite sva obavezna polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        int brojSpasenih, brojPovredjenih, uspesnost;
        if (!int.TryParse(txtBrojSpasenih.Text, out brojSpasenih) ||
            !int.TryParse(txtBrojPovredjenih.Text, out brojPovredjenih) ||
            !int.TryParse(txtUspesnost.Text, out uspesnost))
        {
            MessageBox.Show("Broj spasenih, povređenih i uspešnost moraju biti numeričke vrednosti.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }
}