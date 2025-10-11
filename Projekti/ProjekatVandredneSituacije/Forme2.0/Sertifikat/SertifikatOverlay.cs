using NHibernate.Util;
using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Forme2._0.Saradnja;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.Sertifikat
{
    public partial class SertifikatOverlay : Form
    {
        OperativniRadnikView operativni;
        public SertifikatOverlay(OperativniRadnikView op)
        {
            InitializeComponent();
            operativni = op;
            PopuniPodacima();
        }



        private async void buttonObrisiO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite sertifikat koju zelite da obrisete!");
                return;
            }

            string JMBG = (string)(dataGridView1.SelectedRows[0].Cells["JMBGOperativnogRadnika"].Value.ToString());
            string Naziv = (string)(dataGridView1.SelectedRows[0].Cells["Naziv"].Value.ToString());
            string Institucija = (string)(dataGridView1.SelectedRows[0].Cells["Institucija"].Value.ToString());
            SertifikatIdAddView Id= new SertifikatIdAddView();
            Id.JMBGRadnika = JMBG;
            Id.Naziv = Naziv;
            Id.Institucija = Institucija;
            string poruka = "Da li zelite da obrisete izabrani sertifikat?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiSertifikat(Id);
                MessageBox.Show("Brisanje sertifikata je uspesno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {

            }
        }

        private void SertifikatOverlay_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }

        private async void PopuniPodacima()
        {
            var podaci = await DataProvider.VratiSertifikateZaposlenog(operativni.JMBG);
            dataGridView1.DataSource = podaci;
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void buttonDodajOp_Click(object sender, EventArgs e)
        {
            DodajIzmeniSerttifikat form = new DodajIzmeniSerttifikat(operativni.JMBG);
            form.ShowDialog();
            PopuniPodacima();
        }

        private async void buttonIzmeniO_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo vas odaberite polje koje zelite da izmenite");
            }

            var sertifikat = dataGridView1.CurrentRow.DataBoundItem as SertifikatGetView;
            DodajIzmeniSerttifikat forma = new DodajIzmeniSerttifikat(sertifikat);
            forma.ShowDialog();
            PopuniPodacima();
        }
    }
}
