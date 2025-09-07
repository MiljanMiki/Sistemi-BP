using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    internal class DodeljujeSeMapiranja:ClassMap<DodeljujeSe>
    {
        public DodeljujeSeMapiranja() {
            Table("DodeljujeSe");
            CompositeId()
                .KeyReference(x => x.Vozilo, "Vozilo")
                .KeyProperty(x => x.DatumOd, "Datum_Od");


            References(x => x.Pojedinac, "Pojedinac").Nullable();

            References(x => x.Jedinica, "Id_Jedinice").Nullable();

           
            Map(x => x.DatumDo).Column("Datum_Do");
        }
    }
}
