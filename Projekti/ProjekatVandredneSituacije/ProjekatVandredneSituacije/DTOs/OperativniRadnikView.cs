using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVanredneSituacije.Entiteti;

namespace ProjekatVanredneSituacije.DTOs
{
    internal class OperativniRadnikView:ZaposleniView
    {
        public virtual int Broj_Sati { get; set; }
        public virtual string Fizicka_Spremnost { get; set; }

        public virtual IList<DodeljujeSeView> Dodeljuje { get; set; }

        public virtual InterventnaJedinicaView InterventnaJedinica { get; set; }

        public virtual IList<SertifikatView> Sertifikats { get; set; }

        public OperativniRadnikView()
        {
            Dodeljuje = new List<DodeljujeSeView>();
            Sertifikats = new List<SertifikatView>();
        }

        public OperativniRadnikView(OperativniRadnik o): base(o)
        {
            Broj_Sati = o.Broj_Sati;
            Fizicka_Spremnost = o.Fizicka_Spremnost;
            InterventnaJedinica = new InterventnaJedinicaView(o.InterventnaJedinica);
            
        }
    }

    internal class OperativniRadnikChangeView:ZaposleniView
    {
        public virtual int Broj_Sati { get; set; }
        public virtual string Fizicka_Spremnost { get; set; }

        public virtual IList<DodeljujeSeView> Dodeljuje { get; set; }

        public virtual int IdJedinice { get; set; }

        public virtual string NazivJedinice { get; set; }

        public virtual IList<SertifikatView> Sertifikats { get; set; }

        public OperativniRadnikChangeView()
        {
            Dodeljuje = new List<DodeljujeSeView>();
            Sertifikats = new List<SertifikatView>();
        }

        public OperativniRadnikChangeView(OperativniRadnik i):base(i)
        {
            this.Broj_Sati = i.Broj_Sati;
            this.Fizicka_Spremnost = i.Fizicka_Spremnost;
            this.IdJedinice = i.InterventnaJedinica.Jedinstveni_Broj;
            this.NazivJedinice = i.InterventnaJedinica.Naziv;
        }
    }
}
