using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanrednaSituacijaLibrary.Entiteti;

namespace VanrednaSituacijaLibrary.DTOs
{
    public  class OpstaInterventnaView:InterventnaJedinicaView
    {
        public OpstaInterventnaView() { }
        public OpstaInterventnaView(InterventnaJedinica i):base(i) { }
    }

    public class OpstaInterventnaBasicView : InterventnaJedinicaBasicView
    {
        public OpstaInterventnaBasicView() { }
        public OpstaInterventnaBasicView(InterventnaJedinica i) : base(i) { }
    }

    public  class OpstaIntervetnaGetView:InterventnaJedinicaGetView
    {
        public OpstaIntervetnaGetView() { }
        public OpstaIntervetnaGetView(InterventnaJedinica i): base(i) { }
    }

}
