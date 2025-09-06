using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;


namespace ProjekatVandredneSituacije.Mapiranja
{
    class VoziloMapiranja : ClassMap<Vozilo>
    {
        public VoziloMapiranja()
        {
            Table("Vozilo");

            Id(x => x.Registarska_Oznaka).GeneratedBy.TriggerIdentity();

            Map(x => x.Proizvodjac).Column("Proizvodjac");
            Map(x => x.Tip).Column("Tip");
            Map(x => x.Status).Column("Status");
            Map(x => x.Lokacija).Column("Lokacija");


            HasMany(x => x.Servisi)
           .Cascade.All()              
           .Inverse()                  
           .KeyColumn("Registarska_Oznaka");  

            HasMany(x => x.Dodeljuje)
                .Cascade.All()
                .Inverse()
                .KeyColumn("Registarska_Oznaka");

            
        }
    }
}
