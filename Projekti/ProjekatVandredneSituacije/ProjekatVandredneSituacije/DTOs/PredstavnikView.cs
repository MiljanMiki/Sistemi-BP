using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
  

    public  class PredstavnikView
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Pozicija { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Email { get; set; }



        public PredstavnikView() { }
        public PredstavnikView(Predstavnik p)
        {
            JMBG = p.JMBG;
            Ime = p.Ime;
            Prezime = p.Prezime;
            Pozicija = p.Pozicija;
            Telefon = p.Telefon;
            Email = p.Email;
        }
    }

    public class PredstavnikChangeView
    {

        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Pozicija { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Email { get; set; }



        public PredstavnikChangeView() { }
        public PredstavnikChangeView(Predstavnik p)
        {

            Ime = p.Ime;
            Prezime = p.Prezime;
            Pozicija = p.Pozicija;
            Telefon = p.Telefon;
            Email = p.Email;
        }
    }
}
