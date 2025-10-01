using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Entiteti
{
    public enum NivoOpasnosti{
        niska, srednja, visoka
    }
    public class VanrednaSituacija
    {
        public virtual int Id { get; set; }
        public virtual DateTime Datum_Od {  get; set; }
        public virtual DateTime Datum_Do { get; set; }

        public virtual string Tip { get; set; }
        public virtual int Broj_Ugrozenih_Osoba {  get; set; }
        public virtual NivoOpasnosti Nivo_Opasnosti { get; set; }
        public virtual string Opstina { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual string Opis { get; set; }

        public virtual Prijava Prijava_ID { get; set; }
        public virtual IList<Ucestvuje> Ucestvuje {  get; set; }
        public virtual IList<Saradjuje> Saradjuje {  get; set; }

        public VanrednaSituacija()
        {
            Ucestvuje = new List<Ucestvuje>();
            Saradjuje= new List<Saradjuje>();
        }
    }
}
