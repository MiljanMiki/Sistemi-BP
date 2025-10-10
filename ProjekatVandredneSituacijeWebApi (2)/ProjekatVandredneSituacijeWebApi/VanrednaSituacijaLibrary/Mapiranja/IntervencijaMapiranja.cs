using FluentNHibernate.Mapping;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.Mapiranja
{
    public  class IntervencijaMapiranja:ClassMap<Intervencija>
    {

        public IntervencijaMapiranja()
        {
            
            Table("Intervencija");

            
            Id(x => x.Id, "Id").GeneratedBy.TriggerIdentity();

            
            Map(x => x.Datum_I_Vreme, "Datum_I_Vreme");
            Map(x => x.Lokacija, "Lokacija");
            Map(x => x.Status, "Status").CustomType<EnumStringType<Status>>();
            Map(x => x.Resursi, "Resursi");
            Map(x => x.Broj_Spasenih, "Broj_Spasenih");
            Map(x => x.Broj_Povredjenih, "Broj_Povredjenih");
            Map(x => x.Uspesnost, "Uspesnost");

            
            HasMany(x => x.Ucestvuje)
                .KeyColumn("IdIntervencije") 
                .Inverse()
                .Cascade.All();

            HasMany(x => x.Ucestvovalos)
                .KeyColumn("IdIntervencije")
                .Inverse()
                .Cascade.All();
        }
    }
}
