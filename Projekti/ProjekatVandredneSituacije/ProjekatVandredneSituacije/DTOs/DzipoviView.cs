using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.DTOs
{
    internal class DzipoviView:VoziloView
    {
        public DzipoviView() { }

        public DzipoviView(Vozilo v): base(v) { }
    }
}
