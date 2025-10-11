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

namespace ProjekatVandredneSituacije.Forme2._0.Softver
{
    public partial class SoftverOverlay : Form
    {
        AnaliticarView Analiticar;
        public SoftverOverlay(AnaliticarView an)
        {
            InitializeComponent();
            Analiticar = an;
            popuniPodacima();
        }

        private void buttonDodajOp_Click(object sender, EventArgs e)
        {
            var forma = new AddChangeSoftver(Analiticar.JMBG);
            forma.ShowDialog();
            popuniPodacima();
        }

        private void buttonIzmeniO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite softver cije podatke zelite da izmenite!");
                return;
            }
            var softver = dataGridView1.CurrentRow.DataBoundItem as DTOs.SoftverView;

            var forma = new AddChangeSoftver(softver);
            forma.ShowDialog();

            popuniPodacima();
        }

        private async void buttonObrisiO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite softver koju zelite da obrisete!");
                return;
            }
            string poruka = "Da li zelite da obrisete izabrani softver?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                var softver = dataGridView1.SelectedRows[0].DataBoundItem as DTOs.SoftverView;
                await DataProvider.ObrisiSoftver(softver.Id);
                MessageBox.Show("Brisanje Softvera je uspesno obavljeno!");
                popuniPodacima();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            popuniPodacima();
        }

        public async void popuniPodacima()
        {
            var podaci = await DataProvider.VratiSoftvereAnaliticara(Analiticar.JMBG);
            dataGridView1.DataSource = podaci;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void SoftverOverlay_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
