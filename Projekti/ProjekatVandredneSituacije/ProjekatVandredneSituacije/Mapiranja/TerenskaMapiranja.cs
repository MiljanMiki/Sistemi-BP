using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
     class TerenskaMapiranja:SubclassMap<Terenska>
    {
        public TerenskaMapiranja()
        {
            Table("Terensko_Vozilo");

            KeyColumn("Registarska_Oznaka");

            Map(x => x.TipVozila).Column("TipVozila");

        }
    }
}
