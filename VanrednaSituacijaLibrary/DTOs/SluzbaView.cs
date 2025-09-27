using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.DTOs
{
    internal class SluzbaView
    {
        public virtual int Id_Sektora { get; set; }
        public virtual string TipSektora { get; set; }
        public IList<SaradjujeView> VandredneSituacije { get; set; }
        public PredstavnikView? Predstavnik { get; set; }



        public SluzbaView()
        {
            VandredneSituacije = new List<SaradjujeView>();
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

    internal class SluzbaMinView
    {
        public virtual int Id_Sektora { get; set; }
        public virtual string TipSektora { get; set; }
        public SluzbaMinView() { }
        public SluzbaMinView(Sluzba s)
        {
            Id_Sektora = s.Id_Sektora;
            TipSektora = s.TipSektora;
        }
    }

    internal class SluzbaAddView
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
