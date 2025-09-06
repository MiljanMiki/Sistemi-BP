using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
     class SektoriMapiranja:ClassMap<Sektor>
    {
        public SektoriMapiranja()
        {
            Table("Sektor");

            Id(x => x.Id_Sektora, "Id_Sektora").GeneratedBy.TriggerIdentity();

            Map(x => x.TipSektora).Column("Tip");
            Map(x => x.Uloga).Column("Uloga");
          
           
            References(x => x.Predstavnik).Column("Predstavnik");


            HasMany(x => x.VandredneSituacije)
           .Cascade.All()
           .Inverse()
           .KeyColumn("Id_Sektora");

            
        }
    }
}
