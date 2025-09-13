using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
namespace ProjekatVandredneSituacije.Mapiranja
{
    class KordinatorMapiranje : SubclassMap<Kordinator>
    {
        public KordinatorMapiranje()
        {
            Table("Kordinator");

            KeyColumn("JMBG");

            Map(x => x.BrojTimova).Column("BrojTimova");

        }
    }
}