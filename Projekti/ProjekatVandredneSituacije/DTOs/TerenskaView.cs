using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class TerenskaView: VoziloView
    {
        public TerenskaView() { }

        public TerenskaView(Vozilo v):base(v) { }
    }

    public class TerenskaChangeView : VoziloChangeView
    {
        public TerenskaChangeView() { }

        public TerenskaChangeView(Vozilo v) : base(v) { }
    }

}
