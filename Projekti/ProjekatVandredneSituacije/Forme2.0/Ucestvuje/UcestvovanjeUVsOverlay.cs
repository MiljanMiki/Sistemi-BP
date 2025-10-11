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

namespace ProjekatVandredneSituacije.Forme2._0.Ucestvuje
{
    public partial class UcestvovanjeUVsOverlay : Form
    {

        public UcestvovanjeUVsOverlay()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            AddChangeUcestvovanje forma = new AddChangeUcestvovanje();
            forma.ShowDialog();
            popuniPodacima();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite ucestovanje cije podatke zelite da izmenite!");
                return;
            }
            var ucestvuje = dataGridView1.CurrentRow.DataBoundItem as UcestvujeGetView;

            var forma = new AddChangeUcestvovanje(ucestvuje);
            forma.ShowDialog();
            popuniPodacima();
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite ucestvovanje koje zelite da obrisete!");
                return;
            }

            var ucestvuje = dataGridView1.CurrentRow.DataBoundItem as UcestvujeGetView;
            string poruka = "Da li zelite da obrisete izabrano ucestovanje?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiUcestvuje(ucestvuje.Id);
                MessageBox.Show("Brisanje ucestvovanja je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        public async void popuniPodacima()
        {
            var podaci = await DataProvider.VratiSvaUcestvovanja();
            dataGridView1.DataSource = podaci;

            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void ucestvujeViewBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void UcestvovanjeUVsOverlay_Load_1(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
