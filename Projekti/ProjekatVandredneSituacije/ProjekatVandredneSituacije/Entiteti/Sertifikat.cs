using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Sertifikat
    {
        public virtual OperativniRadnik OperativniRadnik { get; set; }
        public virtual string Naziv {  get; set; }
        public virtual string Institucija { get; set; } 
        public virtual DateTime DatumIzdavanja {  get; set; }
        public virtual DateTime DatumVazenja {  get; set; }
    }
}
