using NHibernate.Cfg;
using ProjekatVandredneSituacije.DTOs;
using ProjekatVandredneSituacije.Forme2._0.Ekspertiza;
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
    public partial class DodeljivanjaOverlay : Form
    {
        public DodeljivanjaOverlay()
        {
            InitializeComponent();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            AddChangeDodelu form = new AddChangeDodelu();
            form.ShowDialog();
            this.Close();
            Ucitaj();
        }


        private async void Ucitaj()
        {
            var podaci = await DataProvider.VratiSvaDodeljivanja();
            dataGridView1.DataSource = podaci;

            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void DodeljivanjaOverlay_Load(object sender, EventArgs e)
        {
            Ucitaj();
        }

        private async void button19_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite ekspertizu cije podatke zelite da izmenite!");
                return;
            }

            int Id = Int32.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            DodeljujeSeGetView dodeljuje = await DataProvider.VratiDodeljivanje(Id);
            AddChangeDodelu forma = new AddChangeDodelu(dodeljuje);
            forma.ShowDialog();
            Ucitaj();
        }

        private async void button18_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Izaberite dodeljivanje koju zelite da izbrisete!");
                return;
            }
            var dodeljuje = dataGridView1.CurrentRow.DataBoundItem as DodeljujeSeGetView;
            await DataProvider.ObrisiDodeljivanje(dodeljuje.Id);

            MessageBox.Show("Dodeljivanje uspesno izbrisano!");
            Ucitaj();
        }
    }
}
