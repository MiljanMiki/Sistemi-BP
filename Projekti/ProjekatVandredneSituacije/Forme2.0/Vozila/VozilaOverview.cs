using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Entiteti;
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
    public partial class VozilaOverview : Form
    {
        public VozilaOverview()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var forma = new DodajVoziloDijalog();
            forma.ShowDialog();
            popuniPodacima();
        }


        public async void popuniPodacima()
        {
            string tip = comboBox1.SelectedItem?.ToString();
            if (tip == "Sva Vozila")
            {
                dataGridView1.DataSource = await DataProvider.VratiSvaVozila();
            }
            else if (tip == "Sanitetska Vozila")
            {
                dataGridView1.DataSource = await DataProvider.VratiSanitetskaVozila();
            }
            else if (tip == "Specijalna Vozila")
            {
                dataGridView1.DataSource = await DataProvider.VratiSpecijalnaVozila();
            }
            else if (tip == "Kamioni")
            {
                dataGridView1.DataSource = await DataProvider.VratiKamione();
            }
            else if (tip == "Dzipovi")
            {
                dataGridView1.DataSource = await DataProvider.VratiDzipove();
            }
            else
            {
                dataGridView1.DataSource = await DataProvider.VratiSvaVozila();
            }
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo cije podatke zelite da izmenite!");
                return;
            }

            var vozilo = dataGridView1.CurrentRow.DataBoundItem as VoziloView;

            Form form;

            if (vozilo is SanitetskaView sanitetska)
            {
                form = new DodajIzmeniSanitetska(sanitetska);
            }
            else if (vozilo is SpecijalnaVozilaView specijalna)
            {
                form = new DodajIzmeniSpecijalna(specijalna.Registarska_Oznaka);
            }
            else if (vozilo is KamioniView kamioni)
            {
                form = new KamioniAddChange(kamioni.Registarska_Oznaka);
            }
            else if (vozilo is DzipoviView dzipovi)
            {
                form = new DzipAddChange(dzipovi.Registarska_Oznaka);
            }
            else
            {
                throw new Exception("Neimplementirani tip vozila!");
            }
            form.ShowDialog();
            popuniPodacima();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo koje zelite da obrisete!");
                return;
            }


            string poruka = "Da li zelite da obrisete izabrano vozilo?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {

                var vozilo = dataGridView1.CurrentRow.DataBoundItem as VoziloView;

                if (vozilo is SanitetskaView sanitetska)
                {
                    await DataProvider.ObrisiSanitetskoVozilo(sanitetska.Registarska_Oznaka);
                }
                else if (vozilo is SpecijalnaVozilaView specijalna)
                {
                    await DataProvider.ObrisiSpecijalnoVozilo(specijalna.Registarska_Oznaka);
                }
                else if (vozilo is KamioniView kamioni)
                {
                    await DataProvider.ObrisiKamion(kamioni.Registarska_Oznaka);
                }
                else if (vozilo is DzipoviView dzipovi)
                {
                    await DataProvider.ObrisiDzip(dzipovi.Registarska_Oznaka);
                }
                else
                {
                    throw new Exception("Neimplementirani tip vozila!");
                }
                MessageBox.Show("Brisanje vozila je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void VozilaOverview_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "Sve vozila";
            popuniPodacima();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo ciju istoriju intervencija zelite da prikazete!");
                return;
            }

            string Reg = (dataGridView1.SelectedRows[0].Cells[0].ToString());

            var forma = new UcestvovaloU(Reg);
            forma.ShowDialog();
            popuniPodacima();

        }

        private async void VozilaOverview_Load_1(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "Sva Vozila";
            dataGridView1.DataSource = await DataProvider.VratiSvaVozila();
            popuniPodacima();
        }

        private void comboBox1_DropDownStyleChanged(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var forma = new DodajVoziloDijalog();
            forma.ShowDialog();
            popuniPodacima();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo cije podatke zelite da izmenite!");
                return;
            }

            var vozilo = dataGridView1.CurrentRow.DataBoundItem as VoziloView;

            Form form;

            if (vozilo is SanitetskaView sanitetska)
            {
                form = new DodajIzmeniSanitetska(sanitetska);
            }
            else if (vozilo is SpecijalnaVozilaView specijalna)
            {
                form = new DodajIzmeniSpecijalna(specijalna.Registarska_Oznaka);
            }
            else if (vozilo is KamioniView kamioni)
            {
                form = new KamioniAddChange(kamioni.Registarska_Oznaka);
            }
            else if (vozilo is DzipoviView dzipovi)
            {
                form = new DzipAddChange(dzipovi.Registarska_Oznaka);
            }
            else
            {
                throw new Exception("Neimplementirani tip vozila!");
            }
            form.ShowDialog();
            popuniPodacima();
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo koje zelite da obrisete!");
                return;
            }


            string poruka = "Da li zelite da obrisete izabrano vozilo?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {

                var vozilo = dataGridView1.CurrentRow.DataBoundItem as VoziloView;

                if (vozilo is SanitetskaView sanitetska)
                {
                    await DataProvider.ObrisiSanitetskoVozilo(sanitetska.Registarska_Oznaka);
                }
                else if (vozilo is SpecijalnaVozilaView specijalna)
                {
                    await DataProvider.ObrisiSpecijalnoVozilo(specijalna.Registarska_Oznaka);
                }
                else if (vozilo is KamioniView kamioni)
                {
                    await DataProvider.ObrisiKamion(kamioni.Registarska_Oznaka);
                }
                else if (vozilo is DzipoviView dzipovi)
                {
                    await DataProvider.ObrisiDzip(dzipovi.Registarska_Oznaka);
                }
                else
                {
                    throw new Exception("Neimplementirani tip vozila!");
                }
                MessageBox.Show("Brisanje vozila je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }



        private void comboBox1_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo ciju istoriju intervencija zelite da prikazete!");
                return;
            }

            var vozilo = dataGridView1.CurrentRow.DataBoundItem as VoziloView;

            var forma = new UcestvovaloU(vozilo.Registarska_Oznaka);
            forma.ShowDialog();
            popuniPodacima();
        }

        private async void button1_Click_2(object sender, EventArgs e)
        {
            var forma = new DodajVoziloDijalog();
            forma.ShowDialog();
            popuniPodacima();
        }

        private async void button2_Click_2(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo cije podatke zelite da izmenite!");
                return;
            }

            var vozilo = dataGridView1.CurrentRow.DataBoundItem as VoziloView;

            Form form;

            if (vozilo is SanitetskaView sanitetska)
            {
                form = new DodajIzmeniSanitetska(sanitetska);
            }
            else if (vozilo is SpecijalnaVozilaView specijalna)
            {
                form = new DodajIzmeniSpecijalna(specijalna.Registarska_Oznaka);
            }
            else if (vozilo is KamioniView kamioni)
            {
                form = new KamioniAddChange(kamioni.Registarska_Oznaka);
            }
            else if (vozilo is DzipoviView dzipovi)
            {
                form = new DzipAddChange(dzipovi.Registarska_Oznaka);
            }
            else
            {
                throw new Exception("Neimplementirani tip vozila!");
            }
            form.ShowDialog();
            popuniPodacima();
        }

        private async void button3_Click_2(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo koje zelite da obrisete!");
                return;
            }


            string poruka = "Da li zelite da obrisete izabrano vozilo?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {

                var vozilo = dataGridView1.CurrentRow.DataBoundItem as VoziloView;

                if (vozilo is SanitetskaView sanitetska)
                {
                    await DataProvider.ObrisiSanitetskoVozilo(sanitetska.Registarska_Oznaka);
                }
                else if (vozilo is SpecijalnaVozilaView specijalna)
                {
                    await DataProvider.ObrisiSpecijalnoVozilo(specijalna.Registarska_Oznaka);
                }
                else if (vozilo is KamioniView kamioni)
                {
                    await DataProvider.ObrisiKamion(kamioni.Registarska_Oznaka);
                }
                else if (vozilo is DzipoviView dzipovi)
                {
                    await DataProvider.ObrisiDzip(dzipovi.Registarska_Oznaka);
                }
                else
                {
                    throw new Exception("Neimplementirani tip vozila!");
                }
                MessageBox.Show("Brisanje vozila je uspesno obavljeno!");
                this.popuniPodacima();
            }
        }

        private void comboBox1_DropDownStyleChanged_1(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonServisi_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo ciju istoriju intervencija zelite da prikazete!");
                return;
            }

            var vozilo = dataGridView1.CurrentRow.DataBoundItem as VoziloView;

            var forma = new ServisOverlay(vozilo);
            forma.ShowDialog();
            popuniPodacima();
        }
    }
}
