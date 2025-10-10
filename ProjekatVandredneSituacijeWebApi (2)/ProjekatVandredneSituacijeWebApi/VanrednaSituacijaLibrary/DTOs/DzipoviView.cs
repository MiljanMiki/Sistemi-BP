using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class DzipoviView:VoziloView
    {
        public DzipoviView() { }

        public DzipoviView(Vozilo v): base(v) { }
    }

    public class DzipoviAddView : VoziloAddView
    {
        public DzipoviAddView() { }

        public DzipoviAddView(Vozilo v) : base(v) { }
    }

    public class DzipoviChangeView : VoziloChangeView
    {
        public DzipoviChangeView() { }

        public DzipoviChangeView(Vozilo v) : base(v) { }
    }
}
