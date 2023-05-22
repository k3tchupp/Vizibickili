using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizibickili_prog_ora
{
    internal class Adat
    {
        public string nev;
        public char JAzon;
        public int EOra;
        public int EPerc;
        public int VOra;
        public int VPerc;

        public Adat(string s)
        {
            string[] darabok = s.Split(';');
            this.nev = darabok[0];
            this.JAzon = Convert.ToChar(darabok[1]);
            this.EOra = Convert.ToInt32(darabok[2]);
            this.EPerc = Convert.ToInt32(darabok[3]);
            this.VOra = Convert.ToInt32(darabok[4]);
            this.VPerc = Convert.ToInt32(darabok[5]);

        }
    }
}
