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
			komunikat.Text = "Witaj w grze The Forest!";
		}
		private void kup(object sender, RoutedEventArgs e)
		{
			int wybranyPrzedmiotWSklepie = sklep.SelectedIndex; 
			if (wybranyPrzedmiotWSklepie != -1)
			{
				if (Sklep.Kup(wybranyPrzedmiotWSklepie))
				{
					komunikat.Text = "Kupiłeś " + Sklep.NazwaPrzedmiotuBiernik(wybranyPrzedmiotWSklepie) + ".";
				}
				else
				{
					komunikat.Text = "Nie możesz kupić " + Sklep.NazwaPrzedmiotuDopelniacz(wybranyPrzedmiotWSklepie) + ". Masz za mało pieniędzy.";
				}
			}
			else
			{
				komunikat.Text = "Wybierz przedmiot, który chcesz kupić.";
			}
			AktualizujWartości();
		}
		private void sprzedaj(object sender, RoutedEventArgs e)
		{
			int wybranyPrzedmiotWSklepie = sklep.SelectedIndex;
			if(wybranyPrzedmiotWSklepie != -1)
			{
				if (Sklep.Sprzedaj(wybranyPrzedmiotWSklepie))
				{
					komunikat.Text = "Sprzedałeś " + Sklep.NazwaPrzedmiotuBiernik(wybranyPrzedmiotWSklepie) + ".";
				}
				else
				{
					komunikat.Text = "Nie sprzedałeś " + Sklep.NazwaPrzedmiotuDopelniacz(wybranyPrzedmiotWSklepie) + ". Nie masz takiego przedmiotu w ekwipunku.";
				}
			}
			else
			{
				komunikat.Text = "Wybierz przedmiot, który chcesz sprzedać.";
			}
			AktualizujWartości();
		}
		private void poluj(object sender, RoutedEventArgs e)
		{
			int[] dane = Las.Poluj();
			if(dane[0] == 1)
			{
				komunikat.Text = "Upolowane jedzenie: " + dane[1] + ". Strata energii: " + dane[2] + ". Strata życia: " + dane[3] + ". Czas polowania " + dane[5] + " min.";
			}
			else if(dane[0] == 0)
			{
				komunikat.Text = "Nie masz wystarczającej energii, aby udać się na polowanie. Odpocznij nad jeziorem lub idź spać.";
			}
			else
			{
				komunikat.Text = "błąd - polowanie";
			}
			AktualizujWartości();
		}
		private void zbieraj(object sender, RoutedEventArgs e)
		{
			int[] dane = Las.Zbieraj();
			if(dane[0] == 1)
			{
				komunikat.Text = "Zebrane drewno: " + dane[1] + ", kamień: " + dane[2] + ", skóra: " + dane[3] + ", metal: " + dane[4] + ". Stracona energia: " + dane[5] + ". Czas zbierania: " + dane[6] + " min."; 
			}
			else if(dane[0] == 0)
			{
				komunikat.Text = "Nie masz wystarczającej energii, aby zbierać surowce. Odpocznij nad jeziorem lub idź spać.";
			}
			else
			{
				komunikat.Text = "błąd - zbieraj";
			}
			AktualizujWartości();
		}
		private void odpoczywaj(object sender, RoutedEventArgs e)
		{
			int[] dane = Jezioro.Odpoczywaj();
			if(dane[0] == 1)
			{
				komunikat.Text = "Odpoczynek udany. Zdobyłeś " + dane[1] + " punktów energii, a zajęło Ci to " + dane[2] + " min.";
			}
			else if(dane[0] == 0)
			{
				komunikat.Text = "Jesteś pełen energii. Nie musisz odpoczywać.";
			}
			else
			{
				komunikat.Text = "błąd - odpoczynek";
			}
			AktualizujWartości();
		}
		private void low(object sender, RoutedEventArgs e)
		{
			int[] dane =  Jezioro.Low();
			if(dane[0] == 1)
			{
				if(dane[1] == 0)
				{
					komunikat.Text = "Niestey nie udało ci się złowić ryby. Stacona energia: " + dane[4] + " ,czas wędkowania: " + dane[2] + " min. Zyskane doświadczenie: " + dane[3];
				}
				else
				{
					komunikat.Text = "Brawo, wędkowanie udane. Złowione ryby: " + dane[1] + ". Stacona energia: " + dane[4] + " ,czas wędkowania: " + dane[2] + " min. Zyskane doświadczenie: " + dane[3];

				}
			}
			else if(dane[0] == 0)
			{
				komunikat.Text = "Nie masz wystarczającej energii, aby łowić ryby. Odpocznij nad jeziorem lub idź spać.";
			}
			else
			{
				komunikat.Text = "błąd - lów";
			}
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
			if (!Gracz.CzyZyje()) 
			{
				KoniecGry();
			}
		}
		private void KoniecGry()
		{
			przycisk_wczytaj.IsEnabled = false;
			przycisk_zapisz.IsEnabled = false;
			przycisk_kup.IsEnabled = false;
			przycisk_sprzedaj.IsEnabled = false;
			przycisk_poluj.IsEnabled = false;
			przycisk_zbieraj.IsEnabled = false;
			przycisk_odpoczywaj.IsEnabled = false;
			przycisk_low.IsEnabled = false;
			przycisk_jedz.IsEnabled = false;
			przycisk_spij.IsEnabled = false;
			komunikat.Text = "Przegrałeś! Koniec gry!";
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
			if(Gracz.CzyZyje())
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
			komunikat.Text = "Zapisano stan gry." ;
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
				komunikat.Text = "Wczytano stan gry.";
			}
		}
	}
}
