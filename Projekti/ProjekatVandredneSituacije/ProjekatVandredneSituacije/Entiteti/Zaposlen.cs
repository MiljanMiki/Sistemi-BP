using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Zaposlen
    {
        public virtual int JMBG { get; set; }

        public virtual string Ime { get; set; }

        public virtual string Prezime { get; set; }

        public virtual DateTime Datum_Rodjenja { get; set; }

        public virtual string Pol { get; set; }

        public virtual string Kontakt_Telefon { get; set; }

        public virtual string Email { get; set; }

        public virtual string AdresaStanovanja { get; set; }

        public virtual string Datum_Zaposlenja { get; set; }

        public virtual string Tip { get; set; }

        public virtual IList<Istorija_Uloga_Zaposlenih> Istorija {  get; set; }

        public Zaposlen()
        {
            Istorija= new List<Istorija_Uloga_Zaposlenih>();
        }

    }
}
