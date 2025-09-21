using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    internal class Istorija_Uloga_ZaposlenihView
    {
        public virtual int Id { get; set; }
        public virtual ZaposleniView Zaposleni { get; set; }
       
        public virtual string Uloga { get; set; }
        public virtual DateTime Datum_Od { get; set; }
        public virtual DateTime Datum_Do { get; set; }
        public Istorija_Uloga_ZaposlenihView(Istorija_Uloga_Zaposlenih i)
        {
            Id = i.Id;
            Uloga = i.Uloga;
            Datum_Od = i.Datum_Od;
            Datum_Do = i.Datum_Do;
            Zaposleni = new ZaposleniView(i.Zaposleni);
        }
    }
    internal class Istorija_Uloga_ZaposlenihAddView
    {
        public virtual int Id { get; set; }
        public virtual ZaposleniView Zaposleni { get; set; }
        public virtual string JMBGZaposlenog { get; set; }
        public virtual string ImeZaposlenog { get; set; }
        public virtual string PrezimeZaposlenog { get; set; }

        public virtual string Uloga { get; set; }
        public virtual DateTime Datum_Od { get; set; }
        public virtual DateTime Datum_Do { get; set; }

        public Istorija_Uloga_ZaposlenihAddView(Istorija_Uloga_Zaposlenih i)
        {
            Id=i.Id;
            Uloga=i.Uloga;
            JMBGZaposlenog = i.Zaposleni.JMBG;
            ImeZaposlenog = i.Zaposleni.Ime;
            PrezimeZaposlenog = i.Zaposleni.Prezime;
            Datum_Od =i.Datum_Od;
            Datum_Do=i.Datum_Do;
            
        }
    }
}
