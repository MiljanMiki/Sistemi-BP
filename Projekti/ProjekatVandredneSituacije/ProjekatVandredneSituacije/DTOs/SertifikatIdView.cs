using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class SertifikatIdAddView
    {
        public virtual OperativniRadnikView OperativniRadnik { get; set; }

        public virtual string ImeOperativnogRadnika { get; set; }
        public virtual string PrezimeOperativnogRadnika { get; set; }
        public virtual string JMBGRadnika { get; set; }
        public virtual string Naziv { get; set; }
        public virtual string Institucija { get; set; }

        public SertifikatIdAddView()
        {
            
        }

        public SertifikatIdAddView(SertifikatId s)
        {
            //OperativniRadnik = new OperativniRadnikView(s.OperativniRadnik);
            JMBGRadnika = s.OperativniRadnik.JMBG;
            ImeOperativnogRadnika = s.OperativniRadnik.Ime;
            PrezimeOperativnogRadnika = s.OperativniRadnik.Prezime;
            Naziv = s.Naziv;
            Institucija = s.Institucija;
        }


    }

    internal class SertifikatIdView
    {
        public virtual int Id { get; set; }
        public virtual OperativniRadnikView OperativniRadnik { get; set; }
      
        public virtual string Naziv { get; set; }
        public virtual string Institucija { get; set; }
        public SertifikatIdView()
        {
        }
        public SertifikatIdView(SertifikatId s)
        {
            OperativniRadnik = new OperativniRadnikView(s.OperativniRadnik);
  
            Naziv = s.Naziv;
            Institucija = s.Institucija;
        }
    }
}
