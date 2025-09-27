using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVanredneSituacije.Entiteti;

namespace ProjekatVanredneSituacije.DTOs
{
    internal class LicnaZastitaView : OpremaView
    {
        public virtual TipLicneZastite Tip { get; set; }
        public LicnaZastitaView(LicnaZastita l) : base(l)
        {
            Tip = l.Tip;
        }
    }

    internal class LicnaZastitaAddView : OpremaAddView
    {
        public virtual TipLicneZastite Tip { get; set; }
        public LicnaZastitaAddView(LicnaZastita l) : base(l)
        {
            Tip = l.Tip;
        }
    }

}
