using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    public enum TipLicneZastite
    {
        Odelo, 
        Maska,
        Kaciga
    }

    public enum TipTehnicke
    {
        Pumpa, Detektor, Radio_stanica
    }

    public enum TipMedicinske
    {
        Prenosive_nosiljka, Defibrilator, Komplet_za_reanimaciju
    }

    public enum TipZalihe
    {
        Sator, Hrana, Voda, Lek
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
