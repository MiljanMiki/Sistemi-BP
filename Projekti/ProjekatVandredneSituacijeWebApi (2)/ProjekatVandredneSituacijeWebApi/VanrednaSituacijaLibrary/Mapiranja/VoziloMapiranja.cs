using FluentNHibernate.Mapping;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;


namespace VanrednaSituacijaLibrary.Mapiranja
{
    class VoziloMapiranja : ClassMap<Vozilo>
    {
        public VoziloMapiranja()
        {
            Table("Vozilo");

            Id(x => x.Registarska_Oznaka, "Registarska_Oznaka").GeneratedBy.Assigned();

            Map(x => x.Proizvodjac).Column("Proizvodjac");
            
            Map(x => x.Status).Column("Status").CustomType<EnumStringType<StatusVozila>>();
            Map(x => x.Lokacija).Column("Lokacija");


            HasMany(x => x.Servisi)
           .Cascade.All()              
           .Inverse()                  
           .KeyColumn("Registarska_Oznaka_Vozila");  

            HasMany(x => x.Dodeljuje)
                .Cascade.All()
                .Inverse()
                .KeyColumn("Registarska_Oznaka");

            
        }
    }

    class TerenskaMapiranja : SubclassMap<Terensko>
    {

        public TerenskaMapiranja()
        {
            Table("Terensko_Vozilo");

            KeyColumn("Registarska_Oznaka");
        }
    }
}
    

