using FluentNHibernate.Mapping;
using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Mapiranja
{
    class OperativniRadnikMapiranja : SubclassMap<OperativniRadnik>
    {
        public OperativniRadnikMapiranja()
        {
            Table("Operativni_Radnik");

            KeyColumn("JMBG");

            Map(x => x.Broj_Sati).Column("Broj_Sati");
            Map(x => x.Fizicka_Spremnost).Column("Fizicka_Spremnost");
            References(x => x.InterventnaJedinica).Column("Jedinica_Id").Nullable().LazyLoad();


            HasMany(x => x.Sertifikats)
           .Cascade.All()
           .Inverse()
           .KeyColumn("JMBG");


            HasMany(x => x.Dodeljuje)
                .Cascade.All()
                .Inverse()
                .KeyColumn("JMBG_Pojedinca");


        }
    }
}
