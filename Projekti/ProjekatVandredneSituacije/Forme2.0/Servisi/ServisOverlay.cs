using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Entiteti;
using ProjekatVandredneSituacije.Forme2._0.Servisi;
using ProjekatVandredneSituacije.Forme2._0.Specijalizacija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.Vozila
{
    public partial class ServisOverlay : Form
    {
        public VoziloView vozilo;
        public ServisOverlay()
        {
            InitializeComponent();
        }

        public ServisOverlay(VoziloView vozilo)
        {
            InitializeComponent();
            this.vozilo = vozilo;
            PopuniPodacima();
        }

        public async void PopuniPodacima()
        {
            var podaci = await DataProvider.VratiServiseVozila(vozilo.Registarska_Oznaka);
            dataGridView1.DataSource = podaci;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var forma = new AddChangeServis(vozilo.Registarska_Oznaka);

            forma.ShowDialog();
            PopuniPodacima();
        }



        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite servis koji zelite da izmenite!");
                return;
            }
            var Servis = dataGridView1.CurrentRow.DataBoundItem as ServisiView;
            var forma = new AddChangeServis(Servis);
            forma.ShowDialog();
            PopuniPodacima();
        }

        private async void buttonObrisi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite servis koji zelite da obrisete!");
                return;
            }
            var Servis = dataGridView1.CurrentRow.DataBoundItem as ServisiView;
            var result = MessageBox.Show("Da li ste sigurni da zelite da obrisete servis?", "Potvrda brisanja", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                await DataProvider.ObrisiServis(Servis.Id);
                MessageBox.Show("Uspesno ste obrisali servis");
                PopuniPodacima();
            }
        }
    }
}