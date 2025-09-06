using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{

    public enum Namena{
        Voda,
        Sator,
        Hemija,
        Mobilna_Laboratorija
    }
    internal class SpecijalnaVozila:Vozilo
    {
        public virtual int Registarska_Oznaka { get; set; }
        public virtual Namena Namena { get; set; }

      
    }

}   

