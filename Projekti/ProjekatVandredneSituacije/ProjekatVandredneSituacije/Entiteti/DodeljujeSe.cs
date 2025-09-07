using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class DodeljujeSe
    {
        public virtual Vozilo Vozilo { get; set; }

        public virtual OperativniRadnik? Pojedinac { get; set; }

        public virtual InterventnaJedinica? Jedinica{ get; set; }

        public virtual DateTime DatumOd {  get; set; }

        public virtual DateTime DatumDo {  get; set; }
    }
}
