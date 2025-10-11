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
    public partial class SluzbaOverlay : Form
    {
        public SluzbaOverlay()
        {
            InitializeComponent();
        }

        private void SluzbaOverlay_Load(object sender, EventArgs e)
        {
            Popuni();
        }

        public async void Popuni()
        {
            var podaci = await DataProvider.VratiSluzbe();
            dataGridView1.DataSource = podaci;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void buttonDodaj_Click(object sender, EventArgs e)
        {
            SluzbaAddChange forma = new SluzbaAddChange();
            forma.ShowDialog();
            Popuni();
        }

        private async void buttonIzmeni_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo vas odaberite polje koje zelite da izmenite");
            }

            int IdSluzbe=Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            SluzbaView sl = await DataProvider.VratiSluzbu(IdSluzbe);
            SluzbaAddChange forma = new SluzbaAddChange(sl);
            forma.ShowDialog();
            Popuni();
        }

        private async void buttonObrisi_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite sluzbu koju zelite da obrisete!");
                return;
            }


            int id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            string poruka = "Da li zelite da obrisete izabranu sluzbu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiSluzbu(id);
                MessageBox.Show("Brisanje prijave je uspesno obavljeno!");
                this.Popuni();
            }
            else
            {

            }
        }
    }
}

