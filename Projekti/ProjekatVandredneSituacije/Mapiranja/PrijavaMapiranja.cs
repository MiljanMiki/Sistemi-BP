using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Type;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class PrijavaMapiranja:ClassMap<Prijava>
    {
        public PrijavaMapiranja()
        {
            
            Table("Prijava");

           
            Id(x => x.Id, "ID").GeneratedBy.TriggerIdentity();


           
            Map(x => x.Datum_I_Vreme, "Datum_I_Vreme");
            Map(x => x.Tip).Column("Tip");
            Map(x => x.Ime_Prijavioca).Column("Ime_Prijavioca");
            Map(x => x.Kontakt).Column("Kontakt_Prijavioca");
            Map(x => x.Lokacija).Column("Lokacija");
            Map(x => x.Opis).Column("Opis");
            Map(x => x.JMBG_Dispecer).Column("JMBG_Dispecera");
            Map(x => x.Prioritet).Column("Prioritet");


             
    }
    }
}
