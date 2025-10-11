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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ProjekatVandredneSituacije.Forme2._0.ZaposleniForma
{
    public partial class AddChangeAnaliticar : Form
    {
        private AnaliticarView? analiticar;
        public AddChangeAnaliticar()
        {
            InitializeComponent();
        }
        public AddChangeAnaliticar(AnaliticarView analiticar)
        {
            InitializeComponent();
            this.analiticar = analiticar;
            PopuniPodacima();
            textJmbg.Enabled = false;
            textJmbg.BackColor = Color.LightGray;
        }

        public async void PopuniPodacima()
        {
            textJmbg.Text = analiticar.JMBG;
            textIme.Text = analiticar.Ime;
            textPrezime.Text = analiticar.Prezime;
            dateRodjenja.Value = analiticar.Datum_Rodjenja;
            if (analiticar.Pol == "M")
            {
                checkMusko.Checked = true;
                checkZensko.Checked = false;
            }
            else if (analiticar.Pol == "Z")
            {
                checkMusko.Checked = false;
                checkZensko.Checked = true;
            }

            textKontakt.Text = analiticar.Kontakt_Telefon;
            textEmail.Text = analiticar.Email;
            textAdresa.Text = analiticar.AdresaStanovanja;
            dateZaposlenje.Value = analiticar.Datum_Zaposlenja;
        }
        private void buttonReset_Click(object sender, EventArgs e)
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

        private void buttonCancel_Click(object sender, EventArgs e)
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

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            AnaliticarView analiticar = new AnaliticarView();
            analiticar.JMBG = textJmbg.Text;
            analiticar.Ime = textIme.Text;
            analiticar.Prezime = textPrezime.Text;
            analiticar.Datum_Rodjenja = dateRodjenja.Value;
            analiticar.Kontakt_Telefon = textKontakt.Text;
            analiticar.Email = textEmail.Text;
            analiticar.AdresaStanovanja = textAdresa.Text;
            analiticar.Datum_Zaposlenja = dateZaposlenje.Value;

            if (textJmbg.Text.Length != 13 || int.TryParse(textJmbg.Text, out _))
            {
                MessageBox.Show("Neispravan JMBG!");
            }

            if (checkMusko.Checked == true)
            {
                analiticar.Pol = "M";
            }
            else if (checkZensko.Checked == true)
            {
                analiticar.Pol = "Z";
            }
            if (string.IsNullOrEmpty(textJmbg.Text) || string.IsNullOrEmpty(textIme.Text) || string.IsNullOrEmpty(textPrezime.Text) || string.IsNullOrEmpty(textKontakt.Text) || string.IsNullOrEmpty(textEmail.Text) ||
                string.IsNullOrEmpty(textAdresa.Text))
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (analiticar == null)
            {
                await DataProvider.DodajAnalitcar(analiticar);
            }
            else
            {
                await DataProvider.IzmeniAnaliticar(analiticar, analiticar.JMBG);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
