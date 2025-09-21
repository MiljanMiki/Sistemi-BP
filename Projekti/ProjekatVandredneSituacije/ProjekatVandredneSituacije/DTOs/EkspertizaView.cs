using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class EkspertizaView
    {
        public virtual int Id { get; set; }
        public virtual AnaliticarView Analiticar { get; set; }
        public virtual string Oblast { get; set; }

        public EkspertizaView()
        {
        }
        public EkspertizaView(Ekspertiza e)
        {
            Id = e.Id;
            Oblast = e.Oblast;
            Analiticar = new AnaliticarView(e.Analiticar);

        }
    }
    internal class EkspertizaChangeView
    {
        public virtual int Id { get; set; }

        public virtual string JMBGAnaliticara { get; set; }

        public virtual string Oblast { get; set; }

        public EkspertizaChangeView()
        {
        }

        public EkspertizaChangeView(Ekspertiza e)
        {
            Id = e.Id;
            Oblast = e.Oblast;
            JMBGAnaliticara = e.Analiticar.JMBG;
            
        }
    }
}
