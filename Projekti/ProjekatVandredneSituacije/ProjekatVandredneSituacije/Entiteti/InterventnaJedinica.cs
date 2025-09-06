using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class InterventnaJedinica
    {
        public virtual int Jedinstveni_Broj { get; set; }
        public virtual string Naziv { get; set; }
        public virtual int BrojClanova { get; set; }
        public virtual int MatBrOp { get; set; }
        public virtual string Baza { get; set; }

        public virtual IList<DajeSeJedinicama> Dodeljuje {  get; set; }
       
        public virtual Oprema Oprema {  get; set; }

        public virtual IList<OperativniRadnik> Radnici {  get; set; }

        public virtual IList<Ucestvuje> Ucestvuje { get; set; }

       
        public virtual OperativniRadnik Komandir {  get; set; }
        public InterventnaJedinica()
        {
            Dodeljuje = new List<DajeSeJedinicama>();
            Radnici= new List<OperativniRadnik>();
            Ucestvuje = new List<Ucestvuje>();
        }
    }

    internal class OpstaIntervetnaJed : InterventnaJedinica { }

    internal class SpecijalnaInterventna : InterventnaJedinica
    {
        public virtual string TipSpecijalneJed{ get; set; }
    }
}
