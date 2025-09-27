using ProjekatVanredneSituacije;
using ProjekatVanredneSituacije.DTOs;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VanrednaSituacijaLibrary;

public class DodajIzmeniOpremuDialog : Form
{
    private ComboBox cmbTipOpreme;
    private TextBox txtSerijskiBroj, txtNaziv, txtStatus;
    private DateTimePicker dtpDatumNabavke;
    private ComboBox cmbJedinica;
    private Button btnOk, btnCancel;

    public OpremaBasic? OpremaBasic { get; private set; }

    public DodajIzmeniOpremuDialog(OpremaBasic? oprema = null)
    {
        InitializeComponent();

        btnOk.Click += BtnOk_Click;
        btnCancel.Click += BtnCancel_Click;

        if (oprema != null)
        { 
            this.Text = "Izmeni opremu";
            PopuniPolja(oprema);
        }
        else
        { 
            this.Text = "Dodaj novu opremu";
        }

        LoadJedinice();
    }

    private void InitializeComponent()
    {
        this.Size = new Size(400, 350);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.StartPosition = FormStartPosition.CenterParent;

        var lblTip = new Label { Text = "Tip opreme:", Location = new Point(20, 20) };
        cmbTipOpreme = new ComboBox { Location = new Point(150, 20), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
        cmbTipOpreme.Items.AddRange(new string[] { "Licna Zastita", "Medicinska Oprema", "Tehnicka Oprema", "Zalihe" });
        cmbTipOpreme.SelectedIndexChanged += CmbTipOpreme_SelectedIndexChanged;

        var lblSerijskiBroj = new Label { Text = "Serijski broj:", Location = new Point(20, 50) };
        txtSerijskiBroj = new TextBox { Location = new Point(150, 50), Width = 200, ReadOnly = true };

        var lblNaziv = new Label { Text = "Naziv:", Location = new Point(20, 80) };
        txtNaziv = new TextBox { Location = new Point(150, 80), Width = 200 };

        var lblStatus = new Label { Text = "Status:", Location = new Point(20, 110) };
        txtStatus = new TextBox { Location = new Point(150, 110), Width = 200 };

        var lblDatumNabavke = new Label { Text = "Datum nabavke:", Location = new Point(20, 140) };
        dtpDatumNabavke = new DateTimePicker { Location = new Point(150, 140), Width = 200, Format = DateTimePickerFormat.Short };

        var lblJedinica = new Label { Text = "Jedinica:", Location = new Point(20, 170) };
        cmbJedinica = new ComboBox { Location = new Point(150, 170), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

        btnOk = new Button { Text = "OK", Location = new Point(150, 250), Width = 100, DialogResult = DialogResult.OK };
        btnCancel = new Button { Text = "Odustani", Location = new Point(260, 250), Width = 100, DialogResult = DialogResult.Cancel };

        this.Controls.Add(lblTip);
        this.Controls.Add(cmbTipOpreme);
        this.Controls.Add(lblSerijskiBroj);
        this.Controls.Add(txtSerijskiBroj);
        this.Controls.Add(lblNaziv);
        this.Controls.Add(txtNaziv);
        this.Controls.Add(lblStatus);
        this.Controls.Add(txtStatus);
        this.Controls.Add(lblDatumNabavke);
        this.Controls.Add(dtpDatumNabavke);
        this.Controls.Add(lblJedinica);
        this.Controls.Add(cmbJedinica);
        this.Controls.Add(btnOk);
        this.Controls.Add(btnCancel);
    }

    private void CmbTipOpreme_SelectedIndexChanged(object? sender, EventArgs e)
    { 
    }

    private async void LoadJedinice()
    {
        try
        {
            var jedinice = await DTOManager.VratiSveJedinice();
            cmbJedinica.DataSource = jedinice;
            cmbJedinica.DisplayMember = "Naziv";
            cmbJedinica.ValueMember = "Jedinstveni_Broj";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Greška pri učitavanju jedinica: " + ex.Message);
        }
    }

    private void PopuniPolja(OpremaBasic oprema)
    {
        txtSerijskiBroj.Text = oprema.Serijski_Broj.ToString();
        txtSerijskiBroj.ReadOnly = true;
        txtNaziv.Text = oprema.Naziv;
        txtStatus.Text = oprema.Status;
        dtpDatumNabavke.Value = oprema.DatumNabavke;
        cmbJedinica.SelectedValue = oprema.IdJedinica;
         
        if (oprema is LicnaZastitaBasic)
        {
            cmbTipOpreme.SelectedIndex = 0;
        }
        else if (oprema is MedicinskaOpremaBasic)
        {
            cmbTipOpreme.SelectedIndex = 1;
        }
        else if (oprema is TehnickaOpremaBasic)
        {
            cmbTipOpreme.SelectedIndex = 2;
        }
        else if (oprema is ZaliheBasic)
        {
            cmbTipOpreme.SelectedIndex = 3;
        }

        cmbTipOpreme.Enabled = false;
    }

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtNaziv.Text) || cmbJedinica.SelectedValue == null)
        {
            MessageBox.Show("Molimo popunite sva obavezna polja.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.DialogResult = DialogResult.None;
            return;
        }

        string serijskiBroj = "0";
        if (!string.IsNullOrEmpty(txtSerijskiBroj.Text) && int.TryParse(txtSerijskiBroj.Text) != null)
        {
            MessageBox.Show("Serijski broj mora biti broj.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.DialogResult = DialogResult.None;
            return;
        }

        int idJedinica = (int)cmbJedinica.SelectedValue;

        switch (cmbTipOpreme.SelectedIndex)
        {
            case 0: 
                this.OpremaBasic = new LicnaZastitaBasic(serijskiBroj, txtNaziv.Text, txtStatus.Text, dtpDatumNabavke.Value, idJedinica, TipLicneZastite.Maska);
                break;
            case 1:  
                this.OpremaBasic = new MedicinskaOpremaBasic(serijskiBroj, txtNaziv.Text, txtStatus.Text, dtpDatumNabavke.Value, idJedinica);
                break;
            case 2:  
                this.OpremaBasic = new TehnickaOpremaBasic(serijskiBroj, txtNaziv.Text, txtStatus.Text, dtpDatumNabavke.Value, idJedinica);
                break;
            case 3: 
                this.OpremaBasic = new ZaliheBasic(serijskiBroj, txtNaziv.Text, txtStatus.Text, dtpDatumNabavke.Value, idJedinica);
                break;
            default:
                MessageBox.Show("Odaberite tip opreme.", "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
        }
    }

    private void BtnCancel_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
}