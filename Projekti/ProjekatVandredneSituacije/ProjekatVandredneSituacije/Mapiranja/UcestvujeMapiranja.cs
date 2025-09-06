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

            CompositeId()
                .KeyReference(x => x.IdInterventneJed, "IdInterventneJed")
                .KeyReference(x => x.IdVandredneSituacije, "IdVandredneSituacije")
                .KeyReference(x => x.IdIntervencije, "IdIntervencije");

        }
    }
}
