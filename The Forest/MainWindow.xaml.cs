using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace the_forest_game
{
	public partial class MainWindow : Window
	{
		private readonly string nazwaPliku = "save.txt"; //nazwa pliku z zapisem stanu gry
		private int stanGry = 1; // 1 - gra trwa // 2 - gra zapauzowana // 0 - koniec gry
		private readonly DispatcherTimer zegar = new DispatcherTimer();
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
		private void Kup(object sender, RoutedEventArgs e)
		{
			int wybranyPrzedmiotWSklepie = sklep.SelectedIndex;
			if (wybranyPrzedmiotWSklepie != -1)
			{
				if (wybranyPrzedmiotWSklepie <= 10)
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
				else if (wybranyPrzedmiotWSklepie > 10)
				{
					if (Sklep.Kup(wybranyPrzedmiotWSklepie))
					{
						komunikat.Text = "Zbudowałeś " + Sklep.NazwaPrzedmiotuBiernik(wybranyPrzedmiotWSklepie) + ".";
					}
					else
					{
						komunikat.Text = "Nie możesz zbudować " + Sklep.NazwaPrzedmiotuDopelniacz(wybranyPrzedmiotWSklepie) + ". Masz za mało materiałów.";
					}
				}
			}
			else
			{
				komunikat.Text = "Wybierz przedmiot, który chcesz kupić.";
			}
			AktualizujWartości();
		}
		private void Sprzedaj(object sender, RoutedEventArgs e)
		{
			int wybranyPrzedmiotWSklepie = sklep.SelectedIndex;
			if (wybranyPrzedmiotWSklepie != -1)
			{
				if (wybranyPrzedmiotWSklepie <= 10)
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
				else if (wybranyPrzedmiotWSklepie > 10)
				{

					if (Sklep.Sprzedaj(wybranyPrzedmiotWSklepie))
					{
						komunikat.Text = "Rozebrałeś " + Sklep.NazwaPrzedmiotuBiernik(wybranyPrzedmiotWSklepie) + ".";
					}
					else
					{
						if (wybranyPrzedmiotWSklepie == 11)
						{
							komunikat.Text = "Nie możesz rozebrać klepiska. Jest ono podstawowym miejscem zamieszkania.";
						}
						else
						{
							komunikat.Text = "Nie możesz rozebrać " + Sklep.NazwaPrzedmiotuDopelniacz(wybranyPrzedmiotWSklepie) + ", ponieważ jej/go nie posiadasz.";
						}
					}
				}
			}
			else
			{
				komunikat.Text = "Wybierz przedmiot, który chcesz sprzedać.";
			}
			AktualizujWartości();

		}
		private void Poluj(object sender, RoutedEventArgs e)
		{
			int[] dane = Las.Poluj();
			if (dane[0] == 1)
			{
				komunikat.Text = "Upolowane jedzenie: " + dane[1] + ". Strata energii: " + dane[2] + ". Strata życia: " + dane[3] + ". Czas polowania " + dane[5] + " min.";
			}
			else if (dane[0] == 0)
			{
				komunikat.Text = "Nie masz wystarczającej energii, aby udać się na polowanie. Odpocznij nad jeziorem lub idź spać.";
			}
			else
			{
				komunikat.Text = "błąd - polowanie";
			}
			AktualizujWartości();
		}
		private void Zbieraj(object sender, RoutedEventArgs e)
		{
			int[] dane = Las.Zbieraj();
			if (dane[0] == 1)
			{
				komunikat.Text = "Zebrane drewno: " + dane[1] + ", kamień: " + dane[2] + ", skóra: " + dane[3] + ", metal: " + dane[4] + ". Stracona energia: " + dane[5] + ". Czas zbierania: " + dane[6] + " min.";
			}
			else if (dane[0] == 0)
			{
				komunikat.Text = "Nie masz wystarczającej energii, aby zbierać surowce. Odpocznij nad jeziorem lub idź spać.";
			}
			else
			{
				komunikat.Text = "błąd - zbieraj";
			}
			AktualizujWartości();
		}
		private void Odpoczywaj(object sender, RoutedEventArgs e)
		{
			int[] dane = Jezioro.Odpoczywaj();
			if (dane[0] == 1)
			{
				komunikat.Text = "Odpoczynek udany. Zdobyłeś " + dane[1] + " punktów energii, a zajęło Ci to " + dane[2] + " min.";
			}
			else if (dane[0] == 0)
			{
				komunikat.Text = "Jesteś pełen energii. Nie musisz odpoczywać.";
			}
			else
			{
				komunikat.Text = "błąd - odpoczynek";
			}
			AktualizujWartości();
		}
		private void Low(object sender, RoutedEventArgs e)
		{
			int[] dane = Jezioro.Low();
			if (dane[0] == 1)
			{
				if (dane[1] == 0)
				{
					komunikat.Text = "Niestey nie udało ci się złowić ryby. Stacona energia: " + dane[4] + " ,czas wędkowania: " + dane[2] + " min. Zyskane doświadczenie: " + dane[3];
				}
				else
				{
					komunikat.Text = "Brawo, wędkowanie udane. Złowione ryby: " + dane[1] + ". Stacona energia: " + dane[4] + ", czas wędkowania: " + dane[2] + " min. Zyskane doświadczenie: " + dane[3];

				}
			}
			else if (dane[0] == 0)
			{
				komunikat.Text = "Nie masz wystarczającej energii, aby łowić ryby. Odpocznij nad jeziorem lub idź spać.";
			}
			else
			{
				komunikat.Text = "błąd - lów";
			}
			AktualizujWartości();
		}
		private void Jedz(object sender, RoutedEventArgs e)
		{
			int[] dane = Obozowisko.Jedz();
			if (dane[0] == 0)
			{
				komunikat.Text = "Jesteś zdrowy i najedzony. Nie potrzebujesz jeść.";
			}
			else if (dane[0] == 1)
			{
				komunikat.Text = "Zajdłeś jedzenie. Dostałeś " + dane[1] + " punktów życia i " + dane[2] + " punktów energii. Jedzenie zajęło " + dane[3] + " min.";
			}
			else if (dane[0] == 2)
			{
				komunikat.Text = "Nie masz jedzenia. Kup je w sklepie, złów rybę lub udaj się na polowanie.";
			}
			else
			{
				komunikat.Text = "błąd jedz";
			}
			AktualizujWartości();
		}
		private void Spij(object sender, RoutedEventArgs e)
		{
			int[] dane = Obozowisko.Spij();
			if (dane[0] == 0)
			{
				komunikat.Text = "Nie możesz spać teraz. Połóż się wieczorem w godzinach 19:00 - 2:00";
			}
			else if (dane[0] == 1)
			{
				komunikat.Text = "Wyspałeś się. Spałeś " + dane[3] + " godzin i " + dane[4] + " minut. Dostałeś " + dane[1] + " punktów energii i " + dane[2] + " punktów życia.";
			}
			else
			{
				komunikat.Text = "błąd śpij";
			}
			AktualizujWartości();
		}
		private void AktualizujWartości()
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
			dzien.Text = Convert.ToString(Convert.ToInt32((Gracz.czas - Gracz.czasPoczątkowy).TotalDays + 1));
			nazwa_domu.Text = Obozowisko.Dom.posiadany_dom.Nazwa();
			wytrzymalosc_domu.Text = Convert.ToString(Obozowisko.Dom.posiadany_dom.Wytrzymalosc());
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
			przycisk_pauza.IsEnabled = false;
			komunikat.Text = "Przegrałeś! Koniec gry!";
			pole_konca_gry.Visibility = Visibility.Visible;
		}
		private void ZaladujSklep()
		{
			sklep.Items.Clear();
			System.ComponentModel.BindingList<string> listaPrzedmiotow = new System.ComponentModel.BindingList<string>
			{
				"Jedzenie " + Ekwipunek.ekwipunek_ceny[0] + " $",
				"Drewno " + Ekwipunek.ekwipunek_ceny[1] + " $",
				"Kamień " + Ekwipunek.ekwipunek_ceny[2] + " $",
				"Skóra " + Ekwipunek.ekwipunek_ceny[3] + " $",
				"Metal " + Ekwipunek.ekwipunek_ceny[4] + " $",
				Ekwipunek.noz.Nazwa() + " Atak(" + Ekwipunek.noz.Atak() + ") \n" + Ekwipunek.noz.Cena() + " $ | " + Ekwipunek.noz.Drewno() + " drewna | " + Ekwipunek.noz.Kamien() + " kamienia | " + Ekwipunek.noz.Skora() + " skóry | " + Ekwipunek.noz.Metal() + " metalu",
				Ekwipunek.miecz.Nazwa() + " Atak(" + Ekwipunek.miecz.Atak() + ") \n" + Ekwipunek.miecz.Cena() + " $ | " + Ekwipunek.miecz.Drewno() + " drewna | " + Ekwipunek.miecz.Kamien() + " kamienia | " + Ekwipunek.miecz.Skora() + " skóry | " + Ekwipunek.miecz.Metal() + " metalu",
				Ekwipunek.katana.Nazwa() + " Atak(" + Ekwipunek.katana.Atak() + ") \n" + Ekwipunek.katana.Cena() + " $ | " + Ekwipunek.katana.Drewno() + " drewna | " + Ekwipunek.katana.Kamien() + " kamienia | " + Ekwipunek.katana.Skora() + " skóry | " + Ekwipunek.katana.Metal() + " metalu",
				Ekwipunek.kurtka.Nazwa() + " Obrona(" + Ekwipunek.kurtka.Obrona() + ") \n" + Ekwipunek.kurtka.Cena() + " $ | " + Ekwipunek.kurtka.Drewno() + " drewna | " + Ekwipunek.kurtka.Kamien() + " kamienia | " + Ekwipunek.kurtka.Skora() + " skóry | " + Ekwipunek.kurtka.Metal() + " metalu",
				Ekwipunek.kolczuga.Nazwa() + " Obrona(" + Ekwipunek.kolczuga.Obrona() + ") \n" + Ekwipunek.kolczuga.Cena() + " $ | " + Ekwipunek.kolczuga.Drewno() + " drewna | " + Ekwipunek.kolczuga.Kamien() + " kamienia | " + Ekwipunek.kolczuga.Skora() + " skóry | " + Ekwipunek.kolczuga.Metal() + " metalu",
				Ekwipunek.pancerz.Nazwa() + " Obrona(" + Ekwipunek.pancerz.Obrona() + ") \n" + Ekwipunek.pancerz.Cena() + " $ | " + Ekwipunek.pancerz.Drewno() + " drewna | " + Ekwipunek.pancerz.Kamien() + " kamienia | " + Ekwipunek.pancerz.Skora() + " skóry | " + Ekwipunek.pancerz.Metal() + " metalu",
				Obozowisko.Dom.klepisko.Nazwa() + " Wytrzymałość(" + Obozowisko.Dom.klepisko.Wytrzymalosc() + ") \n" + Obozowisko.Dom.klepisko.Cena() + " $ | " + Obozowisko.Dom.klepisko.Drewno() + " drewna | " + Obozowisko.Dom.klepisko.Kamien() + " kamienia | " + Obozowisko.Dom.klepisko.Skora() + " skóry | " + Obozowisko.Dom.klepisko.Metal() + " metalu",
				Obozowisko.Dom.szalas.Nazwa() + " Wytrzymałość(" + Obozowisko.Dom.szalas.Wytrzymalosc() + ") \n" + Obozowisko.Dom.szalas.Cena() + " $ | " + Obozowisko.Dom.szalas.Drewno() + " drewna | " + Obozowisko.Dom.szalas.Kamien() + " kamienia | " + Obozowisko.Dom.szalas.Skora() + " skóry | " + Obozowisko.Dom.szalas.Metal() + " metalu",
				Obozowisko.Dom.ziemianka.Nazwa() + " Wytrzymałość(" + Obozowisko.Dom.ziemianka.Wytrzymalosc() + ") \n" + Obozowisko.Dom.ziemianka.Cena() + " $ | " + Obozowisko.Dom.ziemianka.Drewno() + " drewna | " + Obozowisko.Dom.ziemianka.Kamien() + " kamienia | " + Obozowisko.Dom.ziemianka.Skora() + " skóry | " + Obozowisko.Dom.ziemianka.Metal() + " metalu",
				Obozowisko.Dom.chatka.Nazwa() + " Wytrzymałość(" + Obozowisko.Dom.chatka.Wytrzymalosc() + ") \n" + Obozowisko.Dom.chatka.Cena() + " $ | " + Obozowisko.Dom.chatka.Drewno() + " drewna | " + Obozowisko.Dom.chatka.Kamien() + " kamienia | " + Obozowisko.Dom.chatka.Skora() + " skóry | " + Obozowisko.Dom.chatka.Metal() + " metalu"
			};

			sklep.ItemsSource = listaPrzedmiotow;
		}
		private void WysrodkujOkno()
		{
			double szerokoscEkranu = System.Windows.SystemParameters.PrimaryScreenWidth;
			double wyskokoscEkranu = System.Windows.SystemParameters.PrimaryScreenHeight;
			double szerokoscOkna = Width;
			double wysokoscOkna = Height;
			Left = (szerokoscEkranu / 2) - (szerokoscOkna / 2);
			Top = (wyskokoscEkranu / 2) - (wysokoscOkna / 2);
		}
		protected void UruchomZegar()
		{
			zegar.Interval = TimeSpan.FromMilliseconds(300);
			zegar.Tick += AktualizujZegar;
			zegar.Start();
		}
		private void AktualizujZegar(object sender, EventArgs e)
		{

			godzina.Text = String.Format("{0:t}", Gracz.Czas());
			dzien.Text = Convert.ToString(Convert.ToInt32((Gracz.czas - Gracz.czasPoczątkowy).TotalDays + 1));
			if (Gracz.CzyZyje())
			{
				Gracz.czas = Gracz.czas.AddMinutes(1);
			}
		}
		private void Zapisz(object sender, RoutedEventArgs e)
		{
			File.Delete(nazwaPliku);
			FileStream plik = new FileStream(nazwaPliku, FileMode.OpenOrCreate, FileAccess.ReadWrite);
			plik.Seek(0, SeekOrigin.End);
			StreamWriter strumienZapisu = new StreamWriter(plik);

			strumienZapisu.WriteLine("pieniadze=" + Convert.ToString(Gracz.Pieniadze()));                                                   //0 pieniadze
			strumienZapisu.WriteLine("jedzenie=" + Convert.ToString(Ekwipunek.ekwipunek_ilosci[0]));                                        //1 jedzenie
			strumienZapisu.WriteLine("drewno=" + Convert.ToString(Ekwipunek.ekwipunek_ilosci[1]));                                          //2 drewno
			strumienZapisu.WriteLine("kamien=" + Convert.ToString(Ekwipunek.ekwipunek_ilosci[2]));                                          //3	kamień
			strumienZapisu.WriteLine("skora=" + Convert.ToString(Ekwipunek.ekwipunek_ilosci[3]));                                           //4	skóra
			strumienZapisu.WriteLine("metal=" + Convert.ToString(Ekwipunek.ekwipunek_ilosci[4]));                                           //5	metal
																																			//	
			strumienZapisu.WriteLine("bronNazwa=" + Convert.ToString(Ekwipunek.posiadanaBron.Nazwa()));                                     //6	nazwa broni
			strumienZapisu.WriteLine("bronAtak=" + Convert.ToString(Ekwipunek.posiadanaBron.Atak()));                                       //7	atak broni
			strumienZapisu.WriteLine("bronCena=" + Convert.ToString(Ekwipunek.posiadanaBron.Cena()));                                       //8	cena broni
			strumienZapisu.WriteLine("bronDrewno=" + Convert.ToString(Ekwipunek.posiadanaBron.Drewno()));                                   //9 drewno broni
			strumienZapisu.WriteLine("bronKamien=" + Convert.ToString(Ekwipunek.posiadanaBron.Kamien()));                                   //10 kamien broni
			strumienZapisu.WriteLine("bronSkora=" + Convert.ToString(Ekwipunek.posiadanaBron.Skora()));                                     //11 skora broni
			strumienZapisu.WriteLine("bronMetal=" + Convert.ToString(Ekwipunek.posiadanaBron.Metal()));                                     //12 metal broni
																																			//
			strumienZapisu.WriteLine("zbrojaNazwa=" + Convert.ToString(Ekwipunek.posiadanaZbroja.Nazwa()));                                 //13 nazwa zbroji
			strumienZapisu.WriteLine("zbrojaObrona=" + Convert.ToString(Ekwipunek.posiadanaZbroja.Obrona()));                               //14 atak zbroji
			strumienZapisu.WriteLine("zbrojaCena=" + Convert.ToString(Ekwipunek.posiadanaZbroja.Cena()));                                   //15 cena zbroji
			strumienZapisu.WriteLine("zbrojaDrewno=" + Convert.ToString(Ekwipunek.posiadanaZbroja.Drewno()));                               //16 drewno zbroji
			strumienZapisu.WriteLine("zbrojaKamien=" + Convert.ToString(Ekwipunek.posiadanaZbroja.Kamien()));                               //17 kamien zbroji
			strumienZapisu.WriteLine("zbrojaSkora=" + Convert.ToString(Ekwipunek.posiadanaZbroja.Skora()));                                 //18 skora zbroji
			strumienZapisu.WriteLine("zbrojaMetal=" + Convert.ToString(Ekwipunek.posiadanaZbroja.Metal()));                                 //19 metal zbroji
																																			//
			strumienZapisu.WriteLine("domNazwa=" + Convert.ToString(Obozowisko.Dom.posiadany_dom.Nazwa()));                                 //20 nazwa domu
			strumienZapisu.WriteLine("domWytrzymalosc=" + Convert.ToString(Obozowisko.Dom.posiadany_dom.Wytrzymalosc()));                   //21 wytrzymalosc domu
			strumienZapisu.WriteLine("domCena=" + Convert.ToString(Obozowisko.Dom.posiadany_dom.Cena()));                                   //22 cena domu
			strumienZapisu.WriteLine("domDrewno=" + Convert.ToString(Obozowisko.Dom.posiadany_dom.Drewno()));                               //23 drewno domu
			strumienZapisu.WriteLine("domKamien=" + Convert.ToString(Obozowisko.Dom.posiadany_dom.Kamien()));                               //24 kamien domu
			strumienZapisu.WriteLine("domSkora=" + Convert.ToString(Obozowisko.Dom.posiadany_dom.Skora()));                                 //25 skora domu
			strumienZapisu.WriteLine("domMetal=" + Convert.ToString(Obozowisko.Dom.posiadany_dom.Metal()));                                 //26 metal domu
																																			//
			strumienZapisu.WriteLine("zycie=" + Convert.ToString(Gracz.Zycie()));                                                           //27 zycie
			strumienZapisu.WriteLine("energia=" + Convert.ToString(Gracz.Energia()));                                                       //28 energia
			strumienZapisu.WriteLine("atak=" + Convert.ToString(Gracz.Atak()));                                                             //29 atak
			strumienZapisu.WriteLine("obrona=" + Convert.ToString(Gracz.Obrona()));                                                         //30 obrona
			strumienZapisu.WriteLine("doswiadczenie=" + Convert.ToString(Gracz.Doswiadczenie()));                                           //31 doswiadczenie
			strumienZapisu.WriteLine("czas=" + Convert.ToString(Gracz.czas));                                                               //32 czas


			strumienZapisu.Close();
			plik.Close();
			komunikat.Text = "Zapisano stan gry.";
		}
		private void Wczytaj(object sender, RoutedEventArgs e)
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
					dane[i] = Regex.Replace(dane[i], "\r", string.Empty);
				}
				Gracz.UstawWartosciGracza(Convert.ToInt32(dane[27]), Convert.ToInt32(dane[28]), Convert.ToInt32(dane[0]), Convert.ToInt32(dane[29]), Convert.ToInt32(dane[30]), Convert.ToInt32(dane[31]));
				Ekwipunek.ekwipunek_ilosci[0] = Convert.ToInt32(dane[1]);
				Ekwipunek.ekwipunek_ilosci[1] = Convert.ToInt32(dane[2]);
				Ekwipunek.ekwipunek_ilosci[2] = Convert.ToInt32(dane[3]);
				Ekwipunek.ekwipunek_ilosci[3] = Convert.ToInt32(dane[4]);
				Ekwipunek.ekwipunek_ilosci[4] = Convert.ToInt32(dane[5]);

				Ekwipunek.Bron wczytanaBron = new Ekwipunek.Bron(Convert.ToString(dane[6]), Convert.ToInt32(dane[7]), Convert.ToInt32(dane[8]), Convert.ToInt32(dane[9]), Convert.ToInt32(dane[10]), Convert.ToInt32(dane[11]), Convert.ToInt32(dane[12]));
				Ekwipunek.posiadanaBron = wczytanaBron;

				Ekwipunek.Zbroja wczytanaZbroja = new Ekwipunek.Zbroja(Convert.ToString(dane[13]), Convert.ToInt32(dane[14]), Convert.ToInt32(dane[15]), Convert.ToInt32(dane[16]), Convert.ToInt32(dane[17]), Convert.ToInt32(dane[18]), Convert.ToInt32(dane[19]));
				Ekwipunek.posiadanaZbroja = wczytanaZbroja;

				Obozowisko.Dom wczytanyDom = new Obozowisko.Dom(Convert.ToString(dane[20]), Convert.ToInt32(dane[21]), Convert.ToInt32(dane[22]), Convert.ToInt32(dane[23]), Convert.ToInt32(dane[24]), Convert.ToInt32(dane[25]), Convert.ToInt32(dane[26]));
				Obozowisko.Dom.posiadany_dom = wczytanyDom;

				Gracz.czas = Convert.ToDateTime(dane[32]);

				strumienOdczytu.Close();
				plik.Close();
				AktualizujWartości();
				komunikat.Text = "Wczytano stan gry.";
			}
		}
		private void Pauza(object sender, RoutedEventArgs e)
		{
			if (stanGry == 1)
			{
				//pauzowanie gry
				przycisk_pauza_tekst.Text = "Wznów";
				stanGry = 2;
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
				komunikat.Text = "Gra zapauzowana.";
				zegar.Stop();
			}
			else if (stanGry == 2)
			{
				//odpauzuj
				przycisk_pauza_tekst.Text = "Pauza";
				stanGry = 1;
				przycisk_wczytaj.IsEnabled = true;
				przycisk_zapisz.IsEnabled = true;
				przycisk_kup.IsEnabled = true;
				przycisk_sprzedaj.IsEnabled = true;
				przycisk_poluj.IsEnabled = true;
				przycisk_zbieraj.IsEnabled = true;
				przycisk_odpoczywaj.IsEnabled = true;
				przycisk_low.IsEnabled = true;
				przycisk_jedz.IsEnabled = true;
				przycisk_spij.IsEnabled = true;
				komunikat.Text = "Gra wznowiona.";
				zegar.Start();
			}
			AktualizujWartości();
		}
		private void Reset(object sender, RoutedEventArgs e)
		{
			Ekwipunek.posiadanaBron.ResetujWartosci();
			Ekwipunek.posiadanaZbroja.ResetujWartosci();
			Gracz.InicjalizacjaGracza();
			Ekwipunek.ekwipunek_ilosci[0] = 3;
			Ekwipunek.ekwipunek_ilosci[1] = 0;
			Ekwipunek.ekwipunek_ilosci[2] = 0;
			Ekwipunek.ekwipunek_ilosci[3] = 0;
			Ekwipunek.ekwipunek_ilosci[4] = 0;
			Gracz.czas = Gracz.czasPoczątkowy;
			przycisk_wczytaj.IsEnabled = true;
			przycisk_zapisz.IsEnabled = true;
			przycisk_kup.IsEnabled = true;
			przycisk_sprzedaj.IsEnabled = true;
			przycisk_poluj.IsEnabled = true;
			przycisk_zbieraj.IsEnabled = true;
			przycisk_odpoczywaj.IsEnabled = true;
			przycisk_low.IsEnabled = true;
			przycisk_jedz.IsEnabled = true;
			przycisk_spij.IsEnabled = true;
			przycisk_pauza.IsEnabled = true;
			komunikat.Text = "Może tym razem pójdzie ci lepiej.";
			pole_konca_gry.Visibility = Visibility.Hidden;
			AktualizujWartości();
		}
		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
			pole_czy_zapisac_stan_gry.Visibility = Visibility.Visible;
		}
		private void CzyZapisac(object sender, RoutedEventArgs e)
		{
			
			Button przyciskTakNie = sender as Button;
			if(przyciskTakNie.Name == "zapis_tak")
			{
				Zapisz(sender, e);
				komunikat.Text = "Zapisano stan gry.";
			}
			pole_czy_zapisac_stan_gry.Visibility = Visibility.Hidden;
			System.Environment.Exit(1);
		}
	}
}