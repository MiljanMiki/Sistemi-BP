using ProjekatVandredneSituacije.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.Saradnja
{
    public partial class DodajIzmeniSaradnju : Form
    {
        SaradjujeView saradjuje;
        public DodajIzmeniSaradnju()
        {
            InitializeComponent();
        }

        public DodajIzmeniSaradnju(SaradjujeView saradjuje)
        {
            InitializeComponent();
            this.saradjuje = saradjuje;
            PopuniPodacima();
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void DodajIzmeniSaradnju_Load(object sender, EventArgs e)
        {
            var sluzbe = await DataProvider.VratiSluzbe();
            var vanredneSituacije = await DataProvider.VratiVanredneSituacije();

            comboBox1.DataSource = sluzbe;
            comboBox2.DataSource = vanredneSituacije;

            comboBox1.DisplayMember = "Id_Sektora";
            comboBox1.ValueMember = "Id_Sektora";

            comboBox2.DisplayMember = "Id";
            comboBox2.ValueMember = "Id";

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            PopuniPodacima();
        }

        public void PopuniPodacima()
        {
            if (saradjuje != null)
            {
                comboBox2.SelectedValue = saradjuje.VandrednaSituacija.Id;
                comboBox1.SelectedValue = saradjuje.Sektor.Id_Sektora;
                textBox1.Text = saradjuje.Uloga;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            SaradjujeAddView saradnja = new SaradjujeAddView();
            saradnja.VanrednaSituacijaID = (int)comboBox2.SelectedValue;
            saradnja.SektorID = (int)comboBox1.SelectedValue;
            saradnja.Uloga = textBox1.Text;

            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (saradjuje == null)
            {
                await DataProvider.DodajSaradnju(saradnja);
            }
            else
            {
                await DataProvider.IzmeniSaradnju(saradnja, saradjuje.Id);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Clear();
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
    }
}
