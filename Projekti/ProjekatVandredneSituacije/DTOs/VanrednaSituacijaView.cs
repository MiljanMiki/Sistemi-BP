using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class VanrednaSituacijaAddView
    {
        public virtual   DateTime Datum_Od { get; set; }
        public virtual   DateTime? Datum_Do { get; set; }

        public virtual   string Tip { get; set; }
        public virtual int? Broj_Ugrozenih_Osoba { get; set; } 
        public virtual   NivoOpasnosti Nivo_Opasnosti { get; set; }
        public virtual   string Opstina { get; set; }
        public virtual   string Lokacija { get; set; }
        public virtual string? Opis { get; set; } = "";

        public virtual  int IdPrijave { get; set; }


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
    
   public  class VanrednaSituacijaMiniView
   {
       public virtual  int Id { get; set; }
       public virtual  string Tip { get; set; }
       public virtual  string Opstina { get; set; }
       public virtual  string Lokacija { get; set; }
       public virtual  string Nivo_Opasnosti { get; set; }

      public virtual string? Opis { get; set; }

        public VanrednaSituacijaMiniView() { }
       public VanrednaSituacijaMiniView(VanrednaSituacija v)
       {
           Id = v.Id;
           Tip = v.Tip;
           Opstina = v.Opstina;
           Lokacija = v.Lokacija;
           Nivo_Opasnosti = v.Nivo_Opasnosti.ToString();
           Opis = v.Opis;
        }
    }

    public  class VanrednaSituacijaView
    {
        public virtual  int Id { get; set; }
        public virtual  DateTime Datum_Od { get; set; }
        public virtual DateTime? Datum_Do { get; set; }

        public virtual  string Tip { get; set; }
        public virtual  int? Broj_Ugrozenih_Osoba { get; set; }
        public virtual  string Nivo_Opasnosti { get; set; }
        public virtual   string Opstina { get; set; }
        public virtual   string Lokacija { get; set; }
        public virtual string? Opis { get; set; }

        //Dodat getter
        public virtual int IdPrijave { get { return Prijava.Id; } }
        public virtual PrijavaMiniView Prijava { get; set; }
 
        public VanrednaSituacijaView()
        {

        }

        public VanrednaSituacijaView(VanrednaSituacija v)
        {
            Id = v.Id;
            Datum_Od = v.Datum_Od;
            Datum_Do = v.Datum_Do;
            Tip = v.Tip;
            Broj_Ugrozenih_Osoba = v.Broj_Ugrozenih_Osoba;
            Nivo_Opasnosti = v.Nivo_Opasnosti.ToString();
            Opstina = v.Opstina;
            Lokacija = v.Lokacija;
            Opis = v.Opis;
            Prijava = new PrijavaMiniView(v.Prijava_ID);
        }
    }
}
