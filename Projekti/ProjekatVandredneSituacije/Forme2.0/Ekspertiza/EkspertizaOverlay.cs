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

namespace ProjekatVandredneSituacije.Forme2._0.Ekspertiza
{

    public partial class EkspertizaOverlay : Form
    {
        AnaliticarView analiticar;
      
        public EkspertizaOverlay(AnaliticarView analiticar)
        {
            InitializeComponent();
            this.analiticar = analiticar;
            PopuniPodacima();
        }

        public async void PopuniPodacima()
        {
            var podaci = await DataProvider.VratiEkspertizeAnaliticara(analiticar.JMBG);
            dataGridView1.DataSource = podaci;

            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void EkspertizaOverlay_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        private void buttonDodajOp_Click(object sender, EventArgs e)
        {
            EkspertizaAddChange forma = new EkspertizaAddChange(analiticar.JMBG);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private async void buttonIzmeniO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite ekspertizu cije podatke zelite da izmenite!");
                return;
            }
            var ekspertiza = dataGridView1.CurrentRow.DataBoundItem as EkspertizaView;
            EkspertizaAddChange forma = new EkspertizaAddChange(ekspertiza);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private async void buttonObrisiO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite ekspertizu analiticara koju zelite da obrisete!");
                return;
            }

            var ekspertiza = dataGridView1.CurrentRow.DataBoundItem as EkspertizaView;
            string poruka = "Da li zelite da obrisete izabranu ekspertizu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiEkspertizu(ekspertiza.Id);
                MessageBox.Show("Brisanje Istorije je uspesno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {

            }
        }
    }
}
