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

namespace ProjekatVandredneSituacije.Forme2._0.IstorijaAgencije
{
    public partial class IstorijaOverlay : Form
    {
        public string zaposleni;

        public IstorijaOverlay()
        {
            InitializeComponent();
        }
        public IstorijaOverlay(string zaposleni)
        {
            InitializeComponent();
            this.zaposleni = zaposleni;
            PopuniPodacima(zaposleni);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public async void PopuniPodacima(string JMBG)
        {
            var podaci = await DataProvider.VratiIstorijuUZaposlenog(JMBG);
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        public async void popuniPodacima()
        {
            var podaci = await DataProvider.VratiIstoriju();
            dataGridView1.DataSource = podaci;

            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void IstorijaOverlay_Load(object sender, EventArgs e)
        {
            if (zaposleni == null)
            {
                popuniPodacima();
            }
            else
            {
                PopuniPodacima(zaposleni);
            }
        }

        private async void button20_Click(object sender, EventArgs e)
        {
            if (zaposleni == null)
            {
                ChangeIstorija forma = new ChangeIstorija();
                forma.ShowDialog();
                popuniPodacima();
            }
            else
            {
          //      ChangeIstorija forma =await new ChangeIstorija(zaposleni);
           //     forma.ShowDialog();
           //     PopuniPodacima(zaposleni);
            }
        }

        private async void button19_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite istoriju zaposlenog cije podatke zelite da izmenite!");
                return;
            }
            var istorija = dataGridView1.CurrentRow.DataBoundItem as Istorija_Uloga_ZaposlenihView;
            ChangeIstorija forma = new ChangeIstorija(istorija);
            forma.ShowDialog();
            popuniPodacima();
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite Istoriju koju zelite da obrisete!");
                return;
            }
            var istorija = dataGridView1.CurrentRow.DataBoundItem as Istorija_Uloga_ZaposlenihView;

            string poruka = "Da li zelite da obrisete izabranu istoriju radnika?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                if (zaposleni == null)
                {
                    await DataProvider.ObrisiIstorijuUloga(istorija.Id);
                    MessageBox.Show("Brisanje Istorije je uspesno obavljeno!");
                    this.popuniPodacima();
                }
                else
                {
                    await DataProvider.ObrisiIstorijuUloga(istorija.Id);
                    MessageBox.Show("Brisanje Istorije je uspesno obavljeno!");
                    this.PopuniPodacima(zaposleni);
                }

            }
            else
            {

            }
        }

        private void istorijaUlogaZaposlenihViewBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
