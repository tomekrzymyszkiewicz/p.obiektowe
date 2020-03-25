using System;
using System.Windows;
using System.Windows.Controls;

namespace the_forest_game
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Window mainWindow = this;
            Gracz.InicjalizacjaGracza();
            ZaladujSklep();
            AktualizujWartości();
        }
        private void kup(object sender, RoutedEventArgs e)
        {
            if (Ekwipunek.ekwipunek_ceny[sklep.SelectedIndex] <= Gracz.Pieniadze())
            {
                Ekwipunek.ekwipunek_ilosci[sklep.SelectedIndex] += 1;
                Gracz.ZmienPieniadze(-Ekwipunek.ekwipunek_ceny[sklep.SelectedIndex]);
            }
            AktualizujWartości();
        }
        private void sprzedaj(object sender, RoutedEventArgs e)
        {
            if(Ekwipunek.ekwipunek_ilosci[sklep.SelectedIndex] > 0)
            {
                Ekwipunek.ekwipunek_ilosci[sklep.SelectedIndex] -= 1;
                Gracz.ZmienPieniadze(Ekwipunek.ekwipunek_ceny[sklep.SelectedIndex]);
            }
            AktualizujWartości();
        }
        private void poluj(object sender, RoutedEventArgs e)
        {
            if (Gracz.Energia() > 0)
            {
                Random los = new Random();
                Ekwipunek.ekwipunek_ilosci[0] += los.Next(0, Ekwipunek.ekwipunek_ilosci[5] + 1);
                Gracz.ZmienEnergie(-los.Next(0, 10));
                Gracz.ZmienZycie(-los.Next(0, 10));
                AktualizujWartości();
            }
        }
        private void zbieraj(object sender, RoutedEventArgs e)
        {
            if (Gracz.Energia() > 0)
            {
                Random los = new Random();
                Ekwipunek.ekwipunek_ilosci[1] += los.Next(0, (Ekwipunek.ekwipunek_ilosci[5] + Ekwipunek.ekwipunek_ilosci[6]) / 2 + 1);
                Ekwipunek.ekwipunek_ilosci[2] += los.Next(0, (Ekwipunek.ekwipunek_ilosci[5] + Ekwipunek.ekwipunek_ilosci[6]) / 2 + 1);
                Ekwipunek.ekwipunek_ilosci[3] += los.Next(0, (Ekwipunek.ekwipunek_ilosci[5] + Ekwipunek.ekwipunek_ilosci[6]) / 2 + 1);
                Ekwipunek.ekwipunek_ilosci[4] += los.Next(0, (Ekwipunek.ekwipunek_ilosci[5] + Ekwipunek.ekwipunek_ilosci[6]) / 2 + 1);
                Gracz.ZmienEnergie(-los.Next(0, 10));
                AktualizujWartości();
            }
        }
        private void odpoczywaj(object sender, RoutedEventArgs e)
        {

        }
        private void low(object sender, RoutedEventArgs e)
        {

        }
        private void jedz(object sender, RoutedEventArgs e)
        {

        }
        private void spij(object sender, RoutedEventArgs e)
        {

        }
        public void AktualizujWartości()
        {
            
            pieniadze.Text = Convert.ToString(Gracz.Pieniadze());
            jedzenie.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[0]);
            drewno.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[1]);
            kamien.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[2]);
            skora.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[3]);
            metal.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[4]);
            bron.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[5]);
            zbroja.Text = Convert.ToString(Ekwipunek.ekwipunek_ilosci[6]);
            zycie.Text = Convert.ToString(Gracz.Zycie());
            energia.Text = Convert.ToString(Gracz.Energia());
        }
        private void ZaladujSklep()
        {
            sklep.Items.Add("Jedzenie " + Ekwipunek.ekwipunek_ceny[0]);
            sklep.Items.Add("Drewno " + Ekwipunek.ekwipunek_ceny[1]);
            sklep.Items.Add("Kamień " + Ekwipunek.ekwipunek_ceny[2]);
            sklep.Items.Add("Skóra " + Ekwipunek.ekwipunek_ceny[3]);
            sklep.Items.Add("Metal " + Ekwipunek.ekwipunek_ceny[4]);
            sklep.Items.Add("Ulepsz broń " + Ekwipunek.ekwipunek_ceny[5]);
            sklep.Items.Add("Ulepsz zbroje " + Ekwipunek.ekwipunek_ceny[6]);
        }
    }
}
