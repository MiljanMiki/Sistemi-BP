using FluentNHibernate.Utils;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Impl;
using ProjekatVanredneSituacije;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static SaradjujeBasic;

namespace ProjekatVanredneSituacije
{
   public class ZaposlenBasic
    {
        public string JMBG;

        public string Ime;

        public string Prezime;

        public DateTime Datum_Rodjenja;

        public string Pol;

        public string Kontakt_Telefon;

        public string Email;

        public string AdresaStanovanja;

        public DateTime Datum_Zaposlenja;

        

        public IList<Istorija_Uloga_ZaposlenihBasic> Istorija; 

        public ZaposlenBasic(string JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja,  string pol, string Kontakt_Telefon, string email, string AdresaStanovanja, DateTime DatumZaposlenja)
        {
            this.JMBG = JMBG;
            this.Ime=Ime;
            this.Prezime=Prezime;
            this.Datum_Rodjenja = Datum_Rodjenja;
            Pol = pol;
            this.Kontakt_Telefon = Kontakt_Telefon;
            Email = email;
            this.Datum_Zaposlenja = DatumZaposlenja;
            this.AdresaStanovanja = AdresaStanovanja;

        }

        public ZaposlenBasic()
        {
            Istorija = new List<Istorija_Uloga_ZaposlenihBasic>();
        }


    }

    public class ZaposlenPregled
    {
        public  string JMBG;

        public  string Ime;

        public  string Prezime;

        public  DateTime Datum_Rodjenja;

        public  string Pol;

        public  string Kontakt_Telefon;

        public  string Email;

        public  string AdresaStanovanja;

        public  DateTime Datum_Zaposlenja;

        

        public IList<Istorija_Uloga_ZaposlenihPregled> Istorija; 

        public ZaposlenPregled(string JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string AdresaStanovanja,DateTime DatumZaposlenja)
        {
            this.JMBG = JMBG;
            this.Ime = Ime;
            this.Prezime = Prezime;
            this.Datum_Rodjenja = Datum_Rodjenja;
            Pol = pol;
            this.Kontakt_Telefon = Kontakt_Telefon;
            Email = email;
            this.AdresaStanovanja = AdresaStanovanja;
            this.Datum_Zaposlenja = DatumZaposlenja;
            
        }

        public ZaposlenPregled()
        {
            Istorija = new List<Istorija_Uloga_ZaposlenihPregled>();
        }
    }

    public class AnaliticarBasic: ZaposlenBasic
    {
        public IList<SoftverBasic> Softveri;
        public IList<EkspertizaBasic> Ekspertiza;
        public AnaliticarBasic()
        {
            Softveri = new List<SoftverBasic>();
            Ekspertiza = new List<EkspertizaBasic>();
        }

        public AnaliticarBasic(string JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string AdresaStanovanja, DateTime DatumZaposlenja) :
            base(JMBG,Ime,Prezime,Datum_Rodjenja,pol, Kontakt_Telefon, email, AdresaStanovanja,DatumZaposlenja)
          
        {
            
        }

    }

    public class AnaliticarPregled: ZaposlenPregled
    {

        public IList<SoftverPregled> Softver;
        public IList<EkspertizaPregled> Ekspertiza;
        public AnaliticarPregled()
        {
            Softver = new List<SoftverPregled>();
            Ekspertiza = new List<EkspertizaPregled>();
        }

        public AnaliticarPregled(string JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string AdresaStanovanja,DateTime DatumZaposlenja) :
            base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, AdresaStanovanja, DatumZaposlenja)
        {
           
        }
    }

    public class KordinatorPregled:ZaposlenPregled
    {
        public int BrojTimova;
        public IList<SpecijalizacijaPregled> Specijalizacija;
        public KordinatorPregled()
        {
            Specijalizacija = new List<SpecijalizacijaPregled>();
        }

        public KordinatorPregled(string JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string AdresaStanovanja, DateTime DatumZaposlenja ,int BrojTimova) :
            base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, AdresaStanovanja, DatumZaposlenja)
        {
            this.BrojTimova = BrojTimova;
        }
    }
}

    public class KordinatorBasic:ZaposlenBasic
    {
    public int BrojTimova;
    public IList<SpecijalizacijaBasic> Specijalizacija;
    public KordinatorBasic()
    {
        Specijalizacija = new List<SpecijalizacijaBasic>();
    }


    public KordinatorBasic(string JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string AdresaStanovanja, DateTime DatumZaposlenja, int BrojTimova) 
        :base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, AdresaStanovanja, DatumZaposlenja)
    {
        this.BrojTimova = BrojTimova;
    }
}

 
    public class OperativniRadnikBasic:ZaposlenBasic
    {
    public  int Broj_Sati;
    public  string Fizicka_Spremnost;

    public  IList<DodeljujeSeBasic> Dodeljuje;

    public  int IdInterventnaJedinica;

    public  IList<SertifikatBasic> Sertifikats;

    public OperativniRadnikBasic()
    {
        Dodeljuje = new List<DodeljujeSeBasic>();
        Sertifikats = new List<SertifikatBasic>();
    }

    public OperativniRadnikBasic(string JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email, string AdresaStanovanja, DateTime DatumZaposlenja, int Broj_Sati, string Fizicka_Spremnost, int IdIntervetneJedinice)
        : base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email,AdresaStanovanja, DatumZaposlenja)
    {
        this.Broj_Sati=Broj_Sati;
        this.Fizicka_Spremnost = Fizicka_Spremnost;
        this.IdInterventnaJedinica = IdIntervetneJedinice;
    }
}

    public class OperativniRadnikPregled:ZaposlenPregled
    {
    public int Broj_Sati;
    public string Fizicka_Spremnost;

    public IList<DodeljujeSePregled> Dodeljuje;

    public int IdInterventnaJedinica;

    public IList<SertifikatPregled> Sertifikats;

    public OperativniRadnikPregled()
    {
        Dodeljuje = new List<DodeljujeSePregled>();
        Sertifikats = new List<SertifikatPregled>();
    }
    public OperativniRadnikPregled(string JMBG, string Ime, string Prezime, DateTime Datum_Rodjenja, string pol, string Kontakt_Telefon, string email,string AdresaStanovanja, DateTime DatumZaposlenja, int Broj_Sati, string Fizicka_Spremnost, int IdInterventnaJedinica)
    : base(JMBG, Ime, Prezime, Datum_Rodjenja, pol, Kontakt_Telefon, email, AdresaStanovanja, DatumZaposlenja)
    {
        this.Broj_Sati = Broj_Sati;
        this.Fizicka_Spremnost = Fizicka_Spremnost;
        this.IdInterventnaJedinica = IdInterventnaJedinica;
    }

}

    public class OpremaBasic
    {
    public string Serijski_Broj;

    public string Naziv;

  

    public string Status;

  
    
    public DateTime DatumNabavke;

    public int IdJedinica;

    public OpremaBasic()
    {

    }

    public OpremaBasic(string Serijski_Broj,string Naziv, string Status, DateTime DatumNabavke, int IdJedinica)
    {
        this.Serijski_Broj = Serijski_Broj;
        this.Naziv = Naziv;
       
        this.Status = Status;
        
        this.DatumNabavke = DatumNabavke;
        this.IdJedinica = IdJedinica;
    }
}

    public class OpremaPregled
    {
    public string Serijski_Broj;

    public string Naziv;

    

    public string Status;

    public int  IdJedinica;

    public DateTime DatumNabavke;

    public OpremaPregled()
    {

    }

    public OpremaPregled(string Serijski_Broj, string Naziv, string Status, DateTime DatumNabavke, int IdJedinica)
    {
        this.Serijski_Broj = Serijski_Broj;
        this.Naziv = Naziv;
        this.DatumNabavke = DatumNabavke;
        this.Status = Status;
        
        this.IdJedinica = IdJedinica;
    }
}

    public class VanrednaSituacijaBasic
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
    

    
    public  int  IdPrijava;
    public  IList<UcestvujeBasic> Ucestvuje;
    public  IList<SaradjujeBasic> Saradjuje;

    public VanrednaSituacijaBasic()
    {
        Ucestvuje = new List<UcestvujeBasic>();
        Saradjuje = new List<SaradjujeBasic>();
    }

    public VanrednaSituacijaBasic(int id, DateTime Datum_Od, DateTime Datum_Do, String Tip, int Broj_Ugrozenih_Osoba, NivoOpasnosti Nivo_Opasnosti, string Opstina, string Lokacija, string Opis, int IdPrijava)
    {
        Id = id;
        this.Tip = Tip;
        this.Broj_Ugrozenih_Osoba = Broj_Ugrozenih_Osoba;
        this.Nivo_Opasnosti = Nivo_Opasnosti;
        this.Opstina = Opstina;
        this.Lokacija = Lokacija;
        this.Opis = Opis;
        this.IdPrijava = IdPrijava;
    }
}

    public class VanrednaSituacijaPregled
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

    public int IdPrijava;
    public  IList<UcestvujePregled> Ucestvuje;
    public  IList<SaradjujePregled> Saradjuje;

    public VanrednaSituacijaPregled()
    {
        Ucestvuje = new List<UcestvujePregled>();
        Saradjuje = new List<SaradjujePregled>();
    }


    public VanrednaSituacijaPregled(int id, DateTime Datum_Od, DateTime Datum_Do, String Tip,
    int Broj_Ugrozenih_Osoba, NivoOpasnosti Nivo_Opasnosti, string Opstina, string Lokacija, string Opis, int IdPrijava)
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
        this.IdPrijava = IdPrijava;
    }
}

    public class IntervencijaBasic
    {
    public int ID;

    public DateTime Datum_I_Vreme;
    public string Lokacija;

    public Status Status;
    public int Broj_Spasenih;
    public int Broj_Povredjenih;
    public int Uspesnost;
    public IList<UcestvujeBasic> Ucestvuje;

    public IntervencijaBasic()
    {
        Ucestvuje = new List<UcestvujeBasic>();
    }

    public IntervencijaBasic(int Id, DateTime DatumIVreme, string Lokacija, Status Status, int Broj_Spasenih, int Broj_Povredjenih, int Uspesnost)
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
    public string Komandir;
    public  IList<DodeljujeSeBasic> dodeljujeSe;

    public  IList<OpremaBasic> Oprema;

    public  IList<OperativniRadnikBasic> Radnici;

    public  IList<UcestvujeBasic> Ucestvuje;


    
    public InterventnaJedinicaBasic()
    {
        dodeljujeSe = new List<DodeljujeSeBasic>();
        Radnici = new List<OperativniRadnikBasic>();
        Ucestvuje = new List<UcestvujeBasic>();
        Oprema = new List<OpremaBasic>();

    }

    public InterventnaJedinicaBasic(int Jedinstveni_Broj, string Naziv, int BrojClanova, string Komandir, string Baza)
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

    public IList<DodeljujeSePregled> Dodeljuje;

    public IList<OpremaPregled> Oprema;

    public IList<OperativniRadnikPregled> Radnici;

    public IList<UcestvujePregled> Ucestvuje;


    public string Komandir;
    public InterventnaJedinicaPregled()
    {
        Dodeljuje = new List<DodeljujeSePregled>();
        Radnici = new List<OperativniRadnikPregled>();
        Ucestvuje = new List<UcestvujePregled>();
        Oprema = new List<OpremaPregled>();
    }

    public InterventnaJedinicaPregled(int Jedinstveni_Broj, string Naziv, int BrojClanova, string Komandir, string Baza)
    
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

        public SpecijalnaInterventnaJedinicaBasic(int Jedinstveni_Broj, string Naziv, int BrojClanova, string Komandir, string Baza, string TipSpecijalneJed):base(Jedinstveni_Broj,Naziv,BrojClanova,Komandir,Baza)
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

        public SpecijalnaInterventnaJedinicaPregled(int Jedinstveni_Broj, string Naziv, int BrojClanova, string Komandir, string Baza, string TipSpecijalneJed) : base(Jedinstveni_Broj, Naziv, BrojClanova, Komandir, Baza)
        {
            this.TipSpecijalneJed = TipSpecijalneJed;
        }

    }

public class OpstaInterventnaJedBasic : InterventnaJedinicaBasic
{
    

    public OpstaInterventnaJedBasic()
    {

    }

    public OpstaInterventnaJedBasic(int Jedinstveni_Broj, string Naziv, int BrojClanova, String Komandir, string Baza) : base(Jedinstveni_Broj, Naziv, BrojClanova,Komandir, Baza)
    {
        
    }

}

public class OpstaInterventnaJedPregled : InterventnaJedinicaPregled
{
    

    public OpstaInterventnaJedPregled()
    {

    }

    public OpstaInterventnaJedPregled(int Jedinstveni_Broj, string Naziv, int BrojClanova, string Komandir, string Baza) : base(Jedinstveni_Broj, Naziv, BrojClanova, Komandir, Baza)
    {
       
    }

}
public class EkspertizaBasic
    {
    public int Id;
    public  AnaliticarBasic Analiticar;

    public  string Oblast;

    public EkspertizaBasic()
    {

    }

    public EkspertizaBasic(int Id, AnaliticarBasic Analiticar, string Oblast)
    {
        this.Id = Id;
        this.Analiticar = Analiticar;
        this.Oblast = Oblast;
    }
}

    public class EkspertizaPregled
    {
    public int Id;
    public string Analiticar;

    public String Oblast;

    public EkspertizaPregled()
    {

    }

    public EkspertizaPregled(int Id, string Analiticar, string Oblast)
    {
        this.Id= Id;
        this.Analiticar = Analiticar;
        this.Oblast = Oblast;
    }
}

public class SpecijalizacijaBasic
{
    public virtual int Id { get; set; }
    public virtual KordinatorBasic Kordinator { get; set; }
    public virtual string Tip { get; set; }

    public SpecijalizacijaBasic()
    {
    }
    public SpecijalizacijaBasic(int Id, KordinatorBasic Kordinator, string Tip)
    {
        this.Kordinator = Kordinator;
        this.Tip = Tip;
    }

}
public class SpecijalizacijaPregled
{
    public virtual int Id { get; set; }
    public virtual string Kordinator { get; set; }
    public virtual string Tip { get; set; }

    public SpecijalizacijaPregled()
    {
    }

    public SpecijalizacijaPregled(int Id, string Kordinator, string Tip)
    {
        this.Id = Id;
        this.Kordinator = Kordinator;
        this.Tip = Tip;
    }
}

    public class VoziloBasic
    {
    public  string Registarska_Oznaka;
    public  string Proizvodjac;
   
    public  StatusVozila Status;
    public  string Lokacija;

    public  IList<ServisiBasic> Servisi;

    public  IList<DodeljujeSeBasic> Dodeljuje;

    




    public VoziloBasic()
    {
        Servisi = new List<ServisiBasic>();
        Dodeljuje = new List<DodeljujeSeBasic>();
        
    }

    public VoziloBasic(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija)
    {
        this.Registarska_Oznaka = Registarska_Oznaka;
        this.Proizvodjac = Proizvodjac;
       
        this.Status = Status;
        this.Lokacija = Lokacija;
    }
}

    public class VoziloPregled
    {
    public string Registarska_Oznaka;
    public string Proizvodjac;
    
    public StatusVozila Status;
    public string Lokacija;

    public IList<ServisiPregled> Servisi;

    public IList<DodeljujeSePregled> Dodeljuje;

   




    public VoziloPregled()
    {
        Servisi = new List<ServisiPregled>();
        Dodeljuje = new List<DodeljujeSePregled>();
   
    }

    public VoziloPregled(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija)
    {
        this.Registarska_Oznaka = Registarska_Oznaka;
        this.Proizvodjac = Proizvodjac;
        
        this.Status = Status;
        this.Lokacija = Lokacija;
    }
}

//    public class TerenskaBasic:VoziloBasic
//    {
        

//        public TerenskaBasic()
//        {

//        }

//         public TerenskaBasic(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija):
//         base(Registarska_Oznaka, Proizvodjac, Status, Lokacija)
//         {
           
//         }
//    }

//    public class TerenskaPregled:VoziloPregled
//    {
  

//    public TerenskaPregled()
//    {

//    }

//    public TerenskaPregled(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija) :
//    base(Registarska_Oznaka, Proizvodjac, Status, Lokacija)
//    {
//    }


//}

public class SanitetskaBasic: VoziloBasic
{
    public SanitetskaBasic()
    {
    }
    public SanitetskaBasic(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija) : base(Registarska_Oznaka, Proizvodjac, Status, Lokacija)
    {
    }
}

public class SanitetskaPregled : VoziloPregled
{
    public SanitetskaPregled()
    {
    }
    public SanitetskaPregled(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija) : base(Registarska_Oznaka, Proizvodjac, Status, Lokacija)
    {
    }
}
    public class DzipoviBasic:VoziloBasic
{
    public DzipoviBasic()
    {  
    }

    public DzipoviBasic(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija) : base (Registarska_Oznaka, Proizvodjac, Status, Lokacija)
    {

    }
}

public class DzipoviPregled : VoziloBasic
{
    public DzipoviPregled()
    {
    }

    public DzipoviPregled(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija) : base(Registarska_Oznaka, Proizvodjac, Status, Lokacija)
    {

    }
}

public class KamioniBasic : VoziloBasic
{
    public KamioniBasic()
    {
    }

    public KamioniBasic(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija) : base(Registarska_Oznaka, Proizvodjac, Status, Lokacija)
    {

    }
}

public class KamioniPregled : VoziloBasic
{
    public KamioniPregled()
    {
    }

    public KamioniPregled(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija) : base(Registarska_Oznaka, Proizvodjac, Status, Lokacija)
    {

    }
}
public class SpecijalnaVozilaBasic:VoziloBasic 
    {
    
    public  Namena Namena ;

    public SpecijalnaVozilaBasic()
    {

    }

    public SpecijalnaVozilaBasic(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija, Namena Namena) : base(Registarska_Oznaka, Proizvodjac, Status, Lokacija)
    {
        
        this.Namena = Namena;
    }

}
    public class SpecijalnaVozilaPregled:VoziloPregled
    {
    
    public Namena Namena;


    public SpecijalnaVozilaPregled()
    {

    }

    public SpecijalnaVozilaPregled(string Registarska_Oznaka, string Proizvodjac, StatusVozila Status, string Lokacija, Namena Namena) :base(Registarska_Oznaka, Proizvodjac, Status, Lokacija) 
    {
        
        this.Namena = Namena;
      
    }
}
    public class SertifikatBasic
    {
    public SertifikatIdBasic Id;
    public  DateTime DatumIzdavanja;
    public  DateTime DatumVazenja;
    
    public SertifikatBasic()
    {

    }

    public SertifikatBasic(SertifikatIdBasic Id, DateTime DatumIzdavanja, DateTime DatumVazenja)
    {
        this.Id = Id;
        this.DatumIzdavanja = DatumIzdavanja;
        this.DatumVazenja = DatumVazenja;

    }
}
    public class SertifikatPregled
    {
    public SertifikatIdBasic Id;
    
    public DateTime DatumIzdavanja;
    public DateTime DatumVazenja;

    public SertifikatPregled()
    {

    }

    public SertifikatPregled(SertifikatIdBasic Id, DateTime DatumIzdavanja, DateTime DatumVazenja)
    {

        this.Id = Id;
        this.DatumIzdavanja = DatumIzdavanja;
        this.DatumVazenja = DatumVazenja;

    }
}
 
public class SertifikatIdBasic
{
    
    public OperativniRadnikBasic OperativniRadnik;
    public string Naziv;
    public string Institucija;
    public SertifikatIdBasic()
    {
    }
   
}
//    public class DajeSeJedinicamaBasic
//    {
//    public  VoziloBasic Vozilo;
//    public  InterventnaJedinicaBasic Intervente_Jedinice;

//    public  DateTime datumod;
//    public  DateTime datumDo;

//    public DajeSeJedinicamaBasic()
//    {

//    }

//    public DajeSeJedinicamaBasic(DateTime datumod, DateTime datumDo)
//    {
//        this.datumod = datumod;
//        this.datumDo = datumDo;
//    }

//}
//    public class DajeSeJedinicamaPregled
//    {

//        public VoziloPregled Vozilo;
//        public InterventnaJedinicaPregled Interventna_Jedinica;

//        public DateTime datumod;
//        public DateTime datumDo;

//        public DajeSeJedinicamaPregled()
//        {

//        }

//        public DajeSeJedinicamaPregled(DateTime datumod, DateTime datumDo)
//        {
//            this.datumod = datumod;
//            this.datumDo = datumDo;
//        }
//    }
public class DodeljujeSeBasic
    {
    public int Id;
    public  string RegVozilo;
    public  string JMBGPojedinac;

    public int idJedinica;

    public  DateTime datumod;
    public  DateTime datumDo;

    public DodeljujeSeBasic()
    {

    }


    public DodeljujeSeBasic(int Id, string RegVozilo, string JMBGPojedinac, int IdJedinica, DateTime datumod, DateTime datumDo)
    {
        this.Id = Id;
        this.RegVozilo = RegVozilo;
        this.JMBGPojedinac = JMBGPojedinac;
        this.idJedinica = idJedinica;
        this.datumod = datumod;
        this.datumDo = datumDo;
    }
}
public class DodeljujeSePregled
{
    public int Id;
    public VoziloPregled Vozilo;
    public OperativniRadnikPregled Pojedinac;

    public InterventnaJedinicaPregled Jedinica;

    public DateTime datumod;
    public DateTime datumDo;

    public DodeljujeSePregled()
    {

    }


    public DodeljujeSePregled(int Id, VoziloPregled Vozilo, OperativniRadnikPregled Pojedinac, InterventnaJedinicaPregled Jedinica, DateTime datumod, DateTime datumDo)
    {
        this.Id = Id;
        this.Vozilo = Vozilo;
        this.Pojedinac = Pojedinac;
        this.Jedinica = Jedinica;
        this.datumod = datumod;
        this.datumDo = datumDo;
    }
}

public class Istorija_Uloga_ZaposlenihBasic
{
    public virtual int Id { get; set; }
    public string JMBGZaposleni;
    public string Uloga;
    public DateTime Datum_Od;
    public DateTime Datum_Do;

    public  Istorija_Uloga_ZaposlenihBasic()
{
}
    
    public Istorija_Uloga_ZaposlenihBasic(int Id,string JMBGZaposleni,string Uloga, DateTime Datum_Od, DateTime Datum_Do)
    {
        this.Id = Id;
        this.JMBGZaposleni = JMBGZaposleni;
        this.Uloga = Uloga;
        this.Datum_Od = Datum_Od;
        this.Datum_Do = Datum_Od;
    }
    }
public class Istorija_Uloga_ZaposlenihPregled
    {
    public int Id;
    public string JMBGZaposleni;
    public string Uloga;
    public DateTime Datum_Od;
    public DateTime Datum_Do;

    public Istorija_Uloga_ZaposlenihPregled()
    {

    }
    public Istorija_Uloga_ZaposlenihPregled(int Id, string JMBGZaposleni, string Uloga, DateTime Datum_Od, DateTime Datum_Do)
    {
        this.Id = Id;
        this.JMBGZaposleni=JMBGZaposleni;
        this.Uloga = Uloga;
        this.Datum_Od = Datum_Od;
        this.Datum_Do = Datum_Od;
    }
}
    public class PredstavnikBasic
    {
    public  string JMBG ;
    public  int IdSektor ;
    public string ImeSektora;
    public  string Ime ;
    public  string Prezime ;
    public  string Pozicija ;
    public  string Telefon ;
    public  string Email ;
    

    public  PredstavnikBasic()
    {

    }

    public PredstavnikBasic(string JMBG, string Ime, string Prezime, string Pozicija, string Telefon, string Email, string ImeSektora, int IdSektor)
    {

        this.JMBG = JMBG;
        this.IdSektor = IdSektor;
        this.ImeSektora = ImeSektora;   
        this.Ime = Ime;
        this.Prezime = Prezime;
        this.Pozicija = Pozicija;
        this.Telefon = Telefon;
        this.Email = Email;
    }
}
    public class PredstavnikPregled
    {
    public string JMBG;
    
    public string Ime;
    public string Prezime;
    public string Pozicija;
    public string Telefon;
    public string Email;
    public int IdSektor;
    public string ImeSektora;

    public PredstavnikPregled()
    {

    }

    public PredstavnikPregled(string JMBG,  string Ime,  string Prezime, string Pozicija, string Telefon, string Email, int IdSektor, string ImeSektora)
    {
        this.JMBG = JMBG;
        this.Ime = Ime;
        this.Prezime = Prezime;
        this.Pozicija = Pozicija;
        this.Telefon= Telefon;
        this.Email = Email;
        this.IdSektor = IdSektor;
        this.ImeSektora= ImeSektora; 

    }
}
    public class UcestvujeBasic
    {
    public int Id;
    public  int IdInterventneJed;
    public  int IdVanredneSituacije;

    public  int IdIntervencije;

    public UcestvujeBasic()
    {

    }
    public UcestvujeBasic(int Id,int IdInterventneJedinice, int IdVanredneSituacije, int IdIntervencije)
    {
        this.Id = Id;
        this.IdInterventneJed = IdInterventneJedinice;
        this.IdVanredneSituacije = IdVanredneSituacije;
        this.IdIntervencije = IdIntervencije;
    }
}
    public class UcestvujePregled
    {
    public int Id;
    public InterventnaJedinicaPregled IdInterventneJed;
    public VanrednaSituacijaPregled IdVanredneSituacije;

    public IntervencijaPregled IdIntervencije;
    
    public UcestvujePregled()
    {

    }

    public UcestvujePregled(int Id, InterventnaJedinicaPregled IdInterventneJedinice, VanrednaSituacijaPregled IdVanredneSituacije, IntervencijaPregled IdIntervencije)
    {
        this.Id = Id;
        this.IdInterventneJed = IdInterventneJedinice;
        this.IdVanredneSituacije = IdVanredneSituacije;
        this.IdIntervencije = IdIntervencije;
    }
}

    public class SluzbaBasic
    {
    public int Id_Sektora;
    public  string TipSektora;
    

    public IList<SaradjujeBasic> VanredneSituacije;
    public PredstavnikBasic? Predstavnik;

    public SluzbaBasic()
    {
        VanredneSituacije = new List<SaradjujeBasic>();
    }

    public SluzbaBasic(int Id_Sektora, string TipSektora, PredstavnikBasic predstavnik)
    {
        this.Id_Sektora = Id_Sektora;
        this.TipSektora = TipSektora;
        this.Predstavnik = predstavnik;
    }
}
    public class SluzbaPregled
    {
    public int Id_Sektora;
    public string TipSektora;


    public IList<SaradjujePregled> VanredneSituacije;
    public PredstavnikPregled? Predstavnik;

    public SluzbaPregled()
    {
        VanredneSituacije = new List<SaradjujePregled>();
    }

    public SluzbaPregled(int Id_Sektora, string TipSektora, PredstavnikPregled predstavnik)
    {
        this.Id_Sektora = Id_Sektora;
        this.TipSektora = TipSektora;
        
        this.Predstavnik = predstavnik;
    }
}

    public class ZaliheBasic:OpremaBasic
    {
    public int Kolicina;
    public TipZalihe Zalihe;
    public ZaliheBasic()
    {

    }

    public ZaliheBasic(string Serijski_Broj, string Naziv, string Status, DateTime DatumNabavke, int IdJedinica, int Kolicina, TipZalihe Zalihe) : base(Serijski_Broj, Naziv, Status, DatumNabavke,IdJedinica)
    {
        this.Zalihe = Zalihe;
        this.Kolicina = Kolicina;
    }
}
    public class ZalihePregled:OpremaPregled
    {
    public int Kolicina;
    public TipZalihe Zalihe;
    public ZalihePregled()
    {

    }

    public ZalihePregled(string Serijski_Broj, string Naziv, string Status, DateTime DatumNabavke, int IdJedinica, int Kolicina, TipZalihe Zalihe) : base(Serijski_Broj, Naziv, Status, DatumNabavke, IdJedinica)
    {
        this.Zalihe = Zalihe;
        this.Kolicina = Kolicina;
    }
}

    public class MedicinskaOpremaBasic:OpremaBasic
    {
    public TipMedicinske Medicinska;
    public MedicinskaOpremaBasic()
    {

    }

    public MedicinskaOpremaBasic(string Serijski_Broj, string Naziv, string Status, DateTime DatumNabavke, int IdJedinica, TipMedicinske medicinske) : base(Serijski_Broj, Naziv, Status ,DatumNabavke, IdJedinica)
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

    public MedicinskaOpremaPregled(string Serijski_Broj, string Naziv, string Status,DateTime DatumNabavke, int IdJedinica,TipMedicinske Medicinska) : base(Serijski_Broj, Naziv, Status, DatumNabavke, IdJedinica)
    {
    }
}
    public class LicnaZastitaBasic:OpremaBasic
    {
    public TipLicneZastite Licna;
    public LicnaZastitaBasic()
    {

    }

    public LicnaZastitaBasic(string Serijski_Broj,string Naziv, string Status, DateTime DatumNabavke,int IdJedinica, TipLicneZastite Licna) : base(Serijski_Broj, Naziv, Status,  DatumNabavke, IdJedinica)
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

    public LicnaZastitaPregled(string Serijski_Broj, string Naziv, string Status,  DateTime DatumNabavke, int IdJedinica, TipLicneZastite Licna) : base(Serijski_Broj, Naziv, Status, DatumNabavke, IdJedinica)
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

    public TehnickaOpremaBasic(string Serijski_Broj, string Naziv, string Status, DateTime DatumNabavke, int IdJedinica, TipTehnicke Tehnicka) : base(Serijski_Broj, Naziv, Status, DatumNabavke, IdJedinica)
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

    public TehnickaOpremaPregled(string Serijski_Broj, string Naziv, string Status,  DateTime DatumNabavke, int IdJedinica, TipTehnicke Tehnicka) : base(Serijski_Broj, Naziv, Status, DatumNabavke, IdJedinica)
    {
        this.Tehnicka = Tehnicka;
    }
}

    public class ServisiBasic
    {
    public int Id;
    public  string  RegistracijaVozilo ;
    public  string TipServisa ;
    public  DateTime Datum ;

    public ServisiBasic()
    {

    }

    public ServisiBasic(int Id, string RegistracijaVozila, string TipServisa, DateTime Datum)
    {
        this.Id = Id;
        this.RegistracijaVozilo = RegistracijaVozila;
        this.TipServisa = TipServisa;
        this.Datum = Datum;
    }
}
public class ServisiPregled
    {
    public int Id;
    public  string RegistracijaVozila ;
    public  string TipServisa ;
    public  DateTime Datum ;

    public ServisiPregled()
    {

    }

    public ServisiPregled(int Id,string RegistracijaVozila,string TipServisa, DateTime Datum)
    {
        this.Id= Id;
        this.RegistracijaVozila = RegistracijaVozila;
        this.TipServisa = TipServisa;
        this.Datum = Datum;
    }
}


public class PrijavaBasic 
    {
    public  int Id ;
    
    public  DateTime Datum_I_Vreme ;
    public int? IdVanrednaSituacija;
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

    public PrijavaBasic(int Id, DateTime Datum_I_Vreme, int IdVanrednaSituacija,  string Tip, string Ime_Prijavioca, string Kontakt_Prijavioca, string Lokacija, string Opis, string JMBG_Dispecer, int Prioritet)
    {
        this.Id = Id;
        this.Datum_I_Vreme = Datum_I_Vreme;
        this.IdVanrednaSituacija = IdVanrednaSituacija;
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
    public int IdVanrednaSituacija;
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

    public PrijavaPregled(  DateTime Datum_I_Vreme, int IdVanrednaSituacija,string Tip, string Ime_Prijavioca, string Kontakt_Prijavioca, string Lokacija, string Opis, string JMBG_Dispecer, int Prioritet)
    {
        
        this.Datum_I_Vreme = Datum_I_Vreme;
        this.IdVanrednaSituacija = IdVanrednaSituacija;
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
    public int Id;
    public string Uloga;

    public int IdSektor;
    public int IdVanrednaSituacija;

    public SaradjujeBasic()
    {

    }

    public SaradjujeBasic(int Id, string Uloga, int IdSektor, int IdVanrednaSituacija)
    {
        this.Id = Id;
        this.Uloga = Uloga;
        this.IdSektor = IdSektor;
        this.IdVanrednaSituacija = IdVanrednaSituacija;
    }
}
public class SaradjujePregled
{

    public int Id;
    public string Uloga;

    public SluzbaPregled IdSektor;
    public VanrednaSituacijaPregled IdVanrednaSituacija;

    public SaradjujePregled()
    {

    }

    public SaradjujePregled(int Id, string Uloga, SluzbaPregled IdSektor, VanrednaSituacijaPregled IdVanrednaSituacija)
    {
        this.Id = Id;
        this.Uloga = Uloga;
        this.IdSektor = IdSektor;
        this.IdVanrednaSituacija = IdVanrednaSituacija;
    }
}
    public class SoftverBasic
    {
        public string AnaliticarJMBG;
        public string Naziv;
        public SoftverBasic()
        {

        }
        public SoftverBasic(string AnaliticarJMBG, string Naziv)
        {
            this.AnaliticarJMBG = AnaliticarJMBG;
            this.Naziv = Naziv;
        }

    }
    public class SoftverPregled
    {
        public AnaliticarPregled Analiticar;
        public string Naziv;
        public SoftverPregled()
        {
        }
        public SoftverPregled(AnaliticarPregled Analiticar, string Naziv)
        {
            this.Analiticar = Analiticar;
            this.Naziv = Naziv;
        }
    }

    public class UcestvovaloBasic
{
    public virtual int ID { get; set; }
    public virtual string RegVozilo { get; set; }
    public virtual int IdJedinica { get; set; }

    public UcestvovaloBasic()
    {
    }
    public UcestvovaloBasic(int ID, string RegVozilo, int IdJedinica)
    {
        this.ID = ID;
        this.RegVozilo = RegVozilo;
        this.IdJedinica = IdJedinica;
    }
}
public class UcestvovaloPregled
{
    public virtual int ID { get; set; }
    public virtual VoziloPregled RegVozilo { get; set; }
    public virtual InterventnaJedinicaPregled IdJedinica { get; set; }
    public UcestvovaloPregled()
    {
    }
    public UcestvovaloPregled(int ID, VoziloPregled RegVozilo, InterventnaJedinicaPregled IdJedinica)
    {
        this.ID = ID;
        this.RegVozilo = RegVozilo;
        this.IdJedinica = IdJedinica;
    }
}


