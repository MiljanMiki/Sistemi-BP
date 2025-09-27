using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    internal class IntervencijaView
    {

        public virtual int Id { get; set; }

        public virtual DateTime Datum_I_Vreme { get; set; }

        public virtual string Lokacija { get; set; }
        public virtual Status Status { get; set; }

        public virtual string Resursi { get; set; }
        public virtual int Broj_Spasenih { get; set; }
        public virtual int Broj_Povredjenih { get; set; }
        public virtual int Uspesnost { get; set; }
        public virtual IList<UcestvujeView> Ucestvuje { get; set; }

        public virtual IList<UcestvovaloView> Ucestvovalos { get; set; }
        public IntervencijaView()
        {
            Ucestvuje = new List<UcestvujeView>();
            Ucestvovalos = new List<UcestvovaloView>();
        }

        public IntervencijaView(Intervencija i)
        {
            Id = i.Id;
            Datum_I_Vreme = i.Datum_I_Vreme;
            Lokacija = i.Lokacija;
            Status = i.Status;
            Resursi = i.Resursi;
            Broj_Spasenih = i.Broj_Spasenih;
            Broj_Povredjenih = i.Broj_Povredjenih;
            Uspesnost = i.Uspesnost;
        }
    }
    internal class IntervencijaBasicView
    {
        public virtual int Id { get; set; }

        public virtual DateTime Datum_I_Vreme { get; set; }

        public virtual string Lokacija { get; set; }
        public virtual Status Status { get; set; }

        public virtual string Resursi { get; set; }
        public virtual int Broj_Spasenih { get; set; }
        public virtual int Broj_Povredjenih { get; set; }
        public virtual int Uspesnost { get; set; }

        public IntervencijaBasicView(Intervencija i)
        {
            Id = i.Id;
            Datum_I_Vreme = i.Datum_I_Vreme;
            Lokacija = i.Lokacija;
            Status= i.Status; 
            Resursi = i.Resursi;
            Broj_Spasenih = i.Broj_Spasenih;
            Broj_Povredjenih = i.Broj_Povredjenih;
            Uspesnost = i.Uspesnost;
        }
    }
}
