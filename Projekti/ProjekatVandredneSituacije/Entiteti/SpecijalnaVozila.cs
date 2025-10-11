using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{

    public enum Namena{
        Za_vodu,
        Za_hemiju,
        Za_sator,
        Mobilna_laboratorija
    }
    public  class SpecijalnaVozila:Vozilo
    {

        public virtual   Namena Namena { get; set; }
    }

}   

