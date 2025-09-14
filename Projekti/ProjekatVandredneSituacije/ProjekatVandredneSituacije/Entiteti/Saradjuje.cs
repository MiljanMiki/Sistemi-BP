using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    public class Saradjuje
    {

        public virtual int Id { get; set; }
        public string Uloga {  get; set; }
        public virtual Sluzba Sektor { get; set; }

        public virtual VanrednaSituacija VandrednaSituacija { get; set; }
    }
}
