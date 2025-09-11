using System.Windows.Forms;

public class DodajSertifikatDialog : Form
{
    private TextBox txtTip;
    private TextBox txtInstitucija;
    private DateTimePicker dtpDatumOd;
    private DateTimePicker dtpDatumDo;
    // ...kontrole za unos

    public DodajSertifikatDialog()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.txtTip = new TextBox();
        this.txtInstitucija = new TextBox();
        this.dtpDatumOd = new DateTimePicker();
        this.dtpDatumDo = new DateTimePicker();
        // ...postavljanje svojstava
        this.Text = "Dodaj Sertifikat";

        this.Controls.Add(this.txtTip);
        this.Controls.Add(this.txtInstitucija);
        this.Controls.Add(this.dtpDatumOd);
        this.Controls.Add(this.dtpDatumDo);
    }
}