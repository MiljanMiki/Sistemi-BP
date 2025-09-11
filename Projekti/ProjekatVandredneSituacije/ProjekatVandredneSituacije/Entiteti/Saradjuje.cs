using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    public class Saradjuje
    {
       
        public virtual Sektor Sektor { get; set; }

        public virtual VanrednaSituacija VandrednaSituacija { get; set; }
    }
}
