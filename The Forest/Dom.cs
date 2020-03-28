using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_forest_game
{
    public class Dom
    {
        public static void Jedz()
        {
            if(Ekwipunek.ekwipunek_ilosci[0] > 0)
            {
                Ekwipunek.ekwipunek_ilosci[0] = Ekwipunek.ekwipunek_ilosci[0] - 1;
                Gracz.ZmienZycie(10);
                Gracz.ZmienEnergie(10);
            }
        }
        public static void Spij()
        {
            if (Gracz.Czas().Hour >= 19 || Gracz.Czas().Hour <= 8)
            {
                Gracz.ZmienEnergie(20);
                Gracz.ZmienZycie(5);
            }
        }
    }
}
