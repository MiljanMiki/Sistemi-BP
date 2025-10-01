using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class OpremaView
    {

        public virtual string Serijski_Broj { get; set; }
        public virtual string Naziv { get; set; }

        public virtual string Status { get; set; }

        public virtual DateTime DatumNabavke { get; set; }

        public virtual InterventnaJedinicaView Jedinica { get; set; }




        public OpremaView()
        {
        }

        public OpremaView(Oprema o)
        {
            Serijski_Broj = o.Serijski_Broj;
            Naziv = o.Naziv;
            Status = o.Status;
            DatumNabavke = o.DatumNabavke;
            Jedinica = new InterventnaJedinicaView(o.Jedinica);
        }
    }

    public  class OpremaAddView
    {
        public virtual string Serijski_Broj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime DatumNabavke { get; set; }
        public virtual int JedinicaID { get; set; }
        
        public OpremaAddView() { }
        public OpremaAddView( Oprema o)
        {
            Serijski_Broj = o.Serijski_Broj;
            Naziv = o.Naziv;
            Status = o.Status;
            DatumNabavke = o.DatumNabavke;
            JedinicaID = o.Jedinica.Jedinstveni_Broj;
        }
    }

    public class OpremaChangeView
    {

        public virtual string Naziv { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime DatumNabavke { get; set; }
        public virtual int JedinicaID { get; set; }

        public OpremaChangeView() { }
        public OpremaChangeView(Oprema o)
        {
            Naziv = o.Naziv;
            Status = o.Status;
            DatumNabavke = o.DatumNabavke;
            JedinicaID = o.Jedinica.Jedinstveni_Broj;
        }
    }

    public class OpremaMiniView//samo za vracanje opreme jedinicama
    {
        public virtual string Serijski_Broj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Status { get; set; }
        public virtual DateTime DatumNabavke { get; set; }


        public OpremaMiniView() { }
        public OpremaMiniView(Oprema o)
        {
            Naziv = o.Naziv;
            Status = o.Status;
            DatumNabavke = o.DatumNabavke;

        }
    }
}
