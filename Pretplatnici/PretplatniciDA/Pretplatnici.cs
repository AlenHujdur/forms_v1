using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PretplatniciDA.DATA;

namespace PretplatniciDA
{
    public class Pretplatnici
    {
        public static void InsertPretplatnik(Pretplatnici p)
        { 
            using(PretplatniciEntities dm = new PretplatniciEntities())
	        {
                dm.usp_PretplatniciInsert(p.Ime,p.Prezime,p.Email,p.Lozinka,p.KorisnickoIme,p.Aktivan,p.StrucnaSpremaID,p.Slika,p.Cv)
	        }

        }
    }
}
