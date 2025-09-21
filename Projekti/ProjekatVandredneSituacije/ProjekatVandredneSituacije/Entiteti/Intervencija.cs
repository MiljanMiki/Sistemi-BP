using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Entiteti
{
    public enum Status
    {
        Uspesna, Neuspesna
    }
    public class Intervencija
    {
        public virtual int Id { get; set; }

        public virtual DateTime Datum_I_Vreme { get; set; }
       
        public virtual string Lokacija { get; set; }
        public virtual Status Status { get; set; }

        public virtual string Resursi {  get; set; }
        public virtual int Broj_Spasenih { get; set; }
        public virtual int Broj_Povredjenih { get; set; }
        public virtual int Uspesnost { get; set; }
        public virtual IList<Ucestvuje> Ucestvuje { get; set; }

        public virtual IList<Ucestvovalo> Ucestvovalos { get; set; }
        public Intervencija()
        {
            Ucestvuje = new List<Ucestvuje>();
            Ucestvovalos = new List<Ucestvovalo>();
        }
    }
}
