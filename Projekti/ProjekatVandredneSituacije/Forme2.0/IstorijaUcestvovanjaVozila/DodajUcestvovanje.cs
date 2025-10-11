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
using static System.Net.Mime.MediaTypeNames;

namespace ProjekatVandredneSituacije.Forme2._0.IstorijaUcestvovanjaVozila
{
    public partial class DodajUcestvovanje : Form
    {
        UcestvovaloGetView ucestvovalo;
        public DodajUcestvovanje()
        {
            InitializeComponent();
        }

        public DodajUcestvovanje(UcestvovaloGetView u)
        {
            InitializeComponent();
            ucestvovalo = u;
            PopuniPodacima();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void DodajUcestvovanje_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = await DataProvider.VratiIntervencije();
            comboBox1.DisplayMember = "Id";
            comboBox1.ValueMember = "Id";


            comboBox2.DataSource = await DataProvider.VratiSvaVozila();
            comboBox2.DisplayMember = "Registarska_Oznaka";
            comboBox2.ValueMember = "Registarska_Oznaka";

        }

        public async void PopuniPodacima()
        { 
            comboBox1.SelectedValue = ucestvovalo.VoziloReg;
            comboBox2.SelectedValue = ucestvovalo.IntervencijaID;

            dateTimePicker1.Value = ucestvovalo.Datum_Od;
            if (ucestvovalo.Datum_Do == null)
            {
                dateTimePicker2.Value = DateTime.Now;
            } else
            {
                dateTimePicker2.Value = (DateTime)ucestvovalo.Datum_Do;
            }

            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            comboBox1.BackColor = Color.LightGray;
            comboBox2.BackColor = Color.LightGray;
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            UcestvovaloAddView u = new UcestvovaloAddView();
            u.IntervencijaID = (int)comboBox1.SelectedValue;
            u.VoziloReg = (string)comboBox2.SelectedValue;

            u.Datum_Od = dateTimePicker1.Value;
            u.Datum_Do = dateTimePicker2.Value;

            if (comboBox1.SelectedIndex == -1 || !dateTimePicker1.Checked || !dateTimePicker2.Checked ||
                  comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ucestvovalo == null)
            {
                await DataProvider.DodajUcestvovanje(u);
            }
            else
            {
                await DataProvider.IzmeniUcestvovanje(u, ucestvovalo.Id);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonRst_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
        }

        private void buttonCnc_Click(object sender, EventArgs e)
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
    }
}
