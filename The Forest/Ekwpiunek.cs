namespace the_forest_game
{
    public class Ekwipunek
    {
        /// <summary>
        /// Jedzenie
        /// Drewno
        /// Kamień
        /// Skóra
        /// Metal
        /// </summary>
        public static int[] ekwipunek_ilosci = new int[5] {3, 0, 0, 0, 0};
        public static int[] ekwipunek_ceny = new int[5] {10, 3, 5, 100, 50};
        public static Bron posiadanaBron = new Bron();
        public static Zbroja posiadanaZbroja = new Zbroja();

        public static Bron noz = new Bron("Nóż",15,100);
        public static Bron miecz = new Bron("Miecz",45,500);
        public static Bron katana = new Bron("Katana",100,1000);
        public static Zbroja kurtka = new Zbroja("Kurtka", 20,100);
        public static Zbroja kolczuga = new Zbroja("Kolczuga", 60,450);
        public static Zbroja strojSamuraja = new Zbroja("Pancerz", 100,900);


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
                mocAtaku = 0;
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
            public void ResetujWartosci()
            {
                nazwa = "Brak";
                mocAtaku = 0;
                cena = 0;
            }
        }
        public class Zbroja : Przedmiot
        {
            int mocObrony;
            public Zbroja()
            {
                nazwa = "Brak";
                mocObrony = 0;
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
            public void ResetujWartosci()
            {
                nazwa = "Brak";
                mocObrony = 0;
                cena = 0;
            }
        }
    }

}
