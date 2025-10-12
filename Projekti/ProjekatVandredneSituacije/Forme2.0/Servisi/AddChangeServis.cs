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

namespace ProjekatVandredneSituacije.Forme2._0.Servisi
{
    public partial class AddChangeServis : Form
    {
        public readonly string RegistarskaOznaka;
        public ServisiView servis;

        public AddChangeServis(string RegistarskaOznaka)
        {
            InitializeComponent();
            this.RegistarskaOznaka = RegistarskaOznaka;
            txtVozilo.Text = RegistarskaOznaka;
            txtVozilo.ReadOnly = true;
            txtVozilo.BackColor = Color.LightGray;
        }

        public AddChangeServis(ServisiView servis)
        {
            this.servis = servis;
            InitializeComponent();
            PopuniZaIzmenu();
            txtVozilo.ReadOnly = true;
            txtVozilo.BackColor = Color.LightGray;
        }

        public void PopuniZaIzmenu()
        {
            txtVozilo.Text = servis.RegistarskaOznakaVozila;
            txtTip.Text = servis.TipServisa;
            dateTimePicker1.Value = servis.Datum;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            ServisiAddView servisi = new ServisiAddView();
            servisi.RegistarskaOznakaVozila = txtVozilo.Text ;
            servisi.TipServisa = txtTip.Text;
            servisi.Datum = dateTimePicker1.Value;
            if (string.IsNullOrEmpty(txtTip.Text))
            {
                MessageBox.Show("Niste uneli validnu vrednost za TipServisa");
                return;
            }
            if (servis == null)
            {
                await DataProvider.DodajServis(servisi);
                MessageBox.Show("Uspesno ste dodali servis");
            }
            else
            {
                await DataProvider.IzmeniServis(servisi, servis.Id);
                MessageBox.Show("Uspesno ste izmenili servis");
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

        private void AddChangeServis_Load(object sender, EventArgs e)
        {
        
        }
    }
}
