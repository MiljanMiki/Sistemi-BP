using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Terenska:Vozilo
    {
        public virtual string Tip {  get; set; }
        
    }

    class Kamioni : Terenska 
    {
        public Kamioni() { }
    }
    class Dzipovi : Terenska
    {
        public Dzipovi() { }

    }
}
