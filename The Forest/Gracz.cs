using System;

namespace the_forest_game
{
    class Gracz
    {
        private static bool zyje { get; set; }
        private static int dzien { get; set; }
        private static int zycie { get; set; }
        private static int energia { get; set; }
        private static int pieniadze { get; set; }
        private static int atak { get; set; }
        private static int obrona { get; set; }
        private static int doswiadczenie { get; set; }
        public static DateTime czas = new DateTime(2020, 1, 1, 12, 0, 0);

        public static void InicjalizacjaGracza()
        {
            dzien = 1;
            zycie = 100;
            energia = 100;
            pieniadze = 10;
            atak = Ekwipunek.posiadanaBron.Atak();
            obrona = Ekwipunek.posiadanaZbroja.Obrona();
            zyje = true;
            doswiadczenie = 0;
        }
        public static void UstawWartosciGracza(int _dzien, int _zycie, int _energia, int _pieniadze, int _atak, int _obrona, int _doswiadczenie)
        {
            dzien = _dzien;
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
            DateTime _czas = new DateTime(2020,1,1,czas.Hour,czas.Minute,1);
            return czas;
        }
        public static void ZmienDzien(int oIle)
        {
            dzien += oIle;
        }
        public static void ZmienDoswiadczenie(int oIle)
        {
            doswiadczenie += oIle;
        }
        public static void UstawCzas(int godzina, int minuta)
        {
            TimeSpan temp = new TimeSpan(godzina, minuta, 0);
            czas = czas.Date + temp;
        }
    }
}
