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

namespace ProjekatVandredneSituacije.Forme2._0.Sluzba
{
    public partial class SluzbaAddChange : Form
    {
        SluzbaView sluzba;
        public SluzbaAddChange()
        {
            InitializeComponent();
            popuniPredstavnike();
        }

        public SluzbaAddChange(SluzbaView s)
        {
            InitializeComponent();
            sluzba = s;
            PopuniPodacima();
        }

        public async void PopuniPodacima()
        {
            await popuniPredstavnike();
            textSektor.Text = sluzba.TipSektora;
            comboPredstavnici.SelectedValue = sluzba.Predstavnik;
            comboPredstavnici.Text = sluzba.Predstavnik.PunoIme;
        }

        public async Task popuniPredstavnike()
        {
            comboPredstavnici.DataSource = await DataProvider.VratiPredstavnike();
            comboPredstavnici.DisplayMember = "PunoIme";
            comboPredstavnici.ValueMember = "JMBG";
            comboPredstavnici.SelectedIndex = -1;

        }
        private async void SluzbaAddChange_Load(object sender, EventArgs e)
        {
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            SluzbaAddView s = new SluzbaAddView();
            s.TipSektora = textSektor.Text;
            s.JMBG_Predstavnik = (string)comboPredstavnici.SelectedValue;

            if (string.IsNullOrEmpty(textSektor.Text) || string.IsNullOrEmpty(comboPredstavnici.Text))
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sluzba == null)
            {
                await DataProvider.DodajSluzbu(s);
            }
            else
            {
                await DataProvider.IzmeniSluzbu(s, sluzba.Id_Sektora);
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textSektor.Clear();
            comboPredstavnici.SelectedIndex = -1;
        }

        private void buttonAbort_Click(object sender, EventArgs e)
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
