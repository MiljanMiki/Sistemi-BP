using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class InterventnaJedinicaMapiranja : ClassMap<InterventnaJedinica>
    {
        public InterventnaJedinicaMapiranja()
        {
            Table("INTERVENTNA_JEDINICA");

            Id(x => x.Jedinstveni_Broj, "JEDINSTVENI_BROJ").GeneratedBy.Assigned();

            // Linija za diskriminator je UKLONJENA jer nema nasleđivanja
            // DiscriminateSubClassesOnColumn("TIP_JEDINICE");

            Map(x => x.Naziv, "NAZIV");
            Map(x => x.BrojClanova, "BROJ_CLANOVA");
            Map(x => x.MatBrOp, "MAT_BR_OP");
            Map(x => x.Baza, "BAZA");

            References(x => x.Oprema, "OPREMA_ID");
            References(x => x.Komandir, "KOMANDIR_ID");

            HasMany(x => x.Dodeljuje).KeyColumn("JEDINICA_ID").Inverse().Cascade.All();
            HasMany(x => x.Radnici).KeyColumn("JEDINICA_ID").Inverse().Cascade.All();
            HasMany(x => x.Ucestvuje).KeyColumn("JEDINICA_ID").Inverse().Cascade.All();
        }
    }

     class OpstaIntervetnaJedMap : SubclassMap<OpstaIntervetnaJed>
    {
        public OpstaIntervetnaJedMap()
        {
            // Vrednost u diskriminator koloni za ovu klasu
            DiscriminatorValue("OPSTA");
        }
    }

     class SpecijalnaInterventnaMap : SubclassMap<SpecijalnaInterventna>
    {
        public SpecijalnaInterventnaMap()
        {
            // Vrednost u diskriminator koloni za ovu klasu
            DiscriminatorValue("SPECIJALNA");

            // Mapiranje propertija specifičnog za ovu podklasu
            Map(x => x.TipSpecijalneJed, "TIP_SPECIJALNE_JED");
        }
    }
}


