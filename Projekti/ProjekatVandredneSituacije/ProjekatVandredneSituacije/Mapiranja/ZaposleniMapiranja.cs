using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
namespace ProjekatVandredneSituacije.Mapiranja
{
    class ZaposleniMapiranja : ClassMap<Zaposlen>
    {
        public ZaposleniMapiranja()
        {
            Table("Zaposlen");

            Id(x => x.JMBG, "JMBG").GeneratedBy.TriggerIdentity();

            Map(x => x.Ime).Column("Ime");
            Map(x => x.Prezime).Column("Prezime");
            Map(x => x.Datum_Rodjenja).Column("Datum_Rodjenja");
            Map(x => x.Pol).Column("Pol");
            Map(x => x.Kontakt_Telefon).Column("Kontakt_Telefon");
            Map(x => x.Email).Column("Email");
            Map(x => x.AdresaStanovanja).Column("AdresaStanovanja");
            Map(x => x.Datum_Zaposlenja).Column("Datum_Zaposlenja");

        }
    }
}