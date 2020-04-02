using System;

namespace the_forest_game
{
    class Las
    {
        public static int[] Poluj()
        {
            // 0 - czyMożnaZapolować 0 - nie / 1 - tak
            // 1 - jedzenie
            // 2 - energia
            // 3 - zycie
            // 4 - doswiadczenie
            // 5 - czas
            int[] drop = new int[6];
            if (Gracz.Energia() > 0 && Gracz.Zycie() > 0)
            {
                drop[0] = 1;
                Random los = new Random();
                drop[1] = (Gracz.Atak() + Gracz.Doswiadczenie()) / 5 + 2;
                Ekwipunek.ekwipunek_ilosci[0] += los.Next(0, drop[1]);
                drop[2] = los.Next(1, 10);
                Gracz.ZmienEnergie(-drop[2]);
                drop[3] = los.Next(1, 10);
                Gracz.ZmienZycie(-drop[3]);
                drop[4] = los.Next(2, 4);
                Gracz.ZmienDoswiadczenie(drop[4]);
                drop[5] = los.Next(10, 30);
                Gracz.czas = Gracz.czas.AddMinutes(drop[5]);
            }
            else
            {
                drop[0] = 0;
            }
            return drop;
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
