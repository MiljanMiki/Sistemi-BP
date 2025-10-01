using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    internal class UcestvujeView
    {
        public virtual int Id { get; set; }

        public virtual InterventnaJedinicaBasicView IdInterventneJed { get; set; }
        
        public virtual VanrednaSituacijaMiniView IdVandredneSituacije { get; set; }

        public virtual IntervencijaBasicView IdIntervencije { get; set; }

        public UcestvujeView()
        {
        }   

        public UcestvujeView(Ucestvuje u)
        {
            Id = u.Id;
            if (u.IdInterventneJed != null)
                IdInterventneJed = new InterventnaJedinicaBasicView(u.IdInterventneJed);
            if (u.IdVandredneSituacije != null)
                IdVandredneSituacije = new VanrednaSituacijaMiniView(u.IdVandredneSituacije);
            if (u.IdIntervencije != null)
                IdIntervencije = new IntervencijaBasicView(u.IdIntervencije);
        }

    }

    internal class UcestvujeAddView
    {
        public virtual int Id { get; set; }
        public virtual int IdInterventneJed { get; set; }
        public virtual int IdVandredneSituacije { get; set; }
        public virtual int IdIntervencije { get; set; }

        public UcestvujeAddView()
        {
        }

        public UcestvujeAddView(Ucestvuje u)
        {
            Id = u.Id;
            if (u.IdInterventneJed != null)
                IdInterventneJed = u.IdInterventneJed.Jedinstveni_Broj;
            if (u.IdVandredneSituacije != null)
                IdVandredneSituacije = u.IdVandredneSituacije.Id;
            if (u.IdIntervencije != null)
                IdIntervencije = u.IdIntervencije.Id;
        }
    }
}
