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
                case 11: //klepisko
                    if(Obozowisko.Dom.klepisko.Cena() <= Gracz.Pieniadze() && Obozowisko.Dom.klepisko.Drewno() <= Ekwipunek.ekwipunek_ilosci[1] && Obozowisko.Dom.klepisko.Kamien() <= Ekwipunek.ekwipunek_ilosci[2] && Obozowisko.Dom.klepisko.Skora() <= Ekwipunek.ekwipunek_ilosci[3] && Obozowisko.Dom.klepisko.Metal() <= Ekwipunek.ekwipunek_ilosci[4])
                    {
                        if (Obozowisko.Dom.posiadany_dom.Nazwa() != "Klepisko")
                        {
                            Gracz.ZmienPieniadze(Obozowisko.Dom.posiadany_dom.Cena());
                            Ekwipunek.ekwipunek_ilosci[1] += Obozowisko.Dom.posiadany_dom.Drewno();
                            Ekwipunek.ekwipunek_ilosci[2] += Obozowisko.Dom.posiadany_dom.Kamien();
                            Ekwipunek.ekwipunek_ilosci[3] += Obozowisko.Dom.posiadany_dom.Skora();
                            Ekwipunek.ekwipunek_ilosci[4] += Obozowisko.Dom.posiadany_dom.Metal();
                            Obozowisko.Dom.posiadany_dom = Obozowisko.Dom.klepisko;
                        }
                        return true;
                    }
                    return false;
                case 12: //szalas
                    if (Obozowisko.Dom.szalas.Cena() <= Gracz.Pieniadze() && Obozowisko.Dom.szalas.Drewno() <= Ekwipunek.ekwipunek_ilosci[1] && Obozowisko.Dom.szalas.Kamien() <= Ekwipunek.ekwipunek_ilosci[2] && Obozowisko.Dom.szalas.Skora() <= Ekwipunek.ekwipunek_ilosci[3] && Obozowisko.Dom.szalas.Metal() <= Ekwipunek.ekwipunek_ilosci[4])
                    {
                        if(Obozowisko.Dom.posiadany_dom.Nazwa() != "Klepisko")
                        {
                            Gracz.ZmienPieniadze(Obozowisko.Dom.posiadany_dom.Cena());
                            Ekwipunek.ekwipunek_ilosci[1] += Obozowisko.Dom.posiadany_dom.Drewno();
                            Ekwipunek.ekwipunek_ilosci[2] += Obozowisko.Dom.posiadany_dom.Kamien();
                            Ekwipunek.ekwipunek_ilosci[3] += Obozowisko.Dom.posiadany_dom.Skora();
                            Ekwipunek.ekwipunek_ilosci[4] += Obozowisko.Dom.posiadany_dom.Metal();
                            Obozowisko.Dom.posiadany_dom = Obozowisko.Dom.klepisko;
                        }
                        Obozowisko.Dom.posiadany_dom = Obozowisko.Dom.szalas;
                        Gracz.ZmienPieniadze(-Obozowisko.Dom.szalas.Cena());
                        Ekwipunek.ekwipunek_ilosci[1] -= Obozowisko.Dom.szalas.Drewno();
                        Ekwipunek.ekwipunek_ilosci[2] -= Obozowisko.Dom.szalas.Kamien();
                        Ekwipunek.ekwipunek_ilosci[3] -= Obozowisko.Dom.szalas.Skora();
                        Ekwipunek.ekwipunek_ilosci[4] -= Obozowisko.Dom.szalas.Metal();
                        return true;
                    }
                    return false;
                case 13: //ziemianka
                    if (Obozowisko.Dom.ziemianka.Cena() <= Gracz.Pieniadze() && Obozowisko.Dom.ziemianka.Drewno() <= Ekwipunek.ekwipunek_ilosci[1] && Obozowisko.Dom.ziemianka.Kamien() <= Ekwipunek.ekwipunek_ilosci[2] && Obozowisko.Dom.ziemianka.Skora() <= Ekwipunek.ekwipunek_ilosci[3] && Obozowisko.Dom.ziemianka.Metal() <= Ekwipunek.ekwipunek_ilosci[4])
                    {
                        if (Obozowisko.Dom.posiadany_dom.Nazwa() != "Klepisko")
                        {
                            Gracz.ZmienPieniadze(Obozowisko.Dom.posiadany_dom.Cena());
                            Ekwipunek.ekwipunek_ilosci[1] += Obozowisko.Dom.posiadany_dom.Drewno();
                            Ekwipunek.ekwipunek_ilosci[2] += Obozowisko.Dom.posiadany_dom.Kamien();
                            Ekwipunek.ekwipunek_ilosci[3] += Obozowisko.Dom.posiadany_dom.Skora();
                            Ekwipunek.ekwipunek_ilosci[4] += Obozowisko.Dom.posiadany_dom.Metal();
                            Obozowisko.Dom.posiadany_dom = Obozowisko.Dom.klepisko;
                        }
                        Obozowisko.Dom.posiadany_dom = Obozowisko.Dom.ziemianka;
                        Gracz.ZmienPieniadze(-Obozowisko.Dom.ziemianka.Cena());
                        Ekwipunek.ekwipunek_ilosci[1] -= Obozowisko.Dom.ziemianka.Drewno();
                        Ekwipunek.ekwipunek_ilosci[2] -= Obozowisko.Dom.ziemianka.Kamien();
                        Ekwipunek.ekwipunek_ilosci[3] -= Obozowisko.Dom.ziemianka.Skora();
                        Ekwipunek.ekwipunek_ilosci[4] -= Obozowisko.Dom.ziemianka.Metal();
                        return true;
                    }
                    return false;
                case 14: //chatka
                    if (Obozowisko.Dom.chatka.Cena() <= Gracz.Pieniadze() && Obozowisko.Dom.chatka.Drewno() <= Ekwipunek.ekwipunek_ilosci[1] && Obozowisko.Dom.chatka.Kamien() <= Ekwipunek.ekwipunek_ilosci[2] && Obozowisko.Dom.chatka.Skora() <= Ekwipunek.ekwipunek_ilosci[3] && Obozowisko.Dom.chatka.Metal() <= Ekwipunek.ekwipunek_ilosci[4])
                    {
                        if (Obozowisko.Dom.posiadany_dom.Nazwa() != "Klepisko")
                        {
                            Gracz.ZmienPieniadze(Obozowisko.Dom.posiadany_dom.Cena());
                            Ekwipunek.ekwipunek_ilosci[1] += Obozowisko.Dom.posiadany_dom.Drewno();
                            Ekwipunek.ekwipunek_ilosci[2] += Obozowisko.Dom.posiadany_dom.Kamien();
                            Ekwipunek.ekwipunek_ilosci[3] += Obozowisko.Dom.posiadany_dom.Skora();
                            Ekwipunek.ekwipunek_ilosci[4] += Obozowisko.Dom.posiadany_dom.Metal();
                            Obozowisko.Dom.posiadany_dom = Obozowisko.Dom.klepisko;
                        }
                        Obozowisko.Dom.posiadany_dom = Obozowisko.Dom.chatka;
                        Gracz.ZmienPieniadze(-Obozowisko.Dom.chatka.Cena());
                        Ekwipunek.ekwipunek_ilosci[1] -= Obozowisko.Dom.chatka.Drewno();
                        Ekwipunek.ekwipunek_ilosci[2] -= Obozowisko.Dom.chatka.Kamien();
                        Ekwipunek.ekwipunek_ilosci[3] -= Obozowisko.Dom.chatka.Skora();
                        Ekwipunek.ekwipunek_ilosci[4] -= Obozowisko.Dom.chatka.Metal();
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }
        public static bool Sprzedaj(int wybranyPrzedmiotWSklepie)
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
                        return true;
                    }
                    return false;
                case 5:
                case 6:
                case 7:
                    if(Ekwipunek.posiadanaBron.Cena() > 0)
                    {
                        Gracz.ZmienPieniadze(Ekwipunek.posiadanaBron.Cena());
                        Ekwipunek.posiadanaBron.ResetujWartosci();
                        return true;
                    }
                    return false;
                case 8:
                case 9:
                case 10:
                    if (Ekwipunek.posiadanaZbroja.Cena() > 0)
                    {
                        Gracz.ZmienPieniadze(Ekwipunek.posiadanaZbroja.Cena());
                        Ekwipunek.posiadanaZbroja.ResetujWartosci();
                        return true;
                    }
                    return false;
                case 11:
                case 12:
                case 13:
                case 14:
                    if(Obozowisko.Dom.posiadany_dom.Cena() > 0)
                    {
                        Gracz.ZmienPieniadze(Obozowisko.Dom.posiadany_dom.Cena());
                        Ekwipunek.ekwipunek_ilosci[1] += Obozowisko.Dom.posiadany_dom.Drewno();
                        Ekwipunek.ekwipunek_ilosci[2] += Obozowisko.Dom.posiadany_dom.Kamien();
                        Ekwipunek.ekwipunek_ilosci[3] += Obozowisko.Dom.posiadany_dom.Skora();
                        Ekwipunek.ekwipunek_ilosci[4] += Obozowisko.Dom.posiadany_dom.Metal();
                        Obozowisko.Dom.posiadany_dom = Obozowisko.Dom.klepisko;
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }
        public static string NazwaPrzedmiotuBiernik(int wybranyPrzedmiotWSklepie)
        {
            switch (wybranyPrzedmiotWSklepie)
            {
                case 0:
                    return "jedzenie";
                case 1:
                    return "drewno";
                case 2:
                    return "kamień";
                case 3:
                    return "skórę";
                case 4:
                    return "metal";
                case 5:
                    return "nóż";
                case 6:
                    return "miecz";
                case 7:
                    return "katanę";
                case 8:
                    return "kurtkę";
                case 9:
                    return "kolczugę";
                case 10:
                    return "pancerz";
                case 11:
                    return "klepisko";
                case 12:
                    return "szałas";
                case 13:
                    return "ziemiankę";
                case 14:
                    return "chatkę";
                default:
                    return "<błąd>";
            }
        }
        public static string NazwaPrzedmiotuDopelniacz(int wybranyPrzedmiotWSklepie)
        {
            switch (wybranyPrzedmiotWSklepie)
            {
                case 0:
                    return "jedzenia";
                case 1:
                    return "drewna";
                case 2:
                    return "kamienia";
                case 3:
                    return "skóry";
                case 4:
                    return "metalu";
                case 5:
                    return "noża";
                case 6:
                    return "miecza";
                case 7:
                    return "katany";
                case 8:
                    return "kurtki";
                case 9:
                    return "kolczugi";
                case 10:
                    return "pancerza";
                case 11:
                    return "klepiska";
                case 12:
                    return "szałasu";
                case 13:
                    return "ziemianki";
                case 14:
                    return "chatki";
                default:
                    return "<błąd>";
            }
        }

    }
}
