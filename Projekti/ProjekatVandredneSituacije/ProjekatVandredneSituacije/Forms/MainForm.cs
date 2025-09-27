using System;
using System.Windows.Forms;
using System.Drawing;
using ProjekatVanredneSituacije.Entiteti;

public class MainForm : Form
{
    private readonly Panel pnlNavigation = new Panel();
    private readonly Panel pnlContent = new Panel();
    private readonly Label lblMainTitle = new Label();

    public MainForm()
    {
        InitializeComponent();
        SetupNavigationButtons();
    }

    private void InitializeComponent()
    {
        this.Text = "Aplikacija za Vanredne Situacije";
        this.WindowState = FormWindowState.Maximized;
        this.MinimumSize = new Size(1200, 800);

        this.lblMainTitle.Text = "Vanredne Situacije";
        this.lblMainTitle.Font = new Font("Arial", 48, FontStyle.Bold);
        this.lblMainTitle.Dock = DockStyle.Fill;
        this.lblMainTitle.TextAlign = ContentAlignment.MiddleCenter;

        this.pnlContent.Dock = DockStyle.Fill;
        this.pnlContent.Controls.Add(this.lblMainTitle);
        this.Controls.Add(this.pnlContent);

        this.pnlNavigation.Dock = DockStyle.Left;
        this.pnlNavigation.Width = 200;
        this.pnlNavigation.BackColor = Color.LightGray;
        this.Controls.Add(this.pnlNavigation);
    }

    private void SetupNavigationButtons()
    {
        string[] buttonTitles = {
            "Lista Zaposlenih",
            "Istorija Prijava",
            "Istorija Vanrednih Situacija",
            "Lista Int Jedinica",
            "Lista Intervencija",
            "Lista Vozila",
            "Lista Sektora",
            "Lista Opreme" 
        };

        int yPos = 20;
        foreach (string title in buttonTitles)
        {
            Button btn = new Button
            {
                Text = title,
                Width = this.pnlNavigation.Width - 40,
                Height = 40,
                Location = new Point(20, yPos),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            btn.Click += NavigationButton_Click;
            this.pnlNavigation.Controls.Add(btn);

            yPos += 50;
        }
    }

    private void NavigationButton_Click(object? sender, EventArgs e)
    {
        Button? clickedButton = sender as Button;
        if (clickedButton != null)
        {
            this.pnlContent.Controls.Clear();
            Form? newForm = CreateForm(clickedButton.Text);
            if (newForm != null)
            {
                newForm.TopLevel = false;
                newForm.FormBorderStyle = FormBorderStyle.None;
                newForm.Dock = DockStyle.Fill;
                this.pnlContent.Controls.Add(newForm);
                newForm.Show();
            }
        }
    }

    private Form? CreateForm(string formName)
    {
        switch (formName)
        {
            case "Lista Zaposlenih":
                return new ListaZaposlenihForm();
            case "Istorija Prijava":
                return new ListaPrijavaForm();
            case "Istorija Vanrednih Situacija":
                return new ListaVanrednihSituacijaForm();
            case "Lista Int Jedinica":
                return new ListaInterventnihJedinicaForm();
            case "Lista Intervencija":
                return new IntervencijeForm();
            case "Lista Vozila":
                return new ListaVozilaForm();
            case "Lista Sektora":
                return new ListaSluzbaForm();
            case "Lista Opreme": 
                return new ListaOpremeForm();
            default:
                this.pnlContent.Controls.Add(this.lblMainTitle);
                return null;
        }
    }
}