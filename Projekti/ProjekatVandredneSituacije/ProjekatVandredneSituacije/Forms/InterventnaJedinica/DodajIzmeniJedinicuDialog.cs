using ProjekatVanredneSituacije;
using ProjekatVanredneSituacije.Entiteti;
using ProjekatVanredneSituacije.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VanrednaSituacijaLibrary;

public class DodajIzmeniJedinicuDialog : Form
{
    private Label lblNaziv, lblBrojClanova, lblBaza, lblKomandir, lblTipSpecijalne;
    private TextBox txtNaziv, txtBaza, txtTipSpecijalne;
    private NumericUpDown numBrojClanova;
    private ComboBox cmbKomandir;
    private Button btnSacuvaj, btnOdustani;

    private InterventnaJedinicaBasic Jedinica;
    private IList<OperativniRadnikView> sviKomandiri;

    public DodajIzmeniJedinicuDialog()
    {
        Jedinica = null;
        InitializeComponent();
        this.Text = "Dodaj novu jedinicu";
        this.btnSacuvaj.Text = "Dodaj";
        UcitajKomandire();
    }

    public DodajIzmeniJedinicuDialog(InterventnaJedinicaBasic jedinica)
    {
        Jedinica = jedinica;
        InitializeComponent();
        this.Text = "Izmeni jedinicu";
        this.btnSacuvaj.Text = "Sačuvaj izmene";
        UcitajKomandire();
        PopuniPolja();
    }

    private async void UcitajKomandire()
    {
        try
        {
            sviKomandiri = await DTOManager.VratiOperativneRadnike();
            cmbKomandir.DataSource = sviKomandiri;
            cmbKomandir.DisplayMember = "Ime";
            cmbKomandir.ValueMember = "JMBG";
        }
        catch (Exception ex)
        {
            MessageBox.Show("Došlo je do greške prilikom učitavanja komandira: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.Abort;
            this.Close();
        }
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
        numBrojClanova = new NumericUpDown { Minimum = 1, Maximum = 1000 };
        lblBaza = new Label { Text = "Baza:", TextAlign = ContentAlignment.MiddleLeft };
        txtBaza = new TextBox();
        lblKomandir = new Label { Text = "Komandir:", TextAlign = ContentAlignment.MiddleLeft };
        cmbKomandir = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };

        lblTipSpecijalne = new Label { Text = "Tip specijalne jedinice:", TextAlign = ContentAlignment.MiddleLeft };
        txtTipSpecijalne = new TextBox();

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblNaziv, 0, 0); tlpMain.Controls.Add(txtNaziv, 1, 0);
        tlpMain.Controls.Add(lblBrojClanova, 0, 1); tlpMain.Controls.Add(numBrojClanova, 1, 1);
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
        this.Load += (sender, e) =>
        {
            if (Jedinica is OpstaInterventnaJedBasic || Jedinica == null)
            {
                lblTipSpecijalne.Visible = false;
                txtTipSpecijalne.Visible = false;
            }
            else if (Jedinica is SpecijalnaInterventnaJedinicaBasic)
            {
                lblTipSpecijalne.Visible = true;
                txtTipSpecijalne.Visible = true;
            }
        };
    }

    private void PopuniPolja()
    {
        txtNaziv.Text = Jedinica.Naziv;
        numBrojClanova.Value = Jedinica.BrojClanova;
        txtBaza.Text = Jedinica.Baza;

        if (Jedinica.Komandir != null && sviKomandiri != null)
        {
            var komandir = sviKomandiri.FirstOrDefault(r => r.JMBG == Jedinica.Komandir);
            if (komandir != null)
            {
                cmbKomandir.SelectedValue = komandir.JMBG;
            }
        }

        if (Jedinica is SpecijalnaInterventnaJedinicaBasic specijalna)
        {
            txtTipSpecijalne.Text = specijalna.TipSpecijalneJed;
        }
    }

    private async void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        try
        {
            if (!ValidateInput())
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            if (Jedinica == null)
            {
                // Kreiramo InterventnaJedinicaView DTO objekat
                var novaJedinica = new InterventnaJedinicaView
                {
                    Naziv = txtNaziv.Text,
                    BrojClanova = (int)numBrojClanova.Value,
                    Baza = txtBaza.Text,
                    JMBGKomandira = cmbKomandir.SelectedValue?.ToString()
                };

                // Pretpostavljamo da postoji metoda za dodavanje
                await DTOManager.DodajOpstuIntervetnuJedinicu(novaJedinica);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // Logika za izmenu postojeće jedinice
                if (Jedinica is OpstaInterventnaJedBasic opsta)
                {
                    // Kreiramo OpstaInterventnaView DTO za slanje na server
                    var izmenjenaJedinica = new OpstaInterventnaJedPregled
                    {
                        Naziv = txtNaziv.Text,
                        BrojClanova = (int)numBrojClanova.Value,
                        Baza = txtBaza.Text,
                        JMBGKomandira = cmbKomandir.SelectedValue?.ToString()
                    };

                    // Pozivamo DTOManager.izmeniOpstuInterventnuJedinicu sa ID-em
                    await DTOManager.izmeniOpstuInterventnuJedinicu(izmenjenaJedinica, opsta.Jedinstveni_Broj);
                }
                else if (Jedinica is SpecijalnaInterventnaJedinicaBasic specijalna)
                {
                    // Kreiramo SpecijalnaInterventnaView DTO za slanje na server
                    var izmenjenaJedinica = new SpecijalnaInterventnaView
                    {
                        Naziv = txtNaziv.Text,
                        BrojClanova = (int)numBrojClanova.Value,
                        Baza = txtBaza.Text,
                        JMBGKomandira = cmbKomandir.SelectedValue?.ToString(),
                        TipSpecijalneJed = txtTipSpecijalne.Text
                    };

                    // Pretpostavljamo da slična metoda postoji i za specijalne jedinice
                    await DTOManager.izmeniSpecijalnuInterventnuJedinicu(izmenjenaJedinica, specijalna.Jedinstveni_Broj);
                }
                this.DialogResult = DialogResult.OK;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Došlo je do greške: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.None;
        }
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtNaziv.Text) || string.IsNullOrWhiteSpace(txtBaza.Text) || cmbKomandir.SelectedItem == null)
        {
            MessageBox.Show("Molimo popunite sva obavezna polja.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (Jedinica is SpecijalnaInterventnaJedinicaBasic && string.IsNullOrWhiteSpace(txtTipSpecijalne.Text))
        {
            MessageBox.Show("Molimo unesite tip specijalne jedinice.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }
}