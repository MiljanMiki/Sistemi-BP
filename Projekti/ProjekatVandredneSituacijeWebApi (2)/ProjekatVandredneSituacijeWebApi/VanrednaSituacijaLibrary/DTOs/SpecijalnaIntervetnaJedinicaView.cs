using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class SpecijalnaIntervetnaJedinicaView:InterventnaJedinicaView
    {
        public virtual string TipSpecijalneJedinice { get; set; }

        public SpecijalnaIntervetnaJedinicaView() { }
        public SpecijalnaIntervetnaJedinicaView(SpecijalnaInterventna s):base(s)
        {
            TipSpecijalneJedinice = s.TipSpecijalneJedinice;
        }
    }

    public class SpecijalnaIntervetnaJedinicaBasicView : InterventnaJedinicaBasicView
    {
        public virtual string TipSpecijalneJedinice { get; set; }

        public SpecijalnaIntervetnaJedinicaBasicView() { }
        public SpecijalnaIntervetnaJedinicaBasicView(SpecijalnaInterventna s) : base(s)
        {
            TipSpecijalneJedinice = s.TipSpecijalneJedinice;
        }
    }

    public  class SpecijalnaIntervetnaGetView : InterventnaJedinicaGetView
    {

        public virtual string TipSpecijalneJedinice { get; set; }

        public SpecijalnaIntervetnaGetView()
        { 
        }
        public SpecijalnaIntervetnaGetView(InterventnaJedinica i) : base(i) {

            this.TipSpecijalneJedinice = TipSpecijalneJedinice;
        }
    }
}
