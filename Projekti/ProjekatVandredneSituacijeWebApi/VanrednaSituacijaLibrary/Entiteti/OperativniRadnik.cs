using NHibernate.Hql.Ast;
using VanrednaSituacijaLibrary.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VanrednaSituacijaLibrary.Entiteti
{
    public class OperativniRadnik : Zaposlen
    {
        public virtual int Broj_Sati { get; set; }
        public virtual string Fizicka_Spremnost { get; set; }

        public virtual IList<DodeljujeSe> Dodeljuje { get; set; }

        public virtual InterventnaJedinica InterventnaJedinica { get; set; }

        public virtual IList<Sertifikat> Sertifikats { get; set; }

        public OperativniRadnik()
        {
            Dodeljuje = new List<DodeljujeSe>();
            Sertifikats = new List<Sertifikat>();
        }
    }
}
