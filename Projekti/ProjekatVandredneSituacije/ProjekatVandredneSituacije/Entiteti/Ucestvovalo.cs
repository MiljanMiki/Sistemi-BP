using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Ucestvovalo
    {

        public virtual int ID { get; set; }
        public virtual Vozilo Vozilo { get; set; }
        public virtual InterventnaJedinica Jedinica { get; set; }
    }
}
