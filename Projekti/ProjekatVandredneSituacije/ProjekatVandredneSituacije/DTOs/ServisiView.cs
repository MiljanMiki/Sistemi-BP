using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class ServisiAddView
    {
        public virtual int Id { get; set; }

        public virtual string RegistarskaOznakaVozila { get; set; }
        public virtual string TipServisa { get; set; }
        public virtual DateTime Datum { get; set; }

        public ServisiAddView()
        {
        }

        public ServisiAddView(Servisi s)
        {
            Id = s.Id;
            TipServisa = s.TipServisa;
            Datum = s.Datum;
            RegistarskaOznakaVozila = s.Vozilo.Registarska_Oznaka;

        }

    }
    internal class ServisiView
    {
        public virtual int Id { get; set; }
        public virtual VoziloView Vozilo { get; set; }
        public virtual string RegistarskaOznakaVozila { get; set; }
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
                Vozilo = new VoziloView(s.Vozilo);
                RegistarskaOznakaVozila = s.Vozilo.Registarska_Oznaka;
            }
        }
    }
}
