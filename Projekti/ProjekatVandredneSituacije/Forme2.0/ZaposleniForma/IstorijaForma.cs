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

namespace ProjekatVandredneSituacije.Forme2._0.ZaposleniForma
{
    public partial class IstorijaForma : Form
    {
        string zaposleniJMBG;
        public IstorijaForma(string zaposleniJMBG)
        {
            InitializeComponent();
            this.zaposleniJMBG = zaposleniJMBG;
        }

   

        private async void buttonIzmeni_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite istoriju zaposlenog cije podatke zelite da izmenite!");
                return;
            }

            int idIstorije = Int32.Parse(dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString());
            Istorija_Uloga_ZaposlenihView istorija = await DataProvider.VratiIstorijuU(idIstorije);
            ChangeIstorija forma = new ChangeIstorija(istorija);
            forma.ShowDialog();
            popuniPodacima();
        }

        private async void buttonObrisi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite istoriju uloge zaposlenog koju zelite da obrisete!");
                return;
            }


            string poruka = "Da li zelite da obrisete izabranu istoriju uloge zaposlenog?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {

                var uloga = dataGridView1.CurrentRow.DataBoundItem as Istorija_Uloga_ZaposlenihView;
                await DataProvider.ObrisiIstorijuUloga(uloga.Id);

                MessageBox.Show("Brisanje vozila je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void IstorijaForma_Load(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        public async void popuniPodacima()
        {
            dataGridView1.DataSource = await DataProvider.VratiIstoriju();
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
    }
}
