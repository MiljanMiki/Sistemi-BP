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
    public partial class DzipAddChange : Form
    {
        public readonly string Reg_Oznaka;
        public DzipAddChange()
        {
            InitializeComponent();
            PopuniPodacima();
        }

        public DzipAddChange(string Reg_Oznaka)
        {
            InitializeComponent();
            this.Reg_Oznaka = Reg_Oznaka;
            PopuniPodacima();
            textReg.Enabled = false;
            textReg.BackColor = Color.LightGray;
        }

        public async void PopuniPodacima()
        {
            comboStatus.DataSource = Enum.GetValues(typeof(StatusVozila));
            if (Reg_Oznaka != null)
            {
                var Dzip = await DataProvider.VratiDzip(Reg_Oznaka);
                textReg.Text = Dzip.Registarska_Oznaka;
                textProizvodjac.Text = Dzip.Proizvodjac;

                textLok.Text = Dzip.Lokacija;
                comboStatus.SelectedItem = Dzip.Status;
            }
          
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DzipAddChange_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textProizvodjac.Clear();
            textLok.Clear();
            comboStatus.SelectedIndex = -1;
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

        private async void buttonSacuvaj_Click(object sender, EventArgs e)
        {
            DzipoviAddView dz = new DzipoviAddView();
            dz.Registarska_Oznaka = textReg.Text;
            dz.Proizvodjac = textProizvodjac.Text;
            dz.Lokacija = textLok.Text;
            if (comboStatus.SelectedItem is StatusVozila statusEnum)
            {
                dz.Status = statusEnum;
            }

            if (Reg_Oznaka == null)
            {
                await DataProvider.DodajDzip(dz);
            }
            else
            {
                await DataProvider.IzmeniDzip(dz, Reg_Oznaka);
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

