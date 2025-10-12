using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Mapiranja
{
    class SoftverMapiranja : ClassMap<Entiteti.Softver>
    {
        public SoftverMapiranja()
        {
            Table("SoftverAnaliticara");
            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            References(x => x.Analiticar, "JMBG_Analiticara").Cascade.None();
            Map(x => x.Naziv, "Naziv");
        }
    }
}
