using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Entiteti
{
    public enum TipLicneZastite
    {
        odela, 
        maske,
        kacige
    }

    public enum TipTehnicke
    {
        pumpe, detektori, radio_stanice
    }

    public enum TipMedicinske
    {
        prenosive_nosiljke, defibrilatori, kompleti_za_reanimaciju
    }

    public enum TipZalihe
    {
        satori, hrana, voda, lekovi
    }
    public abstract class Oprema
    {
        public virtual string Serijski_Broj {  get; set; }    
        public virtual string Naziv {  get; set; }

       
        public virtual string Status { get; set; }

        public virtual DateTime DatumNabavke { get; set; }

        public virtual InterventnaJedinica Jedinica { get; set; }


    }

    internal class MedicinskaOprema : Oprema {
        public virtual TipMedicinske Tip {  get; set; }
    }
    internal class TehnickaOprema: Oprema {
        public virtual TipTehnicke Tip {  get; set; }
    }
    internal class LicnaZastita : Oprema { 
        public virtual TipLicneZastite Tip {  get; set; }
    }
    internal class Zalihe : Oprema 
    {
        public virtual TipZalihe Tip {  get; set; }
        public virtual int Kolicina {  get; set; }

    }
}
