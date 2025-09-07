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
using static SaradjujeBasic;

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
            Istorija = new List<Istorija_Uloga_ZaposlenihBasic>();
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

        public IList<Istorija_Uloga_ZaposlenihPregled> Istorija; 

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
            Istorija = new List<Istorija_Uloga_ZaposlenihPregled>();
        }
    }

    public class AnaliticarBasic: ZaposlenBasic
    {
     
        public AnaliticarBasic()
        {
        }

        public AnaliticarBasic(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip) :
            base(JMBG,Ime,Prezime,Datum_Rodjenja,pol, Kontakt_Telefon, email,DatumZaposlenja, Tip)
          
        {
            
        }

    }

    public class AnaliticarPregled: ZaposlenPregled
    {
        


        public AnaliticarPregled()
        { 
        }

        public AnaliticarPregled(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip) :
            base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, DatumZaposlenja, Tip)
        {
           
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

    public  IList<DodeljujeSeBasic> Dodeljuje;

    public  InterventnaJedinicaBasic InterventnaJedinica;

    public  IList<SertifikatBasic> Sertifikats;

    public OperativniRadnikBasic()
    {
        Dodeljuje = new List<DodeljujeSeBasic>();
        Sertifikats = new List<SertifikatBasic>();
    }

    public OperativniRadnikBasic(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip, int Broj_Sati, string Fizicka_Spremnost, InterventnaJedinicaBasic interventna)
        : base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, DatumZaposlenja, Tip)
    {
        this.Broj_Sati=Broj_Sati;
        this.Fizicka_Spremnost = Fizicka_Spremnost;
        this.InterventnaJedinica = interventna;
    }
}

    public class OperativniRadnikPregled:ZaposlenPregled
    {
    public int Broj_Sati;
    public string Fizicka_Spremnost;

    public IList<DodeljujeSePregled> Dodeljuje;

    public InterventnaJedinicaPregled InterventnaJedinica;

    public IList<SertifikatPregled> Sertifikats;

    public OperativniRadnikPregled()
    {
        Dodeljuje = new List<DodeljujeSePregled>();
        Sertifikats = new List<SertifikatPregled>();
    }
    public OperativniRadnikPregled(int JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string DatumZaposlenja, string Tip, int Broj_Sati, string Fizicka_Spremnost, InterventnaJedinicaPregled IntervernaJedinica)
    : base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, DatumZaposlenja, Tip)
    {
        this.Broj_Sati = Broj_Sati;
        this.Fizicka_Spremnost = Fizicka_Spremnost;
    }

}

    public class OpremaBasic
    {
    public int Serijski_Broj;

    public string Naziv;

  
    public string Tip;

    public string Status;

  
    
    public DateTime DatumNabavke;

    public InterventnaJedinicaBasic Jedinica;

    public OpremaBasic()
    {

    }

    public OpremaBasic(int Serijski_Broj,string Naziv, string Status, string Tip, DateTime DatumNabavke, InterventnaJedinicaBasic Jedinica)
    {
        this.Serijski_Broj = Serijski_Broj;
        this.Naziv = Naziv;
       
        this.Status = Status;
        this.Tip=Tip;
        this.DatumNabavke = DatumNabavke;
        this.Jedinica = Jedinica;
    }
}

    public class OpremaPregled
    {
    public int Serijski_Broj;

    public string Naziv;

    public string Tip;

    public string Status;

    public InterventnaJedinicaPregled Jedinica;

    public DateTime DatumNabavke;

    public OpremaPregled()
    {

    }

    public OpremaPregled(int Serijski_Broj, string Naziv, string Status, string Tip, DateTime DatumNabavke, InterventnaJedinicaPregled Jedinica)
    {
        this.Serijski_Broj = Serijski_Broj;
        this.Naziv = Naziv;
        this.DatumNabavke = DatumNabavke;
        this.Status = Status;
        this.Tip = Tip;
        this.Jedinica = Jedinica;
    }
}

    public class VandrednaSituacijaBasic
    {
    public  int Id;
    public  DateTime Datum_Od;
    public  DateTime Datum_Do;
    public string Tip;
    public  int Broj_Ugrozenih_Osoba;
    public  NivoOpasnosti Nivo_Opasnosti;
    public  string Opstina;
    public  string Lokacija;
    public string Opis;
    

    
    public  PrijavaBasic Prijava;
    public  IList<UcestvujeBasic> Ucestvuje;
    public  IList<SaradjujeBasic> Saradjuje;

    public VandrednaSituacijaBasic()
    {
        Ucestvuje = new List<UcestvujeBasic>();
        Saradjuje = new List<SaradjujeBasic>();
    }

    public VandrednaSituacijaBasic(int id, DateTime Datum_Od, DateTime Datum_Do, String Tip, int Broj_Ugrozenih_Osoba, NivoOpasnosti Nivo_Opasnosti, string Opstina, string Lokacija, string Opis, PrijavaBasic Prijava)
    {
        Id = id;
        this.Tip = Tip;
        this.Broj_Ugrozenih_Osoba = Broj_Ugrozenih_Osoba;
        this.Nivo_Opasnosti = Nivo_Opasnosti;
        this.Opstina = Opstina;
        this.Lokacija = Lokacija;
        this.Opis = Opis;
        this.Prijava = Prijava;
    }
}

    public class VandrednaSituacijaPregled
    {
    public  int Id;
    public DateTime Datum_Od;
    public DateTime Datum_Do;
    public string Tip;
    public  int Broj_Ugrozenih_Osoba;
    public  NivoOpasnosti Nivo_Opasnosti;
    public  string Opstina;
    public  string Lokacija;
    public  string Opis;

    public  PrijavaPregled Prijava;
    public  IList<UcestvujePregled> Ucestvuje;
    public  IList<SaradjujePregled> Saradjuje;

    public VandrednaSituacijaPregled()
    {
        Ucestvuje = new List<UcestvujePregled>();
        Saradjuje = new List<SaradjujePregled>();
    }


    public VandrednaSituacijaPregled(int id, DateTime Datum_Od, DateTime Datum_Do, String Tip,
    int Broj_Ugrozenih_Osoba, NivoOpasnosti Nivo_Opasnosti, string Opstina, string Lokacija, string Opis, PrijavaPregled Prijava)
    {
        Id = id;
        this.Tip = Tip;  
        this.Datum_Od = Datum_Od;
        this.Datum_Do = Datum_Do;
        this.Broj_Ugrozenih_Osoba = Broj_Ugrozenih_Osoba;
        this.Nivo_Opasnosti = Nivo_Opasnosti;
        this.Opstina = Opstina;
        this.Lokacija = Lokacija;
        this.Opis = Opis;
        this.Prijava = Prijava;
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
    public int BrojClanova;
    public  string Baza;
    public OperativniRadnikBasic Komandir;
    public  IList<DajeSeJedinicamaBasic> Dodeljuje;

    public  OpremaBasic Oprema;

    public  IList<OperativniRadnikBasic> Radnici;

    public  IList<UcestvujeBasic> Ucestvuje;


    
    public InterventnaJedinicaBasic()
    {
        Dodeljuje = new List<DajeSeJedinicamaBasic>();
        Radnici = new List<OperativniRadnikBasic>();
        Ucestvuje = new List<UcestvujeBasic>();
    }

    public InterventnaJedinicaBasic(int Jedinstveni_Broj, string Naziv, int BrojClanova, OperativniRadnikBasic Komandir, string Baza)
    {
        this.Jedinstveni_Broj = Jedinstveni_Broj;
        this.Naziv = Naziv;
        this.BrojClanova = BrojClanova;
        this.Komandir = Komandir;
        this.Baza = Baza;
    }
}

    public class InterventnaJedinicaPregled
    {
    public int Jedinstveni_Broj;
    public string Naziv;
    public int BrojClanova;
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

    public InterventnaJedinicaPregled(int Jedinstveni_Broj, string Naziv, int BrojClanova, OperativniRadnikPregled Komandir, string Baza)
    
    {
        this.Jedinstveni_Broj = Jedinstveni_Broj;
        this.Naziv = Naziv;
        this.BrojClanova = BrojClanova;
        this.Komandir = Komandir;
        this.Baza = Baza;
    }
}

    public class SpecijalnaInterventnaJedinicaBasic:InterventnaJedinicaBasic
    {
        public string TipSpecijalneJed;
        
        public SpecijalnaInterventnaJedinicaBasic()
        {

        }

        public SpecijalnaInterventnaJedinicaBasic(int Jedinstveni_Broj, string Naziv, int BrojClanova, OperativniRadnikBasic Komandir, string Baza, string TipSpecijalneJed):base(Jedinstveni_Broj,Naziv,BrojClanova,Komandir,Baza)
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

        public SpecijalnaInterventnaJedinicaPregled(int Jedinstveni_Broj, string Naziv, int BrojClanova, OperativniRadnikPregled Komandir, string Baza, string TipSpecijalneJed) : base(Jedinstveni_Broj, Naziv, BrojClanova, Komandir, Baza)
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

    public OpstaInterventnaJedBasic(int Jedinstveni_Broj, string Naziv, int BrojClanova, OperativniRadnikBasic Komandir, string Baza, string TipSpecijalneJed) : base(Jedinstveni_Broj, Naziv, BrojClanova, Komandir, Baza)
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

    public OpstaInterventnaJedPregled(int Jedinstveni_Broj, string Naziv, int BrojClanova, OperativniRadnikPregled Komandir, string Baza, string TipSpecijalneJed) : base(Jedinstveni_Broj, Naziv, BrojClanova, Komandir, Baza)
    {
        this.TipSpecijalneJed = TipSpecijalneJed;
    }

}
public class EkspertizaBasic
    {
    public  AnaliticarBasic Analiticar;

    public  String Oblast;

    public EkspertizaBasic()
    {

    }

    public EkspertizaBasic(AnaliticarBasic Analiticar, string Oblast)
    {
        this.Analiticar = Analiticar;
        this.Oblast = Oblast;
    }
}

    public class EkspertizaPregled
    {
    public AnaliticarPregled Analiticar;

    public String Oblast;

    public EkspertizaPregled()
    {

    }

    public EkspertizaPregled(AnaliticarPregled Analiticar, string Oblast)
    {
        this.Analiticar = Analiticar;
        this.Oblast = Oblast;
    }
}


    public class VoziloBasic
    {
    public  int Registarska_Oznaka;
    public  string Proizvodjac;
    public  string Tip;
    public  StatusVozila Status;
    public  string Lokacija;

    public  IList<ServisiBasic> Servisi;

    public  IList<DodeljujeSeBasic> Dodeljuje;

    




    public VoziloBasic()
    {
        Servisi = new List<ServisiBasic>();
        Dodeljuje = new List<DodeljujeSeBasic>();
        
    }

    public VoziloBasic(int Registarska_Oznaka, string Proizvodjac, string Tip, StatusVozila Status, string Lokacija)
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
    public StatusVozila Status;
    public string Lokacija;

    public IList<ServisiPregled> Servisi;

    public IList<DodeljujeSePregled> Dodeljuje;

   




    public VoziloPregled()
    {
        Servisi = new List<ServisiPregled>();
        Dodeljuje = new List<DodeljujeSePregled>();
   
    }

    public VoziloPregled(int Registarska_Oznaka, string Proizvodjac, string Tip, StatusVozila Status, string Lokacija)
    {
        this.Registarska_Oznaka = Registarska_Oznaka;
        this.Proizvodjac = Proizvodjac;
        this.Tip = Tip;
        this.Status = Status;
        this.Lokacija = Lokacija;
    }
}

    public class TerenskaBasic:VoziloBasic
    {
         public string TipVozila;

        public TerenskaBasic()
        {

        }

         public TerenskaBasic(int Registarska_Oznaka, string Proizvodjac, string Tip, StatusVozila Status, string Lokacija, string TipVozila):
         base(Registarska_Oznaka, Proizvodjac, Tip, Status, Lokacija)
         {
        this.Tip = TipVozila;
         }
    }

    public class TerenskaPregled:VoziloPregled
    {
    public string TipVozila;

    public TerenskaPregled()
    {

    }

    public TerenskaPregled(int Registarska_Oznaka, string Proizvodjac, string Tip, StatusVozila Status, string Lokacija, string TipVozila) :
    base(Registarska_Oznaka, Proizvodjac, Tip, Status, Lokacija)
    {
        this.TipVozila = TipVozila;
    }
}
public class DzipoviBasic:TerenskaBasic
{
    public DzipoviBasic()
    {  
    }

    public DzipoviBasic(int Registarska_Oznaka, string Proizvodjac, string Tip, StatusVozila Status, string Lokacija,string TipVozila) : base (Registarska_Oznaka, Proizvodjac, Tip, Status, Lokacija,TipVozila)
    {

    }
}

public class DzipoviPregled : TerenskaBasic
{
    public DzipoviPregled()
    {
    }

    public DzipoviPregled(int Registarska_Oznaka, string Proizvodjac, string Tip, StatusVozila Status, string Lokacija, string TipVozila) : base(Registarska_Oznaka, Proizvodjac, Tip, Status, Lokacija, TipVozila)
    {

    }
}

public class KamioniBasic : TerenskaBasic
{
    public KamioniBasic()
    {
    }

    public KamioniBasic(int Registarska_Oznaka, string Proizvodjac, string Tip, StatusVozila Status, string Lokacija, string TipVozila) : base(Registarska_Oznaka, Proizvodjac, Tip, Status, Lokacija, TipVozila)
    {

    }
}

public class KamioniPregled : TerenskaBasic
{
    public KamioniPregled()
    {
    }

    public KamioniPregled(int Registarska_Oznaka, string Proizvodjac, string Tip, StatusVozila Status, string Lokacija, string TipVozila) : base(Registarska_Oznaka, Proizvodjac, Tip, Status, Lokacija, TipVozila)
    {

    }
}
public class SpecijalnaVozilaBasic
    {
    public  int Registarska_Oznaka ;
    public  Namena Namena ;



    public  bool Mobilna_Laboratorija ;

    public SpecijalnaVozilaBasic()
    {

    }

    public SpecijalnaVozilaBasic(int Registarska_Oznaka, Namena Namena)
    {
        this.Registarska_Oznaka = Registarska_Oznaka;
        this.Namena = Namena;
    }

}
    public class SpecijalnaVozilaPregled
    {
    public int Registarska_Oznaka;
    public Namena Namena;


    public SpecijalnaVozilaPregled()
    {

    }

    public SpecijalnaVozilaPregled(int Registarska_Oznaka, Namena Namena)
    {
        this.Registarska_Oznaka = Registarska_Oznaka;
        this.Namena = Namena;
      
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

    public SertifikatBasic(OperativniRadnikBasic OperativniRadnik, string Naziv, string Institucija, DateTime DatumIzdavanja, DateTime DatumVazenja)
    {
        this.OperativniRadnik = OperativniRadnik;
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

    public SertifikatPregled(OperativniRadnikPregled OperativniRadnik,string Naziv, string Institucija, DateTime DatumIzdavanja, DateTime DatumVazenja)
    {
        this.OperativniRadnik = OperativniRadnik;
        this.Naziv = Naziv;
        this.Institucija = Institucija;
        this.DatumIzdavanja = DatumIzdavanja;
        this.DatumVazenja = DatumVazenja;

    }
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
    public class DodeljujeSeBasic
    {
    public  VoziloBasic Vozilo;
    public  OperativniRadnikBasic Pojedinac;

    public InterventnaJedinicaBasic Jedinica;

    public  DateTime datumod;
    public  DateTime datumDo;

    public DodeljujeSeBasic()
    {

    }


    public DodeljujeSeBasic(VoziloBasic Vozilo, OperativniRadnikBasic Pojedinac, InterventnaJedinicaBasic Jedinica, DateTime datumod, DateTime datumDo)
    {
        this.Vozilo = Vozilo;
        this.Pojedinac = Pojedinac;
        this.Jedinica = Jedinica;
        this.datumod = datumod;
        this.datumDo = datumDo;
    }
}
public class DodeljujeSePregled
{
    public VoziloPregled Vozilo;
    public OperativniRadnikPregled Pojedinac;

    public InterventnaJedinicaPregled Jedinica;

    public DateTime datumod;
    public DateTime datumDo;

    public DodeljujeSePregled()
    {

    }


    public DodeljujeSePregled(VoziloPregled Vozilo, OperativniRadnikPregled Pojedinac, InterventnaJedinicaPregled Jedinica, DateTime datumod, DateTime datumDo)
    {
        this.Vozilo = Vozilo;
        this.Pojedinac = Pojedinac;
        this.Jedinica = Jedinica;
        this.datumod = datumod;
        this.datumDo = datumDo;
    }
}
//public class DajeSePojedincuPregled
//{
//    public VoziloPregled Vozilo;
//    public OperativniRadnikPregled Pojedinac;

//    public DateTime datumod;
//    public DateTime datumDo;

public class Istorija_Uloga_ZaposlenihBasic
{
    public ZaposlenBasic Zaposlen;
    public string Uloga;
    public DateTime Datum_Od;
    public DateTime Datum_Do;

    public  Istorija_Uloga_ZaposlenihBasic()
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

    public IList<SaradjujeBasic> VandredneSituacije;
    public PredstavnikBasic? Predstavnik;

    public SektorBasic()
    {
        VandredneSituacije = new List<SaradjujeBasic>();
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

    public IList<SaradjujePregled> VandredneSituacije;
    public PredstavnikPregled? Predstavnik;

    public SektorPregled()
    {
        VandredneSituacije = new List<SaradjujePregled>();
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
    public TipLicneZastite Zalihe;
    public ZaliheBasic()
    {

    }

    public ZaliheBasic(int Serijski_Broj, string Naziv, string Status, string Tip, DateTime DatumNabavke, InterventnaJedinicaBasic Jedinica, int Kolicina, TipZalihe Zalihe) : base(Serijski_Broj, Naziv, Status, Tip, DatumNabavke,Jedinica)
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

    public ZalihePregled(int Serijski_Broj, string Naziv, string Status, string Tip, DateTime DatumNabavke, InterventnaJedinicaPregled Jedinica, int Kolicina, TipZalihe Zalihe) : base(Serijski_Broj, Naziv, Status, Tip, DatumNabavke, Jedinica)
    {
        this.Kolicina = Kolicina;
    }
}

    public class MedicinskaOpremaBasic:OpremaBasic
    {
    public TipMedicinske Medicinska;
    public MedicinskaOpremaBasic()
    {

    }

    public MedicinskaOpremaBasic(int Serijski_Broj, string Naziv, string Status, string Tip, DateTime DatumNabavke, InterventnaJedinicaBasic Jedinica, TipMedicinske medicinske) : base(Serijski_Broj, Naziv, Status, Tip ,DatumNabavke, Jedinica)
    {
        this.Medicinska = medicinske;
    }
}
   
    public class MedicinskaOpremaPregled:OpremaPregled
    {

    public TipMedicinske Medicinska;
    public MedicinskaOpremaPregled()
    {

    }

    public MedicinskaOpremaPregled(int Serijski_Broj, string Naziv, string Status, string Tip,DateTime DatumNabavke, InterventnaJedinicaPregled Jedinica,TipMedicinske Medicinska) : base(Serijski_Broj, Naziv, Status, Tip, DatumNabavke, Jedinica)
    {
    }
}
    public class LicnaZastitaBasic:OpremaBasic
    {
    public TipLicneZastite Licna;
    public LicnaZastitaBasic()
    {

    }

    public LicnaZastitaBasic(int Serijski_Broj,string Naziv, string Status, string Tip, DateTime DatumNabavke,InterventnaJedinicaBasic Jedinica, TipLicneZastite Licna) : base(Serijski_Broj, Naziv, Status, Tip, DatumNabavke, Jedinica)
    {
        this.Licna = Licna;
    }
}
    public class LicnaZastitaPregled:OpremaPregled
    {
    public TipLicneZastite Licna;
    public LicnaZastitaPregled()
    {

    }

    public LicnaZastitaPregled(int Serijski_Broj, string Naziv, string Status, string Tip, DateTime DatumNabavke, InterventnaJedinicaPregled Jedinica, TipLicneZastite Licna) : base(Serijski_Broj, Naziv, Status, Tip, DatumNabavke, Jedinica)
    {
        this.Licna = Licna;
    }
}

    public class TehnickaOpremaBasic : OpremaBasic
    {
    public TipTehnicke Tehnicka;
    public TehnickaOpremaBasic()
    {

    }

    public TehnickaOpremaBasic(int Serijski_Broj, string Naziv, string Status, string Tip, DateTime DatumNabavke, InterventnaJedinicaBasic Jedinica, TipTehnicke Tehnicka) : base(Serijski_Broj, Naziv, Status, Tip, DatumNabavke, Jedinica)
    {
        this.Tehnicka = Tehnicka;
    }
}
    public class TehnickaOpremaPregled:OpremaPregled
    {
    public TipTehnicke Tehnicka;
    public TehnickaOpremaPregled()
    {

    }

    public TehnickaOpremaPregled(int Serijski_Broj, string Naziv, string Status, string Tip, DateTime DatumNabavke, InterventnaJedinicaPregled Jedinica, TipTehnicke Tehnicka) : base(Serijski_Broj, Naziv, Status, Tip, DatumNabavke, Jedinica)
    {
        this.Tehnicka = Tehnicka;
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

    public ServisiBasic(VoziloBasic Vozilo, string TipServisa, DateTime Datum)
    {
        this.Vozilo = Vozilo;
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

    public ServisiPregled(VoziloPregled Vozilo,string TipServisa, DateTime Datum)
    {
        this.Vozilo = Vozilo;
        this.TipServisa = TipServisa;
        this.Datum = Datum;
    }
}


public class PrijavaBasic 
    {
    public  int Id ;
    
    public  DateTime Datum_I_Vreme ;
    public VandrednaSituacijaBasic VandrednaSituacija;
    public  string Tip ;
    public  string Ime_Prijavioca ;
    public  string Kontakt_Prijavioca ;
    public  string Lokacija ;
    public  string Opis ;
    public  string JMBG_Dispecer ;

    public  int Prioritet ;

    public PrijavaBasic()
    {

    }

    public PrijavaBasic(int Id, DateTime Datum_I_Vreme, VandrednaSituacijaBasic VandrednaSituacija,  string Tip, string Ime_Prijavioca, string Kontakt_Prijavioca, string Lokacija, string Opis, string JMBG_Dispecer, int Prioritet)
    {
        this.Id = Id;
        this.Datum_I_Vreme = Datum_I_Vreme;
        this.VandrednaSituacija = VandrednaSituacija;
        this.Tip = Tip;
        this.Ime_Prijavioca = Ime_Prijavioca;
        this.Kontakt_Prijavioca = Kontakt_Prijavioca;
        this.Lokacija = Lokacija;
        this.Opis = Opis;
        this.JMBG_Dispecer = JMBG_Dispecer;
        this.Prioritet = Prioritet;
    }
}
    public class PrijavaPregled
    {
    public  int Id ;
    
    public  DateTime Datum_I_Vreme ;
    public VandrednaSituacijaPregled VandrednaSituacija;
    public  string Tip ;
    public  string Ime ;
    public  string Kontakt ;
    public  string Lokacija ;
    public  string Opis ;
    public  string JMBG_Dispecer ;

    public  int Prioritet ;


    public PrijavaPregled()
    {

    }

    public PrijavaPregled(int Id,  DateTime Datum_I_Vreme, VandrednaSituacijaPregled VandrednaSituacija,string Tip, string Ime_Prijavioca, string Kontakt_Prijavioca, string Lokacija, string Opis, string JMBG_Dispecer, int Prioritet)
    {
        this.Id = Id;
        this.Datum_I_Vreme = Datum_I_Vreme;
        this.VandrednaSituacija = VandrednaSituacija;
        this.Tip = Tip;
        this.Ime = Ime_Prijavioca;
        this.Kontakt = Kontakt_Prijavioca;
        this.Lokacija = Lokacija;
        this.Opis = Opis;
        this.JMBG_Dispecer = JMBG_Dispecer;
        this.Prioritet = Prioritet;
    }
}

public class SaradjujeBasic
{
    public PredstavnikBasic Predstavnik;
    public int Uloga;

    public SektorBasic Sektor;
    public VandrednaSituacijaBasic VandrednaSituacija;

    public SaradjujeBasic()
    {

    }

    public SaradjujeBasic(PredstavnikBasic Predstavnik, int Uloga, SektorBasic Sektor, VandrednaSituacijaBasic VandrednaSituacija)
    {
        this.Predstavnik = Predstavnik;
        this.Uloga = Uloga;
        this.Sektor = Sektor;
        this.VandrednaSituacija = VandrednaSituacija;
    }

    public class SaradjujePregled
    {
        public PredstavnikPregled Predstavnik;
        public int Uloga;

        public SektorPregled Sektor;
        public VandrednaSituacijaPregled VandrednaSituacija;

        public SaradjujePregled()
        {

        }

        public SaradjujePregled(PredstavnikPregled Predstavnik, int Uloga, SektorPregled Sektor, VandrednaSituacijaPregled VandrednaSituacija)
        {
            this.Predstavnik = Predstavnik;
            this.Uloga = Uloga;
            this.Sektor = Sektor;
            this.VandrednaSituacija = VandrednaSituacija;
        }
    }
}

