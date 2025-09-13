using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
     class SpecijalizacijaMapiranja:ClassMap<Specijalizacija>
    {

        public SpecijalizacijaMapiranja()
        {
            Table("Specijalizacija");

            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            References(x => x.Kordinator, "JMBG");
            References(x => x.Tip, "Oblast");

        }
    }
}
