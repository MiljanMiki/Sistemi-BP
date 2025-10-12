using FluentNHibernate.Mapping;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.Mapiranja
{
     class OpremaMapiranja:ClassMap<Oprema>
    {
        public OpremaMapiranja()
        {
            Table("Oprema");

           
            Id(x => x.Serijski_Broj, "Serijski_Broj").GeneratedBy.Assigned();

           

          
            Map(x => x.Naziv).Column("Naziv");
           
            Map(x => x.Status).Column("Status").CustomType<EnumStringType<StatusOpreme>>();
            Map(x => x.DatumNabavke).Column("DatumNabavke");
           
            References(x => x.Jedinica, "Id_Jedinice").Cascade.None();

        }
    }

     class MedicinskaOpremaMapiranja : SubclassMap<MedicinskaOprema>
    {
        public MedicinskaOpremaMapiranja() {
            Table("MedicinskaOprema");

            KeyColumn("Serijski_Broj");
                Map(x => x.Tip).Column("Tip").CustomType<EnumStringType<TipMedicinske>>();
            
        }
    }

     class TehnickaOpremaMapiranja : SubclassMap<TehnickaOprema>
    {
        public TehnickaOpremaMapiranja() {
            Table("Tehnicka");
            
                KeyColumn("Serijski_Broj");
                Map(x => x.Tip).Column("Tip").CustomType<EnumStringType<TipTehnicke>>();
            
        }
    }

     class LicnaZastitaMapiranja : SubclassMap<LicnaZastita>
    {
        public LicnaZastitaMapiranja() 
        {
            Table("LicnaZastita");
            
                KeyColumn("Serijski_Broj");
                Map(x => x.Tip).Column("Tip").CustomType<EnumStringType<TipLicneZastite>>();
            
        }
    }

    class ZaliheMapiranja : SubclassMap<Zalihe>
    {
        public ZaliheMapiranja()
        {
            Table("Zalihe");
            
                KeyColumn("Serijski_Broj");
                Map(x => x.Tip).Column("Tip").CustomType<EnumStringType<TipZalihe>>();
                Map(x => x.Kolicina, "Kolicina");
            
            
        }
    }
}
