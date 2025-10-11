using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Forme2._0.IstorijaAgencije;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.IstorijaUcestvovanjaVozila
{
    public partial class UcestvovaloOverlay : Form
    {
        public UcestvovaloOverlay()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public async void popuniPodacima()
        {
            dataGridView1.DataSource = await DataProvider.VratiUcestvovanja();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        private void button20_Click(object sender, EventArgs e)
        {
            DodajUcestvovanje forma = new DodajUcestvovanje();
            forma.ShowDialog();
            popuniPodacima();
        }

        private async void button19_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite ucestvovanje cije podatke zelite da izmenite!");
                return;
            }

            var ucestvovalo = (UcestvovaloGetView)dataGridView1.CurrentRow.DataBoundItem;
            DodajUcestvovanje forma = new DodajUcestvovanje(ucestvovalo);
            forma.ShowDialog();
            popuniPodacima();
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite ucestvovanje koju zelite da obrisete!");
                return;
            }
            var ucestvovalo = dataGridView1.CurrentRow.DataBoundItem as UcestvovaloGetView;
            string poruka = "Da li zelite da obrisete izabranu istoriju vozila u intervenciji?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiUcestvovanje(ucestvovalo.Id);
                MessageBox.Show("Brisanje Istorije je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void UcestvovaloOverlay_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
