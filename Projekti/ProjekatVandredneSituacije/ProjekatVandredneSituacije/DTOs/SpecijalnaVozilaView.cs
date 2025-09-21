using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class SpecijalnaVozilaView:VoziloView
    {
        public virtual Namena Namena { get; set; }

        public SpecijalnaVozilaView() { }

        public SpecijalnaVozilaView(SpecijalnaVozila s): base(s)
        {
            Namena = s.Namena;
        }
    }
}
