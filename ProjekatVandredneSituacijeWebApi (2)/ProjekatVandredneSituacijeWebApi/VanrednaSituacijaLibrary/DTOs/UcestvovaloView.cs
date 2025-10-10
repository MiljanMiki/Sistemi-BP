using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class UcestvovaloView
    {
        public virtual int ID { get; set; }
        public virtual VoziloView Vozilo { get; set; }
        public virtual IntervencijaView Intervencija { get; set; }

        public virtual DateTime Datum_Od { get; set; }
        public virtual DateTime? Datum_Do { get; set; }

        public UcestvovaloView() { }

        public UcestvovaloView(Ucestvovalo u)
        {
            ID = u.ID;
            Vozilo= new VoziloView(u.Vozilo);
            Intervencija= new IntervencijaView(u.Intervencija);
            Datum_Od= u.Datum_Od;
            Datum_Do= u.Datum_Do;
        }
    }

    public  class UcestvovaloAddView
    {

        public virtual string VoziloReg { get; set; }
        public virtual int IntervencijaID { get; set; }

        public virtual DateTime Datum_Od { get; set; }

        public virtual DateTime? Datum_Do { get; set; }

        public UcestvovaloAddView() { }
        public UcestvovaloAddView(Ucestvovalo u)
        {

            VoziloReg = u.Vozilo.Registarska_Oznaka;
            IntervencijaID = u.Intervencija.Id;
            Datum_Od = u.Datum_Od;
            Datum_Do = u.Datum_Do;
            
        }
    }
}
