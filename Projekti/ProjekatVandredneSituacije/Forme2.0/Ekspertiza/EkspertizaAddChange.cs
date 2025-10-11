using ProjekatVandredneSituacije.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.Ekspertiza
{
    public partial class EkspertizaAddChange : Form
    {
        EkspertizaView eksp;
        private readonly string JMBG;
        public EkspertizaAddChange()
        {
            InitializeComponent();
        }

        public EkspertizaAddChange(string JMBG)
        {
            InitializeComponent();
            this.JMBG = JMBG;
            textJMBG.Text = JMBG;
            textJMBG.ReadOnly = true;
            textJMBG.BackColor = Color.LightGray;
        }

        public EkspertizaAddChange(EkspertizaView eksp)
        {
            this.eksp = eksp;
            InitializeComponent();
            PopuniZaIzmenu();
 
            textJMBG.ReadOnly = true;
            textJMBG.BackColor = Color.LightGray;
        }

        private async void PopuniZaIzmenu()
        {
            textJMBG.Text=eksp.JMBGAnaliticara;
            textOblast.Text=eksp.Oblast;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            EkspertizaChangeView Ekspertiza = new EkspertizaChangeView();
            Ekspertiza.JMBGAnaliticara = JMBG;
            Ekspertiza.Oblast = textOblast.Text;
            if (string.IsNullOrEmpty(Ekspertiza.Oblast))
            {
                MessageBox.Show("Niste uneli validnu vrednost za Oblast");
            }
            if(eksp==null)
            {
                await DataProvider.DodajEkspertizu(Ekspertiza);
                MessageBox.Show("Uspesno ste dodali ekspertizu");
                
            }
            else
            {
                await DataProvider.IzmeniEkspertizu(Ekspertiza, eksp.Id);
               MessageBox.Show("Uspesno ste izmenili ekspertzu");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void buttonReset_Click(object sender, EventArgs e)
        {
            textOblast.Clear();
        }

        private void buttonAbort_Click(object sender, EventArgs e)
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