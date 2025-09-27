using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.DTOs
{
    internal class SpecijalnaVozilaView:VoziloView
    {
        public virtual Namena Namena { get; set; }

        public SpecijalnaVozilaView(string registarska_Oznaka, string proizvodjac)
        {
            Registarska_Oznaka = registarska_Oznaka;
            Proizvodjac = proizvodjac;
        }

        public SpecijalnaVozilaView(SpecijalnaVozila s): base(s)
        {
            Namena = s.Namena;
        }
    }
}
