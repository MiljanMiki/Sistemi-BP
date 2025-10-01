
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class KamioniView: VoziloView
    {
        public KamioniView() { }
        public KamioniView(Vozilo v): base(v) { }
    }

    public class KamioniAddView : VoziloAddView
    {
        public KamioniAddView() { }
        public KamioniAddView(Vozilo v) : base(v) { }
    }

    public class KamioniChangeView : VoziloChangeView
    {
        public KamioniChangeView() { }
        public KamioniChangeView(Vozilo v) : base(v) { }
    }
}
