using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    public class Kordinator:Zaposlen
    {
        public virtual int BrojTimova { get; set; }

        public virtual Specijalizacija Specijalizacija { get; set; }
    }
}
