using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{
    internal class OpstaInterventnaView:InterventnaJedinicaView
    {
        public OpstaInterventnaView(InterventnaJedinica i):base(i) { }
    }

    internal class OpstaIntervetnaGetView:InterventnaJedinicaGetView
    {
        public OpstaIntervetnaGetView(InterventnaJedinica i): base(i) { }
    }

}
