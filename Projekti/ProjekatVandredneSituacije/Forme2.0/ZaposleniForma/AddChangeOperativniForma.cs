using NHibernate.Linq;
using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Entiteti;
using ProjekatVandredneSituacije.Mapiranja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ProjekatVandredneSituacije.Forme2._0.ZaposleniForma
{
    public partial class AddCHangeOperativniForma : Form
    {
        public OperativniRadnikView? OperativniRadnik;
        public AddCHangeOperativniForma()
        {
            InitializeComponent();
            PopuniCombo();
        }

       
        public AddCHangeOperativniForma(OperativniRadnikView radnik)
        {
            this.OperativniRadnik = radnik;
            InitializeComponent();
            PopuniPodacima();
            textJmbg.Enabled = false;
            textJmbg.BackColor = Color.LightGray;
        }

        public async void  PopuniCombo()
        {
            comboSpremnost.DataSource = Enum.GetValues(typeof(Spremnost));
            comboSpremnost.SelectedIndex = -1;
        }
        public async void PopuniPodacima()
        {
            PopuniCombo();
            textJmbg.Text = OperativniRadnik.JMBG;
            texIme.Text = OperativniRadnik.Ime;
            textPrezime.Text = OperativniRadnik.Prezime;
            dateRodjenje.Value = OperativniRadnik.Datum_Rodjenja;
            if (OperativniRadnik.Pol == "M")
            {
                checkMusko.Checked = true;
                checkZensko.Checked = false;
            }
            else if (OperativniRadnik.Pol == "Z")
            {
                checkMusko.Checked = false;
                checkZensko.Checked = true;
            }

            textKontakt.Text = OperativniRadnik.Kontakt_Telefon;
            textEmail.Text = OperativniRadnik.Email;
            textAdresa.Text = OperativniRadnik.AdresaStanovanja;
            dateZaposlenje.Value = OperativniRadnik.Datum_Zaposlenja;
            numericBrojSati.Value = OperativniRadnik.Broj_Sati;
            comboSpremnost.SelectedItem = OperativniRadnik.Fizicka_Spremnost;
            if (OperativniRadnik.InterventnaJedinica.Jedinstveni_Broj == null)
            {
                comboJedinica.SelectedIndex = -1;
            }
            else
                comboJedinica.SelectedValue = OperativniRadnik.InterventnaJedinica.Jedinstveni_Broj;

        }
        private async void AddCHangeOperativniForma_Load(object sender, EventArgs e)
        {
            var jedinice = await DataProvider.VratiSveJedinice();

            comboJedinica.DataSource = jedinice;
            comboJedinica.DisplayMember = "Naziv";
            comboJedinica.ValueMember = "Jedinstveni_Broj";
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            texIme.Clear();
            textPrezime.Clear();
            dateRodjenje.Value = DateTime.Now;
            checkMusko.Checked = false;
            checkZensko.Checked = false;
            textKontakt.Clear();
            textEmail.Clear();
            textAdresa.Clear();
            dateZaposlenje.Value = DateTime.Now;
            numericBrojSati.Value = 0;
            comboSpremnost.SelectedIndex = -1;
            comboJedinica.SelectedIndex = -1;
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

        private async void buttonCancel_Click(object sender, EventArgs e)
        {
            OperativniRadnikAddView operativni = new OperativniRadnikAddView();
            operativni.JMBG = textJmbg.Text;
            operativni.Ime = texIme.Text;
            operativni.Prezime = textPrezime.Text;
            operativni.Datum_Rodjenja = dateRodjenje.Value;
            operativni.Kontakt_Telefon = textKontakt.Text;
            operativni.Email = textEmail.Text;
            operativni.AdresaStanovanja = textAdresa.Text;
            operativni.Datum_Zaposlenja=dateZaposlenje.Value;
            operativni.Broj_Sati = (int)numericBrojSati.Value;
            operativni.Fizicka_Spremnost = (Spremnost)comboSpremnost.SelectedValue;
            if (textJmbg.Text.Length != 13 || int.TryParse(textJmbg.Text, out _))
            {
                MessageBox.Show("Neispravan JMBG!");
            }
            if (checkMusko.Checked == true)
            {
                operativni.Pol = "M";
            }
            else if (checkZensko.Checked == true)
            {
                operativni.Pol = "Z";
            }
            if (comboJedinica.SelectedValue != null)
            {
                operativni.InterventnaJedinica = (int)comboJedinica.SelectedValue;
            }
            else operativni.InterventnaJedinica = null;
            if (string.IsNullOrEmpty(textJmbg.Text) || string.IsNullOrEmpty(texIme.Text) || string.IsNullOrEmpty(textPrezime.Text) || string.IsNullOrEmpty(textKontakt.Text) || string.IsNullOrEmpty(textEmail.Text)||
                string.IsNullOrEmpty(textAdresa.Text)|| decimal.IsNegative(numericBrojSati.Value))
            {
                MessageBox.Show("Sva polja moraju biti popunjena.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (OperativniRadnik == null)
            {
                await DataProvider.DodajOperativnogRadnik(operativni);
            }
            else
            {
                await DataProvider.IzmeniOperativnog(operativni, OperativniRadnik.JMBG);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
