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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatVandredneSituacije.Forme2._0.Vozila
{
    public partial class DodajIzmeniSpecijalna : Form
    {
        private readonly string Reg;
        public DodajIzmeniSpecijalna()
        {
            InitializeComponent();
            PopuniPodacima();
        }

        public DodajIzmeniSpecijalna(string Reg)
        {
            InitializeComponent();
            this.Reg = Reg;
            PopuniPodacima();
            textReg.Enabled = false;
            textReg.BackColor = Color.LightGray;
        }


        public async void PopuniPodacima()
        {
            comboStatus.DataSource = Enum.GetValues(typeof(StatusVozila));
            comboTip.DataSource = Enum.GetValues(typeof(Namena));
            if (Reg != null)
            {
                var specijalno = await DataProvider.VratiSpecijalnoVozilo(Reg);
                textReg.Text = specijalno.Registarska_Oznaka;
                textPro.Text = specijalno.Proizvodjac;
                textLokacija.Text = specijalno.Lokacija;

                comboStatus.SelectedItem = specijalno.Status;
                comboTip.SelectedItem = specijalno.Namena;
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            SpecijalnaVozilaAddView spec = new SpecijalnaVozilaAddView();
            spec.Registarska_Oznaka = textReg.Text;
            spec.Proizvodjac = textPro.Text;
            spec.Lokacija = textLokacija.Text;
            if (comboStatus.SelectedItem is StatusVozila statusEnum)
            {
                spec.Status = statusEnum;
            }
            if (comboTip.SelectedItem is Namena namenaEnum)
            {
                spec.Namena = namenaEnum;
            }

            if (Reg == null)
            {
                await DataProvider.DodajSpecijalnoVozilo(spec);
            }
            else
            {
                await DataProvider.IzmeniSpecijalnaVozila(spec, Reg);
            }


            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void buttonRst_Click(object sender, EventArgs e)
        {
            textPro.Clear();
            textLokacija.Clear();
            comboStatus.SelectedIndex = -1;
            comboTip.SelectedIndex = -1;
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

        private void DodajIzmeniSpecijalna_Load(object sender, EventArgs e)
        {
           
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
