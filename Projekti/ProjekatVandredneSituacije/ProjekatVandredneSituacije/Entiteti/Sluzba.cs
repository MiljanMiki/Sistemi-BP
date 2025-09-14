using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    public class Sluzba
    {
        public virtual int Id_Sektora {  get; set; }
        public virtual string TipSektora { get; set; }
       
        

        public IList<Saradjuje> VandredneSituacije {  get; set; }
        public Predstavnik? Predstavnik { get; set;}

        public Sluzba()
        {
            VandredneSituacije = new List<Saradjuje>();
        }
    }
}
