using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    internal class UcestvovaloMapiranja:ClassMap<Ucestvovalo>
    {
        public UcestvovaloMapiranja()
        {
            Table("Ucestvovalo");
            Id(x => x.ID, "Id").GeneratedBy.TriggerIdentity();
            References(x => x.Vozilo)
                .Column("Registarska_Oznaka")
                .Not.Nullable();
            References(x => x.Jedinica)
                .Column("Jedinstveni_Broj")
                .Not.Nullable();
        }
    }
}
