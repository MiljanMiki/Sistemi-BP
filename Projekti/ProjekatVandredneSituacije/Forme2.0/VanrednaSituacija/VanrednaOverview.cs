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

namespace ProjekatVandredneSituacije.Forme2._0.VanrednaSituacija
{
    public partial class VanrednaOverview : Form
    {
        public VanrednaOverview()
        {
            InitializeComponent();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            var forma = new VanrednaSituacija();
            forma.ShowDialog();
            popuniPodacima();
        }

        private void buttonIzmeni_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vanrednu situaciju cije podatke zelite da izmenite!");
                return;
            }

            var situacija = dataGridView1.CurrentRow.DataBoundItem as VanrednaSituacijaView;
            var forma = new VanrednaSituacija(situacija);
            forma.ShowDialog();
            popuniPodacima();
        }

        private async void buttonObrisi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vanrednu situaciju koju zelite da obrisete!");
                return;
            }

            var situacija = dataGridView1.CurrentRow.DataBoundItem as VanrednaSituacijaView;

            string poruka = "Da li zelite da obrisete izabranu vanrednu situaciju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.obrisiVanrednuSituaciju(situacija.Id);
                MessageBox.Show("Brisanje Vanredne Situacije je uspesno obavljeno!");
                this.popuniPodacima();
            }
            else
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VanrednaOverview_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public async void popuniPodacima()
        {
            var podaci = await DataProvider.VratiVanredneSituacije();
            dataGridView1.DataSource = podaci;

            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

    }
}
