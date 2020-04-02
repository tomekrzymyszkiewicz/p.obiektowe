using System;

namespace the_forest_game
{
    public class Jezioro
    {
        public static void Odpoczywaj()
        {
            Random los = new Random();
            int mocOdpczynku = los.Next(5, 20);
            Gracz.ZmienEnergie(mocOdpczynku);
            Gracz.czas = Gracz.czas.AddMinutes(mocOdpczynku*4);
        }
        public static void Low()
        {
            Random los = new Random();
            Ekwipunek.ekwipunek_ilosci[0] += los.Next(0, 2);
            Gracz.czas = Gracz.czas.AddMinutes(los.Next(30,90));
            Gracz.ZmienDoswiadczenie(los.Next(1, 3));
        }
    }
}
