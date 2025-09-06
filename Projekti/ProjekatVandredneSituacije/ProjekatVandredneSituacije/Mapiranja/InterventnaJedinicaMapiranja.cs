using FluentNHibernate.Automapping.Steps;
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
            Table("Intervetna_Jedinica");

            Id(x => x.Jedinstveni_Broj, "Jedinstveni_Broj").GeneratedBy.Assigned();

            
            Map(x => x.Naziv, "Naziv");
            Map(x => x.BrojClanova, "Broj_Clanova");
          
            Map(x => x.Baza, "Baza");

            References(x => x.Oprema, "Oprema");
            References(x => x.Komandir, "Komandir");


            HasMany(x => x.Dodeljuje).KeyColumn("Interventna").Inverse().Cascade.All();
            HasMany(x => x.Radnici).KeyColumn("IntervetnaJedinica").Inverse().Cascade.All();
            HasMany(x => x.Ucestvuje).KeyColumn("Id_Jedinice").Inverse().Cascade.All();
            HasMany(x => x.AngazovanaVozila).KeyColumn("IntervetnaJedinica").Inverse().Cascade.All();
        }   
    }

     class OpstaIntervetnaJedMap : SubclassMap<OpstaIntervetnaJed>
    {
        public OpstaIntervetnaJedMap()
        {
            Table("OpstaIntervetnaJedinica");
            
            KeyColumn("JedinstveniBroj");
        }
    }

     class SpecijalnaInterventnaMap : SubclassMap<SpecijalnaInterventna>
    {
        public SpecijalnaInterventnaMap()
        {


            Table("SpecijalnaIntervetnaJedinica");
            KeyColumn("JedinstveniBroj");
            Map(x => x.TipSpecijalneJedinice, "TipSpecijalneJed");
        }
    }
}


