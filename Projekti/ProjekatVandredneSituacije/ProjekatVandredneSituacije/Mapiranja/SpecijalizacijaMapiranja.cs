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
            /*
            Table("Specijalizacija");

            CompositeId()
                .KeyReference(x => x.Kordinator., "JMBG")
                .KeyReference(x => x.Tip, "Oblast");
            */
        }
    }
}
