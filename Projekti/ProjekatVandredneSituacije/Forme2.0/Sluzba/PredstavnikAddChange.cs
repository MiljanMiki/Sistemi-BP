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

namespace ProjekatVandredneSituacije.Forme2._0.Sluzba
{
    public partial class PredstavnikAddChange : Form
    {
        PredstavnikView predstavnik;

        public PredstavnikAddChange()
        {
            InitializeComponent();
        }

        public PredstavnikAddChange(PredstavnikView p)
        {
            predstavnik = p;
            InitializeComponent();
            PopuniPodacima();
            textJmbg.Enabled = false;
            textJmbg.BackColor = Color.LightGray;
        }

        public void PopuniPodacima()
        {
            textJmbg.Text = predstavnik.JMBG;
            textIme.Text = predstavnik.Ime;
            textPrezime.Text = predstavnik.Prezime;
            textPozicija.Text = predstavnik.Pozicija;
            textKontakt.Text = predstavnik.Telefon;
            textEmail.Text = predstavnik.Email;
        }
        private async void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                PredstavnikView pred = new PredstavnikView();
                pred.JMBG = textJmbg.Text;
                pred.Ime = textIme.Text;
                pred.Prezime = textPrezime.Text;
                pred.Pozicija = textPozicija.Text;
                pred.Telefon = textKontakt.Text;
                pred.Email = textEmail.Text;
                if (textJmbg.Text.Length != 13 || int.TryParse(textJmbg.Text, out _))
                {
                    MessageBox.Show("Neispravan JMBG!");
                    return;
                }
                if (!int.TryParse(textKontakt.Text, out _))
                {
                    MessageBox.Show("Neispravan telefon! Koristite samo brojeve!");
                    return;
                }
                if (string.IsNullOrEmpty(textJmbg.Text) || string.IsNullOrEmpty(textIme.Text) || string.IsNullOrEmpty(textPrezime.Text) ||
                    string.IsNullOrEmpty(textPozicija.Text) || string.IsNullOrEmpty(textKontakt.Text) || string.IsNullOrEmpty(textEmail.Text))
                {
                    MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (predstavnik == null)
                {
                    await DataProvider.DodajPredstavnika(pred);
                }
                else
                {
                    await DataProvider.IzmeniPredstavnika(pred, predstavnik.JMBG);
                }

                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textIme.Clear();
            textPrezime.Clear();
            textPozicija.Clear();
            textKontakt.Clear();
            textEmail.Clear();
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
    }
}