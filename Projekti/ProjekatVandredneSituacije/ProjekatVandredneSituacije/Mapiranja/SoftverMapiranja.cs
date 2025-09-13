using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class SoftverMapiranja : ClassMap<Entiteti.Softver>
    {
        public SoftverMapiranja()
        {
            Table("Softver");
            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            References(x => x.Analiticar, "Analiticar");
            Map(x => x.Naziv, "Naziv");
            

        }
    }
}
