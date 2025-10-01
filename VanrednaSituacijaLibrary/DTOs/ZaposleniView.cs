using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    internal class ZaposleniView
    {

        public virtual string JMBG { get; set; }

        public virtual string Ime { get; set; }

        public virtual string Prezime { get; set; }

        public virtual DateTime Datum_Rodjenja { get; set; }

        public virtual string Pol { get; set; }

        public virtual string Kontakt_Telefon { get; set; }

        public virtual string Email { get; set; }

        public virtual string AdresaStanovanja { get; set; }

        public virtual DateTime Datum_Zaposlenja { get; set; }


        public virtual IList<Istorija_Uloga_ZaposlenihView> Istorija { get; set; }

        public ZaposleniView()
        {
            Istorija = new List<Istorija_Uloga_ZaposlenihView>();
        }

        public ZaposleniView(Zaposlen z)
        {
            JMBG = z.JMBG;
            Ime = z.Ime;
            Prezime = z.Prezime;
            Datum_Rodjenja = z.Datum_Rodjenja;
            Pol = z.Pol;
            Kontakt_Telefon = z.Kontakt_Telefon;
            Email = z.Email;
            AdresaStanovanja = z.AdresaStanovanja;
            Datum_Zaposlenja = z.Datum_Zaposlenja;
            
        }



    }
}
