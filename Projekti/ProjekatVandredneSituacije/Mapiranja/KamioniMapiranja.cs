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
    class KamioniMapiranja : SubclassMap<Kamioni>
    {
        public KamioniMapiranja()
        {
            Table("Kamioni");
            KeyColumn("Registarska_Oznaka");
        }
    }
}
