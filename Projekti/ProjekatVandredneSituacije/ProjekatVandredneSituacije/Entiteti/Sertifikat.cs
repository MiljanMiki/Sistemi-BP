using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Entiteti
{
    public class Sertifikat
    {
       
        public virtual SertifikatId Id { get; set; }
        public virtual DateTime DatumIzdavanja {  get; set; }
        public virtual DateTime DatumVazenja {  get; set; }

        public Sertifikat()
        {
            Id = new SertifikatId();
        }
    }
}
