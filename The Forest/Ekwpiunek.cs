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
        public static int[] ekwipunek_ilosci = new int[5] {5, 0, 0, 0, 0};
        public static int[] ekwipunek_ceny = new int[5] {10, 10, 10, 10, 10};
        public static Bron posiadanaBron = new Bron();
        public static Zbroja posiadanaZbroja = new Zbroja();

        public static Bron noz = new Bron("Nóż",10,10);
        public static Bron miecz = new Bron("Miecz",20,20);
        public static Bron katana = new Bron("Katana",30,30);
        public static Zbroja kurtka = new Zbroja("Kurtka", 10,10);
        public static Zbroja kolczuga = new Zbroja("Kolczuga", 20,20);
        public static Zbroja strojSamuraja = new Zbroja("Strój samuraja", 30,30);


        public abstract class Przedmiot
        {
            protected string nazwa;
            protected int cena;
            public string Nazwa()
            {
                return nazwa;
            }
            public int Cena()
            {
                return cena;
            }
        }
        public class Bron : Przedmiot
        {
            int mocAtaku;
            public Bron()
            {
                nazwa = "Brak";
                mocAtaku = 2;
                cena = 0;
            }
            public Bron(string _nazwa, int _mocAtaku, int _cena)
            {
                nazwa = _nazwa;
                mocAtaku = _mocAtaku;
                cena = _cena;
            }
            public int Atak()
            {
                return mocAtaku;
            }
            public void UstawWartosci(string _nazwa, int _mocAtaku, int _cena)
            {
                nazwa = _nazwa;
                mocAtaku = _mocAtaku;
                cena = _cena;
            }
        }
        public class Zbroja : Przedmiot
        {
            int mocObrony;
            public Zbroja()
            {
                nazwa = "Brak";
                mocObrony = 2;
                cena = 0;
            }
            public Zbroja(string _nazwa, int _mocObrony, int _cena)
            {
                nazwa = _nazwa;
                mocObrony = _mocObrony;
                cena = _cena;
            }
            public int Obrona()
            {
                return mocObrony;
            }
            public void UstawWartosci(string _nazwa, int _mocObrony, int _cena)
            {
                nazwa = _nazwa;
                mocObrony = _mocObrony;
                cena = _cena;
            }
        }
    }

}
