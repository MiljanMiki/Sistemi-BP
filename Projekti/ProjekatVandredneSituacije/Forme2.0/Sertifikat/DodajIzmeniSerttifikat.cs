using FluentNHibernate.Conventions;
using NHibernate.Hql.Ast;
using NHibernate.Mapping;
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

namespace ProjekatVandredneSituacije.Forme2._0.Sertifikat
{
    public partial class DodajIzmeniSerttifikat : Form
    {
        SertifikatIdAddView si;
        SertifikatGetView s;
        public readonly string JMBG;
        public DodajIzmeniSerttifikat()
        {
            InitializeComponent();
            
        }

        public DodajIzmeniSerttifikat(string JMBG)
        {
            InitializeComponent();
            this.JMBG = JMBG;
            textJMBG.Text = JMBG;
            textJMBG.Enabled = false;
            textJMBG.BackColor = Color.LightGray;
        }

        public DodajIzmeniSerttifikat(SertifikatGetView sert)
        {
            InitializeComponent();
            this.s = sert;
            LoadPodaci();
           
        }
        public async void LoadPodaci()
        {
            if (JMBG != null)
            {
                string JMBG = s.JMBGOperativnogRadnika;
                textJMBG.Text = JMBG;
                textJMBG.Enabled = false;
                textJMBG.BackColor = Color.LightGray;
            }
            if (s != null)
            {
                textJMBG.Text = s.JMBGOperativnogRadnika;
                textJMBG.Enabled = false;
                textJMBG.BackColor = Color.LightGray;
                textNaziv.Text = s.Naziv;
                textNaziv.Enabled = false;
                textNaziv.BackColor = Color.LightGray;

                textInstitucija.Text = s.Institucija;
                textInstitucija.Enabled = false;
                textInstitucija.BackColor = Color.LightGray;

                dateIzdavanje.Value = s.DatumIzdavanja;

                if (s.DatumVazenja != null)
                    dateVazenje.Value = (DateTime)s.DatumVazenja;
                else
                    dateVazenje.Value = DateTime.Now;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SertifikatView sertifikat = new SertifikatView
            {
                Id = new SertifikatIdAddView
                {
                    JMBGRadnika = string.IsNullOrWhiteSpace(this.JMBG) ? textJMBG.Text.Trim() : this.JMBG,
                    Naziv = textNaziv.Text.Trim(),
                    Institucija = textInstitucija.Text.Trim()
                },
                DatumIzdavanja = dateIzdavanje.Value,
                DatumVazenja = dateVazenje.Checked ? dateVazenje.Value : (DateTime?)null
            };

            if (string.IsNullOrEmpty(sertifikat.Id.JMBGRadnika)|| string.IsNullOrEmpty(sertifikat.Id.Naziv)|| string.IsNullOrEmpty(sertifikat.Id.Institucija)||
               (!dateIzdavanje.Checked))
            {
                MessageBox.Show("Niste uneli validnu vrednost za neko od obaveznih polja");
                return;
            }
            if (s == null)
            {
                await DataProvider.DodajSertifikat(sertifikat);
            }
            else
            {
                await DataProvider.IzmeniSertifikat(sertifikat);
                MessageBox.Show("Uspesno ste izmenili sertifikat");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textNaziv.Clear();
            textInstitucija.Clear();
            dateIzdavanje.Value= DateTime.Now;
            dateVazenje.Value = DateTime.Now;
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
