using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
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
            ;
            Map(x => x.Status).Column("Status");
            Map(x => x.Lokacija).Column("Lokacija");


            HasMany(x => x.Servisi)
           .Cascade.All()              
           .Inverse()                  
           .KeyColumn("Vozilo");  

            HasMany(x => x.Dodeljuje)
                .Cascade.All()
                .Inverse()
                .KeyColumn("Vozilo");

            
        }
    }
    
}
