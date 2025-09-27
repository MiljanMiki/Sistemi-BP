using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Entiteti
{
    public class SertifikatId
    {
        public virtual OperativniRadnik OperativniRadnik { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Institucija { get; set; }

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != typeof(SertifikatId))
                return false;

            SertifikatId recievedObject = (SertifikatId)obj;

            if ((OperativniRadnik.JMBG == recievedObject.OperativniRadnik.JMBG) &&
                ( Naziv==recievedObject.Naziv) && (Institucija== recievedObject.Institucija))
            {
                return true;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
