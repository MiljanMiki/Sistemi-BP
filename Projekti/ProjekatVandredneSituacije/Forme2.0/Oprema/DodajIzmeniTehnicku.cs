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

namespace ProjekatVandredneSituacije.Forme2._0.Oprema
{
    public partial class DodajIzmeniTehnicku : Form
    {
        TehnickaOpremaAddView tehnicka;
        public DodajIzmeniTehnicku()
        {
            InitializeComponent();
            PopuniComboe();
        }

        public DodajIzmeniTehnicku(TehnickaOpremaAddView t)
        {
            this.tehnicka = t;
            InitializeComponent();
            PopuniPodacima();
            textSb.Enabled = false;
            textSb.BackColor = Color.LightGray;

        }

        public async void PopuniPodacima()
        {
            await PopuniComboe();
            textSb.Text = tehnicka.Serijski_Broj;
            textNaziv.Text = tehnicka.Naziv;
            comboStatus.SelectedItem = tehnicka.Status;
            comboJedinica.SelectedValue = tehnicka.JedinicaID;
            dateTimePicker1.Value = tehnicka.DatumNabavke;
            comboTip.SelectedItem = tehnicka.Tip;
        }

        private async Task PopuniComboe()
        {
            var jedinice = await DataProvider.VratiSpecijalneJedinice();
            comboJedinica.DataSource = jedinice;
            comboJedinica.DisplayMember = "Naziv";
            comboJedinica.ValueMember = "Jedinstveni_Broj";

            comboStatus.DataSource = Enum.GetValues(typeof(StatusOpreme));
            comboTip.DataSource = Enum.GetValues(typeof(TipTehnicke));

            comboJedinica.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            comboTip.SelectedIndex = -1;

        }
        private async void DodajIzmeniTehnicku_Load(object sender, EventArgs e)
        {
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            TehnickaOpremaAddView teh = new TehnickaOpremaAddView();
            teh.Serijski_Broj = textSb.Text;
            teh.Naziv = textNaziv.Text;
            teh.Status = (StatusOpreme)comboStatus.SelectedValue;
            teh.DatumNabavke = dateTimePicker1.Value;
            teh.Tip = (TipTehnicke)comboTip.SelectedValue;
            teh.JedinicaID = (int)comboJedinica.SelectedValue;
            if (string.IsNullOrEmpty(textSb.Text) || string.IsNullOrEmpty(textNaziv.Text) ||
                  comboTip.SelectedIndex == -1 || comboJedinica.SelectedIndex == -1 || comboStatus.SelectedIndex == -1
               )
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tehnicka == null)
            {
                await DataProvider.DodajTehnickuOpremu(teh);
            }
            else
            {
                await DataProvider.IzmeniTehnickuOpremu(teh, tehnicka.Serijski_Broj);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textNaziv.Clear();
            dateTimePicker1.Value = DateTime.Now;
            comboJedinica.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            comboTip.SelectedIndex = -1;
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
