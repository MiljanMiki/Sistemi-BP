using FluentNHibernate.Mapping;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Mapiranja
{
     class SanitetskaMapiranja:SubclassMap<Sanitetska>
    {

        public SanitetskaMapiranja()
        {
            Table("Sanitetsko_Vozilo");

            KeyColumn("Registarska_Oznaka");
        }
    }
}
