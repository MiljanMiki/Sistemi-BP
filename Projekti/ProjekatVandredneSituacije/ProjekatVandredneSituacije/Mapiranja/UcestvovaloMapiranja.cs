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
                .Column("Registarska_Oznaka_Vozila")
                .Not.Nullable();
            References(x => x.Intervencija)
                .Column("IdIntervencije")
                .Not.Nullable();

            Map(x => x.Datum_Od, "Datum_Od");
            Map(x => x.Datum_Do, "Datum_Do");

        }
    }
}
