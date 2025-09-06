using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class DajeSeJedinicama
    {
        public virtual Vozilo Vozilo {  get; set; }
        public virtual InterventnaJedinica Intervente_Jedinice { get; set; }

        public virtual DateTime datumod {  get; set; }
        public virtual DateTime datumDo {  get; set; }
    }
}
