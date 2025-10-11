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

namespace ProjekatVandredneSituacije.Forme2._0.Oprema
{
    public partial class DodajIzmeniMedicinsku : Form
    {
        MedicinskaOpremaAddView medicinska;
        public DodajIzmeniMedicinsku()
        {
            InitializeComponent();
            PopuniComboe();
        }

        public DodajIzmeniMedicinsku(MedicinskaOpremaAddView medi)
        {
            InitializeComponent();
            medicinska = medi;
            PopuniPodacima();
            textSb.Enabled = false;
            textSb.BackColor = Color.LightGray;
        }

        private async void PopuniPodacima()
        {
            await PopuniComboe();
            textSb.Text = medicinska.Serijski_Broj;
            textNaziv.Text = medicinska.Naziv;
            comboStatus.SelectedItem = medicinska.Status;
            comboJedinice.SelectedValue = medicinska.JedinicaID;
            dateNabavke.Value = medicinska.DatumNabavke;
            comboTip.SelectedItem = medicinska.Tip;
        }

        private async Task PopuniComboe()
        {
            var jedinice = await DataProvider.VratiOpstejedinice();
            comboJedinice.DataSource = jedinice;
            comboJedinice.DisplayMember = "Naziv";
            comboJedinice.ValueMember = "Jedinstveni_Broj";

            comboTip.DataSource = Enum.GetValues(typeof(TipMedicinske));
            comboStatus.DataSource = Enum.GetValues(typeof(StatusOpreme));
            comboJedinice.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            comboTip.SelectedIndex = -1;

        }

        private async void DodajIzmeniMedicinsku_Load(object sender, EventArgs e)
        {
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            MedicinskaOpremaAddView med = new MedicinskaOpremaAddView();
            med.Serijski_Broj = textSb.Text;
            med.Naziv = textNaziv.Text;
            med.Status = (StatusOpreme)comboStatus.SelectedValue;
            med.DatumNabavke = dateNabavke.Value;
            med.Tip = (TipMedicinske)comboTip.SelectedValue;
            med.JedinicaID = (int)comboJedinice.SelectedValue;

            if (string.IsNullOrEmpty(textSb.Text) || string.IsNullOrEmpty(textNaziv.Text) ||
                  comboTip.SelectedIndex == -1 || comboJedinice.SelectedIndex == -1 || comboStatus.SelectedIndex == -1
                )
            {
                MessageBox.Show("Popunite sva polja.", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (medicinska == null)
            {
                await DataProvider.DodajMedicinskuOpremu(med);
            }
            else
            {
                await DataProvider.IzmeniMedicinskuOpremu(medicinska.Serijski_Broj, med);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
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

        private void buttonRst_Click(object sender, EventArgs e)
        {
            textNaziv.Clear();
            dateNabavke.Value = DateTime.Now;
            comboJedinice.SelectedIndex = -1;
            comboStatus.SelectedIndex = -1;
            comboTip.SelectedIndex = -1;
        }
    }
}
