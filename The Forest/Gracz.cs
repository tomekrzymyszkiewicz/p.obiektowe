using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_forest_game
{
    class Gracz
    {
        private static int time, zycie, energia, pieniadze, atak, obrona;

        public void InicjalizacjaGracza()
        {
            time = 0;
            zycie = 100;
            energia = 100;
            pieniadze = 0;
            atak = 0;
            obrona = 0;
        }
        public int Zycie()
        {
            return zycie;
        }
        public int Energia()
        {
            return energia;
        }

    }
}
