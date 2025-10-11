using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class UcestvujeView
    {
        public virtual int Id { get; set; }
        public virtual  InterventnaJedinicaGetView IdInterventneJed { get; set; }
        
        public virtual  VanrednaSituacijaMiniView IdVandredneSituacije { get; set; }

        public virtual  IntervencijaView IdIntervencije { get; set; }

        public UcestvujeView()
        {
        }   

        public UcestvujeView(Ucestvuje u)
        {
            Id=u.Id;
            IdInterventneJed = new InterventnaJedinicaGetView(u.IdInterventneJed);
            IdVandredneSituacije = new VanrednaSituacijaMiniView(u.IdVandredneSituacije);
            IdIntervencije = new IntervencijaView(u.IdIntervencije);
        }

    }

    public  class UcestvujeAddView
    {
        public virtual int IdInterventneJed { get; set; }
        public virtual int IdVanredneSituacije { get; set; }
        public virtual int IdIntervencije { get; set; }

        public UcestvujeAddView()
        {
        }

        public UcestvujeAddView(Ucestvuje u)
        {
   
            if (u.IdInterventneJed != null)
                IdInterventneJed = u.IdInterventneJed.Jedinstveni_Broj;
            if (u.IdVandredneSituacije != null)
                IdVanredneSituacije = u.IdVandredneSituacije.Id;
            if (u.IdIntervencije != null)
                IdIntervencije = u.IdIntervencije.Id;
        }
    }

    public class UcestvujeGetView
    {
        public virtual int Id { get; set; }
        public virtual int IdInterventneJed { get; set; }
        public virtual int IdVanredneSituacije { get; set; }
        public virtual int IdIntervencije { get; set; }

        public UcestvujeGetView()
        {
        }

        public UcestvujeGetView(Ucestvuje u)
        {
            this.Id=u.Id;
            if (u.IdInterventneJed != null)
                IdInterventneJed = u.IdInterventneJed.Jedinstveni_Broj;
            if (u.IdVandredneSituacije != null)
                IdVanredneSituacije = u.IdVandredneSituacije.Id;
            if (u.IdIntervencije != null)
                IdIntervencije = u.IdIntervencije.Id;
        }
    }
}
