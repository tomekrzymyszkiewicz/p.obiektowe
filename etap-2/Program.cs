﻿using System;

namespace katalog_samochodowy_cs
{
    class Program
    {
        static void Main(string[] args)
        {
            //MENU UŻYTKOWNIKA
            bool on = true;
            while (on)
            {
                Console.Clear();
                Console.WriteLine("KATALOG SAMOCHODOWY\nWYBIERZ OPERACJĘ:");
                Console.WriteLine("1. Wczytaj dane z pliku do rejestru");
                Console.WriteLine("2. Zapisz rejestr do pliku");
                Console.WriteLine("3. Dodaj nowy samochód do rejestru");
                Console.WriteLine("4. Wypisz zawartość rejestru");
                Console.WriteLine("5. Usuń samochód");
                Console.WriteLine("6. Sortuj rejestr");
                Console.WriteLine("7. Wypisz rejestr według warunku");
                Console.WriteLine( "8. Wypisz konkretny samochód");
                Console.WriteLine("ESC. Wyjście");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Rejestr.WczytajZawartoscKataloguZPliku();
                        break;
                    case ConsoleKey.D2:
                        Rejestr.ZapiszZawartoscKataloguDoPliku();
                        break;
                    case ConsoleKey.D3:
                        Rejestr.DodajSamochodDoRejestru();
                        break;
                    case ConsoleKey.D4:
                        Rejestr.WypiszRejestr();
                        Console.WriteLine("Naciśnij klawisz, aby kontynuować");
                        Console.ReadLine();
                        break;
                    case ConsoleKey.D5:
                        Rejestr.UsunSamochodZRejestru();
                        break;
                    case ConsoleKey.D6:
                        Rejestr.SortowanieRejestru();
                        break;
                    case ConsoleKey.D7:
                        Rejestr.WarunkoweWypisanieRejestru();
                        break;
                    case ConsoleKey.D8:
                        Rejestr.WypiszKonkretnySamochód();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }


}
