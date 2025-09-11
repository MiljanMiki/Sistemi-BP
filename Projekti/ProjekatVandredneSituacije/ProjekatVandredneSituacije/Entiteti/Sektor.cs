using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    public class Sektor
    {
        public virtual int Id_Sektora {  get; set; }
        public virtual string TipSektora { get; set; }
        public virtual string Uloga { get; set; }
        

        public IList<Saradjuje> VandredneSituacije {  get; set; }
        public Predstavnik? Predstavnik { get; set;}

        public Sektor()
        {
            VandredneSituacije = new List<Saradjuje>();
        }
    }
}
