using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    internal class KamioniView: VoziloView
    {
        public KamioniView() { }
        public KamioniView(Vozilo v): base(v) { }
    }
}
