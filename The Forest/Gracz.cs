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
        private static int dzien, zycie, energia, pieniadze, atak, obrona, doswiadczenie;
        public static DateTime czas = new DateTime(2020, 1, 1, 1, 12, 0);

        public static void InicjalizacjaGracza()
        {
            dzien = 1;
            zycie = 100;
            energia = 100;
            pieniadze = 100;
            atak = 0;
            obrona = 0;
            zyje = true;
            doswiadczenie = 0;
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
        public static int Dzien()
        {
            return dzien;
        }
        public static int Atak()
        {
            return atak;
        }
        public static int Obrona()
        {
            return obrona;
        }
        public static int Doswiadczenie()
        {
            return doswiadczenie;
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
        public static void AktualizujAtakIObrone(int mocAtaku, int mocObrony)
        {
            atak = mocAtaku;
            obrona = mocObrony;
        }
        public static bool CzyZyje()
        {
            if (zycie == 0)
            {
                zyje = false;
                return false;
            }
            else return true;
        }
        public static DateTime Czas()
        {
            //czas = DateTime.Now;
            DateTime _czas = new DateTime(2020,1,1,czas.Minute%24,czas.Second,1);
            return _czas;
        }
        public static void ZmienDzien(int oIle)
        {
            dzien += oIle;
        }
    }
}
