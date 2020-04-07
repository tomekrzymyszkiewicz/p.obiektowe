using System;

namespace the_forest_game
{
    public class Obozowisko
    {

        
        public static int[] Jedz()
        {
            int[] dane = new int[4];
            // 0 - warunek // 0 - zycie 100 i energia 100 // 1 - zjadł // 2 - nie ma jedzenia 
            // 1 - ile dodno życia
            // 2 - ile dodano energii
            // 3 - ile minęło czasu
            if(Gracz.Zycie() == 100 && Gracz.Energia() == 100)
            {
                dane[0] = 0;
            }
            else if(Ekwipunek.ekwipunek_ilosci[0] > 0)
            {
                dane[0] = 1;
                Random los = new Random();
                Ekwipunek.ekwipunek_ilosci[0] = Ekwipunek.ekwipunek_ilosci[0] - 1;
                dane[1] = 10; // Ile dodać życia
                if(dane[1] + Gracz.Zycie() > 100)
                {
                    dane[1] -= dane[1] + Gracz.Zycie() - 100;
                }
                Gracz.ZmienZycie(dane[1]);
                dane[2] = 10; // Ile dodać energii
                if(dane[2] + Gracz.Energia() > 100)
                {
                    dane[2] -= dane[2] + Gracz.Energia() - 100;
                }
                Gracz.ZmienEnergie(dane[2]);
                dane[3] = los.Next(10, 20);
                Gracz.czas = Gracz.czas.AddMinutes(dane[3]);
            }
            else
            {
                dane[0] = 2;
            }
            return dane;
        }
        public static int[] Spij()
        {
            int[] dane = new int[5];
            // 0 - warunek // 0 - jest dzień, nie można spać // 1 - sen odbyty
            // 1 - energia
            // 2 - zycie
            // 3 - czas snu - godziny
            // 4 - czas snu - minuty
            if (Gracz.Czas().Hour >= 19 || Gracz.Czas().Hour <= 2)
            {
                dane[0] = 1;
                Random los = new Random();
                dane[1] = los.Next(50, 80);
                if(dane[1] + Gracz.Energia() > 100)
                {
                    dane[1] -= dane[1] + Gracz.Energia() - 100;
                }
                Gracz.ZmienEnergie(dane[1]);
                dane[2] = los.Next(3, 7);
                if(dane[2] + Gracz.Zycie() > 100)
                {
                    dane[2] -= dane[2] + Gracz.Zycie() - 100;
                }
                Gracz.ZmienZycie(dane[2]);
                dane[3] = los.Next(40, 49) * 10 + los.Next(0, 10);
                Gracz.czas = Gracz.czas.AddMinutes(dane[3]);
                dane[4] = dane[3] % 60;
                dane[3] = (dane[3]-dane[4])/60; 
            }
            else
            {
                dane[0] = 0;
            }
            return dane;
        }
        public class Dom
        {
            private string nazwa;
            private int wytrzymalosc;
            private readonly int[] koszty = new int[5]; // 0 - pieniadze // 1 - drewno // 2 - kamień // 3 - skóra // 4 - metal

            public static Dom klepisko = new Dom("Klepisko", 0, 0, 0, 0, 0, 0);
            public static Dom szalas = new Dom("Szałas", 10, 100, 50, 100, 2, 2);
            public static Dom ziemianka = new Dom("Ziemianka", 20, 1000, 1000, 500, 20, 20);
            public static Dom chatka = new Dom("Chatka", 30, 10000, 5000, 2000, 100, 200);

            public static Dom posiadany_dom = new Dom();

            public Dom()
            {
                nazwa = "Klepisko";
                wytrzymalosc = 0;
                koszty[0] = 0; //pieniadze
                koszty[1] = 0; //drewno
                koszty[2] = 0; //kamień
                koszty[3] = 0; //skóra
                koszty[4] = 0; //metal
            }
            public Dom(string _nazwa, int _wytrzymalosc, int _cena, int _drewno, int _kamien, int _skora, int _metal)
            {
                nazwa = _nazwa;
                wytrzymalosc = _wytrzymalosc;
                koszty[0] = _cena;
                koszty[1] = _drewno;
                koszty[2] = _kamien;
                koszty[3] = _skora;
                koszty[4] = _metal;
            }
            public void RestetujWartosci()
            {
                nazwa = "Klepisko";
                wytrzymalosc = 10;
                koszty[0] = 0; //pieniadze
                koszty[1] = 0; //drewno
                koszty[2] = 0; //kamień
                koszty[3] = 0; //skóra
                koszty[4] = 0; //metal
            }
            public string Nazwa()
            {
                return nazwa;
            }
            public int Wytrzymalosc()
            {
                return wytrzymalosc;
            }
            public int Cena()
            {
                return koszty[0];
            }
            public int Drewno()
            {
                return koszty[1];
            }
            public int Kamien()
            {
                return koszty[2];
            }
            public int Skora()
            {
                return koszty[3];
            }
            public int Metal()
            {
                return koszty[4];
            }
        }

    }
}
