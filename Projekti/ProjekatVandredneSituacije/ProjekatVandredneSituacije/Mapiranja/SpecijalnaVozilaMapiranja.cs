using FluentNHibernate.Mapping;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Mapiranja
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
