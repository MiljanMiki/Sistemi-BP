using ProjekatVandredneSituacije.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class SoftverView
    {
        public virtual int Id { get; set; }
        public AnaliticarView Analiticar { get; set; }

        public virtual string ImeAnaliticara { get; set; }

        public virtual string PrezimeAnaliticara { get; set; }
        public virtual string JMBGAnaliticara { get; set; }
        public virtual string Naziv { get; set; }

        public SoftverView()
        {

        }

        public SoftverView(Softver s)
        {
            Id = s.Id;
            Naziv = s.Naziv;
            ImeAnaliticara = s.Analiticar.Ime;
            PrezimeAnaliticara = s.Analiticar.Prezime;
            JMBGAnaliticara = s.Analiticar.JMBG;
            Analiticar = new AnaliticarView(s.Analiticar);
            
        }
    }

    internal class SoftverAddView
    {
        public virtual string JMBG_Analiticar { get; set; }
        public virtual string Naziv { get; set; }
        public SoftverAddView() { }
        public SoftverAddView(Softver s)
        {
            JMBG_Analiticar = s.Analiticar.JMBG;
            Naziv = s.Naziv;
        }
    }
}
