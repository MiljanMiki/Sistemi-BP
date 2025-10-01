using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class MedicinskaOpremaView:OpremaView
    {
        public virtual string Tip { get; set; }

        public MedicinskaOpremaView()
        {
        }

        public MedicinskaOpremaView(MedicinskaOprema m):base(m)
        {
            Tip = m.Tip.ToString();
        }
    }

    public  class MedicinskaOpremaAddView: OpremaAddView
    {
        public virtual TipMedicinske Tip { get; set; }
        public MedicinskaOpremaAddView() { }

        public MedicinskaOpremaAddView(MedicinskaOprema m): base(m)
        {
            Tip = m.Tip;
        }
    }


    public class MedicinskaOpremaChangeView : OpremaChangeView
    {
        public virtual TipMedicinske Tip { get; set; }
        public MedicinskaOpremaChangeView() { }

        public MedicinskaOpremaChangeView(MedicinskaOprema m) : base(m)
        {
            Tip = m.Tip;
        }
    }

    public class MedicinskaOpremaMiniView : OpremaMiniView
    {
        public virtual string Tip { get; set; }
        public MedicinskaOpremaMiniView() { }

        public MedicinskaOpremaMiniView(MedicinskaOprema m) : base(m)
        {
            Tip = m.Tip.ToString();
        }
    }
}

