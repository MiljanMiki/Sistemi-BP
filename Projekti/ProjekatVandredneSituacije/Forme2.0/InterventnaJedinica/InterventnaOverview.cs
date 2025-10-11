using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Forme2._0.Prijava;
using ProjekatVandredneSituacije.Forme2._0.ZaposleniForma;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    public partial class InterventnaOverview : Form
    {
        public InterventnaOverview()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        public async void popuniPodacima()
        {
            string tip = comboBox2.SelectedItem?.ToString();
            if (tip == "Opste Jedinice")
            {
                dataGridView1.DataSource = await DataProvider.VratiOpstejedinice();
            }
            else if (tip == "Specijalne Jedinice")
            {
                dataGridView1.DataSource = await DataProvider.VratiSpecijalneJedinice();
            }
            else
            {
                dataGridView1.DataSource = await DataProvider.VratiSveJedinice();
            }
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            popuniPodacima();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var form = new AddIntervencijaDIjalog();
            form.ShowDialog();
            popuniPodacima();

        }

        private async void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite jedinicu cije podatke zelite da izmenite!");
                return;
            }

            var jedinica = dataGridView1.CurrentRow.DataBoundItem as InterventnaJedinicaGetView;

            Form form;

            if (jedinica is SpecijalnaIntervetnaGetView spec)
            {
                form = new AddChangeSpecJed(spec);
            }
            else if (jedinica is OpstaIntervetnaGetView opsta)
            {
                form = new AddChangeOpstu(opsta);
            }
            else
            {
                throw new Exception("Neimplementirani tip jedinice!");
            }
            form.ShowDialog();
            popuniPodacima();
        }


        private async void button11_Click(object sender, EventArgs e)
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
                var jedinica = dataGridView1.CurrentRow.DataBoundItem as InterventnaJedinicaGetView;

                if (jedinica is OpstaIntervetnaGetView opsta)
                {
                    await DataProvider.ObrisiOpstuInterventnuJedinicu(opsta.Jedinstveni_Broj);
                }
                else if (jedinica is SpecijalnaIntervetnaGetView spec)
                {
                    await DataProvider.ObrisiSpecijalnuInterventnuJedinicu(spec.Jedinstveni_Broj);
                }
                
                else
                {
                    throw new Exception("Neimplementirani tip radnika!");
                }
                popuniPodacima();
            }

        }


        private async void InterventnaOverview_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedText = "Sve Jedinice";
            dataGridView1.DataSource = await DataProvider.VratiSveJedinice();
            popuniPodacima();
        }



        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite jedinicu cija vozila zelite da prikazete!");
                return;
            }

            var jedinica = dataGridView1.CurrentRow.DataBoundItem as InterventnaJedinicaGetView;

            Form form;

            if (jedinica is SpecijalnaIntervetnaGetView spec)
            {
                form = new VozilaJedinice(spec.Jedinstveni_Broj);
            }
            else if (jedinica is OpstaIntervetnaGetView opsta)
            {
                form = new VozilaJedinice(opsta.Jedinstveni_Broj);
            }
            else
            {
                throw new Exception("Neimplementirani tip jedinice!");
            }
            form.ShowDialog();
            popuniPodacima();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite jedinicu cije clanove zelite da prikazete!");
                return;
            }

            var jedinica = dataGridView1.CurrentRow.DataBoundItem as InterventnaJedinicaGetView;

            Form form;

            if (jedinica is SpecijalnaIntervetnaGetView spec)
            {
                form = new ClanoviForma(spec.Jedinstveni_Broj);
            }
            else if (jedinica is OpstaIntervetnaGetView opsta)
            {
                form = new ClanoviForma(opsta.Jedinstveni_Broj);
            }
            else
            {
                throw new Exception("Neimplementirani tip jedinice!");
            }
            form.ShowDialog();
            popuniPodacima();
        }

        private void comboBox2_DropDownStyleChanged(object sender, EventArgs e)
        {
            popuniPodacima();
        }
    }
}

