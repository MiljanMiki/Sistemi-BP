using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    public class Softver
    {
        public virtual int Id { get; set; }
        public Analiticar Analiticar { get; set; }
        public virtual string Naziv { get; set; }

        
    }
}
