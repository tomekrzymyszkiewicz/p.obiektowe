using System;

namespace the_forest_game
{
    public class Jezioro
    {
        public static int[] Odpoczywaj()
        {
            int[] dane = new int[3];
            if(Gracz.Energia() == 100)
            {
                dane[0] = 0; //wypoczęty - energia 100
            }
            else
            {
                dane[0] = 1;
                Random los = new Random();
                //czas odpoczynku musi być wprost proporcjonalny do uzyskanej energii
                dane[1] = los.Next(5, 20); 
                if(dane[1] + Gracz.Energia() > 100)
                {
                    dane[1] -= dane[1] + Gracz.Energia() - 100;
                }
                Gracz.ZmienEnergie(dane[1]);
                dane[2] = dane[1] * 4;
                Gracz.czas = Gracz.czas.AddMinutes(dane[2]);
            }
            return dane;
        }
        public static int[] Low()
        {
            int[] dane = new int[5];
            if(Gracz.Energia() > 0)
            {
                dane[0] = 1;
                Random los = new Random();
                dane[1] = los.Next(0, 2);
                Ekwipunek.ekwipunek_ilosci[0] += dane[1];
                dane[2] = los.Next(30, 90);
                Gracz.czas = Gracz.czas.AddMinutes(dane[2]);
                dane[3] = los.Next(1, 3);
                Gracz.ZmienDoswiadczenie(dane[3]);
                dane[4] = los.Next(5, 15);
                Gracz.ZmienEnergie(-dane[4]);
            }
            else
            {
                dane[0] = 0;
            }
            return dane;
        }
    }
}
