using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.ZaposleniForma
{
    public partial class ZaposleniAddDIjalog : Form
    {
        public ZaposleniAddDIjalog()
        {
            InitializeComponent();
        }

        private void ZaposleniAddDIjalog_Load(object sender, EventArgs e)
        {

        }

        private void buttonDodajO_Click(object sender, EventArgs e)
        {
            new AddCHangeOperativniForma().ShowDialog();
            Close();
        }

        private void buttonKoordinator_Click(object sender, EventArgs e)
        {
            new KoordAddChange().ShowDialog();
            Close();

        }


        private void buttonOdustani_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonAnaliticar_Click_1(object sender, EventArgs e)
        {
            new AddChangeAnaliticar().ShowDialog();

            Close();
        }
    }
}
