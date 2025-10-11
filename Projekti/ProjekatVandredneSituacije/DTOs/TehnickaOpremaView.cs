using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class TehnickaOpremaView:OpremaView
    {
        public virtual string Tip { get; set; }

        public TehnickaOpremaView() { }
        public TehnickaOpremaView(TehnickaOprema t):base(t)
        {
            Tip = t.Tip.ToString();
        }   
    }

    public  class TehnickaOpremaAddView : OpremaAddView
    {
        public virtual TipTehnicke Tip { get; set; }
        public TehnickaOpremaAddView() { }

        public TehnickaOpremaAddView(TehnickaOprema m) : base(m)
        {
            Tip = m.Tip;
        }
    }

    public class TehnickaOpremaChangeView : OpremaChangeView
    {
        public virtual TipTehnicke Tip { get; set; }
        public TehnickaOpremaChangeView() { }

        public TehnickaOpremaChangeView(TehnickaOprema m) : base(m)
        {
            Tip = m.Tip;
        }
    }

    public class TehnickaOpremaMiniView : OpremaMiniView
    {
        public virtual string Tip { get; set; }
        public TehnickaOpremaMiniView() { }

        public TehnickaOpremaMiniView(TehnickaOprema m) : base(m)
        {
            Tip = m.Tip.ToString();
        }
    }
}
