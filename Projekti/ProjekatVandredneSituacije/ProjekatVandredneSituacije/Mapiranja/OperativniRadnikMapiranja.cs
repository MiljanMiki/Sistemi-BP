using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class OperativniRadnikMapiranja : SubclassMap<OperativniRadnik>
    {
        public OperativniRadnikMapiranja()
        {
            Table("OperativniRadnik");

            KeyColumn("JMBG");

            Map(x => x.Broj_Sati).Column("Broj_Sati");
            Map(x => x.Fizicka_Spremnost).Column("Fizicka_Spremnost");
            References(x => x.InterventnaJedinica).Column("Jedinstveni_Broj");


            HasMany(x => x.Sertifikats)
           .Cascade.All()
           .Inverse()
           .KeyColumn("Sertifikat");

            References(x => x.InterventnaJedinica).Column("Jedinstveni_Broj");


            HasMany(x => x.Dodeljuje)
                .Cascade.All()
                .Inverse()
                .KeyColumn("Pojedinac");


        }
    }
}
