using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVanredneSituacije.Entiteti
{
    public enum StatusVozila
    {
        operativno, u_kvaru
    }
    public class Vozilo
    {
        public virtual string Registarska_Oznaka { get; set; }
        public virtual string Proizvodjac {  get; set; }
        
        public virtual StatusVozila Status { get; set; }
        public virtual string Lokacija { get; set; }

        public virtual IList<Servisi> Servisi { get; set; }

        public virtual IList<DodeljujeSe> Dodeljuje { get; set; }

        public IList<Ucestvovalo> Ucestvovalo {  get; set; }
     
        public Vozilo()
        {
            Servisi = new List<Servisi>();
            Dodeljuje= new List<DodeljujeSe>();
        
            Ucestvovalo = new List<Ucestvovalo>();
        }
    }

    public abstract class VoziloZaJedinice:Vozilo
    {
        //objasnjenje dummy class za odvajanje dzipova od ostalih vozila
    }

    public class Sanitetska : VoziloZaJedinice
    { 
    }



}
