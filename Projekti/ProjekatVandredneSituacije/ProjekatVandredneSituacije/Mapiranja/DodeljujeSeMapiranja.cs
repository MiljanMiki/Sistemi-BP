using FluentNHibernate.Mapping;
using NHibernate.Proxy;
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
            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            References(x=> x.Vozilo, "Registarska_Oznaka").Nullable();
  

            References(x => x.Radnik, "JMBG_Pojedinca").Nullable();

            References(x => x.Jedinica, "IdJedinice").Nullable();
            Map(x=> x.DatumOd).Column("Datum_Od");
            Map(x => x.DatumDo).Column("Datum_Do");
        }
    }
}
