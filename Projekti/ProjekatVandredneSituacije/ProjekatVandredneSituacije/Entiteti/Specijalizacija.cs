using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatVandredneSituacije.Entiteti
{
    public class Specijalizacija
    {
        public virtual int Id { get; set; }
        public virtual Kordinator Kordinator { get; set; }
        public virtual string Tip { get; set; }


    }
}
