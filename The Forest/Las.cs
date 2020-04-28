using System;

namespace the_forest_game
{
    internal class Las
    {
        /// <summary>
        /// 0 - czyMożnaZapolować 0 - nie / 1 - tak
        /// 1 - jedzenie
        /// 2 - energia
        /// 3 - zycie
        /// 4 - doswiadczenie
        /// 5 - czas
        /// </summary>
        /// <returns></returns>
        public static int[] Poluj()
        {
            int[] dane = new int[6];
            if (Gracz.Energia() > 0 && Gracz.Zycie() > 0)
            {
                dane[0] = 1;
                Random los = new Random();
                dane[1] = los.Next(0, (Gracz.Atak() + Gracz.Doswiadczenie()) / 100 + 2);
                Ekwipunek.ekwipunek_ilosci[0] += dane[1];
                dane[2] = los.Next(1, 10);
                if (Gracz.Energia() - dane[2] < 0)
                {
                    dane[2] = Gracz.Energia();
                }
                Gracz.ZmienEnergie(-dane[2]);
                dane[3] = los.Next(1, 12 - (Gracz.Obrona()/10));
                Gracz.ZmienZycie(-dane[3]);
                dane[4] = los.Next(2, 4);
                Gracz.ZmienDoswiadczenie(dane[4]);
                dane[5] = los.Next(30, 60);
                Gracz.czas = Gracz.czas.AddMinutes(dane[5]);
            }
            else
            {
                dane[0] = 0;
            }
            return dane;
        }
        /// <summary>
        /// 0 - czyMaEnergię  0 - nie / 1 - tak
        /// 1 - drewno
        /// 2 - kamień
        /// 3 - skóra
        /// 4 -  metal
        /// 5 - energia
        /// 6 - czas
        /// </summary>
        /// <returns></returns>
        public static int[] Zbieraj()
        {
            int[] dane = new int[7];
            if (Gracz.Energia() > 0)
            {
                dane[0] = 1;
                Random los = new Random();
                dane[1] = los.Next(0, ((Gracz.Atak() + Gracz.Obrona() + Gracz.Doswiadczenie()) / 20) + 2);
                dane[2] = los.Next(0, ((Gracz.Atak() + Gracz.Obrona() + Gracz.Doswiadczenie()) / 10) + 2);
                dane[3] = los.Next(0, ((Gracz.Atak() + Gracz.Obrona() + Gracz.Doswiadczenie()) / 5000) + 2);
                dane[4] = los.Next(0, ((Gracz.Atak() + Gracz.Obrona() + Gracz.Doswiadczenie()) / 3000) + 2);
                Ekwipunek.ekwipunek_ilosci[1] += dane[1];
                Ekwipunek.ekwipunek_ilosci[2] += dane[2];
                Ekwipunek.ekwipunek_ilosci[3] += dane[3];
                Ekwipunek.ekwipunek_ilosci[4] += dane[4];
                dane[5] = los.Next(0, 10);
                if (Gracz.Energia() - dane[5] < 0)
                {
                    dane[5] = Gracz.Energia();
                }
                Gracz.ZmienEnergie(-dane[5]);
                dane[6] = los.Next(20, 60);
                Gracz.czas = Gracz.czas.AddMinutes(dane[6]);
            }
            else
            {
                dane[0] = 0;
            }
            return dane;
        }
    }
}
