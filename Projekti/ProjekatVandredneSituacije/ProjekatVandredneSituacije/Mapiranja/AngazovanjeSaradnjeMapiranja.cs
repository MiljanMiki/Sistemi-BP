using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjekatVandredneSituacije.Mapiranja
{
    class AngazovanjeSaradnjeMapiranja : ClassMap<AngazovanjeSaradnje>
    {

        public AngazovanjeSaradnjeMapiranja(){
        Table("AngazovanjeSaradjenj");

        CompositeId()
            .KeyReference(x => x.Predstavnik, "PREDSTAVNIK_ID")
            .KeyReference(x => x.Sektor, "SEKTOR_ID")
            .KeyReference(x => x.VandrednaSituacija, "VANDREDNA_SITUACIJA_ID");

        Map(x => x.Uloga, "ULOGA");
     }

    }
}
   
