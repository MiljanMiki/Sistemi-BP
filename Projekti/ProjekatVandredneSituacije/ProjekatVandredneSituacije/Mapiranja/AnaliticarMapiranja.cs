using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using VanrednaSituacijaLibrary.Entiteti;
namespace VanrednaSituacijaLibrary.Mapiranja
{
     class AnaliticarMapiranja : SubclassMap<Analiticar>
    {
        public AnaliticarMapiranja()
        {
            Table("Analiticar");

            KeyColumn("JMBG");

            HasMany(x => x.Softveri)
           .Cascade.All()
           .Inverse()
           .KeyColumn("JMBG_Analiticara");

            HasMany(x => x.Ekspertiza)
           .Cascade.All()
           .Inverse()
           .KeyColumn("JMBG");

        } 
    }
}
