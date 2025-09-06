using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Saradjuje
    {
       
        public virtual Sektor Sektor { get; set; }

        public virtual VandrednaSituacija VandrednaSituacija { get; set; }
    }
}
