using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Entiteti;
using ProjekatVandredneSituacije.Forme2._0.VanrednaSituacija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace ProjekatVandredneSituacije.Forme2._0.IstorijaIntervencija
{
    public partial class IntervencijaAddChange : Form
    {
        IntervencijaView intervencijaa;
        
        public IntervencijaAddChange()
        {
            InitializeComponent();
        }

        
        public IntervencijaAddChange(IntervencijaView intervencija)
        {
            InitializeComponent();
            this.intervencijaa = intervencija;
            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            dateDatumVreme.Value = intervencijaa.Datum_I_Vreme;
            textLokacija.Text = intervencijaa.Lokacija;
            comboStatus.Text = intervencijaa.Status;
            textResursi.Text = intervencijaa.Resursi;
            numericSpaseni.Value = intervencijaa.Broj_Spasenih;
            numericPovredjeni.Value = intervencijaa.Broj_Povredjenih;
            numericUspesnost.Value = intervencijaa.Uspesnost;
        }

        private void IntervencijaAddChange_Load(object sender, EventArgs e)
        {
        }

        private void buttonRst_Click(object sender, EventArgs e)
        {
            dateDatumVreme.Value = DateTime.Now;
            textLokacija.Clear();
            comboStatus.SelectedIndex = -1;
            textResursi.Clear();
            numericSpaseni.Value = 0;
            numericPovredjeni.Value = 0;
            numericUspesnost.Value = 0;
        }

        private async void buttonSave_Click_1(object sender, EventArgs e)
        {
            IntervencijaBasicView intervencija = new IntervencijaBasicView();
            intervencija.Datum_I_Vreme = dateDatumVreme.Value;
            intervencija.Lokacija = textLokacija.Text; ;
            intervencija.Status = (Status)Enum.Parse(typeof (Status), comboStatus.Text);
            intervencija.Resursi = textResursi.Text;
            intervencija.Broj_Spasenih = (int)numericSpaseni.Value;
            intervencija.Broj_Povredjenih = (int)numericPovredjeni.Value;
            intervencija.Uspesnost = (int)numericUspesnost.Value;

            if (comboStatus.SelectedIndex == -1 || string.IsNullOrEmpty(textLokacija.Text) || string.IsNullOrEmpty(textResursi.Text))
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (intervencijaa == null)
            {
                await DataProvider.DodajIntervenciju(intervencija);
                MessageBox.Show("Uspesno ste dodali Intervenciju!", "Uspeh", MessageBoxButtons.OK);
            }
            else
            {
                await DataProvider.IzmeniIntervenciju(intervencija, intervencijaa.Id);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
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
