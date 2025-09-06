using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class VandrednaSituacija
    {
        public virtual int Id { get; set; }
        public virtual DateTime Datum_Od {  get; set; }
        public virtual DateTime Datum_Do { get; set; }

        public virtual string Tip { get; set; }
        public virtual int Broj_Ugrozenih_Osoba {  get; set; }
        public virtual int Nivo_Opasnosti { get; set; }
        public virtual string Opstina { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual string Opis { get; set; }

        public virtual Prijava Prijava { get; set; }
        public virtual IList<Ucestvuje> Ucestvuje {  get; set; }
        public virtual IList<AngazovanjeSaradnje> Saradjuje {  get; set; }

        public VandrednaSituacija()
        {
            Ucestvuje = new List<Ucestvuje>();
            Saradjuje= new List<AngazovanjeSaradnje>();
        }
    }
}
