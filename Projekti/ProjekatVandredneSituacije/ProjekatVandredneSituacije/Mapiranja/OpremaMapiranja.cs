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

            // Mapiranje primarnog ključa. Serijski broj se verovatno unosi ručno.
            Id(x => x.Serijski_Broj, "SERIJSKI_BROJ").GeneratedBy.Assigned();

            // Definicija diskriminator kolone koja određuje tip opreme.
            // Vrednost ove kolone će biti "MEDICINSKA", "TEHNICKA" itd.
            DiscriminateSubClassesOnColumn("TIP_OPREME");

            // Mapiranje zajedničkih propertija
            Map(x => x.Naziv, "NAZIV");
            Map(x => x.DatumNabavke, "DATUM_NABAVKE");
            Map(x => x.Status, "STATUS");

            // Mapiranje many-to-one veze
            References(x => x.Jedinica, "JEDINICA_ID");

            // Property "TipOpreme" se NE MAPIRA direktno jer služi kao diskriminator!
        }
    }

     class MedicinskaOpremaMapiranja : SubclassMap<MedicinskaOprema>
    {
        public MedicinskaOpremaMapiranja() { DiscriminatorValue("MEDICINSKA"); }
    }

     class TehnickaOpremaMapiranja : SubclassMap<TehnickaOprema>
    {
        public TehnickaOpremaMapiranja() { DiscriminatorValue("TEHNICKA"); }
    }

     class LicnaZastitaMapiranja : SubclassMap<LicnaZastita>
    {
        public LicnaZastitaMapiranja() { DiscriminatorValue("LICNA_ZASTITA"); }
    }

    // Za klasu Zalihe koja ima dodatni property
    class ZaliheMapiranja : SubclassMap<Zalihe>
    {
        public ZaliheMapiranja()
        {
            DiscriminatorValue("ZALIHE");
            Map(x => x.Kolicina, "KOLICINA");
        }
    }
}
