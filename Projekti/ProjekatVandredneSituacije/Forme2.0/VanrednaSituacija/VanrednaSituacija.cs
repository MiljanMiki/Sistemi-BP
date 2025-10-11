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

namespace ProjekatVandredneSituacije.Forme2._0.VanrednaSituacija
{
    public partial class VanrednaSituacija : Form
    {
        VanrednaSituacijaView vanrednaSituacija;
        public VanrednaSituacija()
        {
            InitializeComponent();
            PopuniPrijave();
        }

        public VanrednaSituacija(VanrednaSituacijaView vanrednaSituacija)
        {
            InitializeComponent();
            this.vanrednaSituacija = vanrednaSituacija;
            PopuniPodacima();

        }

        public async Task PopuniPrijave()
        {
            comboBoxPrijava.DataSource = await DataProvider.VratiPrijave();
            comboBoxPrijava.DisplayMember = "Id";
            comboBoxPrijava.ValueMember = "Id";
            comboBoxPrijava.SelectedValue = vanrednaSituacija?.Prijava.Id;

        }
        public async void PopuniPodacima()
        {
            await PopuniPrijave();
            dateTimePickerOd.Value = vanrednaSituacija.Datum_Od;
            if (vanrednaSituacija.Datum_Do != null)
            {
                dateTimePickerDo.Value = (DateTime)vanrednaSituacija.Datum_Do;
            }
            textBoxTip.Text = vanrednaSituacija.Tip;
            numericBrojUgrozenih.Value = vanrednaSituacija.Broj_Ugrozenih_Osoba ?? 0;
            comboBoxOpasnost.Text = vanrednaSituacija.Nivo_Opasnosti.ToString();
            textBoxOpstina.Text = vanrednaSituacija.Opstina;
            textBoxLokacija.Text = vanrednaSituacija.Lokacija;
            textBoxOpis.Text = vanrednaSituacija.Opis;
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        private async void buttonSacuvaj_Click(object sender, EventArgs e)
        {

            bool hasError = false;
            if (string.IsNullOrEmpty(textBoxTip.Text)) hasError = true;
            if (string.IsNullOrEmpty(textBoxOpstina.Text)) hasError = true;
            if (comboBoxPrijava.SelectedIndex < 0) hasError = true;

            if (hasError)
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var situacijaAdd = new VanrednaSituacijaAddView();
            situacijaAdd.Lokacija = textBoxLokacija.Text;
            situacijaAdd.Datum_Od = dateTimePickerOd.Value;
            situacijaAdd.Datum_Do = dateTimePickerDo.Value;
            situacijaAdd.Tip = textBoxTip.Text;
            situacijaAdd.Broj_Ugrozenih_Osoba = (int)numericBrojUgrozenih.Value;
            situacijaAdd.IdPrijave = (int)comboBoxPrijava.SelectedValue;
            situacijaAdd.Lokacija = textBoxLokacija.Text;
            situacijaAdd.Opstina = textBoxOpstina.Text;
            situacijaAdd.Opis = textBoxOpis.Text;

            if (comboBoxOpasnost.Text == "nizak")
            {
                situacijaAdd.Nivo_Opasnosti = Entiteti.NivoOpasnosti.nizak;
            }
            else if (comboBoxOpasnost.Text == "srednji")
            {
                situacijaAdd.Nivo_Opasnosti = Entiteti.NivoOpasnosti.srednji;
            }
            else if (comboBoxOpasnost.Text == "visok")
            {
                situacijaAdd.Nivo_Opasnosti = Entiteti.NivoOpasnosti.visok;
            }

            if (vanrednaSituacija != null)
            {
                await DataProvider.IzmeniVanrednuSituaciju(situacijaAdd, vanrednaSituacija.Id);
            }
            else
            {
                await DataProvider.DodajVanrednuSituaciju(situacijaAdd);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
