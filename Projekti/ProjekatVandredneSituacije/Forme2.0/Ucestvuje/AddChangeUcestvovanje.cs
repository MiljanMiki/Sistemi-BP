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

namespace ProjekatVandredneSituacije.Forme2._0.Ucestvuje
{
    public partial class AddChangeUcestvovanje : Form
    {
        UcestvujeGetView ucestvuje;
        public AddChangeUcestvovanje()
        {
            InitializeComponent();
        }

        public AddChangeUcestvovanje(UcestvujeGetView ucestvuje)
        {
            InitializeComponent();
            this.ucestvuje = ucestvuje;
        }

        public async void PopuniPodacima()
        {
            var jedinice = await DataProvider.VratiSveJedinice();
            comboJedinica.DataSource = jedinice;

            comboJedinica.DisplayMember = "Naziv";
            comboJedinica.ValueMember = "Jedinstveni_Broj";
           

            var intervencije = await DataProvider.VratiIntervencije();
            comboIntervencija.DataSource = intervencije;
            comboIntervencija.DisplayMember = "Id";
            comboIntervencija.ValueMember = "Id";
            

            var vanredne = await DataProvider.VratiVanredneSituacije();
            comboVs.DataSource = vanredne;
            comboVs.DisplayMember = "Id";
            comboVs.ValueMember = "Id";
            if (ucestvuje != null)
            {
                comboVs.SelectedValue = ucestvuje.IdVanredneSituacije;
                comboJedinica.SelectedValue = ucestvuje.IdInterventneJed;
                comboIntervencija.SelectedValue = ucestvuje.IdIntervencije;
            }
        }

        private void comboJedinica_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboIntervencija_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboVs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var add = new UcestvujeAddView();
            add.IdInterventneJed = (int)comboJedinica.SelectedValue;
            add.IdIntervencije = (int)comboIntervencija.SelectedValue;
            add.IdVanredneSituacije = (int)comboVs.SelectedValue;

            if (ucestvuje != null)
            {
                await DataProvider.IzmeniUcestvuje(add, ucestvuje.Id);
            }
            else
            {
                await DataProvider.DodajUcestvuje(add);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PopuniPodacima();
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
        }

        private void AddChangeUcestvovanje_Load(object sender, EventArgs e)
        {
            PopuniPodacima();
        }
    }
}
