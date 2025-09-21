using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.DTOs
{
    internal class SpecijalizacijaView
    {
        public virtual int Id { get; set; }
        public virtual KordinatorView Kordinator { get; set; }
        public virtual string Tip { get; set; }

        public SpecijalizacijaView()
        {
        }

        public SpecijalizacijaView(Specijalizacija s)
        {
            Id = s.Id;
            Tip = s.Tip;
            Kordinator = new KordinatorView(s.Kordinator);
        }
    }

    internal class SpecijalizacijaAddView
    {
        public virtual int Id { get; set; }
        public virtual string JMBG_Kordinator { get; set; }
        public virtual string Tip { get; set; }
        public SpecijalizacijaAddView() { }
        public SpecijalizacijaAddView(Specijalizacija s)
        {
            Id = s.Id;
            JMBG_Kordinator = s.Kordinator.JMBG;
            Tip = s.Tip;
        }
    }
}
