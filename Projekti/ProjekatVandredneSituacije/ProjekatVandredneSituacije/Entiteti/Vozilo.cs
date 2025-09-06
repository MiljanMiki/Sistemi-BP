using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Vozilo
    {
        public virtual int Registarska_Oznaka { get; set; }
        public virtual string Proizvodjac {  get; set; }
        public virtual string Tip {  get; set; }
        public virtual string Status { get; set; }
        public virtual string Lokacija { get; set; }

        public virtual IList<Servisi> Servisi { get; set; }

        public virtual IList<DajeSeJedinicama> DodeljujeJed { get; set; }

        public virtual IList<DajeSePojedincu> DodeljujePojed { get; set; }


      
        
        public Vozilo()
        {
            Servisi = new List<Servisi>();
            DodeljujeJed= new List<DajeSeJedinicama>();
            DodeljujePojed = new List<DajeSePojedincu>();
        }
    }

}
