using System;

namespace the_forest_game
{
    public class Dom
    {
        public static void Jedz()
        {
            if(Ekwipunek.ekwipunek_ilosci[0] > 0)
            {
                Random los = new Random();
                Ekwipunek.ekwipunek_ilosci[0] = Ekwipunek.ekwipunek_ilosci[0] - 1;
                Gracz.ZmienZycie(10);
                Gracz.ZmienEnergie(10);
                Gracz.czas = Gracz.czas.AddMinutes(los.Next(0, 20));
            }
        }
        public static void Spij()
        {
            if (Gracz.Czas().Hour >= 19 || Gracz.Czas().Hour <= 8)
            {
                Random los = new Random();
                Gracz.ZmienEnergie(los.Next(50,80));
                Gracz.ZmienZycie(los.Next(3,7));
                Gracz.czas = Gracz.czas.AddMinutes(los.Next(36,49)*10 + los.Next(0,10));
            }
        }
    }
}
