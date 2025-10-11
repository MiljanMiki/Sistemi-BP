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

namespace ProjekatVandredneSituacije.Forme2._0.Prijava
{
    public partial class PrijavaAddChange : Form
    {
        public PrijavaView prijava;
        public PrijavaAddChange()
        {
            InitializeComponent();
            dateDatumVreme.Format = DateTimePickerFormat.Custom;
        }

        public PrijavaAddChange(PrijavaView prijava)
        {
            InitializeComponent();
            this.prijava = prijava;
            PopuniPodacima();

        }

        public async void PopuniPodacima()
        {

            dateDatumVreme.Value = prijava.Datum_I_Vreme;
            textTip.Text = prijava.Tip;
            textIme.Text = prijava.Ime_Prijavioca;
            textKontakt.Text = prijava.Kontakt;
            textLokacija.Text = prijava.Lokacija;
            textOpis.Text = prijava.Opis;
            textDispecer.Text = prijava.JMBG_Dispecer;
            numericUpDown1.Value = (int)prijava.Prioritet;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            PrijavaAddView pr = new PrijavaAddView();
            pr.Datum_I_Vreme = dateDatumVreme.Value;
            pr.Tip = textTip.Text;
            pr.Ime_Prijavioca = textIme.Text;
            pr.Kontakt = textKontakt.Text;
            pr.Lokacija = textLokacija.Text;
            pr.Opis = textOpis.Text;
            pr.Prioritet = (int)numericUpDown1.Value;
            pr.JMBG_Dispecer = textDispecer.Text;
            if (!dateDatumVreme.Checked || string.IsNullOrEmpty(textTip.Text) || string.IsNullOrEmpty(textIme.Text) || string.IsNullOrEmpty(textKontakt.Text) ||
                string.IsNullOrEmpty(textLokacija.Text) || string.IsNullOrEmpty(textOpis.Text) || string.IsNullOrEmpty(textDispecer.Text) || numericUpDown1.Value <= 0)
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (prijava == null)
            {
                await DataProvider.DodajPrijavu(pr);
            }
            else
            {
                await DataProvider.IzmeniPrijavu(pr, prijava.Id);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonRst_Click(object sender, EventArgs e)
        {
            dateDatumVreme.Value = DateTime.Now;
            textTip.Clear();
            textIme.Clear();
            textKontakt.Clear();
            textLokacija.Clear();
            textOpis.Clear();
            numericUpDown1.Value = 0;
            textDispecer.Clear();
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
    }
}
