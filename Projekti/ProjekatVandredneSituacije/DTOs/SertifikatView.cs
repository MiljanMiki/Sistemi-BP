using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
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
            Id = new SertifikatIdAddView
            {
                JMBGRadnika = s.Id.OperativniRadnik.JMBG,
                Naziv = s.Id.Naziv,
                Institucija = s.Id.Institucija
            };
            DatumIzdavanja = s.DatumIzdavanja;
            DatumVazenja = s.DatumVazenja;
        }
    }

    public class SertifikatGetView
    {
        public virtual string  JMBGOperativnogRadnika { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Institucija { get; set; }
        public virtual DateTime DatumIzdavanja { get; set; }
        public virtual DateTime? DatumVazenja { get; set; }

        public SertifikatGetView()
        {
            
        }

        public SertifikatGetView(Sertifikat s)
        {
            JMBGOperativnogRadnika = s.Id.OperativniRadnik.JMBG;
            Naziv = s.Id.Naziv;
            Institucija = s.Id.Institucija;
            DatumIzdavanja = s.DatumIzdavanja;
            DatumVazenja = s.DatumVazenja;
        }
    }
}
