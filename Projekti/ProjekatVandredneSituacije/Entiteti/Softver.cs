using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.Entiteti
{
    public class Softver
    {
        public virtual  int Id { get; set; }
        public virtual   Analiticar Analiticar { get; set; }
        public virtual  string Naziv { get; set; }

        
    }
}
