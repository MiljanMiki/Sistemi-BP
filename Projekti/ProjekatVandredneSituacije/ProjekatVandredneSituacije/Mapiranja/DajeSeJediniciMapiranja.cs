using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
namespace ProjekatVandredneSituacije.Mapiranja
{
     class DajeSeJediniciMapiranja:ClassMap<DajeSeJedinicama>
    {
        public DajeSeJediniciMapiranja()
        {
            // Naziv tabele u bazi
            Table("DAJE_SE_JEDINICAMA");

            // Definicija kompozitnog primarnog ključa
            CompositeId()
                .KeyReference(x => x.Vozilo, "VOZILO_ID")
                .KeyReference(x => x.Intervente_Jedinice, "JEDINICA_ID");

            // Mapiranje ostalih propertija
            Map(x => x.datumod, "DATUM_OD");
            Map(x => x.datumDo, "DATUM_DO");
        }
    }
}
