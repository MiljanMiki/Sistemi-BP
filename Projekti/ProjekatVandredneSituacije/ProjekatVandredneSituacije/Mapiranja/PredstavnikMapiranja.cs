using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
     class PredstavnikMapiranja:ClassMap<Predstavnik>
    {

        public PredstavnikMapiranja()
        {
            // Naziv tabele u bazi
            Table("Predstavnik");

            // Mapiranje primarnog ključa (pretpostavka: auto-increment u bazi)
            Id(x => x.Id, "ID").GeneratedBy.Identity();

            // Mapiranje many-to-one veze
            // Jedan predstavnik pripada jednom sektoru
            References(x => x.Sektor, "SEKTOR_ID");

            // Mapiranje ostalih propertija
            Map(x => x.Ime, "IME");
            Map(x => x.Prezime, "PREZIME");
            Map(x => x.Pozicija, "POZICIJA");
            Map(x => x.Telefon, "TELEFON");
            Map(x => x.Email, "EMAIL");
        }
    }
}
