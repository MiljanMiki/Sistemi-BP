using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class UcestvujeMapiranja : ClassMap<Ucestvuje>
    {
        public UcestvujeMapiranja()
        {
            Table("Ucestvuje");

            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            References(x => x.IdInterventneJed, "Jedinstveni_Broj");
            References(x => x.IdVandredneSituacije, "Id");
            References(x => x.IdIntervencije, "Id");

        }
    }
}
