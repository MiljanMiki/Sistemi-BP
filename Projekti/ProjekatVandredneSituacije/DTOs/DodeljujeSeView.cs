
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class DodeljujeSeView
    {
        public virtual int Id { get; set; }
        public virtual  VoziloView Vozilo { get; set; }
        public virtual OperativniRadnikView? Radnik { get; set; }
        public virtual InterventnaJedinicaView? Jedinica { get; set; }

        public virtual  DateTime DatumOd { get; set; }

        public virtual DateTime? DatumDo { get; set; }

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

    public  class DodeljujeSeAddView
    {

        public virtual string RegVozilo { get; set; }
        public virtual string? JMBGRadnik { get; set; }
        public virtual int? IdJedinica { get; set; }

        public virtual DateTime DatumOd { get; set; }

        public virtual DateTime? DatumDo { get; set; }

        public DodeljujeSeAddView()
        {
        }

        public DodeljujeSeAddView(DodeljujeSe d)
        {
            RegVozilo = d.Vozilo.Registarska_Oznaka;
            if (d.Radnik!=null)
            {
                JMBGRadnik = d.Radnik.JMBG;
            }
            if (d.Jedinica != null)
            {
                IdJedinica = d.Jedinica.Jedinstveni_Broj;
            }
            DatumOd = d.DatumOd;
            DatumDo = d.DatumDo;
        }
    }

    public class DodeljujeSeGetView
    {
        public virtual int Id { get; set; }
        public virtual string RegVozilo { get; set; }
        public virtual string? JMBGRadnik { get; set; }
        public virtual string? ImeRadnika { get; set; }
        public virtual string? PrezimeRadnika { get; set; }
        public virtual int? IdJedinica { get; set; }

        public virtual string NazivJedinice { get; set; }
        public virtual DateTime DatumOd { get; set; }

        public virtual DateTime? DatumDo { get; set; }

        public string PunoIme => ImeRadnika + " " +PrezimeRadnika;

        public DodeljujeSeGetView()
        {
        }

        public DodeljujeSeGetView(DodeljujeSe d)
        {
            Id = d.Id;
            RegVozilo = d.Vozilo.Registarska_Oznaka;
            if (d.Radnik != null)
            {
                JMBGRadnik = d.Radnik.JMBG;
                ImeRadnika = d.Radnik.Ime;
                PrezimeRadnika = d.Radnik.Prezime;
            }
            if (d.Jedinica != null)
            {
                IdJedinica = d.Jedinica.Jedinstveni_Broj;
                NazivJedinice = d.Jedinica.Naziv;
            }
            DatumOd = d.DatumOd;
            DatumDo = d.DatumDo;
        }
    }
}
