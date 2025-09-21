using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.Entiteti
{
    public class Kordinator:Zaposlen
    {
        public virtual int BrojTimova { get; set; }
        public virtual IList<Specijalizacija> Specijalizacija { get; set; }
        
        public Kordinator()
        {
            Specijalizacija = new List<Specijalizacija>();
        }
    }
}
