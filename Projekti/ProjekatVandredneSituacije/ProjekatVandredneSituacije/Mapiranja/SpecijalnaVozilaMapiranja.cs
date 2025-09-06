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

            Id(x => x.Registarska_Oznaka).GeneratedBy.TriggerIdentity();

            Map(x => x.Namena).Column("Namena").CustomType<string>();
            


        }
    }
}
