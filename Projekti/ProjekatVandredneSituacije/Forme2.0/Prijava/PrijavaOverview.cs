using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Forme2._0.Ekspertiza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.Prijava
{
    public partial class PrijavaOverview : Form
    {
        public PrijavaOverview()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void PrijavaOverview_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        public async void PopuniPodacima()
        {
            var podaci = await DataProvider.VratiPrijave();
            dataGridView1.DataSource = podaci;

            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            PrijavaAddChange formaPrijava = new PrijavaAddChange();
            formaPrijava.ShowDialog();
            PopuniPodacima();
        }

        private async void buttonIzmeni_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Molimo vas odaberite polje koje zelite da izmenite");
            }
            var prijava = dataGridView1.CurrentRow.DataBoundItem as PrijavaView;
            PrijavaAddChange forma = new PrijavaAddChange(prijava);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private async void buttonObrisi_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite prijavu koju zelite da obrisete!");
                return;
            }
            var prijava = dataGridView1.CurrentRow.DataBoundItem as PrijavaView;

            string poruka = "Da li zelite da obrisete izabranu prijavu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiPrijavu(prijava.Id);
                MessageBox.Show("Brisanje prijave je uspesno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {

            }
        }
    }
}
