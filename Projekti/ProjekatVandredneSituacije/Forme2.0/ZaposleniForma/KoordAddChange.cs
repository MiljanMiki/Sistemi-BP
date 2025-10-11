using ProjekatVandredneSituacije.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.ZaposleniForma
{
    public partial class KoordAddChange : Form
    {
        public KordinatorView? kord;

        public KoordAddChange()
        {
            InitializeComponent();
        }

        public KoordAddChange(KordinatorView koordView)
        {
            InitializeComponent();
            this.kord = koordView;
            PopuniPodacima();
            textJmbg.Enabled = false;
            textJmbg.BackColor = Color.LightGray;
            kord = koordView;
        }

        public async void PopuniPodacima()
        {
            textJmbg.Text = kord.JMBG;
            textIme.Text = kord.Ime;
            textPrezime.Text = kord.Prezime;
            dateRodjenje.Value = kord.Datum_Rodjenja;
            if (kord.Pol == "M")
            {
                checkMusko.Checked = true;
                checkZensko.Checked = false;
            }
            else if (kord.Pol == "Z")
            {
                checkMusko.Checked = false;
                checkZensko.Checked = true;
            }

            textKontakt.Text = kord.Kontakt_Telefon;
            textEmail.Text = kord.Email;
            textAdresa.Text = kord.AdresaStanovanja;
            try
            {
                dateZaposlenje.Value = kord.Datum_Zaposlenja;
            }
            catch (Exception ex)
            {
                dateZaposlenje.Value = DateTime.Now;
            }
        }

        private void buttonRst_Click(object sender, EventArgs e)
        {
            textIme.Clear();
            textPrezime.Clear();
            dateZaposlenje.Value = DateTime.Now;
            checkMusko.Checked = false;
            checkZensko.Checked = false;
            textKontakt.Clear();
            textEmail.Clear();
            textAdresa.Clear();
            dateZaposlenje.Value = DateTime.Now;
        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
           "Da li si siguran da želiš da zatvoriš formu?",
           "Potvrda",
           MessageBoxButtons.YesNo,
           MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Close();
            }
            else
            {

            }
        }

        private async void buttonSacuvaj_Click(object sender, EventArgs e)
        {
            KordinatorView kordinator = new KordinatorView();
            kordinator.JMBG = textJmbg.Text;
            kordinator.Ime = textIme.Text;
            kordinator.Prezime = textPrezime.Text;
            kordinator.Datum_Rodjenja = dateRodjenje.Value;
            kordinator.Kontakt_Telefon = textKontakt.Text;
            kordinator.Email = textEmail.Text;
            kordinator.AdresaStanovanja = textAdresa.Text;

            if (textJmbg.Text.Length != 13 || int.TryParse(textJmbg.Text, out _))
            {
                MessageBox.Show("Neispravan JMBG!");
            }
            if (checkMusko.Checked == true)
            {
                kordinator.Pol = "M";
            }
            else if (checkZensko.Checked == true)
            {
                kordinator.Pol = "Z";
            }

            if (string.IsNullOrEmpty(textJmbg.Text) || string.IsNullOrEmpty(textIme.Text) || string.IsNullOrEmpty(textPrezime.Text) || string.IsNullOrEmpty(textKontakt.Text) || string.IsNullOrEmpty(textEmail.Text) ||
                string.IsNullOrEmpty(textAdresa.Text))
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (kord == null)
            {
                await DataProvider.DodajKordinatora(kordinator);
            }
            else
            {
                await DataProvider.IzmeniKordinatora(kordinator, kord.JMBG);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
