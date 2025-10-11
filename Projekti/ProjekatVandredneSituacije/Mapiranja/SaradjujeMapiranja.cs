using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    public  class SaradjujeMapiranja:ClassMap<Saradjuje>
    {
        public SaradjujeMapiranja()
        {
            Table("Saradnja");

            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            Map(x => x.Uloga).Column("Uloga");


            References(x => x.Sektor)
                .Column("Id_Sluzbe") 
                .Not.Nullable();

            
            References(x => x.VandrednaSituacija)
                .Column("Id_Vanredne_Situacije")
                .Not.Nullable();

        }
    }
}
