using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class KordinatorView:ZaposleniView
    {

        public virtual int BrojTimova { get; set; }
        public KordinatorView()
        {
        }


        public KordinatorView(Kordinator k): base(k)
        {
            BrojTimova = k.BrojTimova;
        }
    }

    public  class KordinatorMinView
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


    public class KordinatorChangeView : ZaposleniChangeView
    {

        public virtual int BrojTimova { get; set; }
        public KordinatorChangeView()
        {
        }


        public KordinatorChangeView(Kordinator k) : base(k)
        {
            BrojTimova = k.BrojTimova;
        }
    }
}
