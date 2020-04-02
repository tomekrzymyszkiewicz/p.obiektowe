using System;

namespace the_forest_game
{
    class Las
    {
        public static void Poluj()
        {
            if (Gracz.Energia() > 0 && Gracz.Zycie() > 0)
            {
                Random los = new Random();
                Ekwipunek.ekwipunek_ilosci[0] += los.Next(0, (Gracz.Atak() + Gracz.Doswiadczenie()) / 5 + 2);
                Gracz.ZmienEnergie(-los.Next(0, 10));
                Gracz.ZmienZycie(-los.Next(0, 10));
                Gracz.ZmienDoswiadczenie(los.Next(2,4));
                Gracz.czas = Gracz.czas.AddMinutes(los.Next(10, 30));
            }
        }
        public static void Zbieraj()
        {
            if (Gracz.Energia() > 0)
            {
                Random los = new Random();
                Ekwipunek.ekwipunek_ilosci[1] += los.Next(0, (Gracz.Atak() + Gracz.Obrona() + Gracz.Doswiadczenie() / 2) + 2);
                Ekwipunek.ekwipunek_ilosci[2] += los.Next(0, (Gracz.Atak() + Gracz.Obrona() + Gracz.Doswiadczenie() / 2) + 2);
                Ekwipunek.ekwipunek_ilosci[3] += los.Next(0, (Gracz.Atak() + Gracz.Obrona() + Gracz.Doswiadczenie() / 5) + 2);
                Ekwipunek.ekwipunek_ilosci[4] += los.Next(0, (Gracz.Atak() + Gracz.Obrona() + Gracz.Doswiadczenie() / 3) + 2);
                Gracz.ZmienEnergie(-los.Next(0, 10));
                Gracz.czas = Gracz.czas.AddMinutes(los.Next(1, 12));
            }
        }
    }
}
