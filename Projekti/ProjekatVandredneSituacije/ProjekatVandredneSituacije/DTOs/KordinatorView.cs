using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProjekatVanredneSituacije.Entiteti;

namespace ProjekatVanredneSituacije.DTOs
{
    internal class KordinatorView:ZaposleniView
    {
        public IList<SpecijalizacijaView> Specijalizacije { get; set; }
        public virtual int BrojTimova { get; set; }
        public KordinatorView()
        {
               Specijalizacije = new List<SpecijalizacijaView>();
        }


        public KordinatorView(Kordinator k): base(k)
        {
            BrojTimova = k.BrojTimova;
        }
    }

    internal class KordinatorMinView
    {
        public virtual string JMBG { get; set; }    
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }

        public KordinatorMinView() { }
        public KordinatorMinView(Kordinator k)
        {
            JMBG = k.JMBG;
            Ime = k.Ime;
            Prezime = k.Prezime;
        }
    }
}
