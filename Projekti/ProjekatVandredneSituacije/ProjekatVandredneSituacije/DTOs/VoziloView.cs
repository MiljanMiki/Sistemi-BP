using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.DTOs
{


    public class VoziloView
    {
        public virtual string Registarska_Oznaka { get; set; }
        public virtual string Proizvodjac { get; set; }

        public virtual StatusVozila Status { get; set; }
        public virtual string Lokacija { get; set; }

        public virtual IList<ServisiView> Servisi { get; set; }

        public virtual IList<DodeljujeSeView> Dodeljuje { get; set; }

        public IList<UcestvovaloView> Ucestvovalo { get; set; }

        public VoziloView()
        {
            Servisi = new List<ServisiView>();
            Dodeljuje = new List<DodeljujeSeView>();
            Ucestvovalo = new List<UcestvovaloView>();
        }
        public VoziloView(Vozilo v)
        {
            Registarska_Oznaka = v.Registarska_Oznaka;
            Proizvodjac = v.Proizvodjac;
            Status = v.Status;
            Lokacija = v.Lokacija;
        }


    }
}
