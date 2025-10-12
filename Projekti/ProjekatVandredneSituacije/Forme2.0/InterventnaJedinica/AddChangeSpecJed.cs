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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    public partial class AddChangeSpecJed : Form
    {
        SpecijalnaIntervetnaGetView specijalna;
        public AddChangeSpecJed()
        {
            InitializeComponent();
            PopuniPodacima();
        }

        public AddChangeSpecJed(SpecijalnaIntervetnaGetView sp)
        {
            InitializeComponent();
            specijalna = sp;
            PopuniPodacima();
            
        }

        public async void PopuniPodacima()
        {
            var operativni = await DataProvider.VratiOperativneRadnike();
            comboKomandir.DataSource = operativni;
            comboKomandir.DisplayMember = "PunoIme";
            comboKomandir.ValueMember = "JMBG";

            if (specijalna != null)
            {

                textNaziv.Text = specijalna.Naziv;
                textBaza.Text = specijalna.Baza;
                textTip.Text = specijalna.TipSpecijalneJedinice;

                if (specijalna.JMBGKomandira != null)
                {
                    comboKomandir.SelectedValue = specijalna.JMBGKomandira;
                    comboKomandir.Enabled = false;
                }
                else
                {
                    comboKomandir.SelectedIndex = -1;
                    comboKomandir.Enabled = true;
                }
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            SpecijalnaIntervetnaJedinicaBasicView spec = new SpecijalnaIntervetnaJedinicaBasicView();
            spec.Naziv = textNaziv.Text;
            spec.Baza = textBaza.Text;
            spec.JMBGKomandira = comboKomandir.SelectedValue.ToString();
            
            spec.TipSpecijalneJedinice = textTip.Text;
            if (string.IsNullOrEmpty(textNaziv.Text) || string.IsNullOrEmpty(textBaza.Text) ||
                string.IsNullOrEmpty(textTip.Text) || comboKomandir.SelectedIndex == -1)
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (specijalna == null)
            {
                await DataProvider.DodajSpecijalnuIntervetnuJedinicu(spec);
            }
            else
            {
                await DataProvider.izmeniSpecijalnuInterventnuJedinicu(spec, specijalna.Jedinstveni_Broj);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private async void comboKomandir_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var operativni = await DataProvider.VratiOperativneRadnike();
            //comboKomandir.DataSource = operativni;
            //comboKomandir.DisplayMember = "Ime";
            //comboKomandir.ValueMember = "JMBG";
        }

        private void buttonRst_Click(object sender, EventArgs e)
        {
            textNaziv.Clear();
            textBaza.Clear();
            comboKomandir.SelectedIndex = -1;
            textTip.Clear();
        }

        private void buttonCnc_Click(object sender, EventArgs e)
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

        private async void AddChangeSpecJed_Load(object sender, EventArgs e)
        {
            
        }
    }
}
