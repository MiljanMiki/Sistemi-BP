using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Entiteti
{
    public abstract class InterventnaJedinica
    {
        public virtual int Jedinstveni_Broj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual int BrojClanova { get; set; }
        public virtual string Baza { get; set; }

        public virtual OperativniRadnik Komandir {  get; set; }
        public virtual IList<DodeljujeSe> Dodeljuje {  get; set; }
       
  
        public virtual IList<OperativniRadnik> Radnici {  get; set; }

        public virtual IList<Ucestvuje> Ucestvuje { get; set; }

       
     
        public virtual IList<Oprema> Oprema { get; set; }

        public InterventnaJedinica()
        {
            Dodeljuje = new List<DodeljujeSe>();
            Radnici= new List<OperativniRadnik>();
            Ucestvuje = new List<Ucestvuje>();
            Oprema = new List<Oprema>();
        }
    }

    public class OpstaIntervetnaJed : InterventnaJedinica { }

    public class SpecijalnaInterventna : InterventnaJedinica
    {
        public virtual string TipSpecijalneJedinice{ get; set; }
    }
}
