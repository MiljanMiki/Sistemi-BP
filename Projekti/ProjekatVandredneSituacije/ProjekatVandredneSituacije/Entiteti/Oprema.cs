using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Oprema
    {
        public virtual int Serijski_Broj {  get; set; }    
        public virtual string Naziv {  get; set; }

        public virtual DateTime DatumNabavke {  get; set; }

        public virtual string Status { get; set; }

        public virtual string TipOpreme {  get; set; }

        public virtual InterventnaJedinica Jedinica {  get; set; }

    }

    internal class MedicinskaOprema : Oprema { }

    internal class TehnickaOprema: Oprema { }
    internal class LicnaZastita : Oprema { }
    internal class Zalihe : Oprema 
    {
        public virtual int Kolicina {  get; set; }

    }
}
