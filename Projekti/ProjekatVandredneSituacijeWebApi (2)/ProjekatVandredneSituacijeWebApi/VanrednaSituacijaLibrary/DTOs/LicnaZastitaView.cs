using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class LicnaZastitaView : OpremaView
    {
        public virtual string Tip { get; set; }

        public LicnaZastitaView() { }
        public LicnaZastitaView(LicnaZastita l) : base(l)
        {
            Tip = l.Tip.ToString();
        }
    }

    public  class LicnaZastitaAddView : OpremaAddView
    {
        public virtual TipLicneZastite Tip { get; set; }

        public LicnaZastitaAddView() { }
        public LicnaZastitaAddView(LicnaZastita l) : base(l)
        {
            Tip = l.Tip;
        }
    }

    public class LicnaZastitaChangeView : OpremaChangeView
    {
        public virtual TipLicneZastite Tip { get; set; }
        public LicnaZastitaChangeView() { }
        public LicnaZastitaChangeView(LicnaZastita l) : base(l)
        {
            Tip = l.Tip;
        }
    }

    public class LicnaZastitaMiniView : OpremaMiniView
    {
        public virtual string Tip { get; set; }

        public LicnaZastitaMiniView() { }
        public LicnaZastitaMiniView(LicnaZastita l) : base(l)
        {
            Tip = l.Tip.ToString();
        }
    }
}
