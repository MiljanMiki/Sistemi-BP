using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class AnaliticarView: ZaposleniView
    {

        public AnaliticarView()
        {
 
        }
        public AnaliticarView(Analiticar a): base(a)
        {
        }
    }

    public class AnaliticarChangeView : ZaposleniChangeView
    {

        public AnaliticarChangeView()
        {

        }
        public AnaliticarChangeView(Analiticar a) : base(a)
        {
        }
    }

    public  class AnaliticarMinView
    {
        public virtual  string JMBG { get; set; }
        public virtual  string Ime { get; set; }
        public virtual  string Prezime { get; set; }
        public AnaliticarMinView() { }
        public AnaliticarMinView(Analiticar a)
        {
            JMBG = a.JMBG;
            Ime = a.Ime;
            Prezime = a.Prezime;
        }
    }
}
