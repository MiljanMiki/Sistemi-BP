using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum VrstaSpecijalnogVozila
{
    Voda,
    Sator,
    Hemija,
    Mobilna_Laboratorija
}

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class SpecijalnaVozila
    {
        public virtual int Registarska_Oznaka { get; set; }
        public virtual VrstaSpecijalnogVozila Vrsta { get; set; }

    }

}   

