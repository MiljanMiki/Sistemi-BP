using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
     class SertifikatMapiranja:ClassMap<Sertifikat>
    {
        public SertifikatMapiranja()
        {
            
                Table("Sertifikat");

                CompositeId()
                    .KeyReference(x => x.OperativniRadnik, "JMBG")
                    .KeyProperty(x => x.Naziv, "Tip")
                    .KeyProperty(x => x.Institucija, "Institucija");

            Map(x => x.DatumIzdavanja).Column("DATUM_OD");
            Map(x => x.DatumVazenja).Column("DATUM_DO");

            
        }
    }
}
