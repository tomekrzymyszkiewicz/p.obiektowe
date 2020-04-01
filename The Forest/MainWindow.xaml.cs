using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Threading;

namespace the_forest_game
{
    public partial class MainWindow : Window
    {
        private string nazwaPliku = "save.txt";
        public MainWindow()
        {
            InitializeComponent();
            WysrodkujOkno();
            UruchomZegar();
            Gracz.InicjalizacjaGracza();
            ZaladujSklep();
            AktualizujWartości();
        }
        private void kup(object sender, RoutedEventArgs e)
        {
            int wybranyPrzedmiotWSklepie = sklep.SelectedIndex;
            Sklep.Kup(wybranyPrzedmiotWSklepie);
            AktualizujWartości();
        }
        private void sprzedaj(object sender, RoutedEventArgs e)
        {
            int wybranyPrzedmiotWSklepie = sklep.SelectedIndex;
            Sklep.Sprzedaj(wybranyPrzedmiotWSklepie);
            AktualizujWartości();
        }
        private void poluj(object sender, RoutedEventArgs e)
        {
            Las.Poluj();
            AktualizujWartości();
        }
        private void zbieraj(object sender, RoutedEventArgs e)
        {
            Las.Zbieraj();
            AktualizujWartości();
        }
        private void odpoczywaj(object sender, RoutedEventArgs e)
        {
            Jezioro.Odpoczywaj();
            AktualizujWartości();
        }
        private void low(object sender, RoutedEventArgs e)
        {
            Jezioro.Odpoczywaj();
            AktualizujWartości();
        }
        private void jedz(object sender, RoutedEventArgs e)
        {
            Dom.Jedz();
            AktualizujWartości();
        }
        private void spij(object sender, RoutedEventArgs e)
        {
            Dom.Spij();
            AktualizujWartości();
        }
        public void AktualizujWartości()
        {
            Gracz.AktualizujAtakIObrone(Ekwipunek.posiadanaBron.Atak(), Ekwipunek.posiadanaZbroja.Obrona());
            pieniadze.Text = Convert.ToString(Gracz.Pieniadze());
            jedzenie.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[0]);
            drewno.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[1]);
            kamien.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[2]);
            skora.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[3]);
            metal.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[4]);
            bron.Text = Convert.ToString(Ekwipunek.posiadanaBron.Nazwa());
            zbroja.Text = Convert.ToString(Ekwipunek.posiadanaZbroja.Nazwa());
            zycie.Text = Convert.ToString(Gracz.Zycie());
            energia.Text = Convert.ToString(Gracz.Energia());
            atak.Text = Convert.ToString(Gracz.Atak());
            obrona.Text = Convert.ToString(Gracz.Obrona());
            doswiadczenie.Text = Convert.ToString(Gracz.Doswiadczenie());
            godzina.Text = String.Format("{0:t}", Gracz.Czas());
            dzien.Text = Convert.ToString(Gracz.Dzien());
            if (Gracz.CzyZyje()) { }
        }
        private void ZaladujSklep()
        {
            sklep.Items.Clear();
            sklep.Items.Add("Jedzenie " + Ekwipunek.ekwipunek_ceny[0] + " $");
            sklep.Items.Add("Drewno " + Ekwipunek.ekwipunek_ceny[1] + " $");
            sklep.Items.Add("Kamień " + Ekwipunek.ekwipunek_ceny[2] + " $");
            sklep.Items.Add("Skóra " + Ekwipunek.ekwipunek_ceny[3] + " $");
            sklep.Items.Add("Metal " + Ekwipunek.ekwipunek_ceny[4] + " $");
            sklep.Items.Add(Ekwipunek.noz.Nazwa() + " Atak(" + Ekwipunek.noz.Atak() + ") " + Ekwipunek.noz.Cena() + " $");
            sklep.Items.Add(Ekwipunek.miecz.Nazwa() + " Atak(" + Ekwipunek.miecz.Atak() + ") " + Ekwipunek.miecz.Cena() + " $");
            sklep.Items.Add(Ekwipunek.katana.Nazwa() + " Atak(" + Ekwipunek.katana.Atak() + ") " + Ekwipunek.katana.Cena() + " $");
            sklep.Items.Add(Ekwipunek.kurtka.Nazwa() + " Obrona(" + Ekwipunek.kurtka.Obrona() + ") " + Ekwipunek.kurtka.Cena() + " $");
            sklep.Items.Add(Ekwipunek.kolczuga.Nazwa() + " Obrona(" + Ekwipunek.kolczuga.Obrona() + ") " + Ekwipunek.kolczuga.Cena() + " $");
            sklep.Items.Add(Ekwipunek.strojSamuraja.Nazwa() + " Obrona(" + Ekwipunek.strojSamuraja.Obrona() + ") " + Ekwipunek.strojSamuraja.Cena() + " $");
        }
        private void WysrodkujOkno()
        {
            double szerokoscEkranu = System.Windows.SystemParameters.PrimaryScreenWidth;
            double wyskokoscEkranu = System.Windows.SystemParameters.PrimaryScreenHeight;
            double szerokoscOkna = this.Width;
            double wysokoscOkna = this.Height;
            this.Left = (szerokoscEkranu / 2) - (szerokoscOkna / 2);
            this.Top = (wyskokoscEkranu / 2) - (wysokoscOkna / 2);
        }
        private void UruchomZegar()
        {
            DispatcherTimer zegar = new DispatcherTimer();
            zegar.Interval = TimeSpan.FromMilliseconds(100);
            zegar.Tick += AktualizujZegar;
            zegar.Start();
        }
        public void AktualizujZegar(object sender, EventArgs e)
        {
            godzina.Text = String.Format("{0:t}", Gracz.Czas());
            dzien.Text = Convert.ToString(Gracz.Dzien());
            if (Gracz.Czas().Hour == 23 && Gracz.Czas().Minute == 30)
            {
                Gracz.ZmienDzien(1);
            }
            Gracz.czas = Gracz.czas.AddMinutes(1);
        }
        private void zapisz(object sender, RoutedEventArgs e)
        {
            FileStream plik = new FileStream(nazwaPliku, FileMode.Truncate, FileAccess.Write);
            plik.Seek(0, SeekOrigin.End);
            StreamWriter strumienZapisu = new StreamWriter(plik);

            strumienZapisu.WriteLine("pieniadze=" + Convert.ToString(Gracz.Pieniadze()));                     //1
            strumienZapisu.WriteLine("jedzenie=" + Convert.ToString(Ekwipunek.ekwipunek_ilosci[0]));          //2
            strumienZapisu.WriteLine("drewno=" + Convert.ToString(Ekwipunek.ekwipunek_ilosci[1]));            //3
            strumienZapisu.WriteLine("kamien=" + Convert.ToString(Ekwipunek.ekwipunek_ilosci[2]));            //4
            strumienZapisu.WriteLine("skora=" + Convert.ToString(Ekwipunek.ekwipunek_ilosci[3]));             //5
            strumienZapisu.WriteLine("metal=" + Convert.ToString(Ekwipunek.ekwipunek_ilosci[4]));             //6
            strumienZapisu.WriteLine("bronNazwa=" + Convert.ToString(Ekwipunek.posiadanaBron.Nazwa()));       //7
            strumienZapisu.WriteLine("bronAtak=" + Convert.ToString(Ekwipunek.posiadanaBron.Atak()));         //8
            strumienZapisu.WriteLine("bronCena=" + Convert.ToString(Ekwipunek.posiadanaBron.Cena()));         //9
            strumienZapisu.WriteLine("zbrojaNazwa=" + Convert.ToString(Ekwipunek.posiadanaZbroja.Nazwa()));   //10
            strumienZapisu.WriteLine("zbrojaObrona=" + Convert.ToString(Ekwipunek.posiadanaZbroja.Obrona())); //11
            strumienZapisu.WriteLine("zbrojaCena=" + Convert.ToString(Ekwipunek.posiadanaZbroja.Cena()));     //12
            strumienZapisu.WriteLine("zycie=" + Convert.ToString(Gracz.Zycie()));                             //13
            strumienZapisu.WriteLine("energia=" + Convert.ToString(Gracz.Energia()));                         //14
            strumienZapisu.WriteLine("atak=" + Convert.ToString(Gracz.Atak()));                               //15
            strumienZapisu.WriteLine("obrona=" + Convert.ToString(Gracz.Obrona()));                           //16
            strumienZapisu.WriteLine("doswiadczenie=" + Convert.ToString(Gracz.Doswiadczenie()));             //17
            strumienZapisu.WriteLine("dzien=" + Convert.ToString(Gracz.Dzien()));                             //18
            strumienZapisu.WriteLine("godzina=" + Convert.ToString(Gracz.Czas().Hour));                       //19
            strumienZapisu.WriteLine("minuta=" + Convert.ToString(Gracz.Czas().Minute));                      //20

            strumienZapisu.Close();
            plik.Close();
            MessageBox.Show("Zapisano");
        }
        private void wczytaj(object sender, RoutedEventArgs e)
        {
            if (File.Exists(nazwaPliku))
            {
                FileStream plik = new FileStream(nazwaPliku, FileMode.Open, FileAccess.Read);
                StreamReader strumienOdczytu = new StreamReader(nazwaPliku);
                string[] linijki = strumienOdczytu.ReadToEnd().ToString().Split('\n');
                string[] dane = new string[linijki.Length];
                for (int i = 0; i < linijki.Length - 1; i++)
                {
                    int znak = linijki[i].IndexOf('=');
                    dane[i] = linijki[i].Substring(znak + 1);
                    dane[i] = Regex.Replace(dane[i],"\r",string.Empty);
                }
                Gracz.UstawWartosciGracza(Convert.ToInt32(dane[17]), Convert.ToInt32(dane[12]), Convert.ToInt32(dane[13]), Convert.ToInt32(dane[0]), Convert.ToInt32(dane[14]), Convert.ToInt32(dane[15]), Convert.ToInt32(dane[16]));
                Ekwipunek.ekwipunek_ilosci[0] = Convert.ToInt32(dane[1]);
                Ekwipunek.ekwipunek_ilosci[1] = Convert.ToInt32(dane[2]);
                Ekwipunek.ekwipunek_ilosci[2] = Convert.ToInt32(dane[3]);
                Ekwipunek.ekwipunek_ilosci[3] = Convert.ToInt32(dane[4]);
                Ekwipunek.ekwipunek_ilosci[4] = Convert.ToInt32(dane[5]);
                Ekwipunek.posiadanaBron.UstawWartosci(dane[6],Convert.ToInt32(dane[7]),Convert.ToInt32(dane[8]));
                Ekwipunek.posiadanaZbroja.UstawWartosci(dane[9],Convert.ToInt32(dane[10]),Convert.ToInt32(dane[11]));
                Gracz.UstawCzas(Convert.ToInt32(dane[18]),Convert.ToInt32(dane[19]));

                strumienOdczytu.Close();
                plik.Close();
                AktualizujWartości();
                MessageBox.Show("Wczytano");
            }
        }
    }
}
