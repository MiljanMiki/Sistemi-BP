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

namespace ProjekatVandredneSituacije.Forme2._0.Specijalizacija
{
    
    public partial class AddChangeSpecijalizacija : Form
    {

        private SpecijalizacijaView specijalizacijaa;
        private readonly string JMBG;
        public AddChangeSpecijalizacija(string JMBG)
        {
            InitializeComponent();
            this.JMBG = JMBG;
            txtKoordinator.Text = JMBG;
            txtKoordinator.ReadOnly = true;
            txtKoordinator.BackColor = Color.LightGray;
        }

       

        public AddChangeSpecijalizacija(SpecijalizacijaView specijalizacija)
        {

            this.specijalizacijaa = specijalizacija;
            InitializeComponent();
            PopuniZaIzmenu();
            txtKoordinator.ReadOnly = true;
            txtKoordinator.BackColor = Color.LightGray;
        }

        private async void PopuniZaIzmenu()
        {
            txtKoordinator.Text = specijalizacijaa.JMBG_Kordinatora;
            txtTip.Text = specijalizacijaa.Tip;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            SpecijalizacijaAddView specijalizacija = new SpecijalizacijaAddView();
            specijalizacija.JMBG_Kordinator = txtKoordinator.Text; ;
            specijalizacija.Tip = txtTip.Text;
            if (string.IsNullOrEmpty(specijalizacija.Tip))
            {
                MessageBox.Show("Niste uneli validnu vrednost za Oblast");
                return;
            }
            if (specijalizacijaa == null)
            {
                await DataProvider.DodajSpecijalizaciju(specijalizacija);
                MessageBox.Show("Uspesno ste dodali ekspertizu");
            }
            else
            {
                await DataProvider.IzmeniSpecijalizaciju(specijalizacija, specijalizacijaa.Id);
                MessageBox.Show("Uspesno ste izmenili ekspertzu");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtTip.Clear();
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
