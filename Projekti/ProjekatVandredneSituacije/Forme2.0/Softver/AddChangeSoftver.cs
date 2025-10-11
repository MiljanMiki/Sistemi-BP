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

namespace ProjekatVandredneSituacije.Forme2._0.Softver
{

    public partial class AddChangeSoftver : Form
    {
        public readonly SoftverView Softver;
        public readonly string JMBG;
        public AddChangeSoftver()
        {
            InitializeComponent();
        }

        public AddChangeSoftver(string JMBG)
        {
            InitializeComponent();
            this.JMBG = JMBG;
            textJMBG.Text = JMBG;
            textJMBG.ReadOnly = true;
            textJMBG.BackColor = Color.LightGray;
        }

        public AddChangeSoftver(SoftverView s)
        {
            InitializeComponent();
            this.Softver = s;
            PopuniZaIzmenu();
            textJMBG.ReadOnly = true;
            textJMBG.BackColor = Color.LightGray;
        }

        public async void PopuniZaIzmenu()
        {
            
            textJMBG.Text = Softver.JMBGAnaliticara;
            textNaziv.Text = Softver.Naziv;
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

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textNaziv.Clear();
        }

        private async void ave_Click(object sender, EventArgs e)
        {
            SoftverAddView s = new SoftverAddView();
            s.JMBG_Analiticar = textJMBG.Text;
            s.Naziv= textNaziv.Text;
            if (string.IsNullOrEmpty(s.Naziv))
            {
                MessageBox.Show("Niste uneli validnu vrednost za Oblast");
            }
            if (Softver == null)
            {
                await DataProvider.DodajSoftver(s);
                MessageBox.Show("Uspesno ste dodali ekspertizu");

            }
            else
            {
                await DataProvider.IzmeniSoftver(s, Softver.Id);
                MessageBox.Show("Uspesno ste izmenili ekspertzu");
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
