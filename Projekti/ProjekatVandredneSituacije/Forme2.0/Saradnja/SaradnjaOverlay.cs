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

namespace ProjekatVandredneSituacije.Forme2._0.Saradnja
{
    public partial class SaradnjaOverlay : Form
    {
        public SaradnjaOverlay()
        {
            InitializeComponent();
        }

        private void SaradnjaOverlay_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        private async void PopuniPodacima()
        {
            var podaci = await DataProvider.VratiSaradnje();
            dataGridView1.DataSource = podaci;

            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            DodajIzmeniSaradnju form = new DodajIzmeniSaradnju();
            form.ShowDialog();
            PopuniPodacima();
        }

        private async void button19_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo vas odaberite polje koje zelite da izmenite");
            }
            int saradnjaId = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            SaradjujeView saradjuje = await DataProvider.VratiSaradnju(saradnjaId);
            DodajIzmeniSaradnju forma = new DodajIzmeniSaradnju(saradjuje);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite saradnju koju zelite da obrisete!");
                return;
            }
            
            // Fix: Convert the cell value to string before parsing to int
            int id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            string poruka = "Da li zelite da obrisete izabranu saradnju?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiSaradnju(id);
                MessageBox.Show("Brisanje saradnje je uspesno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {

            }
        }

        private void saradjujeGetViewBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
