using FluentNHibernate.Mapping;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Mapiranja
{
    internal class SaradjujeMapiranja:ClassMap<Saradjuje>
    {
        public SaradjujeMapiranja()
        {
            Table("Saradjuje");

            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            Map(x => x.Uloga).Column("Uloga");


            References(x => x.Sektor)
                .Column("Id_Sluzbe") 
                .Not.Nullable();

            
            References(x => x.VanrednaSituacija)
                .Column("Id_VandedneSituacije")
                .Not.Nullable();

        }
    }
}
