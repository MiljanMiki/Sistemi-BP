using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class SpecijalizacijaView
    {
        public virtual int Id { get; set; }
        public virtual string JMBG_Kordinatora { get; set; }

        public virtual string ImeKordinatora{get; set;}

        public virtual string PrezimeKordinatora{get; set;}
        public virtual string Tip { get; set; }

        public SpecijalizacijaView()
        {
        }

        public SpecijalizacijaView(Specijalizacija s)
        {
            Id = s.Id;
            Tip = s.Tip;
            JMBG_Kordinatora = s.Kordinator.JMBG;
            ImeKordinatora = s.Kordinator.Ime;
            PrezimeKordinatora = s.Kordinator.Prezime;

        }
    }

    public  class SpecijalizacijaAddView
    {
        public virtual string JMBG_Kordinator { get; set; }

        public virtual string Tip { get; set; }
        public SpecijalizacijaAddView() { }
        public SpecijalizacijaAddView(Specijalizacija s)
        {
            JMBG_Kordinator = s.Kordinator.JMBG;
            Tip = s.Tip;
        }
    }
}
