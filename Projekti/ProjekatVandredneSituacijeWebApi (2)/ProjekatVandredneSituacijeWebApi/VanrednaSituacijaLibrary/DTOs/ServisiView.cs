using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class ServisiAddView
    {

        public virtual string RegistarskaOznakaVozila { get; set; }
        public virtual string TipServisa { get; set; }
        public virtual DateTime Datum { get; set; }

        public ServisiAddView()
        {
        }

        public ServisiAddView(Servisi s)
        {
            TipServisa = s.TipServisa;
            Datum = s.Datum;
            RegistarskaOznakaVozila = s.Vozilo.Registarska_Oznaka;

        }

    }
    public  class ServisiView
    {
        public virtual int Id { get; set; }
        public virtual string RegistarskaOznakaVozila { get; set; }
        public virtual string Status { get; set; }
        public virtual string TipServisa { get; set; }
        public virtual DateTime Datum { get; set; }
        public ServisiView()
        {
        }
        public ServisiView(Servisi s)
        {
            Id = s.Id;
            TipServisa = s.TipServisa;
            Datum = s.Datum;
            if (s.Vozilo != null)
            {
                RegistarskaOznakaVozila = s.Vozilo.Registarska_Oznaka;
                Status = s.Vozilo.Status.ToString();
            }
        }
    }
}
