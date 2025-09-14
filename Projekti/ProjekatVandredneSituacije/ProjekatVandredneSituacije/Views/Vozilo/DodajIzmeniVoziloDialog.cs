using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVandredneSituacije.Entiteti;

public class DodajIzmeniVoziloDialog : Form
{
    private Label lblRegistarskaOznaka, lblProizvodjac, lblStatus, lblLokacija;
    private TextBox txtRegistarskaOznaka, txtProizvodjac, txtLokacija;
    private ComboBox cmbStatus;
    private Button btnSacuvaj, btnOdustani;

    public Vozilo? Vozilo { get; private set; }

    public DodajIzmeniVoziloDialog(Vozilo? vozilo = null)
    {
        InitializeComponent();
        this.Vozilo = vozilo ?? new Vozilo();
        this.Text = vozilo != null ? "Izmeni vozilo" : "Dodaj novo vozilo";

        if (vozilo != null)
        {
            PopulateFields();
        }
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(400, 300);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        var tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 2 };
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

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblRegistarskaOznaka, 0, 0); tlpMain.Controls.Add(txtRegistarskaOznaka, 1, 0);
        tlpMain.Controls.Add(lblProizvodjac, 0, 1); tlpMain.Controls.Add(txtProizvodjac, 1, 1);
        tlpMain.Controls.Add(lblStatus, 0, 2); tlpMain.Controls.Add(cmbStatus, 1, 2);
        tlpMain.Controls.Add(lblLokacija, 0, 3); tlpMain.Controls.Add(txtLokacija, 1, 3);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 4); tlpMain.SetColumnSpan(pnlButtons, 2);
        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += BtnSacuvaj_Click;
    }

    protected void PopulateFields()
    {
        if (Vozilo != null)
        {
            txtRegistarskaOznaka.Text = Vozilo.Registarska_Oznaka;
            txtProizvodjac.Text = Vozilo.Proizvodjac;
            cmbStatus.SelectedItem = Vozilo.Status.ToString();
            txtLokacija.Text = Vozilo.Lokacija;
        }
    }

    protected void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (ValidateInput())
        {
            Vozilo!.Registarska_Oznaka = txtRegistarskaOznaka.Text;
            Vozilo.Proizvodjac = txtProizvodjac.Text;
            Vozilo.Status = (StatusVozila)Enum.Parse(typeof(StatusVozila), cmbStatus.SelectedItem!.ToString()!);
            Vozilo.Lokacija = txtLokacija.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
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
        return true;
    }
}