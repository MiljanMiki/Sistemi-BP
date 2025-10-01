
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VanrednaSituacijaLibrary.Entiteti;
namespace VanrednaSituacijaLibrary.DTOs
{
    public  class OperativniRadnikView:ZaposleniView
    {
        public virtual int Broj_Sati { get; set; }
        public virtual string Fizicka_Spremnost { get; set; }

        public virtual InterventnaJedinicaGetView? InterventnaJedinica { get; set; }



        public OperativniRadnikView()
        {
        }

        public OperativniRadnikView(OperativniRadnik o) : base(o)
        {
            Broj_Sati = o.Broj_Sati;
            Fizicka_Spremnost = o.Fizicka_Spremnost;
            if (o.InterventnaJedinica!= null) { 
            InterventnaJedinica = new InterventnaJedinicaGetView(o.InterventnaJedinica);
            }
        }
    }

    public  class OperativniRadnikChangeView:ZaposleniChangeView
    {

        public virtual int Broj_Sati { get; set; }

        public virtual string Fizicka_Spremnost { get; set; }


        public virtual int? IdJedinice { get; set; }
        public OperativniRadnikChangeView()
        {
           
        }

        public OperativniRadnikChangeView(OperativniRadnik i):base(i)
        {
            this.Broj_Sati = i.Broj_Sati;
            this.Fizicka_Spremnost = i.Fizicka_Spremnost;
            if (i.InterventnaJedinica!=null)
            {
                this.IdJedinice = i.InterventnaJedinica.Jedinstveni_Broj;
            }
        }
    }

    public class OperativniRadnikAddView : ZaposleniView
    {
        public virtual int Broj_Sati { get; set; }
        public virtual string Fizicka_Spremnost { get; set; }

        public virtual int? InterventnaJedinica { get; set; }



        public OperativniRadnikAddView()
        {
        }

        public OperativniRadnikAddView(OperativniRadnik o) : base(o)
        {
            Broj_Sati = o.Broj_Sati;
            Fizicka_Spremnost = o.Fizicka_Spremnost;
            if (o.InterventnaJedinica != null)
            {
                InterventnaJedinica = o.InterventnaJedinica.Jedinstveni_Broj;
            }
        }
    }
}
