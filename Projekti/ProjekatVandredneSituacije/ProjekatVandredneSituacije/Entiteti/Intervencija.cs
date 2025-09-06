using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Intervencija
    {
        public virtual int ID { get; set; }
        public virtual int Id_VAndredne_Situacije { get; set; }
    
        public virtual DateTime Datum_I_Vreme { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual string Status { get; set; }
        public virtual int Broj_Spasenih { get; set; }
        public virtual int Broj_Povredjenih { get; set; }
        public virtual int Uspesnost { get; set; }
        public virtual IList<Ucestvuje> Ucestvuje { get; set; }

        public Intervencija()
        {
            Ucestvuje = new List<Ucestvuje>();
        }
    }
}
