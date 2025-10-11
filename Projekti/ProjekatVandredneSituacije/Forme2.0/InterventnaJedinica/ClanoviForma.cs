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

namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    public partial class ClanoviForma : Form
    {
        public readonly int idJedinice;
        public ClanoviForma(int idJedinice)
        {
            InitializeComponent();
            this.idJedinice = idJedinice;
            PopuniPodacima();
        }

        public async void PopuniPodacima()
        {
            dataGridView1.DataSource = await DataProvider.VratiOperativneRadnikeIzJedincie(idJedinice);
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();

        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite radnika kog zelite da obrisete!");
                return;
            }

            var radnik = dataGridView1.CurrentRow.DataBoundItem as ZaposleniView;
            string poruka = "Da li zelite da obrisete izabranog radnika?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiOperativnogRadnika(radnik.JMBG);
                MessageBox.Show("Brisanje radnika je uspesno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
