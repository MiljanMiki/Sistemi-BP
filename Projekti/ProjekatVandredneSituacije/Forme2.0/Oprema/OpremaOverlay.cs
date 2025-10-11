using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica;
using ProjekatVandredneSituacije.Forme2._0.Prijava;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatVandredneSituacije.Forme2._0.Oprema
{
    public partial class OpremaOverlay : Form
    {
        public OpremaOverlay()
        {
            InitializeComponent();
        }

        private void panelLicna_Paint(object sender, PaintEventArgs e)
        {

        }

        public async void popuniPodacima()
        {
            string tip = comboBox1.SelectedItem?.ToString();

            if (tip == "Sve")
            {
                dataGridView1.DataSource = await DataProvider.VratiSvuOpremu();

            }
            else if (tip == "Licna zastita")
            {
                dataGridView1.DataSource = await DataProvider.VratiOpremuLicneZastite();
            }
            else if (tip == "Medicinska")
            {
                dataGridView1.DataSource = await DataProvider.VratiMedicinskuZastitu();
            }
            else if (tip == "Tehnicka")
            {
                dataGridView1.DataSource = await DataProvider.VratiTehnickuZastitu();
            }
            else if (tip == "Zalihe")
            {
                dataGridView1.DataSource = await DataProvider.VratiZalihe();
            }
            else
            {
                dataGridView1.DataSource = await DataProvider.VratiSvuOpremu();
            }
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private async void OpremaOverlay_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedText = "Sve";
            dataGridView1.DataSource = await DataProvider.VratiSvuOpremu();
            popuniPodacima();
        }

        private async void button3_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite jedinicu koje zelite da obrisete!");
                return;
            }


            string poruka = "Da li zelite da obrisete izabranu jedinicu?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                var oprema = dataGridView1.CurrentRow.DataBoundItem as OpremaAddView;

                if (oprema is ZaliheAddView zalihe)
                {
                    await DataProvider.ObrisiZalihe(zalihe.Serijski_Broj);
                }
                else if (oprema is MedicinskaOpremaAddView med)
                {
                    await DataProvider.ObrisiMedicinskuOpremu(med.Serijski_Broj);
                }
                else if (oprema is TehnickaOpremaAddView teh)
                {
                    await DataProvider.ObrisiTehnickuOpremu(teh.Serijski_Broj);
                }
                else if (oprema is LicnaZastitaAddView liz)
                {
                    await DataProvider.ObrisiLicnuZastitu(liz.Serijski_Broj);
                }
                else
                {
                    throw new Exception("Neimplementirani tip jedinice!");
                }

            }
            popuniPodacima();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DodajOpremuDijalog forma = new DodajOpremuDijalog();
            forma.ShowDialog();
            popuniPodacima();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite jedinicu cije podatke zelite da izmenite!");
                return;
            }

            var oprema = dataGridView1.CurrentRow.DataBoundItem as OpremaAddView;

            Form form;

            if (oprema is ZaliheAddView zalihe)
            {
                form = new DodajIzmeniZalihe(zalihe);
            }
            else if (oprema is MedicinskaOpremaAddView med)
            {
                form = new DodajIzmeniMedicinsku(med);
            }
            else if (oprema is TehnickaOpremaAddView teh)
            {
                form = new DodajIzmeniTehnicku(teh);
            }
            else if (oprema is LicnaZastitaAddView liz)
            {
                form = new DodajIzmeniLicnuZastitu(liz);
            }
            else
            {
                throw new Exception("Neimplementirani tip jedinice!");
            }
            form.ShowDialog();
            popuniPodacima();
        }

        private void comboBox1_DropDownStyleChanged(object sender, EventArgs e)
        {
            popuniPodacima();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}
