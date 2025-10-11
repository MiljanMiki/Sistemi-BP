using NHibernate.Util;
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

namespace ProjekatVandredneSituacije.Forme2._0.Vozila
{
    public partial class DodajIzmeniSanitetska : Form
    {
        SanitetskaView initial;
        public DodajIzmeniSanitetska()
        {
            InitializeComponent();
            PopuniPodacima();
        }

        public DodajIzmeniSanitetska(SanitetskaView sanitetska)
        {
            initial = sanitetska;
            InitializeComponent();
            PopuniPodacima();
            textReg.Enabled = false;
            textReg.BackColor = Color.LightGray;

        }

        private async void PopuniPodacima()
        {
            comboStatus.DataSource = Enum.GetValues(typeof(StatusVozila));
            if (initial != null)
            {

                textReg.Text = initial.Registarska_Oznaka;
                textLokacija.Text = initial.Lokacija;
                textPro.Text = initial.Proizvodjac;
                comboStatus.SelectedItem = initial.Status;
            }
        }

        private void buttonRst_Click(object sender, EventArgs e)
        {
            PopuniPodacima();
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
        private async void buttonSv_Click(object sender, EventArgs e)
        {
            var kvar = comboStatus.Text == "U_kvaru";

            var add = new SanitetskaAddView();
            add.Status = kvar ? Entiteti.StatusVozila.U_kvaru : Entiteti.StatusVozila.Operativno;
            add.Registarska_Oznaka = textReg.Text;
            add.Lokacija = textLokacija.Text;
            add.Proizvodjac = textPro.Text;

            var change = new SanitetskaChangeView();
            change.Status = kvar ? Entiteti.StatusVozila.U_kvaru : Entiteti.StatusVozila.Operativno;
            change.Lokacija = textLokacija.Text;
            change.Proizvodjac = textPro.Text;

            bool hasError = false;
            if (string.IsNullOrEmpty(textReg.Text)) hasError = true;
            if (string.IsNullOrEmpty(textLokacija.Text)) hasError = true;
            if (string.IsNullOrEmpty(textPro.Text)) hasError = true;

            if (hasError)
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (initial == null)
            {
                await DataProvider.DodajSanitetskaVozilo(add);
            }
            else
            {
                await DataProvider.IzmeniSanitetskoVozilo(change, initial.Registarska_Oznaka);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void DodajIzmeniSanitetska_Load(object sender, EventArgs e)
        {
            
        }
    }
}
