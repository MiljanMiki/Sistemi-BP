using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class KamioniView: VoziloView
    {
        public KamioniView() { }
        public KamioniView(Vozilo v): base(v) { }
    }
}
