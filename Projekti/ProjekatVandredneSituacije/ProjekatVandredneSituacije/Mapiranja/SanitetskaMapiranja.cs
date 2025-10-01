using FluentNHibernate.Mapping;
using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Mapiranja
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
