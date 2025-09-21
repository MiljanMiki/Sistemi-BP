using FluentNHibernate.Mapping;
using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Mapiranja
{
     class ServisiMapiranja:ClassMap<Servisi>
    {
        public ServisiMapiranja()
        {
            Table("Servisi");
            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();
            References(x => x.Vozilo, "Registarska_Oznaka");


            Map(x => x.TipServisa).Column("TipServisa");
               

            Map(x => x.Datum).Column("Datum");
                
        }
    }
}
