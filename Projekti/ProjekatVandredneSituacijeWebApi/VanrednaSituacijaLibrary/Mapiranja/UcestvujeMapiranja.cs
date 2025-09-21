using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.Mapiranja
{
    class UcestvujeMapiranja : ClassMap<Ucestvuje>
    {
        public UcestvujeMapiranja()
        {
            Table("Ucestvuje");

            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            References(x => x.IdInterventneJed, "IdIntervetneJed");
            References(x => x.IdVandredneSituacije, "IdVanredneSituacije");
            References(x => x.IdIntervencije, "IdIntervencije");

        }
    }
}
