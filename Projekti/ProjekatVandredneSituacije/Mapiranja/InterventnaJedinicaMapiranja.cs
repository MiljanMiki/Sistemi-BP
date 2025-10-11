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
            Table("Interventna_Jedinica");

            Id(x => x.Jedinstveni_Broj, "Jedinstveni_Broj").GeneratedBy.TriggerIdentity();

            
            Map(x => x.Naziv, "Naziv");
            Map(x => x.BrojClanova, "Broj_Clanova");
          
            Map(x => x.Baza, "Baza");


            References(x => x.Komandir, "JMBG_Komandira").Nullable().Cascade.None().LazyLoad();

            HasMany(x => x.Oprema).KeyColumn("Id_Jedinice").Cascade.All();
            HasMany(x => x.Dodeljuje).KeyColumn("IdJedinice").Inverse().Cascade.All().LazyLoad();
            HasMany(x => x.Radnici).KeyColumn("Jedinica_Id").Inverse().Cascade.All().LazyLoad();
            HasMany(x => x.Ucestvuje).KeyColumn("IdInterventneJed").Inverse().Cascade.All().LazyLoad();
            
        }   
    }

     class OpstaIntervetnaJedMap : SubclassMap<OpstaIntervetnaJed>
    {
        public OpstaIntervetnaJedMap()
        {
            Table("OpstaIntervetnaJedinica");
            
            KeyColumn("Jedinstveni_Broj");
        }
    }

     class SpecijalnaInterventnaMap : SubclassMap<SpecijalnaInterventna>
    {
        public SpecijalnaInterventnaMap()
        {


            Table("SpecijalnaIntervetnaJedinica");
            KeyColumn("Jedinstveni_Broj");
            Map(x => x.TipSpecijalneJedinice, "TipSpecijalneJedinice");
        }
    }
}


