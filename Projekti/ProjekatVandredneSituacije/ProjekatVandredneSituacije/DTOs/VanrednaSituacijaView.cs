using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVanredneSituacije.Entiteti;

namespace ProjekatVanredneSituacije.DTOs
{
    public class VanrednaSituacijaAddView
    {
        public virtual DateTime Datum_Od { get; set; }
        public virtual DateTime Datum_Do { get; set; }

        public virtual string Tip { get; set; }
        public virtual int Broj_Ugrozenih_Osoba { get; set; }
        public virtual NivoOpasnosti Nivo_Opasnosti { get; set; }
        public virtual string Opstina { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual string Opis { get; set; }

        public virtual int IdPrijave { get; set; }


        public VanrednaSituacijaAddView()
        {
           
        }

        public VanrednaSituacijaAddView(VanrednaSituacija v)
        {
            Datum_Od = v.Datum_Od;
            Datum_Do = v.Datum_Do;
            Tip = v.Tip;
            Broj_Ugrozenih_Osoba = v.Broj_Ugrozenih_Osoba;
            Nivo_Opasnosti = v.Nivo_Opasnosti;
            Opstina = v.Opstina;
            Lokacija = v.Lokacija;
            Opis = v.Opis;
            IdPrijave = v.Prijava_ID.Id;
        }
    }
    
   internal class VanrednaSituacijaMiniView
   {
       public virtual int Id { get; set; }
       public virtual string Tip { get; set; }
       public virtual string Opstina { get; set; }
       public virtual string Lokacija { get; set; }
       public virtual NivoOpasnosti Nivo_Opasnosti { get; set; }

      public virtual string Opis { get; set; }

        public VanrednaSituacijaMiniView() { }
       public VanrednaSituacijaMiniView(VanrednaSituacija v)
       {
           Id = v.Id;
           Tip = v.Tip;
           Opstina = v.Opstina;
           Lokacija = v.Lokacija;
           Nivo_Opasnosti = v.Nivo_Opasnosti;
           Opis = v.Opis;
        }
    }

    internal class VanrednaSituacijaView
    {
        public virtual int Id { get; set; }
        public virtual DateTime Datum_Od { get; set; }
        public virtual DateTime Datum_Do { get; set; }

        public virtual string Tip { get; set; }
        public virtual int Broj_Ugrozenih_Osoba { get; set; }
        public virtual NivoOpasnosti Nivo_Opasnosti { get; set; }
        public virtual string Opstina { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual string Opis { get; set; }

        public virtual PrijavaMiniView Prijava { get; set; }
        public virtual IList<UcestvujeView> Ucestvuje { get; set; }
        public virtual IList<SaradjujeView> Saradjuje { get; set; }

        public VanrednaSituacijaView()
        {
            Ucestvuje = new List<UcestvujeView>();
            Saradjuje = new List<SaradjujeView>();
        }

        public VanrednaSituacijaView(VanrednaSituacija v)
        {
            Id = v.Id;
            Datum_Od = v.Datum_Od;
            Datum_Do = v.Datum_Do;
            Tip = v.Tip;
            Broj_Ugrozenih_Osoba = v.Broj_Ugrozenih_Osoba;
            Nivo_Opasnosti = v.Nivo_Opasnosti;
            Opstina = v.Opstina;
            Lokacija = v.Lokacija;
            Opis = v.Opis;
            Prijava = new PrijavaMiniView(v.Prijava_ID);
        }
    }
}
