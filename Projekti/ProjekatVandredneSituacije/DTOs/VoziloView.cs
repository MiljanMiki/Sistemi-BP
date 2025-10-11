
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatVandredneSituacije.Entiteti;

namespace ProjekatVandredneSituacije.DTOs
{


    public  class VoziloAddView
    {
        public virtual  string Registarska_Oznaka { get; set; }
        public virtual  string Proizvodjac { get; set; }

        public virtual  StatusVozila Status { get; set; }
        public virtual  string Lokacija { get; set; }


        public VoziloAddView()
        {
        }
        public VoziloAddView(Vozilo v)
        {
            Registarska_Oznaka = v.Registarska_Oznaka;
            Proizvodjac = v.Proizvodjac;
            Status = v.Status;
            Lokacija = v.Lokacija;
        }


    }


    public class VoziloView
    {
        public virtual string Registarska_Oznaka { get; set; }
        public virtual string Proizvodjac { get; set; }

        public virtual StatusVozila Status { get; set; }
        public virtual string Lokacija { get; set; }


        public VoziloView()
        {
            
        }
        public VoziloView(Vozilo v)
        {
            Registarska_Oznaka = v.Registarska_Oznaka;
            Proizvodjac = v.Proizvodjac;
            Status = v.Status;
            Lokacija = v.Lokacija;
        }


    }

    public class VoziloChangeView
    {
        public virtual string Proizvodjac { get; set; }

        public virtual StatusVozila Status { get; set; }
        public virtual string Lokacija { get; set; }


        public VoziloChangeView()
        { 
        }
        public VoziloChangeView(Vozilo v)
        {
            Proizvodjac = v.Proizvodjac;
            Status = v.Status;
            Lokacija = v.Lokacija;
        }


    }
}
