using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
namespace ProjekatVandredneSituacije.Mapiranja
{
     class AnaliticarMapiranja : SubclassMap<Analiticar>
    {
        public AnaliticarMapiranja()
        {
            Table("Analiticar");

            KeyColumn("JMBG");
            

        } 
    }
}
