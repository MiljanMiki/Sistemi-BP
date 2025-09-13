using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    internal class Prijava
    {
        public virtual int Id {  get; set; }

        public virtual DateTime Datum_I_Vreme { get; set; }
        public virtual VandrednaSituacija Id_VandrednaSituacija { get; set; }
        public virtual string Tip {  get; set; }
        public virtual string Ime_Prijavioca { get; set; }
        public virtual string Kontakt {  get; set; }    
        public virtual string Lokacija { get; set; }
        public virtual string Opis {  get; set; }
        public virtual string JMBG_Dispecer { get; set; }

        public virtual int Prioritet {  get; set; }

    }
}
