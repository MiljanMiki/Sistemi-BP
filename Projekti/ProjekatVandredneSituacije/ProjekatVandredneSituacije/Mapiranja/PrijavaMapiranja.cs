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

            
            References(x => x.Id_VandrednaSituacija, "IdVandredne_Situacije");

           
            Map(x => x.Datum_I_Vreme, "Datum_I_Vreme");
            Map(x => x.Tip).Column("Tip").CustomType<string>();
            //Srdjan Map(x => x.Ime).Column("Ime");
            Map(x => x.Kontakt).Column("Kontakt");
            Map(x => x.Lokacija).Column("Lokacija");
            Map(x => x.Opis).Column("Opis");
            Map(x => x.JMBG_Dispecer).Column("JMBG_Dispecer");
            Map(x => x.Prioritet).Column("Prioriter");


             
    }
    }
}
