using ProjekatVandredneSituacije.Entiteti;
using ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica;
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
    public partial class DodajVoziloDijalog : Form
    {
        public DodajVoziloDijalog()
        {
            InitializeComponent();
        }

        

        private void buttonOpsta_Click_1(object sender, EventArgs e)
        {
            var forma = new DodajIzmeniSanitetska();
            forma.ShowDialog();
            this.Close();
        }

        private void buttonSpec_Click_1(object sender, EventArgs e)
        {
            var forma = new DodajIzmeniSpecijalna();
            forma.ShowDialog();
            this.Close();
        }

        private void buttonOdustani_Click_1(object sender, EventArgs e)
        {
            var forma = new DzipAddChange();
            forma.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var forma = new KamioniAddChange();
            forma.ShowDialog();
            this.Close();
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
