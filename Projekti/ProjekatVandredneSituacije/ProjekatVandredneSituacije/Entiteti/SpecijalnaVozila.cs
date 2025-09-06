using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class SpecijalnaVozila
    {
        public virtual int Registarska_Oznaka { get; set; }
        public virtual int Namena { get; set; }

        public virtual bool Voda { get; set; }
        public virtual bool Sator { get; set; }
        public virtual bool Hemija { get; set; }

        public virtual bool Mobilna_Laboratorija { get; set; }

    }

}   

