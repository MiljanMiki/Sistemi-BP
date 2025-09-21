using FluentNHibernate.Mapping;
using ProjekatVanredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Mapiranja
{
     class SluzbaMapiranja:ClassMap<Sluzba>
    {
        public SluzbaMapiranja()
        {
            Table("Sluzba");

            Id(x => x.Id_Sektora, "Id_Sektora").GeneratedBy.TriggerIdentity();

            Map(x => x.TipSektora).Column("Tip");

            References(x => x.Predstavnik).Column("JMBG");


            HasMany(x => x.VanredneSituacije)
           .Cascade.All()
           .Inverse()
           .KeyColumn("Id_Sluzbe");

            
        }
    }
}
