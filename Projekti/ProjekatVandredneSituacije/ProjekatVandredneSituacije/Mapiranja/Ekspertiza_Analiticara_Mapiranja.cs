using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class Ekspertiza_Analiticara_Mapiranja : ClassMap<Ekspertiza>
    {
        public Ekspertiza_Analiticara_Mapiranja()
        {

            Table("Ekspertize");


            CompositeId()
                .KeyReference(x => x.Analiticar, "JMBG")
                .KeyProperty(x => x.Oblast, "Oblast");
        }
    }
}
