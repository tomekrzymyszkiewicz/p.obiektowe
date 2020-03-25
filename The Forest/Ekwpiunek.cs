using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_forest_game
{
    public class Ekwipunek
    {
        /// <summary>
        /// 0jedzenie
        /// 1drewno
        /// 2kamien
        /// 3skóra
        /// 4metal
        /// 5broń
        /// 6zbroja
        /// </summary>
        //public static string[] ekwipunek_nazwy = new string[7] {"Jedzenie"};
        public static int[] ekwipunek_ilosci = new int[7] { 5, 0, 0, 0, 0, 1, 1 };
        public static int[] ekwipunek_ceny = new int[7] { 10, 10, 10, 10, 10, 10, 10 };
        

    }
    class Przedmiot
    {
        string nazwa;
    }
    class Bron : Przedmiot
    {

    }
}
