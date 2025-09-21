using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Mapiranja
{
     class DzipoviMapiranja : SubclassMap<Dzipovi>
    {
        public DzipoviMapiranja()
        {
            Table("Dzipovi");
            KeyColumn("Registarska_Oznaka");
        }
    }
}
