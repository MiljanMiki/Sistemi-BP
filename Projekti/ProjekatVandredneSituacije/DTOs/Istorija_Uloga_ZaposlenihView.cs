using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class Istorija_Uloga_ZaposlenihView
    {
        public virtual int Id { get; set; }
        public virtual string JMBGZaposlenog { get; set; }
      
        
        public virtual string Uloga { get; set; }
        public virtual DateTime Datum_Od { get; set; }
        public virtual DateTime? Datum_Do { get; set; }

        public Istorija_Uloga_ZaposlenihView() { }
        public Istorija_Uloga_ZaposlenihView(Istorija_Uloga_Zaposlenih i)
        {
            Id = i.Id;
            Uloga = i.Uloga;
            Datum_Od = i.Datum_Od;
            Datum_Do = i.Datum_Do;
            JMBGZaposlenog = i.Zaposleni.JMBG;
            //Zaposleni = new ZaposleniView(i.Zaposleni);
        }
    }
    public  class Istorija_Uloga_ZaposlenihAddView
    {
        public virtual string JMBGZaposlenog { get; set; }

        public virtual string Uloga { get; set; }
        public virtual DateTime Datum_Od { get; set; }
        public virtual DateTime? Datum_Do { get; set; }

        public Istorija_Uloga_ZaposlenihAddView() { }
        public Istorija_Uloga_ZaposlenihAddView(Istorija_Uloga_Zaposlenih i)
        {
        
            Uloga=i.Uloga;
            JMBGZaposlenog = i.Zaposleni.JMBG;
            Datum_Od =i.Datum_Od;
            Datum_Do=i.Datum_Do;
            
        }
    }
}
