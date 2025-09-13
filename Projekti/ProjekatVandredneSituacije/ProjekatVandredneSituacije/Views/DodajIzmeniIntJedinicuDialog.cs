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
    private Panel pnlButtons;
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
        tlpMain = new TableLayoutPanel();
        lblNaziv = new Label();
        txtNaziv = new TextBox();
        lblBrojClanova = new Label();
        txtBrojClanova = new TextBox();
        lblBaza = new Label();
        txtBaza = new TextBox();
        lblTip = new Label();
        cmbTipJedinice = new ComboBox();
        pnlButtons = new Panel();
        btnSacuvaj = new Button();
        btnOdustani = new Button();
        tlpMain.SuspendLayout();
        pnlButtons.SuspendLayout();
        SuspendLayout();
        // 
        // tlpMain
        // 
        tlpMain.ColumnCount = 2;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        tlpMain.Controls.Add(lblNaziv, 0, 0);
        tlpMain.Controls.Add(txtNaziv, 1, 0);
        tlpMain.Controls.Add(lblBrojClanova, 0, 1);
        tlpMain.Controls.Add(txtBrojClanova, 1, 1);
        tlpMain.Controls.Add(lblBaza, 0, 2);
        tlpMain.Controls.Add(txtBaza, 1, 2);
        tlpMain.Controls.Add(lblTip, 0, 3);
        tlpMain.Controls.Add(cmbTipJedinice, 1, 3);
        tlpMain.Controls.Add(pnlButtons, 0, 4);
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Location = new Point(0, 0);
        tlpMain.Name = "tlpMain";
        tlpMain.Padding = new Padding(10);
        tlpMain.RowCount = 5;
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
        tlpMain.Size = new Size(400, 250);
        tlpMain.TabIndex = 0;
        // 
        // lblNaziv
        // 
        lblNaziv.Location = new Point(13, 10);
        lblNaziv.Name = "lblNaziv";
        lblNaziv.Size = new Size(100, 23);
        lblNaziv.TabIndex = 0;
        // 
        // txtNaziv
        // 
        txtNaziv.Location = new Point(127, 13);
        txtNaziv.Name = "txtNaziv";
        txtNaziv.Size = new Size(100, 27);
        txtNaziv.TabIndex = 1;
        // 
        // lblBrojClanova
        // 
        lblBrojClanova.Location = new Point(13, 40);
        lblBrojClanova.Name = "lblBrojClanova";
        lblBrojClanova.Size = new Size(100, 23);
        lblBrojClanova.TabIndex = 2;
        // 
        // txtBrojClanova
        // 
        txtBrojClanova.Location = new Point(127, 43);
        txtBrojClanova.Name = "txtBrojClanova";
        txtBrojClanova.Size = new Size(100, 27);
        txtBrojClanova.TabIndex = 3;
        // 
        // lblBaza
        // 
        lblBaza.Location = new Point(13, 70);
        lblBaza.Name = "lblBaza";
        lblBaza.Size = new Size(100, 23);
        lblBaza.TabIndex = 4;
        // 
        // txtBaza
        // 
        txtBaza.Location = new Point(127, 73);
        txtBaza.Name = "txtBaza";
        txtBaza.Size = new Size(100, 27);
        txtBaza.TabIndex = 5;
        // 
        // lblTip
        // 
        lblTip.Location = new Point(13, 100);
        lblTip.Name = "lblTip";
        lblTip.Size = new Size(100, 23);
        lblTip.TabIndex = 6;
        // 
        // cmbTipJedinice
        // 
        cmbTipJedinice.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbTipJedinice.Items.AddRange(new object[] { "Opšta", "Specijalna" });
        cmbTipJedinice.Location = new Point(127, 103);
        cmbTipJedinice.Name = "cmbTipJedinice";
        cmbTipJedinice.Size = new Size(121, 28);
        cmbTipJedinice.TabIndex = 7;
        // 
        // pnlButtons
        // 
        tlpMain.SetColumnSpan(pnlButtons, 2);
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        pnlButtons.Location = new Point(13, 133);
        pnlButtons.Name = "pnlButtons";
        pnlButtons.Size = new Size(200, 100);
        pnlButtons.TabIndex = 8;
        // 
        // btnSacuvaj
        // 
        btnSacuvaj.Location = new Point(100, 10);
        btnSacuvaj.Name = "btnSacuvaj";
        btnSacuvaj.Size = new Size(75, 23);
        btnSacuvaj.TabIndex = 0;
        btnSacuvaj.Click += BtnSacuvaj_Click;
        // 
        // btnOdustani
        // 
        btnOdustani.Location = new Point(210, 10);
        btnOdustani.Name = "btnOdustani";
        btnOdustani.Size = new Size(75, 23);
        btnOdustani.TabIndex = 1;
        // 
        // DodajIzmeniIntJedinicuDialog
        // 
        ClientSize = new Size(400, 250);
        Controls.Add(tlpMain);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "DodajIzmeniIntJedinicuDialog";
        StartPosition = FormStartPosition.CenterParent;
        tlpMain.ResumeLayout(false);
        tlpMain.PerformLayout();
        pnlButtons.ResumeLayout(false);
        ResumeLayout(false);
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