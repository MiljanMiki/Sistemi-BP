using FluentNHibernate.Mapping;
using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Mapiranja
{
     class SpecijalizacijaMapiranja:ClassMap<Specijalizacija>
    {

        public SpecijalizacijaMapiranja()
        {
            Table("Specijalizacija");

            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            References(x => x.Kordinator, "JMBG_Kordinatora");
            References(x => x.Tip, "Oblast");

        }
    }
}
