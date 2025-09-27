using FluentNHibernate.Mapping;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Mapiranja
{
     class PredstavnikMapiranja:ClassMap<Predstavnik>
    {

        public PredstavnikMapiranja()
        {
          
            Table("Predstavnik_Sluzbe");

            
            Id(x => x.JMBG, "JMBG").GeneratedBy.Identity();

         

          
            Map(x => x.Ime).Column("Ime");
            Map(x => x.Prezime).Column("Prezime");
            Map(x => x.Pozicija).Column("Pozicija");
            Map(x => x.Telefon).Column("Telefon");
            Map(x => x.Email).Column("Email");
            References(x => x.Sluzba, "Id_Sluzbe");
        }
    }
}
