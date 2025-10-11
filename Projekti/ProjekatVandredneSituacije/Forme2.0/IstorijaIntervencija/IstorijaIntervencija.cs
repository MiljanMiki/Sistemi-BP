using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Entiteti;
using ProjekatVandredneSituacije.Forme2._0.IstorijaAgencije;
using ProjekatVandredneSituacije.Forme2._0.IstorijaUcestvovanjaVozila;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.IstorijaIntervencija
{
    public partial class IstorijaIntervencija : Form
    {
        public IstorijaIntervencija()
        {
            InitializeComponent();
        }

        private void IstorijaIntervencija_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        private async void PopuniPodacima()
        {
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = await DataProvider.VratiIntervencije();

            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IntervencijaAddChange forma = new IntervencijaAddChange();
            forma.ShowDialog();
            PopuniPodacima();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite intervenciju cije podatke zelite da izmenite!");
                return;
            }

            IntervencijaView istorija = (IntervencijaView)dataGridView1.CurrentRow.DataBoundItem;
            IntervencijaAddChange forma = new IntervencijaAddChange(istorija);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite intervenciju koju zelite da obrisete!");
                return;
            }

            IntervencijaView intervencija = (IntervencijaView)dataGridView1.CurrentRow.DataBoundItem;
            string poruka = "Da li zelite da obrisete intervenciju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                    await DataProvider.ObrisiIntervenciju(intervencija.Id);
                    MessageBox.Show("Brisanje intervencije je uspesno obavljeno!");
                    this.PopuniPodacima();
            }
            else
            {

            }
        }
    }
}
