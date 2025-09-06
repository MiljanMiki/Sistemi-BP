using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
     class ServisiMapiranja:ClassMap<Servisi>
    {
        public ServisiMapiranja()
        {
            Table("Servisi");

            References(x => x.Vozilo, "Registarska_Oznaka");


            Map(x => x.TipServisa).Column("TipServisa");
               

            Map(x => x.Datum).Column("Datum");
                
        }
    }
}
