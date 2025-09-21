using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Entiteti
{

    public enum Namena{
        Voda,
        Sator,
        Hemija,
        Mobilna_Laboratorija
    }
    internal class SpecijalnaVozila:Vozilo
    {

        public virtual Namena Namena { get; set; }
    }

}   

