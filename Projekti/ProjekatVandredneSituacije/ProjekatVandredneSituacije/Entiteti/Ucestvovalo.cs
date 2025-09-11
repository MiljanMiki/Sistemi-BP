using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    public class Ucestvovalo
    {

        public virtual Vozilo Vozilo { get; set; }
        public virtual InterventnaJedinica Jedinica { get; set; }
    }
}
