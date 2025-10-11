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

namespace ProjekatVandredneSituacije.Forme2._0.Dodeljivanja
{
    public partial class AddChangeDodelu : Form
    {
        DodeljujeSeGetView dodela;
        public AddChangeDodelu()
        {
            InitializeComponent();
            PopuniComboe();
        }

        public AddChangeDodelu(DodeljujeSeGetView d)
        {
            InitializeComponent();
            this.dodela = d;
            PopuniPodacima();
            comboVozilo.Enabled= false;
            comboJedinica.Enabled= false;
            comboRadnik.Enabled= false;
        }

        public async void PopuniPodacima()
        {
            await PopuniComboe();
            comboVozilo.SelectedValue = dodela.RegVozilo;
            if (dodela.JMBGRadnik != null)
            {
                comboRadnik.SelectedValue = dodela.JMBGRadnik;
            }
            if (dodela.IdJedinica != null)
            {
                comboJedinica.SelectedValue = dodela.IdJedinica;
            }
            dateOd.Value = dodela.DatumOd;
            try
            {
                dateDo.Value = (DateTime)dodela.DatumDo;
            }
            catch {
                dateDo.Value = DateTime.Now;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
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
        private async Task PopuniComboe()
        {
            var Vozila = await DataProvider.VratiSvaVozila();
            comboVozilo.DataSource = Vozila;
            comboVozilo.DisplayMember = "Registarska_Oznaka";
            comboVozilo.ValueMember = "Registarska_Oznaka";

            var Radnik = await DataProvider.VratiOperativneRadnike();
            comboRadnik.DataSource = Radnik;
            comboRadnik.DisplayMember = "PunoIme";
            comboRadnik.ValueMember = "JMBG";

            var Jedinica = await DataProvider.VratiSveJedinice();
            comboJedinica.DataSource = Jedinica;
            comboJedinica.DisplayMember = "Naziv";
            comboJedinica.ValueMember = "Jedinstveni_Broj";

            dateOd.Value = DateTime.Now;
            dateDo.Value = DateTime.Now;

            comboVozilo.SelectedIndex = -1;
            comboRadnik.SelectedIndex = -1;
            comboJedinica.SelectedIndex = -1;

        }
        private async void AddChangeDodelu_Load(object sender, EventArgs e)
        {
        }

        private void btnRst_Click(object sender, EventArgs e)
        {
            comboVozilo.SelectedIndex = -1;
            comboRadnik.SelectedIndex = -1;
            comboJedinica.SelectedIndex = -1;

            dateOd.Value = DateTime.Now;
            dateDo.Value = DateTime.Now;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            string reg_Oznaka = (string)comboVozilo.SelectedValue;
            string? JMBG_Radnika = null;
            if (comboRadnik.SelectedValue != null)
            {
                JMBG_Radnika = (string)comboRadnik.SelectedValue;
            }
            int? idJedinice = null;
            if (comboJedinica.SelectedValue != null)
                idJedinice = Convert.ToInt32(comboJedinica.SelectedValue);
            DateTime datumOd = dateOd.Value;
            DateTime datumDo = dateDo.Value;
            if (dodela == null) {
                if (!string.IsNullOrEmpty(JMBG_Radnika) && comboJedinica.SelectedIndex == -1)
                {
                    // radnik + vozilo
                    var d = new DodeljujeSeAddView
                    {
                        RegVozilo = reg_Oznaka,
                        JMBGRadnik = JMBG_Radnika,
                        IdJedinica = null,
                        DatumOd = datumOd,
                        DatumDo = datumDo
                    };

                    await DataProvider.DodajDodeljivanje(d);
                    MessageBox.Show("Uspešno ste dodelili vozilo radniku");
                }
                else if (string.IsNullOrEmpty(JMBG_Radnika) && comboRadnik.SelectedIndex== -1)
                {
                    var d = new DodeljujeSeAddView
                    {
                        RegVozilo = reg_Oznaka,
                        JMBGRadnik = null,
                        IdJedinica = idJedinice.Value,
                        DatumOd = datumOd,
                        DatumDo = datumDo
                    };

                    await DataProvider.DodajDodeljivanje(d);
                    MessageBox.Show("Uspešno ste dodelili vozilo jedinici");
                }
            }
            else 
            {
                if (!string.IsNullOrEmpty(JMBG_Radnika) && comboJedinica.SelectedIndex == -1)
                {
                    // radnik + vozilo
                    var d = new DodeljujeSeAddView
                    {
                        RegVozilo = reg_Oznaka,
                        JMBGRadnik = JMBG_Radnika,
                        IdJedinica = null,
                        DatumOd = datumOd,
                        DatumDo = datumDo
                    };

                    await DataProvider.IzmeniDodeljujeSe(d, dodela.Id);
                    MessageBox.Show("Uspešno ste izmeni dodelu");
                }
                else if (string.IsNullOrEmpty(JMBG_Radnika) && comboJedinica.SelectedIndex == -1)
                {
                    var d = new DodeljujeSeAddView
                    {
                        RegVozilo = reg_Oznaka,
                        JMBGRadnik = null,
                        IdJedinica = idJedinice,
                        DatumOd = datumOd,
                        DatumDo = datumDo
                    };

                    await DataProvider.IzmeniDodeljujeSe(d, dodela.Id);
                    MessageBox.Show("Uspešno ste izmenili dodelu");
                }
                
            }
            {
                MessageBox.Show("Morate izabrati ili radnika ili jedinicu (ne oba i ne nijednog)!");
            }

        }
    



        private void comboVozilo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var vozilo = comboVozilo.SelectedItem as VoziloView;



            if (vozilo is DzipoviView)
            {

                comboJedinica.SelectedIndex = -1;
                comboJedinica.Enabled = false;
                
            }
            else
            {
                comboRadnik.Enabled = false;
                comboRadnik.SelectedIndex = -1;
    
            }

        }

        private void comboRadnik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboRadnik.SelectedIndex != -1)
            {
                comboJedinica.SelectedIndex = -1;
                comboJedinica.Enabled = false;
            }
            else
            {
                comboJedinica.Enabled = true;
            }
        }

        private void comboJedinica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboJedinica.SelectedIndex != -1) 
            {
                comboRadnik.SelectedIndex = -1;    
                comboRadnik.Enabled = false;       
            }
            else
            {
                comboRadnik.Enabled = true;
            }
        }
    }
}
