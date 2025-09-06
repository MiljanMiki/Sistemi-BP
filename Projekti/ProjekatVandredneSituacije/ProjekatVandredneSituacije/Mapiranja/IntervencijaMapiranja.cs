using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    internal class IntervencijaMapiranja:ClassMap<Intervencija>
    {

        public IntervencijaMapiranja()
        {
            // Naziv tabele u bazi
            Table("INTERVENCIJA");

            // Mapiranje primarnog ključa
            // Pretpostavka je da se ID automatski generiše u bazi (Identity kolona)
            Id(x => x.ID, "ID").GeneratedBy.Identity();

            // Mapiranje ostalih prostih propertija
            Map(x => x.Id_VAndredne_Situacije, "ID_VANDREDNE_SITUACIJE");
            Map(x => x.Datum_I_Vreme, "DATUM_I_VREME");
            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.Status, "STATUS");
            Map(x => x.Broj_Spasenih, "BROJ_SPASENIH");
            Map(x => x.Broj_Povredjenih, "BROJ_POVREDJENIH");
            Map(x => x.Uspesnost, "USPESNOST");

            // Mapiranje veze 1-prema-više (one-to-many)
            // Intervencija ima više stavki "Ucestvuje"
            HasMany(x => x.Ucestvuje)
                .KeyColumn("INTERVENCIJA_ID") // Naziv spoljnog ključa u tabeli UCESTVUJE
                .Inverse()
                .Cascade.All(); // Prilikom brisanja Intervencije, brišu se i sve stavke Ucestvuje
        }
    }
}
