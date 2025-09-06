using FluentNHibernate.Mapping;
using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Mapiranja
{
    class Ekspertiza_Analiticara_Mapiranja:ClassMap<Ekspertiza_Analiticara>
    {
        public Ekspertiza_Analiticara_Mapiranja()
        {
            // Naziv tabele u bazi
            Table("Ekspertiza_Analiticara");

            // Definicija kompozitnog primarnog ključa
            CompositeId()
                // Prvi deo ključa je veza ka tabeli Analiticar
                .KeyReference(x => x.Analiticar, "JMBG")
                // Drugi deo ključa je property "Oblast"
                .KeyProperty(x => x.Oblast, "Oblast");
        }
    }
