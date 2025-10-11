
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class SanitetskaView : VoziloView
    {
        public SanitetskaView() { }

        public SanitetskaView(Vozilo v): base(v) { }   
    }

    public class SanitetskaAddView : VoziloAddView
    {
        public SanitetskaAddView() { }

        public SanitetskaAddView(Vozilo v) : base(v) { }
    }

    public class SanitetskaChangeView : VoziloChangeView
    {
        public SanitetskaChangeView() { }

        public SanitetskaChangeView(Vozilo v) : base(v) { }
    }
}
