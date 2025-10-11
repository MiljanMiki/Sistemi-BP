using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Forme2._0.Prijava;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.Sluzba
{
    public partial class PredstavniciOverlay : Form
    {
        public PredstavniciOverlay()
        {
            InitializeComponent();
        }

        private void PredstavniciOverlay_Load(object sender, EventArgs e)
        {
            Ucitaj();
        }

        private async void Ucitaj()
        {
            var podaci = await DataProvider.VratiPredstavnike();
            dataGridView1.DataSource = podaci;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void buttonDodajOp_Click(object sender, EventArgs e)
        {
            PredstavnikAddChange forma = new PredstavnikAddChange();
            forma.ShowDialog();
            Ucitaj();
        }

        private async void buttonIzmeniO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo vas odaberite polje koje zelite da izmenite");
            }

            PredstavnikView pr = dataGridView1.CurrentRow.DataBoundItem as PredstavnikView;
            PredstavnikAddChange forma = new PredstavnikAddChange(pr);
            forma.ShowDialog();
            Ucitaj();
        }

        private async void buttonObrisiO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite predstavnika kojeg zelite da obrisete!");
                return;
            }


            PredstavnikView pr = dataGridView1.CurrentRow.DataBoundItem as PredstavnikView;
            string poruka = "Da li zelite da obrisete izabranu prijavu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiPredstavnika(pr.JMBG);
                MessageBox.Show("Brisanje prijave je uspesno obavljeno!");
                this.Ucitaj();
            }
            else
            {

            }
        }
    }
}
