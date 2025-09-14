using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    public class Analiticar : Zaposlen
    {
        public virtual IList<Softver> Softveri { get; set; }
        public virtual IList<Ekspertiza> Ekspertiza {  get; set; }
        public Analiticar()
        {
            Softveri = new List<Softver>();
            Ekspertiza = new List<Ekspertiza>();
        }
    }
   
}
