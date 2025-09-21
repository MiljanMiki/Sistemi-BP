using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class DzipoviView:VoziloView
    {
        public DzipoviView() { }

        public DzipoviView(Vozilo v): base(v) { }
    }
}
