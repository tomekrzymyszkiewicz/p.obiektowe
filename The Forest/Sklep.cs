namespace the_forest_game
{
    public class Sklep
    {
        /// <summary>
        /// true - zakup udany
        /// false - nie udało się kupić przedmiotu
        /// </summary>
        /// <param name="wybranyPrzedmiotWSklepie"></param>
        /// <returns></returns>
        public static bool Kup(int wybranyPrzedmiotWSklepie)
        {
            switch (wybranyPrzedmiotWSklepie)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    if (Ekwipunek.ekwipunek_ceny[wybranyPrzedmiotWSklepie] <= Gracz.Pieniadze())
                    {
                        Ekwipunek.ekwipunek_ilosci[wybranyPrzedmiotWSklepie] += 1;
                        Gracz.ZmienPieniadze(-Ekwipunek.ekwipunek_ceny[wybranyPrzedmiotWSklepie]);
                        return true;
                    }
                    return false;
                case 5:
                    if(Ekwipunek.noz.Cena() <= Gracz.Pieniadze())
                    {
                        if(Ekwipunek.posiadanaBron.Nazwa() != "Brak")
                        {
                            Gracz.ZmienPieniadze(Ekwipunek.posiadanaBron.Cena());
                            Ekwipunek.posiadanaBron.ResetujWartosci();
                        }
                        Ekwipunek.posiadanaBron.UstawWartosci(Ekwipunek.noz.Nazwa(),Ekwipunek.noz.Atak(),Ekwipunek.noz.Cena());
                        Gracz.ZmienPieniadze(-Ekwipunek.noz.Cena());
                        return true;
                    }
                    return false;
                case 6:
                    if (Ekwipunek.miecz.Cena() <= Gracz.Pieniadze())
                    {
                        if (Ekwipunek.posiadanaBron.Nazwa() != "Brak")
                        {
                            Gracz.ZmienPieniadze(Ekwipunek.posiadanaBron.Cena());
                            Ekwipunek.posiadanaBron.ResetujWartosci();
                        }
                        Ekwipunek.posiadanaBron.UstawWartosci(Ekwipunek.miecz.Nazwa(), Ekwipunek.miecz.Atak(), Ekwipunek.miecz.Cena());
                        Gracz.ZmienPieniadze(-Ekwipunek.miecz.Cena());
                        return true;
                    }
                    return false;
                case 7:
                    if (Ekwipunek.katana.Cena() <= Gracz.Pieniadze())
                    {
                        if (Ekwipunek.posiadanaBron.Nazwa() != "Brak")
                        {
                            Gracz.ZmienPieniadze(Ekwipunek.posiadanaBron.Cena());
                            Ekwipunek.posiadanaBron.ResetujWartosci();
                        }
                        Ekwipunek.posiadanaBron.UstawWartosci(Ekwipunek.katana.Nazwa(), Ekwipunek.katana.Atak(), Ekwipunek.katana.Cena());
                        Gracz.ZmienPieniadze(-Ekwipunek.katana.Cena());
                        return true;
                    }
                    return false;
                case 8:
                    if (Ekwipunek.kurtka.Cena() <= Gracz.Pieniadze())
                    {
                        if (Ekwipunek.posiadanaZbroja.Nazwa() != "Brak")
                        {
                            Gracz.ZmienPieniadze(Ekwipunek.posiadanaZbroja.Cena());
                            Ekwipunek.posiadanaZbroja.ResetujWartosci();
                        }
                        Ekwipunek.posiadanaZbroja.UstawWartosci(Ekwipunek.kurtka.Nazwa(), Ekwipunek.kurtka.Obrona(), Ekwipunek.kurtka.Cena());
                        Gracz.ZmienPieniadze(-Ekwipunek.kurtka.Cena());
                        return true;
                    }
                    return false;
                case 9:
                    if (Ekwipunek.kolczuga.Cena() <= Gracz.Pieniadze())
                    {
                        if (Ekwipunek.posiadanaZbroja.Nazwa() != "Brak")
                        {
                            Gracz.ZmienPieniadze(Ekwipunek.posiadanaZbroja.Cena());
                            Ekwipunek.posiadanaZbroja.ResetujWartosci();
                        }
                        Ekwipunek.posiadanaZbroja.UstawWartosci(Ekwipunek.kolczuga.Nazwa(), Ekwipunek.kolczuga.Obrona(), Ekwipunek.kolczuga.Cena());
                        Gracz.ZmienPieniadze(-Ekwipunek.kolczuga.Cena());
                        return true;
                    }
                    return false;
                case 10:
                    if (Ekwipunek.strojSamuraja.Cena() <= Gracz.Pieniadze())
                    {
                        if (Ekwipunek.posiadanaZbroja.Nazwa() != "Brak")
                        {
                            Gracz.ZmienPieniadze(Ekwipunek.posiadanaZbroja.Cena());
                            Ekwipunek.posiadanaZbroja.ResetujWartosci();
                        }
                        Ekwipunek.posiadanaZbroja.UstawWartosci(Ekwipunek.strojSamuraja.Nazwa(), Ekwipunek.strojSamuraja.Obrona(), Ekwipunek.strojSamuraja.Cena());
                        Gracz.ZmienPieniadze(-Ekwipunek.strojSamuraja.Cena());
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }
        public static void Sprzedaj(int wybranyPrzedmiotWSklepie)
        {
            switch (wybranyPrzedmiotWSklepie)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    if (Ekwipunek.ekwipunek_ilosci[wybranyPrzedmiotWSklepie] > 0)
                    {
                        Ekwipunek.ekwipunek_ilosci[wybranyPrzedmiotWSklepie] -= 1;
                        Gracz.ZmienPieniadze(Ekwipunek.ekwipunek_ceny[wybranyPrzedmiotWSklepie]);
                    }
                    break;
                case 5:
                case 6:
                case 7:
                    if(Ekwipunek.posiadanaBron.Cena() > 0)
                    {
                        Gracz.ZmienPieniadze(Ekwipunek.posiadanaBron.Cena());
                        Ekwipunek.posiadanaBron.ResetujWartosci();
                    }
                    break;
                case 8:
                case 9:
                case 10:
                    if (Ekwipunek.posiadanaZbroja.Cena() > 0)
                    {
                        Gracz.ZmienPieniadze(Ekwipunek.posiadanaZbroja.Cena());
                        Ekwipunek.posiadanaZbroja.ResetujWartosci();
                    }
                    break;
                default:
                    break;
            }
        }
        public static string NazwaPrzedmiotuDopelniacz(int wybranyPrzedmiotWSklepie)
        {
            return "błąd";
        }
    }
}
