using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVanredneSituacije.Entiteti;

namespace ProjekatVanredneSituacije.DTOs
{
    internal class UcestvujeView
    {
        public virtual int Id { get; set; }

        public virtual InterventnaJedinicaBasicView IdInterventneJed { get; set; }
        
        public virtual VanrednaSituacijaMiniView IdVanredneSituacije { get; set; }

        public virtual IntervencijaBasicView IdIntervencije { get; set; }

        public UcestvujeView()
        {
        }   

        public UcestvujeView(Ucestvuje u)
        {
            Id = u.Id;
            if (u.IdInterventneJed != null)
                IdInterventneJed = new InterventnaJedinicaBasicView(u.IdInterventneJed);
            if (u.IdVanredneSituacije != null)
                IdVanredneSituacije = new VanrednaSituacijaMiniView(u.IdVanredneSituacije);
            if (u.IdIntervencije != null)
                IdIntervencije = new IntervencijaBasicView(u.IdIntervencije);
        }

    }

    internal class UcestvujeAddView
    {
        public virtual int Id { get; set; }
        public virtual int IdInterventneJed { get; set; }
        public virtual int IdVanredneSituacije { get; set; }
        public virtual int IdIntervencije { get; set; }

        public UcestvujeAddView()
        {
        }

        public UcestvujeAddView(Ucestvuje u)
        {
            Id = u.Id;
            if (u.IdInterventneJed != null)
                IdInterventneJed = u.IdInterventneJed.Jedinstveni_Broj;
            if (u.IdVanredneSituacije != null)
                IdVanredneSituacije = u.IdVanredneSituacije.Id;
            if (u.IdIntervencije != null)
                IdIntervencije = u.IdIntervencije.Id;
        }
    }
}
