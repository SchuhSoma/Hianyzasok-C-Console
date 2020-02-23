using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hianyzasok_SchuhS
{
    class Hianyzasok
    {
        //Név;Osztály;Első nap;Utolsó nap;Mulasztott órák
        public string Nev;
        public string Osztaly;
        public int ElsoNap;
        public int UtolsoNap;
        public int MulasztottOrak;

        public Hianyzasok(string sor)
        {
            var dbok = sor.Split(';');
            this.Nev = dbok[0];
            this.Osztaly = dbok[1];
            this.ElsoNap = int.Parse(dbok[2]);
            this.UtolsoNap = int.Parse(dbok[3]);
            this.MulasztottOrak = int.Parse(dbok[4]);
        }
    }
}
