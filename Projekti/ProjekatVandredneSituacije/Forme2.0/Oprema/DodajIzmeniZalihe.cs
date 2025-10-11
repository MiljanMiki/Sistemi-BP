using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjekatVandredneSituacije.Forme2._0.Oprema
{
    public partial class DodajIzmeniZalihe : Form
    {
        ZaliheAddView Zalihe;
        public DodajIzmeniZalihe()
        {
            InitializeComponent();
            PopuniComboe();
        }

        public DodajIzmeniZalihe(ZaliheAddView zalihe)
        {
            InitializeComponent();
            this.Zalihe = zalihe;
            PopuniPodacima();
            textSb.Enabled = false;
            textSb.BackColor = Color.LightGray;
        }
        public async void PopuniPodacima()
        {
            await PopuniComboe();
            textSb.Text = Zalihe.Serijski_Broj;
            textNaziv.Text = Zalihe.Naziv;
            comboStatus.SelectedItem = Zalihe.Status;
            comboJed.SelectedValue = Zalihe.JedinicaID;
            dateDatumNabavke.Value = Zalihe.DatumNabavke;
            comboTip.SelectedItem = Zalihe.Tip;
            numericUpDown1.Value = Zalihe.Kolicina;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            ZaliheAddView zal = new ZaliheAddView();
            zal.Serijski_Broj = textSb.Text;
            zal.Naziv = textNaziv.Text;
            zal.Status = (StatusOpreme)comboStatus.SelectedValue;
            zal.DatumNabavke = dateDatumNabavke.Value;
            zal.Tip = (TipZalihe)comboTip.SelectedValue;
            zal.JedinicaID = (int)comboJed.SelectedValue;
            zal.Kolicina = (int)numericUpDown1.Value;
            if (string.IsNullOrEmpty(textSb.Text) || string.IsNullOrEmpty(textNaziv.Text) ||
                  comboTip.SelectedIndex == -1 || comboJed.SelectedIndex == -1 || comboStatus.SelectedIndex == -1
                || numericUpDown1.Value < 0)
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Zalihe == null)
            {
                await DataProvider.DodajZalihe(zal);
            }
            else
            {
                await DataProvider.IzmeniZalihe(zal, Zalihe.Serijski_Broj);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async Task PopuniComboe()
        {
            var jedinice = await DataProvider.VratiSveJedinice();
            comboJed.DataSource = jedinice;
            comboJed.DisplayMember = "Naziv";
            comboJed.ValueMember = "Jedinstveni_Broj";

            comboTip.DataSource = Enum.GetValues(typeof(TipZalihe));
            comboStatus.DataSource = Enum.GetValues(typeof(StatusOpreme));
            comboJed.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            comboTip.SelectedIndex = -1;

        }
        private async void DodajIzmeniZalihe_Load(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textNaziv.Clear();
            dateDatumNabavke.Value = DateTime.Now;
            comboJed.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            comboTip.SelectedIndex = -1;
            numericUpDown1.Value = 0;
        }

        private void button2_Click(object sender, EventArgs e)
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
