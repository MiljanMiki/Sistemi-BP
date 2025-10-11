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
    public partial class VozilaJedinice : Form
    {
        public readonly string JMBG;
        public readonly int IdJedinice;

        public VozilaJedinice(string jMBG)
        {
            InitializeComponent();
            this.JMBG = jMBG;
            PopuniPodacima();
        }
        public VozilaJedinice(int IdJedinice)
        {
            InitializeComponent();
            this.IdJedinice = IdJedinice;
            PopuniPodacima();
        }

        public async void PopuniPodacima()
        {
            if (IdJedinice != null)
            {
                dataGridView1.DataSource = await DataProvider.VratiDodeljivanjaJedinic(IdJedinice);
                dataGridView1.Refresh();
                dataGridView1.ClearSelection();
            }
            else if(JMBG!=null)
            {
                dataGridView1.DataSource= await DataProvider.VratiDodeljenaVozilaRadniku(JMBG);
                dataGridView1.Refresh();
                dataGridView1.ClearSelection();
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite vozilo koje zelite da obrisete!");
                return;
            }
            var vozilo = dataGridView1.CurrentRow.DataBoundItem as VoziloView;
            string poruka = "Da li zelite da obrisete izabrano vozilo?";
            string title = "Pitanje";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show(poruka, title, buttons);

            if (result == DialogResult.OK)
            {
                await DataProvider.ObrisiVozilo(vozilo.Registarska_Oznaka);
                MessageBox.Show("Brisanje vozila je uspesno obavljeno!");
                this.PopuniPodacima();
            }
            else
            {

            }
        }
    }
}
