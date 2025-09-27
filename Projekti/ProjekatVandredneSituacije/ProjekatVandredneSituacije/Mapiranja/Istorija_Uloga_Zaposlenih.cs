using FluentNHibernate.Mapping;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Mapiranja
{
     class Istorija_Uloga_ZaposlenihMapiranja:ClassMap<Istorija_Uloga_Zaposlenih>
    {
        public Istorija_Uloga_ZaposlenihMapiranja()
        {
            Table("Istorija_Uloga_Zaposlenih");

            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            References(x => x.Zaposleni, "Zaposleni");
            Map(x => x.Uloga, "Uloga");


            Map(x => x.Datum_Od)
                .Column("Datum_Od")
                .Nullable();
            Map(x => x.Datum_Do)
                .Column("Datum_Do")
                .Nullable();

        }
    }
}
