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

           CompositeId(x=> x.Id)
            .KeyReference(x => x.OperativniRadnik, "JMBG")
            .KeyProperty(x => x.Naziv, "Naziv")
            .KeyProperty(x => x.Institucija, "Institucija"); ;

            Map(x => x.DatumIzdavanja).Column("Datum_Izdavanja");
            Map(x => x.DatumVazenja).Column("Datum_Vazenja");

            
        }
    }
}
