using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.DTOs;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class InterventnaJedinicaView
    {
        public virtual string Naziv { get; set; }
        public virtual int BrojClanova { get; set; }
        public virtual string Baza { get; set; }

        public virtual string? JMBGKomandira { get; set; }
     


        public InterventnaJedinicaView()
        { }
        

        public InterventnaJedinicaView(InterventnaJedinica ij)
        {
            Naziv = ij.Naziv;
            BrojClanova = ij.BrojClanova;
            Baza = ij.Baza;
            if (ij.Komandir != null)
            {
                JMBGKomandira = ij.Komandir.JMBG;
            }
  
        }
    }

    public  class InterventnaJedinicaBasicView
    {
        public virtual string Naziv { get; set; }

        public virtual string Baza { get; set; }
        public virtual string JMBGKomandira { get; set; }
        public InterventnaJedinicaBasicView()
        {
        }
        public InterventnaJedinicaBasicView(InterventnaJedinica ij)
        {
  
            Naziv = ij.Naziv;
            Baza = ij.Baza;
            if (ij.Komandir != null)
                JMBGKomandira = ij.Komandir.JMBG;
        }
    }

    public  class InterventnaJedinicaGetView
    {
        public virtual int Jedinstveni_Broj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual int BrojClanova { get; set; }
        public virtual string Baza { get; set; }

        public virtual string? JMBGKomandira { get; set; }
        public virtual string? ImeKomandira { get; set; }

        public virtual string? PrezimeKomandira { get; set; }




        public InterventnaJedinicaGetView()
        {

        }

        public InterventnaJedinicaGetView(InterventnaJedinica ij)
        {
            Jedinstveni_Broj = ij.Jedinstveni_Broj;
            Naziv = ij.Naziv;
            BrojClanova = ij.BrojClanova;
            Baza = ij.Baza;
            if (ij.Komandir != null)
            {
                JMBGKomandira = ij.Komandir.JMBG;
                ImeKomandira = ij.Komandir.Ime;
                PrezimeKomandira = ij.Komandir.Prezime;

            }
        }
    }
}
