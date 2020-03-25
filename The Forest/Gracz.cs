using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_forest_game
{
    class Gracz
    {
        private static bool zyje;
        private static int time, zycie, energia, pieniadze, atak, obrona;

        public static void InicjalizacjaGracza()
        {
            time = 0;
            zycie = 100;
            energia = 100;
            pieniadze = 100;
            atak = 0;
            obrona = 0;
            zyje = true;
            MainWindow gra = new MainWindow();

        }
        public static int Zycie()
        {
            return zycie;
        }
        public static int Energia()
        {
            return energia;
        }
        public static int Pieniadze()
        {
            return pieniadze;
        }
        public static void ZmienPieniadze(int ileZmienic)
        {
            pieniadze = pieniadze + ileZmienic;
        }
        public static void ZmienZycie(int ileZmienic)
        {
            if(zycie + ileZmienic > 100)
            {
                zycie = 100;
            }
            else if(zycie + ileZmienic <= 0)
            {
                zycie = 0;
                zyje = false;
            }
            else
            {
                zycie += ileZmienic;
            }
            if (zycie < 0) zycie = 0;
        }
        public static void ZmienEnergie(int ileZmienic)
        {
            if (energia + ileZmienic > 100)
            {
                energia = 100;
            }
            else if (zycie + ileZmienic <= 0)
            {
                energia = 0;
            }
            else
            {
                energia += ileZmienic;
            }
            if (energia < 0) energia = 0;
        }
    }
}
