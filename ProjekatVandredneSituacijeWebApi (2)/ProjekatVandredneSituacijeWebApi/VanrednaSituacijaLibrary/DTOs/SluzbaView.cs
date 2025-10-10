using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class SluzbaView
    {
        public virtual int Id_Sektora { get; set; }
        public virtual string TipSektora { get; set; }
        public PredstavnikView? Predstavnik { get; set; }



        public SluzbaView()
        {
        }

        public SluzbaView(Sluzba s)
        {
            Id_Sektora = s.Id_Sektora;
            TipSektora = s.TipSektora;
            if (s.Predstavnik != null)
            {
                Predstavnik = new PredstavnikView(s.Predstavnik);
            }
        }
    }

    public  class SluzbaMinView
    {
        public virtual string TipSektora { get; set; }
        public SluzbaMinView() { }
        public SluzbaMinView(Sluzba s)
        {
           
            TipSektora = s.TipSektora;
        }
    }

    public  class SluzbaAddView
    {
        public virtual string TipSektora { get; set; }
        public virtual string JMBG_Predstavnik { get; set; }
        public SluzbaAddView() { }
        public SluzbaAddView(Sluzba s)
        {
            TipSektora = s.TipSektora;
            if (s.Predstavnik != null)
                JMBG_Predstavnik = s.Predstavnik.JMBG;
        }
    }
}
