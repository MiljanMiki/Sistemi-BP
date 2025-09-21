using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
  

    internal class PredstavnikView
    {
        public virtual string JMBG { get; set; }
        public virtual string Ime { get; set; }
        public virtual string Prezime { get; set; }
        public virtual string Pozicija { get; set; }
        public virtual string Telefon { get; set; }
        public virtual string Email { get; set; }

        public virtual SluzbaView Sluzba { get; set; }

        public virtual int Id_Sektora { get; set; }
        public virtual string NazivSektora { get; set; }

        public PredstavnikView() { }
        public PredstavnikView(Predstavnik p)
        {
            JMBG = p.JMBG;
            Ime = p.Ime;
            Prezime = p.Prezime;
            Pozicija = p.Pozicija;
            Telefon = p.Telefon;
            Email = p.Email;
            Id_Sektora = p.Sluzba.Id_Sektora;
            NazivSektora = p.Sluzba.TipSektora;
        }
    }
}
