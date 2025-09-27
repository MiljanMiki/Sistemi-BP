using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.DTOs
{
    internal class SanitetskaView : VoziloView
    {
        public SanitetskaView() { }

        public SanitetskaView(Vozilo v): base(v) { }   
    }
}
