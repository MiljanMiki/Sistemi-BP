using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    internal class DodeljujeSeView
    {
        public virtual int Id { get; set; }
        public virtual VoziloView Vozilo { get; set; }
        public virtual OperativniRadnikView Radnik { get; set; }
        public virtual InterventnaJedinicaView? Jedinica { get; set; }

        public virtual DateTime DatumOd { get; set; }

        public virtual DateTime DatumDo { get; set; }

        public DodeljujeSeView()
        { 
        }

        public DodeljujeSeView(DodeljujeSe d)
        {
            Id = d.Id;
            if (d.Vozilo != null)
                Vozilo = new VoziloView(d.Vozilo);
            if (d.Radnik != null)
                Radnik = new OperativniRadnikView(d.Radnik);
            if (d.Jedinica != null)
                Jedinica = new InterventnaJedinicaView(d.Jedinica);
            DatumOd = d.DatumOd;
            DatumDo = d.DatumDo;
        }
    }

    internal class DodeljujeSeAddView
    {
        public virtual int? Id { get; set; }
        public virtual string RegVozilo { get; set; }
        public virtual string? JMBGRadnik { get; set; }
        public virtual int? IdJedinica { get; set; }

        public virtual DateTime DatumOd { get; set; }

        public virtual DateTime DatumDo { get; set; }

        public DodeljujeSeAddView()
        {
        }

        public DodeljujeSeAddView(DodeljujeSe d)
        {
            Id = d.Id;
            RegVozilo = d.Vozilo.Registarska_Oznaka;
            JMBGRadnik = d.Radnik.JMBG;
            IdJedinica = d.Jedinica.Jedinstveni_Broj;
            DatumOd = d.DatumOd;
            DatumDo = d.DatumDo;
        }
    }
}
