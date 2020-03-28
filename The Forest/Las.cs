using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_forest_game
{
    class Las
    {
        public static void Poluj()
        {
            if (Gracz.Energia() > 0 && Gracz.Zycie() > 0)
            {
                Random los = new Random();
                Ekwipunek.ekwipunek_ilosci[0] += los.Next(0, Ekwipunek.posiadanaBron.Atak());
                Gracz.ZmienEnergie(-los.Next(0, 10));
                Gracz.ZmienZycie(-los.Next(0, 10));
            }
        }
        public static void Zbieraj()
        {
            if (Gracz.Energia() > 0)
            {
                Random los = new Random();
                Ekwipunek.ekwipunek_ilosci[1] += los.Next(0, (Ekwipunek.posiadanaBron.Atak() + Ekwipunek.posiadanaZbroja.Obrona()) / 2);
                Ekwipunek.ekwipunek_ilosci[2] += los.Next(0, (Ekwipunek.posiadanaBron.Atak() + Ekwipunek.posiadanaZbroja.Obrona()) / 2);
                Ekwipunek.ekwipunek_ilosci[3] += los.Next(0, (Ekwipunek.posiadanaBron.Atak() + Ekwipunek.posiadanaZbroja.Obrona()) / 2);
                Ekwipunek.ekwipunek_ilosci[4] += los.Next(0, (Ekwipunek.posiadanaBron.Atak() + Ekwipunek.posiadanaZbroja.Obrona()) / 2);
                Gracz.ZmienEnergie(-los.Next(0, 10));
            }
        }
    }
}
