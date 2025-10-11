using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.DTOs
{
    public  class EkspertizaView
    {
        public virtual int Id { get; set; }
        public virtual string ImeAnaliticara { get; set; }

        public virtual string PrezimeAnaliticara { get; set; }
        public virtual string JMBGAnaliticara { get; set; }

        public virtual string Oblast { get; set; }

        public EkspertizaView()
        {
        }
        public EkspertizaView(Ekspertiza e)
        {
            Id = e.Id;
            Oblast = e.Oblast;
            ImeAnaliticara = e.Analiticar.Ime;
            PrezimeAnaliticara = e.Analiticar.Prezime;
            JMBGAnaliticara = e.Analiticar.JMBG;

        }
    }
    public  class EkspertizaChangeView
    {

        public virtual string JMBGAnaliticara { get; set; }

        public virtual string Oblast { get; set; }

        public EkspertizaChangeView()
        {
        }

        public EkspertizaChangeView(Ekspertiza e)
        {
            Oblast = e.Oblast;
            JMBGAnaliticara = e.Analiticar.JMBG;
            
        }
    }
}
