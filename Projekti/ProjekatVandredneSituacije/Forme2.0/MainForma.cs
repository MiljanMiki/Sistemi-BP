using ProjekatVandredneSituacije.Forme2._0.IstorijaUcestvovanjaVozila;
using ProjekatVandredneSituacije.Forme2._0.Prijava;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0
{
    public partial class MainForma : Form
    {
        public MainForma()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void btnZaposleni_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new ZaposleniForma.ZaposleniOverview());
        }

        private void panelPrikaz_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PrikaziFormuUPanelu(Form forma)
        {

            panelPrikaz.Controls.Clear();

            // Podesi formu da se ponaša kao kontrola (embedovana)
            forma.TopLevel = false;
            forma.FormBorderStyle = FormBorderStyle.None;
            forma.Dock = DockStyle.Fill;

            // Dodaj formu u panel
            panelPrikaz.Controls.Add(forma);
            forma.Show();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new Prijava.PrijavaOverview());
        }

        private void btnIntervencije_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new IstorijaIntervencija.IstorijaIntervencija());
        }

        private void btnIstorija_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new IstorijaAgencije.IstorijaOverlay());
        }

        private void btnOprema_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new Oprema.OpremaOverlay());
        }

        private void buttonSaradnje_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new Saradnja.SaradnjaOverlay());
        }

        private void MainForma_Load(object sender, EventArgs e)
        {

        }

        private void btnVozila_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new Vozila.VozilaOverview());
        }

        private void btnJedinice_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new InterventnaJedinica.InterventnaOverview());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new UcestvovaloOverlay());
        }

        private void btnVs_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new VanrednaSituacija.VanrednaOverview());
        }

        private void buttonUcestvuje_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new Ucestvuje.UcestvovanjeUVsOverlay());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new Sluzba.SluzbaOverlay());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new Sluzba.PredstavniciOverlay());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrikaziFormuUPanelu(new Dodeljivanja.DodeljivanjaOverlay());
        }
    }
}
