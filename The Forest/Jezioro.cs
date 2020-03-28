using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_forest_game
{
    public class Jezioro
    {
        public static void Odpoczywaj()
        {
            Gracz.ZmienZycie(10);
        }
        public static void Low()
        {
            Random los = new Random();
            Ekwipunek.ekwipunek_ilosci[0] += los.Next(0, 2);
        }
    }
}
