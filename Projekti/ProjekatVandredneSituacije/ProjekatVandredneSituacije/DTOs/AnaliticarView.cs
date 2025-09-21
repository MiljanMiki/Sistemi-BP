using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class AnaliticarView: ZaposleniView
    {
        public IList<EkspertizaView> Ekspertize { get; set; }
        public IList<SoftverView> Softveri { get; set; }
        public AnaliticarView()
        {
            Ekspertize = new List<EkspertizaView>();
            Softveri = new List<SoftverView>();
        }
        public AnaliticarView(Analiticar a): base(a)
        {
        }
    }

    internal class AnaliticarMinView
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public AnaliticarMinView() { }
        public AnaliticarMinView(Analiticar a)
        {
            JMBG = a.JMBG;
            Ime = a.Ime;
            Prezime = a.Prezime;
        }
    }
}
