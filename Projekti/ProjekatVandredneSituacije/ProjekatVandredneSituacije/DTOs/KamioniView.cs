using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVanredneSituacije.Entiteti;

namespace ProjekatVanredneSituacije.DTOs
{
    internal class KamioniView: VoziloView
    {
        public KamioniView() { }
        public KamioniView(Vozilo v): base(v) { }
    }
}
