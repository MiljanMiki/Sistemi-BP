using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class SpecijalnaIntervetnaJedinicaView:InterventnaJedinicaView
    {
        public virtual string TipSpecijalneJedinice { get; set; }

        public SpecijalnaIntervetnaJedinicaView(SpecijalnaInterventna s):base(s)
        {
            TipSpecijalneJedinice = s.TipSpecijalneJedinice;
        }
    }

    internal class SpecijalnaIntervetnaGetView : InterventnaJedinicaGetView
    {
        public virtual string TipSpecijalneJedinice { get; set; }
        public SpecijalnaIntervetnaGetView(InterventnaJedinica i) : base(i) {

            this.TipSpecijalneJedinice = TipSpecijalneJedinice;
        }
    }
}
