using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVanredneSituacije.Entiteti;

namespace ProjekatVanredneSituacije.DTOs
{
    internal class SertifikatView
    {
        public virtual SertifikatIdView Id { get; set; }
        public virtual DateTime DatumIzdavanja { get; set; }
        public virtual DateTime DatumVazenja { get; set; }

        public SertifikatView()
        {
            Id = new SertifikatIdView();
        }

        public SertifikatView(Sertifikat s)
        {
            Id = new SertifikatIdView(s.Id);
            DatumIzdavanja = s.DatumIzdavanja;
            DatumVazenja = s.DatumVazenja;
        }
    }
}
