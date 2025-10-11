using FluentNHibernate.Mapping;
using NHibernate.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class SpecijalnaVozilaMapiranja : SubclassMap<SpecijalnaVozila>
    {


        SpecijalnaVozilaMapiranja()
        {
            Table("SpecijalnoVozilo");

            KeyColumn("Registarska_Oznaka");

            Map(x => x.Namena).Column("Namena").CustomType<EnumStringType<Namena>>();
            

        }
    }
}
