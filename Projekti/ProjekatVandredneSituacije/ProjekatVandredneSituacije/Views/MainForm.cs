using System;
using System.Windows.Forms;
using System.Drawing;

public class MainForm : Form
{
    private Panel pnlNavigation;
    private Panel pnlContent;
    private Label lblMainTitle;

    public MainForm()
    {
        InitializeComponent();
        SetupNavigationButtons();
    }

    private void InitializeComponent()
    {
        // Podesavanje glavne forme
        this.Text = "Aplikacija za Vanredne Situacije";
        this.WindowState = FormWindowState.Maximized;

        // Labela za glavni naslov u centralnom panelu
        this.lblMainTitle = new Label();
        this.lblMainTitle.Text = "Vanredne Situacije";
        this.lblMainTitle.Font = new Font("Arial", 48, FontStyle.Bold);
        this.lblMainTitle.Dock = DockStyle.Fill;
        this.lblMainTitle.TextAlign = ContentAlignment.MiddleCenter;

        // Panel za sadrzaj (u sredini)
        // DODAJEMO GA PRVI
        this.pnlContent = new Panel();
        this.pnlContent.Dock = DockStyle.Fill;
        this.pnlContent.Controls.Add(this.lblMainTitle);
        this.Controls.Add(this.pnlContent);

        // Panel za navigaciju (sa leve strane)
        // DODAJEMO GA POSLEDNJI DA BI BIO NA VRHU
        this.pnlNavigation = new Panel();
        this.pnlNavigation.Dock = DockStyle.Left;
        this.pnlNavigation.Width = 200;
        this.pnlNavigation.BackColor = Color.LightGray;
        this.Controls.Add(this.pnlNavigation);

    }

    private void SetupNavigationButtons()
    {
        // Kreiranje i dodavanje dugmadi za svaku stranicu
        string[] buttonTitles = {
            "Lista Zaposlenih",
            "Istorija Zaposlenih",
            "Istorija Prijava",
            "Istorija Vanrednih Situacija",
            "Lista Int Jedinica",
            "Lista Intervencija",
            "Lista Vozila",
            "Lista Sektora"
        };

        int yPos = 20;
        foreach (string title in buttonTitles)
        {
            Button btn = new Button();
            btn.Text = title;
            btn.Width = this.pnlNavigation.Width - 40;
            btn.Height = 40;
            btn.Location = new Point(20, yPos);
            btn.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btn.Click += new EventHandler(NavigationButton_Click);
            this.pnlNavigation.Controls.Add(btn);

            yPos += 50;
        }
    }

    private void NavigationButton_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
        if (clickedButton != null)
        {
            // Ocisti postojeci sadrzaj
            this.pnlContent.Controls.Clear();

            // Kreiraj i prikazi novu formu u centralnom panelu
            Form newForm = CreateForm(clickedButton.Text);
            if (newForm != null)
            {
                newForm.TopLevel = false; // Nece biti poseban prozor
                newForm.FormBorderStyle = FormBorderStyle.None; // Bez okvira
                newForm.Dock = DockStyle.Fill; // Prikazi preko celog panela
                this.pnlContent.Controls.Add(newForm);
                newForm.Show();
            }
        }
    }

    private Form CreateForm(string formName)
    {
        switch (formName)
        {
            case "Lista Zaposlenih":
                return new ListaZaposlenihForm();
            case "Istorija Zaposlenih":
                return new IstorijaZaposlenihForm();
            case "Istorija Prijava":
                return new IstorijaPrijavaForm();
            case "Istorija Vanrednih Situacija":
                return new IstorijaVanrednihSituacijaForm();
            case "Lista Int Jedinica":
                return new ListaIntJedinicaForm();
            case "Lista Intervencija":
                return new ListaIntervencijaForm();
            case "Lista Vozila":
                return new ListaVozilaForm();
            case "Lista Sektora":
                return new ListaSektoraForm();
            default:
                // Ako nista nije prepoznato, vrati pocetni tekst
                this.pnlContent.Controls.Add(this.lblMainTitle);
                return null;
        }
    }
}