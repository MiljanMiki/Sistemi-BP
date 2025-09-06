using FluentNHibernate.Utils;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Impl;
using ProjekatVandredneSituacije;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije
{
   public class ZaposlenBasic
    {
        public int JMBG;

        public string Ime;

        public string Prezime;

        public DateTime Datum_Rodjenja;

        public string Pol;

        public string Kontakt_Telefon;

        public string Email;

        public string AdresaStanovanja;

        public string Datum_Zaposlenja;

        public string Tip;

        public IList<Istorija_Uloga_ZaposlenihBasic> Istorija; 

        public ZaposlenBasic(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja,  string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip)
        {
            this.JMBG = JMBG;
            this.Ime=Ime;
            this.Prezime=Prezime;
            this.Datum_Rodjenja = Datum_Rodjenja;
            Pol = pol;
            this.Kontakt_Telefon = Kontakt_Telefon;
            Email = email;
            this.Datum_Zaposlenja = DatumZaposlenja;
            this.Tip = Tip;
        }

        public ZaposlenBasic()
        {

        }


    }

    public class ZaposlenPregled
    {
        public  int JMBG;

        public  string Ime;

        public  string Prezime;

        public  DateTime Datum_Rodjenja;

        public  string Pol;

        public  string Kontakt_Telefon;

        public  string Email;

        public  string AdresaStanovanja;

        public  string Datum_Zaposlenja;

        public  string Tip;

        public IList<Istorija_Uloga_ZaposlenihBasic> Istorija; 

        public ZaposlenPregled(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip)
        {
            this.JMBG = JMBG;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.Datum_Rodjenja = Datum_Rodjenja;
            Pol = pol;
            this.Kontakt_Telefon = Kontakt_Telefon;
            Email = email;
            this.Datum_Zaposlenja = DatumZaposlenja;
            this.Tip = Tip;
        }

        public ZaposlenPregled()
        {

        }
    }

    public class AnaliticarBasic: ZaposlenBasic
    {
        public string Softver;
        public AnaliticarBasic()
        {
        }

        public AnaliticarBasic(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip, string Softver) :
            base(JMBG,Ime,Prezime,Datum_Rodjenja,pol, Kontakt_Telefon, email,DatumZaposlenja, Tip)
          
        {
            this.Softver = Softver;
        }

    }

    public class AnaliticarPregled: ZaposlenPregled
    {
        public string Softver;


        public AnaliticarPregled()
        { 
        }

        public AnaliticarPregled(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip, string Softver):
            base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, DatumZaposlenja, Tip)
        {
            this.Softver = Softver;
        }
    }

    public class KordinatorPregled:ZaposlenPregled
    {
        public int BrojTimova;

        public KordinatorPregled()
        {
        }

        public KordinatorPregled(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip, int BrojTimova) :
            base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, DatumZaposlenja, Tip)
        {
            this.BrojTimova = BrojTimova;
        }
    }
}

    public class KordinatorBasic:ZaposlenBasic
    {
    public int BrojTimova; 

    public KordinatorBasic()
    {
    }

    public KordinatorBasic(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip, int BrojTimova) 
        :base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, DatumZaposlenja, Tip)
    {
        this.BrojTimova = BrojTimova;
    }
}

 
    public class OperativniRadnikBasic:ZaposlenBasic
    {
    public  int Broj_Sati;
    public  string Fizicka_Spremnost;

    public  IList<DajeSePojedincuBasic> Dodeljuje;

    public  InterventnaJedinicaBasic InterventnaJedinica;

    public  IList<SertifikatBasic> Sertifikats;

    public OperativniRadnikBasic()
    {
        Dodeljuje = new List<DajeSePojedincuBasic>();
        Sertifikats = new List<SertifikatBasic>();
    }

    public OperativniRadnikBasic(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip, int Broj_Sati, string Fizicka_Spremnost)
        : base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, DatumZaposlenja, Tip)
    {
        this.Broj_Sati=Broj_Sati;
        this.Fizicka_Spremnost = Fizicka_Spremnost;
    }
}

    public class OperativniRadnikPregled:ZaposlenPregled
    {
    public int Broj_Sati;
    public string Fizicka_Spremnost;

    public IList<DajeSePojedincuBasic> Dodeljuje;

    public InterventnaJedinicaBasic InterventnaJedinica;

    public IList<SertifikatBasic> Sertifikats;

    public OperativniRadnikPregled()
    {
        Dodeljuje = new List<DajeSePojedincuBasic>();
        Sertifikats = new List<SertifikatBasic>();
    }
    public OperativniRadnikPregled(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip, int Broj_Sati, string Fizicka_Spremnost)
    : base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, DatumZaposlenja, Tip)
    {
        this.Broj_Sati = Broj_Sati;
        this.Fizicka_Spremnost = Fizicka_Spremnost;
    }

}

    public class OpremaBasic
    {
    public int Serijski_Broj;
    public DateTime DatumNabavke;

    public string Status;

    public string TipOpreme;

    public InterventnaJedinicaBasic Jedinica;

    public OpremaBasic()
    {

    }

    public OpremaBasic(int Serijski_Broj, DateTime DatumNabavke, string Status, string TipOpreme)
    {
        this.Serijski_Broj = Serijski_Broj;
        this.DatumNabavke = DatumNabavke;
        this.Status = Status;
        this.TipOpreme=TipOpreme; 
    }
}

    public class OpremaPregled
    {
    public int Serijski_Broj;
    public DateTime DatumNabavke;

    public string Status;

    public string TipOpreme;

    public InterventnaJedinicaPregled Jedinica;

    public OpremaPregled()
    {

    }

    public OpremaPregled(int Serijski_Broj, DateTime DatumNabavke, string Status, string TipOpreme)
    {
        this.Serijski_Broj = Serijski_Broj;
        this.DatumNabavke = DatumNabavke;
        this.Status = Status;
        this.TipOpreme = TipOpreme;
    }
}

    public class VandrednaSituacijaBasic
    {
    public  int Id;
    public  DateTime Datum_Od;
    public  DateTime Datum_Do;
    public  int Broj_Ugrozenih_Osoba;
    public  string Nivo_Opasnosti;
    public  string Opstina;
    public  string Lokacija;
    public  string Opis;

    public  PrijavaBasic Prijava;
    public  IList<UcestvujeBasic> Ucestvuje;
    public  IList<AngazovanjeSaradnjeBasic> Saradjuje;

    public VandrednaSituacijaBasic()
    {
        Ucestvuje = new List<UcestvujeBasic>();
        Saradjuje = new List<AngazovanjeSaradnjeBasic>();
    }

    public VandrednaSituacijaBasic(int id, DateTime Datum_Od, DateTime Datum_Do, int Broj_Ugrozenih_Osoba, string Nivo_Opasnosti, string Opstina, string Lokacija, string Opis)
    {
        Id = id;
   
        this.Broj_Ugrozenih_Osoba = Broj_Ugrozenih_Osoba;
        this.Nivo_Opasnosti = Nivo_Opasnosti;
        this.Opstina = Opstina;
        this.Lokacija = Lokacija;
        this.Opis = Opis;
    }
}

    public class VandrednaSituacijaPregled
    {
    public  int Id;
    public DateTime Datum_Od;
    public DateTime Datum_Do;
    public  int Broj_Ugrozenih_Osoba;
    public  string Nivo_Opasnosti;
    public  string Opstina;
    public  string Lokacija;
    public  string Opis;

    public  PrijavaPregled Prijava;
    public  IList<UcestvujePregled> Ucestvuje;
    public  IList<AngazovanjeSaradnjePregled> Saradjuje;

    public VandrednaSituacijaPregled()
    {
        Ucestvuje = new List<UcestvujePregled>();
        Saradjuje = new List<AngazovanjeSaradnjePregled>();
    }


    public VandrednaSituacijaPregled(int id, DateTime Datum_Od, DateTime Datum_Do, int Broj_Ugrozenih_Osoba, string Nivo_Opasnosti, string Opstina, string Lokacija, string Opis)
    {
        Id = id;
        this.Datum_Od = Datum_Od;
        this.Datum_Do = Datum_Do;
        this.Broj_Ugrozenih_Osoba = Broj_Ugrozenih_Osoba;
        this.Nivo_Opasnosti = Nivo_Opasnosti;
        this.Opstina = Opstina;
        this.Lokacija = Lokacija;
        this.Opis = Opis;
    }
}

    public class IntervencijaBasic
    {
    public int ID;

    public DateTime Datum_I_Vreme;
    public string Lokacija;

    public string Status;
    public int Broj_Spasenih;
    public int Broj_Povredjenih;
    public int Uspesnost;
    public IList<UcestvujeBasic> Ucestvuje;

    public IntervencijaBasic()
    {
        Ucestvuje = new List<UcestvujeBasic>();
    }

    public IntervencijaBasic(int Id, DateTime DatumIVreme, string Lokacija, string Status, int Broj_Spasenih, int Broj_Povredjenih, int Uspesnost)
    {
        ID = Id;
        Datum_I_Vreme = DatumIVreme;
        this.Lokacija = Lokacija;
        this.Status = Status;
        this.Broj_Spasenih = Broj_Spasenih;
        this.Broj_Povredjenih = Broj_Povredjenih;
        this.Uspesnost = Uspesnost;

    }

}
    
    public class IntervencijaPregled
    {
    public int ID;

    public DateTime Datum_I_Vreme;
    public string Lokacija;

    public string Status;
    public int Broj_Spasenih;
    public int Broj_Povredjenih;
    public int Uspesnost;
    public IList<UcestvujePregled> Ucestvuje;

    public IntervencijaPregled()
    {
        Ucestvuje = new List<UcestvujePregled>();
    }

    public IntervencijaPregled(int Id, DateTime DatumIVreme, string Lokacija, string Status, int Broj_Spasenih, int Broj_Povredjenih, int Uspesnost)
    {
        ID = Id;
        Datum_I_Vreme = DatumIVreme;
        this.Lokacija = Lokacija;
        this.Status = Status;
        this.Broj_Spasenih = Broj_Spasenih;
        this.Broj_Povredjenih = Broj_Povredjenih;
        this.Uspesnost = Uspesnost;

    }

}
    

    public class InterventnaJedinicaBasic
    {
    public  int Jedinstveni_Broj;
    public  string Naziv;
    public  int BrojClanova;
    public  int MatBrOp;
    public  string Baza;

    public  IList<DajeSeJedinicamaBasic> Dodeljuje;

    public  OpremaBasic Oprema;

    public  IList<OperativniRadnikBasic> Radnici;

    public  IList<UcestvujeBasic> Ucestvuje;


    public  OperativniRadnikBasic Komandir;
    public InterventnaJedinicaBasic()
    {
        Dodeljuje = new List<DajeSeJedinicamaBasic>();
        Radnici = new List<OperativniRadnikBasic>();
        Ucestvuje = new List<UcestvujeBasic>();
    }

    public InterventnaJedinicaBasic(int Jedinstveni_Broj, string Naziv, int BrojClanova, int MatBrOp, string Baza)
    {
        this.Jedinstveni_Broj = Jedinstveni_Broj;
        this.Naziv = Naziv;
        this.BrojClanova = BrojClanova;
        this.MatBrOp = MatBrOp;
        this.Baza = Baza;
    }
}

    public class InterventnaJedinicaPregled
    {
    public int Jedinstveni_Broj;
    public string Naziv;
    public int BrojClanova;
    public int MatBrOp;
    public string Baza;

    public IList<DajeSeJedinicamaPregled> Dodeljuje;

    public OpremaPregled Oprema;

    public IList<OperativniRadnikPregled> Radnici;

    public IList<UcestvujePregled> Ucestvuje;


    public OperativniRadnikPregled Komandir;
    public InterventnaJedinicaPregled()
    {
        Dodeljuje = new List<DajeSeJedinicamaPregled>();
        Radnici = new List<OperativniRadnikPregled>();
        Ucestvuje = new List<UcestvujePregled>();
    }

    public InterventnaJedinicaPregled(int Jedinstveni_Broj, string Naziv, int BrojClanova, int MatBrOp, string Baza)
    
    {
        this.Jedinstveni_Broj = Jedinstveni_Broj;
        this.Naziv = Naziv;
        this.BrojClanova = BrojClanova;
        this.MatBrOp = MatBrOp;
        this.Baza = Baza;
    }
}

    public class SpecijalnaInterventnaJedinicaBasic:InterventnaJedinicaBasic
    {
        public string TipSpecijalneJed;
        
        public SpecijalnaInterventnaJedinicaBasic()
        {

        }

        public SpecijalnaInterventnaJedinicaBasic(int Jedinstveni_Broj, string Naziv, int BrojClanova, int MatBrOp, string Baza, string TipSpecijalneJed):base(Jedinstveni_Broj,Naziv,BrojClanova,MatBrOp,Baza)
        {
            this.TipSpecijalneJed = TipSpecijalneJed;
        }
     
    }

    public class SpecijalnaInterventnaJedinicaPregled : InterventnaJedinicaPregled
    {
        public string TipSpecijalneJed;

        public SpecijalnaInterventnaJedinicaPregled()
        {

        }

        public SpecijalnaInterventnaJedinicaPregled(int Jedinstveni_Broj, string Naziv, int BrojClanova, int MatBrOp, string Baza, string TipSpecijalneJed) : base(Jedinstveni_Broj, Naziv, BrojClanova, MatBrOp, Baza)
        {
            this.TipSpecijalneJed = TipSpecijalneJed;
        }

    }

public class OpstaInterventnaJedBasic : InterventnaJedinicaBasic
{
    public string TipSpecijalneJed;

    public OpstaInterventnaJedBasic()
    {

    }

    public OpstaInterventnaJedBasic(int Jedinstveni_Broj, string Naziv, int BrojClanova, int MatBrOp, string Baza, string TipSpecijalneJed) : base(Jedinstveni_Broj, Naziv, BrojClanova, MatBrOp, Baza)
    {
        this.TipSpecijalneJed = TipSpecijalneJed;
    }

}

public class OpstaInterventnaJedPregled : InterventnaJedinicaPregled
{
    public string TipSpecijalneJed;

    public OpstaInterventnaJedPregled()
    {

    }

    public OpstaInterventnaJedPregled(int Jedinstveni_Broj, string Naziv, int BrojClanova, int MatBrOp, string Baza, string TipSpecijalneJed) : base(Jedinstveni_Broj, Naziv, BrojClanova, MatBrOp, Baza)
    {
        this.TipSpecijalneJed = TipSpecijalneJed;
    }

}
public class EkspertizaBasic
    {
    public  int JMBG;

    public  String Oblast;

    public EkspertizaBasic()
    {

    }

    public EkspertizaBasic(int JMBG, string Oblast)
    {
        this.JMBG = JMBG;
        this.Oblast = Oblast;
    }
}

    public class EkspertizaPregled
    {
    public int JMBG;

    public String Oblast;

    public EkspertizaPregled()
    {

    }

    public EkspertizaPregled(int JMBG, string Oblast)
    {
        this.JMBG = JMBG;
        this.Oblast = Oblast;
    }
}


    public class VoziloBasic
    {
    public  int Registarska_Oznaka;
    public  string Proizvodjac;
    public  string Tip;
    public  string Status;
    public  string Lokacija;

    public  IList<ServisiBasic> Servisi;

    public  IList<DajeSeJedinicamaBasic> DodeljujeJed;

    public  IList<DajeSePojedincuBasic> DodeljujePojed;




    public VoziloBasic()
    {
        Servisi = new List<ServisiBasic>();
        DodeljujeJed = new List<DajeSeJedinicamaBasic>();
        DodeljujePojed = new List<DajeSePojedincuBasic>();
    }

    public VoziloBasic(int Registarska_Oznaka, string Proizvodjac, string Tip, string Status, string Lokacija)
    {
        this.Registarska_Oznaka = Registarska_Oznaka;
        this.Proizvodjac = Proizvodjac;
        this.Tip = Tip;
        this.Status = Status;
        this.Lokacija = Lokacija;
    }
}

    public class VoziloPregled
    {
    public int Registarska_Oznaka;
    public string Proizvodjac;
    public string Tip;
    public string Status;
    public string Lokacija;

    public IList<ServisiPregled> Servisi;

    public IList<DajeSeJedinicamaPregled> DodeljujeJed;

    public IList<DajeSePojedincuPregled> DodeljujePojed;




    public VoziloPregled()
    {
        Servisi = new List<ServisiPregled>();
        DodeljujeJed = new List<DajeSeJedinicamaPregled>();
        DodeljujePojed = new List<DajeSePojedincuPregled>();
    }

    public VoziloPregled(int Registarska_Oznaka, string Proizvodjac, string Tip, string Status, string Lokacija)
    {
        this.Registarska_Oznaka = Registarska_Oznaka;
        this.Proizvodjac = Proizvodjac;
        this.Tip = Tip;
        this.Status = Status;
        this.Lokacija = Lokacija;
    }
}

    public class TerenskoBasic:VoziloBasic
    {
         public string TipVozila;

        public TerenskoBasic()
        {

        }

         public TerenskoBasic(int Registarska_Oznaka, string Proizvodjac, string Tip, string Status, string Lokacija):
         base(Registarska_Oznaka, Proizvodjac, Tip, Status, Lokacija)
         {

         }
    }

    public class TerenskoPregled:VoziloPregled
    {
    public string TipVozila;

    public TerenskoPregled()
    {

    }

    public TerenskoPregled(int Registarska_Oznaka, string Proizvodjac, string Tip, string Status, string Lokacija) :
    base(Registarska_Oznaka, Proizvodjac, Tip, Status, Lokacija)
    {

    }
}

    public class SpecijalnaVozilaBasic
    {
    public  int Registarska_Oznaka ;
    public  int Namena ;

    public  bool Voda ;
    public  bool Sator ;
    public  bool Hemija ;

    public  bool Mobilna_Laboratorija ;

    public SpecijalnaVozilaBasic()
    {

    }

    public SpecijalnaVozilaBasic(int Registarska_Oznaka, int Namena, bool Voda, bool Sator, bool Hemija, bool Mobilna_Laboratorija)
    {
        this.Registarska_Oznaka = Registarska_Oznaka;
        this.Namena = Namena;
        this.Voda = Voda;
        this.Sator = Sator;
        this.Hemija = Hemija;
        this.Mobilna_Laboratorija = Mobilna_Laboratorija;
    }

}
    public class SpecijalnaVozilaPregled
    {
    public int Registarska_Oznaka;
    public int Namena;

    public bool Voda;
    public bool Sator;
    public bool Hemija;

    public bool Mobilna_Laboratorija;

    public SpecijalnaVozilaPregled()
    {

    }

    public SpecijalnaVozilaPregled(int Registarska_Oznaka, int Namena, bool Voda, bool Sator, bool Hemija, bool Mobilna_Laboratorija)
    {
        this.Registarska_Oznaka = Registarska_Oznaka;
        this.Namena = Namena;
        this.Voda = Voda;
        this.Sator = Sator;
        this.Hemija = Hemija;
        this.Mobilna_Laboratorija = Mobilna_Laboratorija;
    }
}
    public class SertifikatBasic
    {
    public  OperativniRadnikBasic OperativniRadnik;
    public  string Naziv;
    public  string Institucija;
    public  DateTime DatumIzdavanja;
    public  DateTime DatumVazenja;
    
    public SertifikatBasic()
    {

    }

    public SertifikatBasic(string Naziv, string Institucija, DateTime DatumIzdavanja, DateTime DatumVazenja)
    {
        this.Naziv = Naziv;
        this.Institucija = Institucija;
        this.DatumIzdavanja = DatumIzdavanja;
        this.DatumVazenja = DatumVazenja;

    }
}
    public class SertifikatPregled
    {
    public OperativniRadnikPregled OperativniRadnik;
    public string Naziv;
    public string Institucija;
    public DateTime DatumIzdavanja;
    public DateTime DatumVazenja;

    public SertifikatPregled()
    {

    }

    public SertifikatPregled(string Naziv, string Institucija, DateTime DatumIzdavanja, DateTime DatumVazenja)
    {
        this.Naziv = Naziv;
        this.Institucija = Institucija;
        this.DatumIzdavanja = DatumIzdavanja;
        this.DatumVazenja = DatumVazenja;

    }
}
    public class TipBasic()
    {

    }
    public class TipPregled()
    {

    }
    public class DajeSeJedinicamaBasic
    {
    public  VoziloBasic Vozilo;
    public  InterventnaJedinicaBasic Intervente_Jedinice;

    public  DateTime datumod;
    public  DateTime datumDo;

    public DajeSeJedinicamaBasic()
    {

    }

    public DajeSeJedinicamaBasic(DateTime datumod, DateTime datumDo)
    {
        this.datumod = datumod;
        this.datumDo = datumDo;
    }

}
    public class DajeSeJedinicamaPregled
    {
    
        public VoziloPregled Vozilo;
        public InterventnaJedinicaPregled Interventna_Jedinica;

        public DateTime datumod;
        public DateTime datumDo;

        public DajeSeJedinicamaPregled()
        {

        }

        public DajeSeJedinicamaPregled(DateTime datumod, DateTime datumDo)
        {
            this.datumod = datumod;
            this.datumDo = datumDo;
        }
    }
    public class DajeSePojedincuBasic
    {
    public  VoziloBasic Vozilo;
    public  OperativniRadnikBasic Pojedinac;

    public  DateTime datumod;
    public  DateTime datumDo;

    public DajeSePojedincuBasic()
    {

    }


    public DajeSePojedincuBasic(DateTime datumod, DateTime datumDo)
    {
        this.datumod = datumod;
        this.datumDo = datumDo;
    }
}
    public class DajeSePojedincuPregled
    {
    public VoziloPregled Vozilo;
    public OperativniRadnikPregled Pojedinac;

    public DateTime datumod;
    public DateTime datumDo;

    public DajeSePojedincuPregled()
    {

    }


    public DajeSePojedincuPregled(DateTime datumod, DateTime datumDo)
    {
        this.datumod = datumod;
        this.datumDo = datumDo;
    }
}
    public class Istorija_Uloga_ZaposlenihBasic
    { 
    public  ZaposlenBasic Zaposlen;
    public  string Uloga;
    public  DateTime Datum_Od;
    public  DateTime Datum_Do;

    public Istorija_Uloga_ZaposlenihBasic()
    {

    }
    public Istorija_Uloga_ZaposlenihBasic(string Uloga, DateTime Datum_Od, DateTime Datum_Do)
    {

        this.Uloga = Uloga;
        this.Datum_Od = Datum_Od;
        this.Datum_Do = Datum_Od;
    }
    }
public class Istorija_Uloga_ZaposlenihPregled
    {
    public ZaposlenPregled Zaposlen;
    public string Uloga;
    public DateTime Datum_Od;
    public DateTime Datum_Do;

    public Istorija_Uloga_ZaposlenihPregled()
    {

    }
    public Istorija_Uloga_ZaposlenihPregled( string Uloga, DateTime Datum_Od, DateTime Datum_Do)
    {
        this.Uloga = Uloga;
        this.Datum_Od = Datum_Od;
        this.Datum_Do = Datum_Od;
    }
}
    public class PredstavnikBasic
    {
    public  int Id ;
    public  SektorBasic Sektor ;
    public  string Ime ;
    public  string Prezime ;
    public  string Pozicija ;
    public  string Telefon ;
    public  string Email ;

    public  PredstavnikBasic()
    {

    }

    public PredstavnikBasic(int Id, string Ime, string Prezime, string Pozicija, string Telefon, string Email)
    {
        this.Id = Id;
        this.Ime = Ime;
        this.Prezime = Prezime;
        this.Pozicija = Pozicija;
        this.Telefon = Telefon;
        this.Email = Email;
    }
}
    public class PredstavnikPregled
    {
    public int Id;
    public SektorPregled Sektor;
    public string Ime;
    public string Prezime;
    public string Pozicija;
    public string Telefon;
    public string Email;

    public PredstavnikPregled()
    {

    }

    public PredstavnikPregled(int Id, string Ime, string Prezime, string Pozicija, string Telefon, string Email)
    {
        this.Id = Id;
        this.Ime = Ime;
        this.Prezime = Prezime;
        this.Pozicija = Pozicija;
        this.Telefon = Telefon;
        this.Email = Email;
    }
}
    public class UcestvujeBasic
    {
    public  InterventnaJedinicaBasic IdInterventneJed;
    public  VandrednaSituacijaBasic IdVandredneSituacije;

    public  IntervencijaBasic IdIntervencije;

    public UcestvujeBasic()
    {

    }
}
    public class UcestvujePregled
    {
    public InterventnaJedinicaPregled IdInterventneJed;
    public VandrednaSituacijaPregled IdVandredneSituacije;

    public IntervencijaPregled IdIntervencije;

    public UcestvujePregled()
    {

    }
}

    public class SektorBasic
    {
    public int Id_Sektora;
    public  string TipSektora;
    public  string Uloga;

    public IList<AngazovanjeSaradnjeBasic> VandredneSituacije;
    public PredstavnikBasic? Predstavnik;

    public SektorBasic()
    {
        VandredneSituacije = new List<AngazovanjeSaradnjeBasic>();
    }

    public SektorBasic(int Id_Sektora, string TipSektora, string Uloga)
    {
        this.Id_Sektora = Id_Sektora;
        this.TipSektora = TipSektora;
        this.Uloga = Uloga;
    }
}
    public class SektorPregled
    {
    public int Id_Sektora;
    public string TipSektora;
    public string Uloga;

    public IList<AngazovanjeSaradnjePregled> VandredneSituacije;
    public PredstavnikPregled? Predstavnik;

    public SektorPregled()
    {
        VandredneSituacije = new List<AngazovanjeSaradnjePregled>();
    }

    public SektorPregled(int Id_Sektora, string TipSektora, string Uloga)
    {
        this.Id_Sektora = Id_Sektora;
        this.TipSektora = TipSektora;
        this.Uloga = Uloga;
    }
}

    public class ZaliheBasic:OpremaBasic
    {
    public int Kolicina;
    public ZaliheBasic()
    {

    }

    public ZaliheBasic(int Serijski_Broj, DateTime DatumNabavke, string Status, string TipOpreme, int Kolicina) : base(Serijski_Broj, DatumNabavke, Status, TipOpreme)
    {
        this.Kolicina = Kolicina;
    }
}
    public class ZalihePregled:OpremaPregled
    {
    public int Kolicina;
    public ZalihePregled()
    {

    }

    public ZalihePregled(int Serijski_Broj, DateTime DatumNabavke, string Status, string TipOpreme, int Kolicina) : base(Serijski_Broj, DatumNabavke, Status, TipOpreme)
    {
        this.Kolicina = Kolicina;
    }
}

    public class MedicinskaOpremaBasic:OpremaBasic
    {
    public MedicinskaOpremaBasic()
    {

    }

    public MedicinskaOpremaBasic(int Serijski_Broj, DateTime DatumNabavke, string Status, string TipOpreme) : base(Serijski_Broj, DatumNabavke, Status, TipOpreme)
    {
    }
}
   
    public class MedicinskaOpremaPregled:OpremaPregled
    {
    public MedicinskaOpremaPregled()
    {

    }

    public MedicinskaOpremaPregled(int Serijski_Broj, DateTime DatumNabavke, string Status, string TipOpreme) : base(Serijski_Broj, DatumNabavke, Status, TipOpreme)
    {
    }
}
    public class LicnaZastitaBasic:OpremaBasic
    {
    public LicnaZastitaBasic()
    {

    }

    public LicnaZastitaBasic(int Serijski_Broj, DateTime DatumNabavke, string Status, string TipOpreme) : base(Serijski_Broj, DatumNabavke, Status, TipOpreme)
    {
    }
}
    public class LicnaZastitaPregled:OpremaPregled
    {
    public LicnaZastitaPregled()
    {

    }

    public LicnaZastitaPregled(int Serijski_Broj, DateTime DatumNabavke, string Status, string TipOpreme) : base(Serijski_Broj, DatumNabavke, Status, TipOpreme)
    {
    }
}

    public class TehnickaOpremaBasic : OpremaBasic
    {
    public TehnickaOpremaBasic()
    {

    }

    public TehnickaOpremaBasic(int Serijski_Broj, DateTime DatumNabavke, string Status, string TipOpreme):base(Serijski_Broj,DatumNabavke, Status, TipOpreme)
    {
    }
}
    public class TehnickaOpremaPregled:OpremaPregled
    {
    public TehnickaOpremaPregled()
    {

    }

    public TehnickaOpremaPregled(int Serijski_Broj, DateTime DatumNabavke, string Status, string TipOpreme) : base(Serijski_Broj, DatumNabavke, Status, TipOpreme)
    {
    }
}

    public class ServisiBasic
    {
    public  VoziloBasic Vozilo ;
    public  string TipServisa ;
    public  DateTime Datum ;

    public ServisiBasic()
    {

    }

    public ServisiBasic(string TipServisa, DateTime Datum)
    {
        this.TipServisa = TipServisa;
        this.Datum = Datum;
    }
}
public class ServisiPregled
    {
    public  VoziloPregled Vozilo ;
    public  string TipServisa ;
    public  DateTime Datum ;

    public ServisiPregled()
    {

    }

    public ServisiPregled(string TipServisa, DateTime Datum)
    {
        this.TipServisa = TipServisa;
        this.Datum = Datum;
    }
}


public class PrijavaBasic 
    {
    public  int Id ;
    public  VandrednaSituacijaBasic VandrednaSituacija ;
    public  DateTime Datum_I_Vreme ;
    public  string Tip ;
    public  string Ime_Prijavioca ;
    public  string Kontakt_Prijavioca ;
    public  string Lokacija ;
    public  string Opis ;
    public  string Dispecer ;

    public  int Prioritet ;

    public PrijavaBasic()
    {

    }

    public PrijavaBasic(int Id, DateTime Datum_I_Vreme, string Tip, string Ime_Prijavioca, string Kontakt_Prijavioca, string Lokacija, string Opis, string Dispecer, int Prioritet)
    {
        this.Id = Id;
        this.Datum_I_Vreme = Datum_I_Vreme;
        this.Tip = Tip;
        this.Ime_Prijavioca = Ime_Prijavioca;
        this.Kontakt_Prijavioca = Kontakt_Prijavioca;
        this.Lokacija = Lokacija;
        this.Opis = Opis;
        this.Dispecer = Dispecer;
        this.Prioritet = Prioritet;
    }
}
    public class PrijavaPregled
    {
    public  int Id ;
    public  VandrednaSituacijaBasic VandrednaSituacija ;
    public  DateTime Datum_I_Vreme ;
    public  string Tip ;
    public  string Ime_Prijavioca ;
    public  string Kontakt_Prijavioca ;
    public  string Lokacija ;
    public  string Opis ;
    public  string Dispecer ;

    public  int Prioritet ;


    public PrijavaPregled()
    {

    }

    public PrijavaPregled(int Id, DateTime Datum_I_Vreme, string Tip, string Ime_Prijavioca, string Kontakt_Prijavioca, string Lokacija, string Opis, string Dispecer, int Prioritet)
    {
        this.Id = Id;
        this.Datum_I_Vreme = Datum_I_Vreme;
        this.Tip = Tip;
        this.Ime_Prijavioca = Ime_Prijavioca;
        this.Kontakt_Prijavioca = Kontakt_Prijavioca;
        this.Lokacija = Lokacija;
        this.Opis = Opis;
        this.Dispecer = Dispecer;
        this.Prioritet = Prioritet;
    }
}

    public class AngazovanjeSaradnjeBasic
    {
    public  PredstavnikBasic Predstavnik;
    public  int Uloga;

    public  SektorBasic Sektor;
    public  VandrednaSituacijaBasic VandrednaSituacija;

    public AngazovanjeSaradnjeBasic()
    {

    }

    public AngazovanjeSaradnjeBasic(int Uloga)
    {
        this.Uloga = Uloga;
    }
}

    public class AngazovanjeSaradnjePregled
    {
    public PredstavnikPregled Predstavnik;
    public int Uloga;

    public SektorPregled Sektor;
    public VandrednaSituacijaPregled VandrednaSituacija;

    public AngazovanjeSaradnjePregled()
    {

    }

    public AngazovanjeSaradnjePregled(int Uloga)
    {
        this.Uloga = Uloga;
    }
}

