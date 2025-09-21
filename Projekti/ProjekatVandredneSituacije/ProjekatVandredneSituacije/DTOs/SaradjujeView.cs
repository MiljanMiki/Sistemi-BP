using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class SaradjujeView
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

    internal class SaradjujeAddView
    {
        public virtual int Id { get; set; }
        public virtual int SektorID { get; set; }
        public virtual int VanrednaSituacijaID { get; set; }
        public string Uloga { get; set; }
        public SaradjujeAddView() { }
        public SaradjujeAddView(int Id, int sektorID, int vanrednaSituacijaID, string uloga)
        {
            SektorID = sektorID;
            VanrednaSituacijaID = vanrednaSituacijaID;
            Uloga = uloga;
        }
    }
}
