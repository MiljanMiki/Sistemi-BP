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
    public partial class DodajOpremuDijalog : Form
    {
        public DodajOpremuDijalog()
        {
            InitializeComponent();
        }

        private void buttonOpsta_Click(object sender, EventArgs e)
        {
            DodajIzmeniZalihe forma = new DodajIzmeniZalihe();
            forma.ShowDialog();
            this.Close();
        }

        private void buttonSpec_Click(object sender, EventArgs e)
        {
            DodajIzmeniMedicinsku forma = new DodajIzmeniMedicinsku();
            forma.ShowDialog();
            this.Close();
        }

        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            DodajIzmeniTehnicku forma = new DodajIzmeniTehnicku();
            forma.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DodajIzmeniLicnuZastitu forma = new DodajIzmeniLicnuZastitu();
            forma.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
