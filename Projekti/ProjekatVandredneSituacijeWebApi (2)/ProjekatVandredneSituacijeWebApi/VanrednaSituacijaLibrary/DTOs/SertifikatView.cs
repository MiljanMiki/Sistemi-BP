using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class SertifikatView
    {
        public virtual SertifikatIdAddView Id { get; set; }
        public virtual DateTime DatumIzdavanja { get; set; }
        public virtual DateTime? DatumVazenja { get; set; }

        public SertifikatView()
        {
            Id = new SertifikatIdAddView();
        }

        public SertifikatView(Sertifikat s)
        {
            Id = new SertifikatIdAddView(s.Id);
            DatumIzdavanja = s.DatumIzdavanja;
            DatumVazenja = s.DatumVazenja;
        }
    }
}
