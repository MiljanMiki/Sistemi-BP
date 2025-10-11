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
    public partial class DodajIzmeniLicnuZastitu : Form
    {
        LicnaZastitaAddView licna;
        public DodajIzmeniLicnuZastitu()
        {
            InitializeComponent();
            PopuniComboe();
        }

        public DodajIzmeniLicnuZastitu(LicnaZastitaAddView liz)
        {
            InitializeComponent();
            licna = liz;
            PopuniPodacima();
        }

        public async void PopuniPodacima()
        {
            await PopuniComboe();
            textSb.Text = licna.Serijski_Broj;
            textNaziv.Text = licna.Naziv;
            comboStatus.SelectedItem = licna.Status;
            comboJedinica.SelectedValue = licna.JedinicaID;
            dateNabavka.Value = licna.DatumNabavke;
            comboTip.SelectedItem = licna.Tip;
        }

        private async Task PopuniComboe()
        {

            var jedinice = await DataProvider.VratiOpstejedinice();
            comboJedinica.DataSource = jedinice;
            comboJedinica.DisplayMember = "Naziv";
            comboJedinica.ValueMember = "Jedinstveni_Broj";

            comboTip.DataSource = Enum.GetValues(typeof(TipLicneZastite));
            comboStatus.DataSource = Enum.GetValues(typeof(StatusOpreme));
            comboJedinica.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            comboTip.SelectedIndex = -1;
        }
        private async void DodajIzmeniLicnuZastitu_Load(object sender, EventArgs e)
        {
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            LicnaZastitaAddView l = new LicnaZastitaAddView();
            l.Serijski_Broj = textSb.Text;
            l.Naziv = textNaziv.Text;
            l.Status = (StatusOpreme)comboStatus.SelectedValue;
            l.DatumNabavke = dateNabavka.Value;
            l.Tip = (TipLicneZastite)comboTip.SelectedValue;
            l.JedinicaID = (int)comboJedinica.SelectedValue;

            if (string.IsNullOrEmpty(textSb.Text) || string.IsNullOrEmpty(textNaziv.Text) ||
                  comboTip.SelectedIndex == -1 || comboJedinica.SelectedIndex == -1 || comboStatus.SelectedIndex == -1
                )
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (licna == null)
            {
                await DataProvider.DodajLicnuZastitu(l);
            }
            else
            {
                await DataProvider.IzmeniLicnuZastitu(l, licna.Serijski_Broj);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
