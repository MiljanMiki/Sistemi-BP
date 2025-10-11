using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Forme2._0.Specijalizacija;
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
    public partial class SpecijalizacijaForma : Form
    {
        KordinatorView kordinator;
        public SpecijalizacijaForma(KordinatorView kord)
        {
            InitializeComponent();
            kordinator = kord;
            popuniPodacima();
        }

        public async void popuniPodacima()
        {
            var podaci = await DataProvider.VratiSpecijalizacijeKoordinatora(kordinator.JMBG);
            dataGridView1.DataSource = podaci;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }


        private void buttonDodajOp_Click(object sender, EventArgs e)
        {
            var forma = new AddChangeSpecijalizacija(kordinator.JMBG);

            forma.ShowDialog();
            popuniPodacima();
        }

        private async void buttonIzmeniO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite specijalizaciju cije podatke zelite da izmenite!");
                return;
            }

            int id = Int32.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
            var specijalizacija = await DataProvider.VratiSpecijalizaciju(id);
            var forma = new AddChangeSpecijalizacija(specijalizacija);

            forma.ShowDialog();
            popuniPodacima();
        }

        private async void buttonObrisiO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite specijalizaciju koju zelite da obrisete!");
                return;
            }

            int id = Int32.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
            string poruka = "Da li zelite da obrisete izabranu specijalizaciju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiSpecijalizaciju(id);
                MessageBox.Show("Brisanje specijalizacije je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void Specijalizaja_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
