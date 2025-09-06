using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class VandrednaSituacijeMapiranja : ClassMap<VandrednaSituacija>
    {
        public VandrednaSituacijeMapiranja()
        {
            Table("VandrednaSituacija");

            Id(x => x.Id,).GeneratedBy.TriggerIdentity();

            Map(x => x.Datum_Od).Column("Datum_Od");
            Map(x => x.Datum_Do).Column("Datum_Do");
            Map(x => x.Broj_Ugrozenih_Osoba).Column("Broj_Ugrozenih_Osoba");
            Map(x => x.Nivo_Opasnosti).Column("Nivo_Opasnosti");
            Map(x => x.Opstina).Column("Opstina");
            Map(x => x.Lokacija).Column("Lokacija");
            Map(x => x.Opis).Column("Opis");

            //mapiranje veza
            References(x => x.Prijava).Column("Prijava");
            

            HasMany(x => x.Ucestvuje)
           .Cascade.All()
           .Inverse()
           .KeyColumn("IdVandredneSituacije");

            HasMany(x => x.Saradjuje)
                .Cascade.All()
                .Inverse()
                .KeyColumn("VandrednaSituacija");

           
        }
    }
}
