using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class SaradjujeView
    {
        public virtual int Id { get; set; }
        public string Uloga { get; set; }
        public virtual SluzbaView Sektor { get; set; }

        public virtual VanrednaSituacijaView VandrednaSituacija { get; set; }

        public SaradjujeView()
        {
        }
        
        public SaradjujeView(Saradjuje s)
        {
            Id = s.Id;
            Uloga = s.Uloga;
            Sektor = new SluzbaView(s.Sektor);
            VandrednaSituacija = new VanrednaSituacijaView(s.VandrednaSituacija);
        }

    }

    public  class SaradjujeAddView
    {
        public virtual int SektorID { get; set; }
        public virtual int VanrednaSituacijaID { get; set; }
        public string Uloga { get; set; }
        public SaradjujeAddView() { }
        public SaradjujeAddView(Saradjuje s)
        {
            SektorID = s.Sektor.Id_Sektora;
            VanrednaSituacijaID = s.VandrednaSituacija.Id;
            Uloga = s.Uloga;
        }
    }

    public class SaradjujeGetView
    {
        public virtual int Id { get; set; }
        public virtual int SektorID { get; set; }
        public virtual string NazivSluzbe { get; set; }
        public virtual int VanrednaSituacijaID { get; set; }

        public virtual string TipVs { get; set; }
        public string Uloga { get; set; }
        public SaradjujeGetView() { }
        public SaradjujeGetView(Saradjuje s)
        {
            Id = s.Id;
            SektorID = s.Sektor.Id_Sektora;
            NazivSluzbe = s.Sektor.TipSektora;
            VanrednaSituacijaID = s.VandrednaSituacija.Id;
            TipVs = s.VandrednaSituacija.Tip;
            Uloga = s.Uloga;
        }
    }

}
