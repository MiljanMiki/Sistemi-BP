using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.Entiteti
{
    public class Ekspertiza
    {
        public virtual int Id { get; set; }
        public virtual Analiticar Analiticar { get; set;}

        public virtual String Oblast { get; set;}

    }
}
