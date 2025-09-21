using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.Entiteti
{
    public class Ucestvuje
    {
        public virtual int Id{ get; set; }
        public virtual InterventnaJedinica IdInterventneJed {  get; set; }
        public virtual VanrednaSituacija IdVandredneSituacije { get; set; }

        public virtual Intervencija IdIntervencije { get; set; }


       


    }
}
