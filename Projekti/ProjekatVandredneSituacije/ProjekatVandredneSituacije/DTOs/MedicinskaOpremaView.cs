using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class MedicinskaOpremaView:OpremaView
    {
        public virtual TipMedicinske Tip { get; set; }

        public MedicinskaOpremaView()
        {
        }

        public MedicinskaOpremaView(MedicinskaOprema m):base(m)
        {
            Tip = m.Tip;
        }
    }

    internal class MedicinskaOpremaAddView: OpremaAddView
    {
        public virtual TipMedicinske Tip { get; set; }
        public MedicinskaOpremaAddView() { }

        public MedicinskaOpremaAddView(MedicinskaOprema m): base(m)
        {
            Tip = m.Tip;
        }
    }
}
