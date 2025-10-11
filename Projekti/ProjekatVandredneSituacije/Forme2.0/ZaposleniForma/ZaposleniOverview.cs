using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Forme2._0.Ekspertiza;
using ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica;
using ProjekatVandredneSituacije.Forme2._0.IstorijaAgencije;
using ProjekatVandredneSituacije.Forme2._0.Sertifikat;
using ProjekatVandredneSituacije.Forme2._0.Softver;
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

namespace ProjekatVandredneSituacije.Forme2._0.ZaposleniForma
{
    public partial class ZaposleniOverview : Form
    {
        public ZaposleniOverview()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        public async void popuniPodacima()
        {
            string tip = comboBox1.SelectedItem?.ToString();
            if (tip == "Svi zaposleni")
            {
                dataGridView1.DataSource = await DataProvider.VratiSveZaposlene();
                buttonSert.Visible = false;
                buttonEkspertiza.Visible = false;
                buttonSoftver.Visible = false;
                buttonSpecijalizacija.Visible = false;

            }
            if (tip == "Operativni radnici")
            {
                dataGridView1.DataSource = await DataProvider.VratiOperativneRadnike();
                buttonSert.Visible = true;
                buttonEkspertiza.Visible = false;
                buttonSoftver.Visible = false;
                buttonSpecijalizacija.Visible = false;
            }
            else if (tip == "Koordinatori")
            {
                dataGridView1.DataSource = await DataProvider.VratiKordinatora();
                buttonSert.Visible = false;
                buttonEkspertiza.Visible = false;
                buttonSoftver.Visible = false;
                buttonSpecijalizacija.Visible = true;
            }
            else if (tip == "Analiticari")
            {
                dataGridView1.DataSource = await DataProvider.VratiAnaliticare();
                buttonSert.Visible = false;
                buttonEkspertiza.Visible = true;
                buttonSoftver.Visible = true;
                buttonSpecijalizacija.Visible = false;
            }
            else
            {
                dataGridView1.DataSource = await DataProvider.VratiSveZaposlene();
                buttonSert.Visible = false;
                buttonEkspertiza.Visible = false;
                buttonSoftver.Visible = false;
                buttonSpecijalizacija.Visible = false;
            }
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite radnika kog zelite da obrisete!");
                return;
            }


            string poruka = "Da li zelite da obrisete izabranog radnika?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                var zaposleni = dataGridView1.CurrentRow.DataBoundItem as ZaposleniView;

                if (zaposleni is OperativniRadnikView operativni)
                {
                    await DataProvider.ObrisiOperativnogRadnika(operativni.JMBG);
                }
                else if (zaposleni is KordinatorView koordinator)
                {
                    await DataProvider.ObrisiKordinatora(koordinator.JMBG);
                }
                else if (zaposleni is AnaliticarView analiticar)
                {
                    await DataProvider.ObrisiAnaliticara(analiticar.JMBG);
                }
                else
                {
                    throw new Exception("Neimplementirani tip radnika!");
                }
                popuniPodacima();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite radnika cije podatke zelite da izmenite!");
                return;
            }

            var zaposleni = dataGridView1.CurrentRow.DataBoundItem as ZaposleniView;

            Form form;

            if (zaposleni is OperativniRadnikView operativni)
            {
                form = new AddCHangeOperativniForma(operativni);
            }
            else if (zaposleni is KordinatorView koordinator)
            {
                form = new KoordAddChange(koordinator);
            }
            else if (zaposleni is AnaliticarView analiticar)
            {
                form = new AddChangeAnaliticar(analiticar);
            }
            else
            {
                throw new Exception("Neimplementirani tip radnika!");
            }
            form.ShowDialog();
            popuniPodacima();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new ZaposleniAddDIjalog();
            form.ShowDialog();
            popuniPodacima();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private async void ZaposleniOverview_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "Svi zaposleni";
            dataGridView1.DataSource = await DataProvider.VratiSveZaposlene();
            popuniPodacima();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite radnika ciju istoriju zelite da prikazete!");
                return;
            }

            var zaposleni = dataGridView1.CurrentRow.DataBoundItem as ZaposleniView;

            Form form;

            form = new IstorijaOverlay(zaposleni.JMBG);
            form.ShowDialog();
            popuniPodacima();

        }

        private void buttonSert_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite radnika ciju istoriju zelite da prikazete!");
                return;
            }

            var zaposleni = dataGridView1.CurrentRow.DataBoundItem as OperativniRadnikView;

            Form form;

            form = new SertifikatOverlay(zaposleni);
            form.ShowDialog();
            popuniPodacima();

        }

        private void buttonEkspertiza_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite radnika cije ekspertize zelite da prikazete!");
                return;
            }

            var zaposleni = dataGridView1.CurrentRow.DataBoundItem as AnaliticarView;

            Form form;

            form = new EkspertizaOverlay(zaposleni);
            form.ShowDialog();
            popuniPodacima();
        }

        private void buttonSpecijalizacija_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite radnika ciju specijalizaciju zelite da prikazete!");
                return;
            }

            var zaposleni = dataGridView1.CurrentRow.DataBoundItem as KordinatorView;

            Form form;

            form = new SpecijalizacijaForma(zaposleni);
            form.ShowDialog();
            popuniPodacima();
        }

        private void buttonSoftver_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite analiticara ciji softver zelite da prikazete!");
                return;
            }

            var zaposleni = dataGridView1.CurrentRow.DataBoundItem as AnaliticarView;

            Form form;

            form = new SoftverOverlay(zaposleni);
            form.ShowDialog();
            popuniPodacima();
        }

        private void buttonVozila_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite radnika ciju istoriju dodele vozila zelite da prikazete!");
                return;
            }

            string JMBG = (dataGridView1.SelectedRows[0].ToString());

            Form form;

            form = new VozilaJedinice(JMBG);
            form.ShowDialog();
            popuniPodacima();
        }

        private void comboBox1_DropDownStyleChanged(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
