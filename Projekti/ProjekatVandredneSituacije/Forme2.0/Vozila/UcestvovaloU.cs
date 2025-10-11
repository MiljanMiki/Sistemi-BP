using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjekatVandredneSituacije.Forme2._0.Vozila
{
    public partial class UcestvovaloU : Form
    {
        private string Reg_oznaka;
        public UcestvovaloU(string Reg_oznaka)
        {
            InitializeComponent();
            this.Reg_oznaka = Reg_oznaka;
            MessageBox.Show("reg oznaka je " + Reg_oznaka);
            PopuniPodacima();
        }

        private async void UcestvovaloU_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await DataProvider.VratiIntervencijeUKojimajeUcestvovaloVozilo(Reg_oznaka);
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        public async void PopuniPodacima()
        {
            dataGridView1.DataSource = await DataProvider.VratiIntervencijeUKojimajeUcestvovaloVozilo(Reg_oznaka);
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PopuniPodacima();
        }
    }
}
