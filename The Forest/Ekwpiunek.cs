﻿namespace the_forest_game
{
    public class Ekwipunek
    {
        /// <summary>
        /// 0 Jedzenie
        /// 1 Drewno
        /// 2 Kamień
        /// 3 Skóra
        /// 4 Metal
        /// </summary>
        public static int[] ekwipunek_ilosci = new int[5] { 3, 0, 0, 0, 0 };
        public static int[] ekwipunek_ceny = new int[5] { 10, 3, 5, 100, 50 };

        public static Bron brakBroni = new Bron();
        public static Bron noz = new Bron("Nóż", 15, 100, 20, 30, 2, 5);
        public static Bron miecz = new Bron("Miecz", 45, 500, 45, 30, 10, 25);
        public static Bron katana = new Bron("Katana", 100, 1000, 100, 50, 20, 50);
        public static Zbroja brakZbroji = new Zbroja();
        public static Zbroja kurtka = new Zbroja("Kurtka", 10, 100, 0, 0, 10, 5);
        public static Zbroja kolczuga = new Zbroja("Kolczuga", 60, 450, 20, 10, 20, 50);
        public static Zbroja pancerz = new Zbroja("Pancerz", 100, 900, 100, 100, 40, 100);

        public static Bron posiadanaBron = brakBroni;
        public static Zbroja posiadanaZbroja = brakZbroji;

        public abstract class Przedmiot
        {
            protected string nazwa;
            protected int cena, drewno, kamien, skora, metal;
            public string Nazwa()
            {
                return nazwa;
            }
            public int Cena()
            {
                return cena;
            }
            public int Drewno()
            {
                return drewno;
            }
            public int Kamien()
            {
                return kamien;
            }
            public int Skora()
            {
                return skora;
            }
            public int Metal()
            {
                return metal;
            }
        }
        public class Bron : Przedmiot
        {
            private int mocAtaku;
            public Bron()
            {
                nazwa = "Brak";
                mocAtaku = 0;
                cena = 0;
                drewno = 0;
                kamien = 0;
                skora = 0;
                metal = 0;
            }
            public Bron(string _nazwa, int _mocAtaku, int _cena, int _drewno, int _kamien, int _skora, int _metal)
            {
                nazwa = _nazwa;
                mocAtaku = _mocAtaku;
                cena = _cena;
                drewno = _drewno;
                kamien = _kamien;
                skora = _skora;
                metal = _metal;
            }
            public int Atak()
            {
                return mocAtaku;
            }
            public void ResetujWartosci()
            {
                nazwa = "Brak";
                mocAtaku = 0;
                cena = 0;
                drewno = 0;
                kamien = 0;
                skora = 0;
                metal = 0;
            }
        }
        public class Zbroja : Przedmiot
        {
            private int mocObrony;
            public Zbroja()
            {
                nazwa = "Brak";
                mocObrony = 0;
                cena = 0;
                drewno = 0;
                kamien = 0;
                skora = 0;
                metal = 0;
            }
            public Zbroja(string _nazwa, int _mocObrony, int _cena, int _drewno, int _kamien, int _skora, int _metal)
            {
                nazwa = _nazwa;
                mocObrony = _mocObrony;
                cena = _cena;
                drewno = _drewno;
                kamien = _kamien;
                skora = _skora;
                metal = _metal;
            }
            public int Obrona()
            {
                return mocObrony;
            }
            public void ResetujWartosci()
            {
                nazwa = "Brak";
                mocObrony = 0;
                cena = 0;
                drewno = 0;
                kamien = 0;
                skora = 0;
                metal = 0;
            }
        }
    }
}