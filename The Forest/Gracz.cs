using System;

namespace the_forest_game
{
    class Gracz
    {
        private static int zycie, energia, pieniadze, atak, obrona, doswiadczenie;
        public static DateTime czas = new DateTime(2020, 1, 1, 12, 0, 0);
        public static DateTime czasPoczątkowy = new DateTime(2020, 1, 1, 12, 0, 0);
        public static void InicjalizacjaGracza()
        {
            zycie = 100;
            energia = 100;
            pieniadze = 10;
            atak = Ekwipunek.posiadanaBron.Atak();
            obrona = Ekwipunek.posiadanaZbroja.Obrona();
            doswiadczenie = 0;
        }
        public static void UstawWartosciGracza(int _zycie, int _energia, int _pieniadze, int _atak, int _obrona, int _doswiadczenie)
        {
            zycie = _zycie;
            energia = _energia;
            pieniadze = _pieniadze;
            atak = _atak;
            obrona = _obrona;
            doswiadczenie = _doswiadczenie;
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
            pieniadze += ileZmienic;
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
                return false;
            }
            else return true;
        }
        public static DateTime Czas()
        {
            return czas;
        }
        public static void ZmienDoswiadczenie(int oIle)
        {
            doswiadczenie += oIle;
        }
    }
}