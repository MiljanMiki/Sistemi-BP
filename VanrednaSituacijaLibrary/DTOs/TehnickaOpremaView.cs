using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    internal class TehnickaOpremaView:OpremaView
    {
        public virtual TipTehnicke Tip { get; set; }

        public TehnickaOpremaView(TehnickaOprema t):base(t)
        {
            Tip = t.Tip;
        }   
    }

    internal class TehnickaOpremaAddView : OpremaAddView
    {
        public virtual TipTehnicke Tip { get; set; }
        public TehnickaOpremaAddView() { }

        public TehnickaOpremaAddView(TehnickaOprema m) : base(m)
        {
            Tip = m.Tip;
        }
    }
}
