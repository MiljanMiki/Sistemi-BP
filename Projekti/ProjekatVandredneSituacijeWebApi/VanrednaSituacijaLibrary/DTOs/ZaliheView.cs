using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    internal class ZaliheView:OpremaView
    {
        
        public virtual TipZalihe Tip { get; set; }
        public virtual int Kolicina { get; set; }

        public ZaliheView() { }
        public ZaliheView(Zalihe z): base(z)
        {
            Tip = z.Tip;
            Kolicina = z.Kolicina;
        }

    }

    internal class ZaliheAddView : OpremaAddView
    {

        public virtual TipZalihe Tip { get; set; }
        public virtual int Kolicina { get; set; }

        public ZaliheAddView() { }
        public ZaliheAddView(Zalihe z) : base(z)
        {
            Tip = z.Tip;
            Kolicina = z.Kolicina;
        }

    }
}
