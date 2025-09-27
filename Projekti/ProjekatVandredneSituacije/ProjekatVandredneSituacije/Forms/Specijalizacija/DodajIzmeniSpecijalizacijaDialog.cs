using ProjekatVanredneSituacije;
using ProjekatVanredneSituacije.DTOs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VanrednaSituacijaLibrary;

public class DodajIzmeniSpecijalizacijaDialog : Form
{
    private Label lblTip, lblKordinator;
    private TextBox txtTip;
    private ComboBox cmbKordinator;
    private Button btnSacuvaj, btnOdustani;
    private TableLayoutPanel tlpMain;

    public SpecijalizacijaBasic SpecijalizacijaBasic { get; private set; }
    private int _specijalizacijaIdToUpdate;

    public DodajIzmeniSpecijalizacijaDialog(SpecijalizacijaPregled? specijalizacijaPregled = null)
    {
        InitializeComponent();
         
        PopuniKordinatore();

        if (specijalizacijaPregled != null)
        {
            this.Text = "Izmena specijalizacije";
            _specijalizacijaIdToUpdate = specijalizacijaPregled.Id;
            PopulateFields(specijalizacijaPregled);
        }
        else
        {
            this.Text = "Dodaj novu specijalizaciju";
        }
    }

    private async void PopuniKordinatore()
    {
        try
        { 
            IList<KordinatorView> kordinatori = await DTOManager.VratiKordinatora();
            cmbKordinator.DataSource = kordinatori;
            cmbKordinator.DisplayMember = "Ime"; 
            cmbKordinator.ValueMember = "JMBG"; 
        }
        catch (Exception ex)
        {
            MessageBox.Show("Greška pri učitavanju kordinatora: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void PopulateFields(SpecijalizacijaPregled specijalizacija)
    {
        txtTip.Text = specijalizacija.Tip;
        if (!string.IsNullOrEmpty(specijalizacija.Kordinator))
        {
            cmbKordinator.SelectedValue = specijalizacija.Kordinator;
        }
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(400, 250);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 2, RowCount = 3 };
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

        lblTip = new Label { Text = "Tip:", TextAlign = ContentAlignment.MiddleLeft };
        txtTip = new TextBox();

        lblKordinator = new Label { Text = "Kordinator (JMBG):", TextAlign = ContentAlignment.MiddleLeft };
        cmbKordinator = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList };

        btnSacuvaj = new Button { Text = "Sačuvaj", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };

        tlpMain.Controls.Add(lblTip, 0, 0); tlpMain.Controls.Add(txtTip, 1, 0);
        tlpMain.Controls.Add(lblKordinator, 0, 1); tlpMain.Controls.Add(cmbKordinator, 1, 1);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnSacuvaj);
        pnlButtons.Controls.Add(btnOdustani);
        btnSacuvaj.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 2); tlpMain.SetColumnSpan(pnlButtons, 2);
        this.Controls.Add(tlpMain);

        btnSacuvaj.Click += BtnSacuvaj_Click;
    }

    private void BtnSacuvaj_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTip.Text))
        {
            MessageBox.Show("Tip specijalizacije mora biti popunjen.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.None;
            return;
        }

        if (cmbKordinator.SelectedValue == null)
        {
            MessageBox.Show("Molimo odaberite kordinatora.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.DialogResult = DialogResult.None;
            return;
        }

        this.SpecijalizacijaBasic = new SpecijalizacijaBasic
        {
            Id = _specijalizacijaIdToUpdate,
            Tip = txtTip.Text,
            Kordinator = new KordinatorBasic { JMBG = cmbKordinator.SelectedValue.ToString() }
        };

        this.DialogResult = DialogResult.OK;
    }
}