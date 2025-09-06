using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Istorija_Uloga_Zaposlenih
    {
        public virtual Zaposlen Zaposleni {  get; set; }
        public virtual string Uloga {  get; set; }
        public virtual DateTime Datum_Od { get; set; }
        public virtual DateTime Datum_Do { get; set; }


    }
}
