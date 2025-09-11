using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
     class OpremaMapiranja:ClassMap<Oprema>
    {
        public OpremaMapiranja()
        {
            Table("OPREMA");

           
            Id(x => x.Serijski_Broj, "Serijski_Broj").GeneratedBy.Assigned();

            
            DiscriminateSubClassesOnColumn("Tip");

          
            Map(x => x.Naziv).Column("Naziv");
            Map(x => x.Tip).Column("Tip");
            Map(x => x.Status).Column("Status");
            Map(x => x.DatumNabavke).Column("DatumNabacke");
            


            
            References(x => x.Jedinica, "IdIntervetneJedinice");

        }
    }

     class MedicinskaOpremaMapiranja : SubclassMap<MedicinskaOprema>
    {
        public MedicinskaOpremaMapiranja() {
            /*
            Table("MedicinskaOprema");
            
                KeyColumn("Serijski_Broj");
                Map(x => x.TipOpreme).Column("Tip").CustomType<string>();
            */
        }
    }

     class TehnickaOpremaMapiranja : SubclassMap<TehnickaOprema>
    {
        public TehnickaOpremaMapiranja() {
            /*
            Table("TehnickaOprema")
            
                KeyColumn("Serijski_Broj");
                Map(x => x.TipOpreme).Column("Tip").CustomType<string>();
            */
            
        }
    }

     class LicnaZastitaMapiranja : SubclassMap<LicnaZastita>
    {
        public LicnaZastitaMapiranja() {
            /*
            Table("LicnaZastita")
            
                KeyColumn("Serijski_Broj");
                Map(x => x.TipOpreme).Column("Tip").CustomType<string>();
            */
            
        }
    }

    class ZaliheMapiranja : SubclassMap<Zalihe>
    {
        public ZaliheMapiranja()
        {
            /*
            Table("MedicinskaOprema")
            
                KeyColumn("Serijski_Broj");
                Map(x => x.TipOpreme).Column("Tip").CustomType<string>();
                Map(x => x.Kolicina, "Kolicina");
            
            */
        }
    }
}
