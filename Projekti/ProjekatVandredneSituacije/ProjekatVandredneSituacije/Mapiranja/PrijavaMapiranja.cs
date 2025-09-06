using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class PrijavaMapiranja:ClassMap<Prijava>
    {
        public PrijavaMapiranja()
        {
            
            Table("Prijava");

           
            Id(x => x.Id, "ID").GeneratedBy.Identity();

            
            References(x => x.VandrednaSituacija, "VANDREDNASITUACIJAID");

           
            Map(x => x.Datum_I_Vreme, "DATUM_I_VREME");
            Map(x => x.Tip, "TIP");
            Map(x => x.Ime_Prijavioca, "IME_PRIJAVIOCA");
            Map(x => x.Kontakt_Prijavioca, "KONTAKT_PRIJAVIOCA");
            Map(x => x.Lokacija, "LOKACIJA");
            Map(x => x.Opis, "OPIS");
            Map(x => x.Dispecer, "DISPECER");
            Map(x => x.Prioritet, "PRIORITET");
        }
    }
}
