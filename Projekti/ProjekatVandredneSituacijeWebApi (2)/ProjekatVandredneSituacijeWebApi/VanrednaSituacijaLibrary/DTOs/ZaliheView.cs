using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class ZaliheView:OpremaView
    {
        
        public virtual  string Tip { get; set; }
        public virtual  int Kolicina { get; set; }

        public ZaliheView() { }
        public ZaliheView(Zalihe z): base(z)
        {
            Tip = z.Tip.ToString();
            Kolicina = z.Kolicina;
        }

    }

    public  class ZaliheAddView : OpremaAddView
    {
        
        public virtual  TipZalihe Tip { get; set; }
        public virtual  int Kolicina { get; set; }

        public ZaliheAddView() { }
        public ZaliheAddView(Zalihe z) : base(z)
        {
            Tip = z.Tip;
            Kolicina = z.Kolicina;
        }

    }

    public class ZaliheChangeView : OpremaChangeView
    {

        public virtual TipZalihe Tip { get; set; }
        public virtual int Kolicina { get; set; }

        public ZaliheChangeView() { }
        public ZaliheChangeView(Zalihe z) : base(z)
        {
            Tip = z.Tip;
            Kolicina = z.Kolicina;
        }

    }

    public class ZaliheMiniView : OpremaMiniView
    {
        
        public virtual string Tip { get; set; }
        public virtual int Kolicina { get; set; }

        public ZaliheMiniView() { }
        public ZaliheMiniView(Zalihe z) : base(z)
        {
            Tip = z.Tip.ToString();
            Kolicina = z.Kolicina;
        }

    }
}
