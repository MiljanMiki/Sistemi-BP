using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Entiteti
{
    class TerenskaVozila : Vozilo
    {
        public TerenskaVozila() { }
    }
    
    class Kamioni : TerenskaVozila 
    {
        public Kamioni() { }
    }
    class Dzipovi : TerenskaVozila
    {
        public Dzipovi() { }

    }
}
