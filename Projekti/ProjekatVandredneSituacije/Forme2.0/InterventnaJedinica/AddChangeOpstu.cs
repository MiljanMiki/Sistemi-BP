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

namespace ProjekatVandredneSituacije.Forme2._0.InterventnaJedinica
{
    public partial class AddChangeOpstu : Form
    {
        OpstaIntervetnaGetView opsta;
        public AddChangeOpstu()
        {
            InitializeComponent();
            PopuniPodacima();
        }

        public AddChangeOpstu(OpstaIntervetnaGetView opsta)
        {
            InitializeComponent();
            this.opsta = opsta;
            PopuniPodacima();
            comboBox1.Enabled= false;
        }
        public async void PopuniPodacima()
        {
            var operativni = await DataProvider.VratiOperativneRadnike();
            comboBox1.DataSource = operativni;
            comboBox1.DisplayMember = "PunoIme";
            comboBox1.ValueMember = "JMBG";

            if (opsta != null)
            {

                textBox3.Text = opsta.Naziv;
                textBox1.Text = opsta.Baza;
                
                comboBox1.SelectedValue = opsta.JMBGKomandira;

            }
        }
        private async void AddChangeOpstu_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
       "Da li si siguran da želiš da zatvoriš formu?",
       "Potvrda",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                this.Close();
            }
            else
            {

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            OpstaInterventnaBasicView ops = new OpstaInterventnaBasicView();
            ops.Naziv = textBox3.Text;
            ops.Baza = textBox1.Text;
            ops.JMBGKomandira = comboBox1.SelectedValue.ToString();
            if (string.IsNullOrEmpty(textBox1.Text)|| string.IsNullOrEmpty(textBox3.Text) || comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (opsta == null)
            {
                await DataProvider.DodajOpstuIntervetnuJedinicu(ops);
            }
            else
            {
                await DataProvider.IzmeniOpstuInterventnuJedinicu(ops, opsta.Jedinstveni_Broj);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

}
