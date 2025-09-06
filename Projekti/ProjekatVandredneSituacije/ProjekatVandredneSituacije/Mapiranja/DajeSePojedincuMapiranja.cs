using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    internal class DajeSePojedincuMapiranja:ClassMap<DajeSePojedincu>
    {
        public DajeSePojedincuMapiranja()
        {
            // Naziv tabele u bazi
            Table("DAJE_SE_POJEDINCU");

            // Definicija kompozitnog primarnog ključa
            CompositeId()
                .KeyReference(x => x.Vozilo, "VOZILO_ID")
                .KeyReference(x => x.Pojedinac, "RADNIK_ID");

            // Mapiranje ostalih propertija
            Map(x => x.DatumOd, "DATUM_OD");
            Map(x => x.DatumDo, "DATUM_DO");
        }
    }
}
