using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Ucestvuje
    {
        public virtual int Id{ get; set; }
        public virtual InterventnaJedinica IdInterventneJed {  get; set; }
        public virtual VandrednaSituacija IdVandredneSituacije { get; set; }

        public virtual Intervencija IdIntervencije { get; set; }


       


    }
}
