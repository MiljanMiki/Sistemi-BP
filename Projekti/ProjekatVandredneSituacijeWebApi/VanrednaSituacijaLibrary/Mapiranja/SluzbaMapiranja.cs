using FluentNHibernate.Mapping;
using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Mapiranja
{
     class SluzbaMapiranja:ClassMap<Sluzba>
    {
        public SluzbaMapiranja()
        {
            Table("Sluzba");

            Id(x => x.Id_Sektora, "Id_Sektora").GeneratedBy.TriggerIdentity();

            Map(x => x.TipSektora).Column("Tip");

            References(x => x.Predstavnik).Column("JMBG");


            HasMany(x => x.VandredneSituacije)
           .Cascade.All()
           .Inverse()
           .KeyColumn("Id_Sluzbe");

            
        }
    }
}
