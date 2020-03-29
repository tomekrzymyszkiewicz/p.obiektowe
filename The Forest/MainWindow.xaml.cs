using System;
using System.Windows;
using System.Windows.Threading;

namespace the_forest_game
{
    public partial class MainWindow : Window
    {
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
            Gracz.AktualizujAtakIObrone(Ekwipunek.posiadanaBron.Atak(), Ekwipunek.posiadanaZbroja.Obrona());
            if (Gracz.CzyZyje())
            {

            }
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
            zegar.Interval = TimeSpan.FromSeconds(1);
            zegar.Tick += CyklZegara;
            zegar.Start();
        }
        private void CyklZegara(object sender, EventArgs e)
        {
            godzina.Text = String.Format("{0:t}", Gracz.Czas());
            dzien.Text = Convert.ToString(Gracz.Dzien());
            if (Gracz.Czas().Hour == 23 && Gracz.Czas().Minute == 30)
            {
                Gracz.ZmienDzien(1);
            }
            Gracz.czas = Gracz.czas.AddSeconds(10);
        }
    }
}
