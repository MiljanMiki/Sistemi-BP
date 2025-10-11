using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
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
