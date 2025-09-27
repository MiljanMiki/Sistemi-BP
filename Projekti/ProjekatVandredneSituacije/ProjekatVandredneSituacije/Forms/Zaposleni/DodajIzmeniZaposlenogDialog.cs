using System;
using System.Drawing;
using System.Windows.Forms;
using ProjekatVanredneSituacije.DTOs;
using ProjekatVanredneSituacije.Entiteti;

public class DodajIzmeniZaposlenogDialog : Form
{
    private ComboBox cmbTip;
    private Button btnDalje, btnOdustani;
    private Label lblUputstvo;

    public ZaposleniView? Zaposlen { get; private set; }
     
    public DodajIzmeniZaposlenogDialog()
    {
        InitializeComponent();
        this.Text = "Dodaj novog zaposlenog";
    }
     
    public DodajIzmeniZaposlenogDialog(Zaposlen zaposlen)
    { 
        Form? dialog = null;

        if (zaposlen is Analiticar)
        {
            dialog = new DodajIzmeniAnaliticaraDialog(zaposlen as Analiticar);
        }
        else if (zaposlen is Kordinator)
        {
            dialog = new DodajIzmeniKoordinatoraDialog(zaposlen as Kordinator);
        }
        else if (zaposlen is OperativniRadnik)
        {
            dialog = new DodajIzmeniOperativnogRadnikaDialog(zaposlen as OperativniRadnik);
        }

        HandleSubDialogResult(dialog);
    }

    private void InitializeComponent()
    {
        this.ClientSize = new Size(350, 180);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterParent;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        var tlpMain = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(10), ColumnCount = 2, RowCount = 3 };
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 50));

        lblUputstvo = new Label { Text = "Izaberite tip zaposlenog:", TextAlign = ContentAlignment.MiddleLeft };
        cmbTip = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Dock = DockStyle.Fill };
        cmbTip.Items.AddRange(new string[] { "Analitičar", "Koordinator", "Operativni Radnik" });

        btnDalje = new Button { Text = "Dalje", DialogResult = DialogResult.OK };
        btnOdustani = new Button { Text = "Odustani", DialogResult = DialogResult.Cancel };
         
        tlpMain.Controls.Add(lblUputstvo, 0, 0);
        tlpMain.SetColumnSpan(lblUputstvo, 2);

        tlpMain.Controls.Add(cmbTip, 0, 1);
        tlpMain.SetColumnSpan(cmbTip, 2);

        var pnlButtons = new Panel { Dock = DockStyle.Fill };
        pnlButtons.Controls.Add(btnDalje);
        pnlButtons.Controls.Add(btnOdustani);
        btnDalje.Location = new Point(50, 10);
        btnOdustani.Location = new Point(160, 10);

        tlpMain.Controls.Add(pnlButtons, 0, 2);
        tlpMain.SetColumnSpan(pnlButtons, 2);

        this.Controls.Add(tlpMain);

        btnDalje.Click += BtnDalje_Click;
    }

    private void BtnDalje_Click(object? sender, EventArgs e)
    {
        if (cmbTip.SelectedItem == null)
        {
            MessageBox.Show("Molimo izaberite tip zaposlenog.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.DialogResult = DialogResult.None;
            return;
        }
         
        Form? dialog = null;
        string? selectedTip = cmbTip.SelectedItem?.ToString();

        if (selectedTip == "Analitičar")
            dialog = new DodajIzmeniAnaliticaraDialog();
        else if (selectedTip == "Koordinator")
            dialog = new DodajIzmeniKoordinatoraDialog();
        else if (selectedTip == "Operativni Radnik")
            dialog = new DodajIzmeniOperativnogRadnikaDialog();

        HandleSubDialogResult(dialog);
    }
     
    private void HandleSubDialogResult(Form? dialog)
    {
        if (dialog?.ShowDialog() == DialogResult.OK)
        {
            if (dialog is DodajIzmeniAnaliticaraDialog analiticarDialog)
                this.Zaposlen = analiticarDialog.Zaposlen;
            else if (dialog is DodajIzmeniKoordinatoraDialog koordinatorDialog)
                this.Zaposlen = koordinatorDialog.Zaposlen;
            else if (dialog is DodajIzmeniOperativnogRadnikaDialog operativniDialog)
                this.Zaposlen = operativniDialog.Zaposlen;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        else
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}