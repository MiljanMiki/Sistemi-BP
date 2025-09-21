using FluentNHibernate.Mapping;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Mapiranja
{
     class SertifikatMapiranja:ClassMap<Sertifikat>
    {
        public SertifikatMapiranja()
        {
            
           Table("Sertifikat");

           CompositeId(x=> x.Id)
            .KeyReference(x => x.OperativniRadnik, "OperativniRadnik")
            .KeyProperty(x => x.Naziv, "Naziv")
            .KeyProperty(x => x.Institucija, "Institucija"); ;

            Map(x => x.DatumIzdavanja).Column("Datum_Od");
            Map(x => x.DatumVazenja).Column("Datum_Do");

            
        }
    }
}
