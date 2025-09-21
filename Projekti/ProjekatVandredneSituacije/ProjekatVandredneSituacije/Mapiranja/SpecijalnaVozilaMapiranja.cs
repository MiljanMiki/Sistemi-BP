using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class SpecijalnaVozilaMapiranja : ClassMap<SpecijalnaVozila>
    {


        SpecijalnaVozilaMapiranja()
        {
            Table("SpecijalnoVozilo");

            

            Map(x => x.Namena).Column("Namena").CustomType<string>();
            


        }
    }
}
