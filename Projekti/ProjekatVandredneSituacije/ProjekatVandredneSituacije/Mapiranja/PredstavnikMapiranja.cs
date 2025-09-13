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
          
            Table("Predstavnik_Sluzbe");

            
            Id(x => x.JMBG, "JMBG").GeneratedBy.Identity();

            References(x => x.Sektor, "Id_Sektora");

          
            Map(x => x.Ime).Column("Ime");
            Map(x => x.Prezime).Column("Prezime");
            Map(x => x.Pozicija).Column("Pozicija");
            Map(x => x.Telefon).Column("Telefon");
            Map(x => x.Email).Column("Email");
        }
    }
}
