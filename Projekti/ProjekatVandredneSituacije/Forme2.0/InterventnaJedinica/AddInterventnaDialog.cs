using ProjekatVandredneSituacije.Forme2._0.Vozila;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    public partial class AddIntervencijaDIjalog : Form
    {
        public AddIntervencijaDIjalog()
        {
            InitializeComponent();
        }

        private void buttonOpsta_Click(object sender, EventArgs e)
        {
            var forma = new AddChangeOpstu();
            forma.ShowDialog();
            this.Close();
        }

        private void buttonSpec_Click(object sender, EventArgs e)
        {
            var forma = new AddChangeSpecJed();
            forma.ShowDialog();
            this.Close();
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
    }
}
