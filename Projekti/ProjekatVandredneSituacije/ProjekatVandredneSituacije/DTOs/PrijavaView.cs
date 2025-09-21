using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class PrijavaView
    {
        public virtual int Id { get; set; }

        public virtual DateTime Datum_I_Vreme { get; set; }
       

        
        public virtual string Tip { get; set; }
        public virtual string Ime_Prijavioca { get; set; }
        public virtual string Kontakt { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual string Opis { get; set; }
        public virtual string JMBG_Dispecer { get; set; }

        public virtual int Prioritet { get; set; }

        public virtual VanrednaSituacijaView? Id_VandrednaSituacija { get; set; }

        public PrijavaView()
        {
        }

        public PrijavaView(Prijava p)
        {
            Id = p.Id;
            Datum_I_Vreme= p.Datum_I_Vreme;
            Tip = p.Tip;
            Ime_Prijavioca = p.Ime_Prijavioca;
            Kontakt = p.Kontakt;
            Lokacija = p.Lokacija;
            Opis = p.Opis;
            JMBG_Dispecer = p.JMBG_Dispecer;
            Prioritet = p.Prioritet;
            if (p.Id_VandrednaSituacija != null)
            Id_VandrednaSituacija = new VanrednaSituacijaView(p.Id_VandrednaSituacija);
        }
    }

    internal class PrijavaAddView
    {
        public virtual int Id { get; set; }

        public virtual DateTime Datum_I_Vreme { get; set; }

        public virtual string Tip { get; set; }
        public virtual string Ime_Prijavioca { get; set; }
        public virtual string Kontakt { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual string Opis { get; set; }
        public virtual string JMBG_Dispecer { get; set; }

        public virtual int Prioritet { get; set; }

        public virtual int Id_VandrednaSituacija { get; set; }

        public PrijavaAddView()
        {
        }

        public PrijavaAddView(Prijava p)
        {
            Id = p.Id;
            Datum_I_Vreme = p.Datum_I_Vreme;
            Tip = p.Tip;
            Ime_Prijavioca = p.Ime_Prijavioca;
            Kontakt = p.Kontakt;
            Lokacija = p.Lokacija;
            Opis = p.Opis;
            JMBG_Dispecer = p.JMBG_Dispecer;
            Prioritet = p.Prioritet;
            if (p.Id_VandrednaSituacija != null)
                Id_VandrednaSituacija = p.Id_VandrednaSituacija.Id;
        }
    }

    internal class PrijavaMiniView
    {
        public virtual int Id { get; set; }
        public virtual DateTime Datum_I_Vreme { get; set; }
        public virtual string Tip { get; set; }
        public virtual string Ime_Prijavioca { get; set; }
        public virtual string Kontakt { get; set; }
        public virtual string Lokacija { get; set; }
        public virtual int Prioritet { get; set; }

        public virtual string Opis { get; set; }
        public PrijavaMiniView() { }
        public PrijavaMiniView(Prijava p)
        {
            Id = p.Id;
            Datum_I_Vreme = p.Datum_I_Vreme;
            Tip = p.Tip;
            Ime_Prijavioca = p.Ime_Prijavioca;
            Kontakt = p.Kontakt;
            Lokacija = p.Lokacija;
            Prioritet = p.Prioritet;
            Opis = p.Opis;
        }
    }

   
}
