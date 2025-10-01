
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class SpecijalnaVozilaView:VoziloView
    {
        public virtual string Namena { get; set; }

        public SpecijalnaVozilaView() { }

        public SpecijalnaVozilaView(SpecijalnaVozila s): base(s)
        {
            Namena = s.Namena.ToString();
        }
    }

    public class SpecijalnaVozilaChangeView : VoziloChangeView
    {
        public virtual Namena Namena { get; set; }

        public SpecijalnaVozilaChangeView() { }

        public SpecijalnaVozilaChangeView(SpecijalnaVozila s) : base(s)
        {
            Namena = s.Namena;
        }
    }

    public class SpecijalnaVozilaAddView : VoziloAddView
    {
        public virtual Namena Namena { get; set; }

        public SpecijalnaVozilaAddView() { }

        public SpecijalnaVozilaAddView(SpecijalnaVozila s) : base(s)
        {
            Namena = s.Namena;
        }
    }
}
