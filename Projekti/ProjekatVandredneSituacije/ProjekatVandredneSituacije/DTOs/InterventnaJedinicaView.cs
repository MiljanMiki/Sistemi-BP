using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class InterventnaJedinicaView
    {
        public virtual int Jedinstveni_Broj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual int BrojClanova { get; set; }
        public virtual string Baza { get; set; }

        public virtual string JMBGKomandira { get; set; }
     

        public virtual IList<DodeljujeSeView> Dodeljuje { get; set; }

        public virtual IList<OperativniRadnikView> Radnici { get; set; }

        public virtual IList<UcestvujeView> Ucestvuje { get; set; }


        public virtual IList<UcestvovaloView> AngazovanaVozila { get; set; }

        public virtual IList<OpremaView> Oprema { get; set; }

        public InterventnaJedinicaView()
        {
            Dodeljuje = new List<DodeljujeSeView>();
            Radnici = new List<OperativniRadnikView>();
            Ucestvuje = new List<UcestvujeView>();
            AngazovanaVozila = new List<UcestvovaloView>();
            Oprema = new List<OpremaView>();

        }

        public InterventnaJedinicaView(InterventnaJedinica ij)
        {
            Naziv = ij.Naziv;
            BrojClanova = ij.BrojClanova;
            Baza = ij.Baza;
            JMBGKomandira = ij.Komandir.JMBG;
            
        }
    }

    internal class InterventnaJedinicaBasicView
    {
        public virtual int Jedinstveni_Broj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual int BrojClanova { get; set; }
        public virtual string Baza { get; set; }
        public InterventnaJedinicaBasicView()
        {
        }
        public InterventnaJedinicaBasicView(InterventnaJedinica ij)
        {
            Jedinstveni_Broj = ij.Jedinstveni_Broj;
            Naziv = ij.Naziv;
            BrojClanova = ij.BrojClanova;
            Baza = ij.Baza;
        }
    }

    internal class InterventnaJedinicaGetView
    {
        public virtual int Jedinstveni_Broj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual int BrojClanova { get; set; }
        public virtual string Baza { get; set; }

        public virtual OperativniRadnikChangeView Komandir { get; set; }


        public virtual IList<DodeljujeSeView> Dodeljuje { get; set; }

        public virtual IList<OperativniRadnikView> Radnici { get; set; }

        public virtual IList<UcestvujeView> Ucestvuje { get; set; }


        public virtual IList<UcestvovaloView> AngazovanaVozila { get; set; }

        public virtual IList<OpremaView> Oprema { get; set; }

        public InterventnaJedinicaGetView()
        {
            Dodeljuje = new List<DodeljujeSeView>();
            Radnici = new List<OperativniRadnikView>();
            Ucestvuje = new List<UcestvujeView>();
            AngazovanaVozila = new List<UcestvovaloView>();
            Oprema = new List<OpremaView>();

        }

        public InterventnaJedinicaGetView(InterventnaJedinica ij)
        {
            Jedinstveni_Broj = ij.Jedinstveni_Broj;
            Naziv = ij.Naziv;
            BrojClanova = ij.BrojClanova;
            Baza = ij.Baza;
            Komandir = new OperativniRadnikChangeView(ij.Komandir);
        }
    }
}
