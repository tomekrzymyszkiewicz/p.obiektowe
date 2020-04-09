using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace the_forest_game
{
    public class Potwory
    {
        public class AtakNaObozowisko
        {
            public static int[] Atak()
            {
                int[] dane = new int[8];
                // 0 - czy był atak? // 0 - nie // 1 - tak
                // 1 - zabrane życie
                // 2 - zabrana energia
                // 3 - zabrane drewno
                // 4 - zabrane kamienie
                // 5 - zabrana skora
                // 6 - zabrany metal
                // 7 - zyskane doświadczenie
                Random los = new Random();
                if(los.Next(0,101) >= Obozowisko.Dom.posiadany_dom.Wytrzymalosc()*3)
                {
                    dane[0] = 1;
                    int mocAtaku = los.Next(0, 35 - Obozowisko.Dom.posiadany_dom.Wytrzymalosc()); // od 5 do 35, zależnie od wytrzymałości domu
                    //zycie
                    dane[1] = los.Next(0, mocAtaku);
                    if(Gracz.Zycie() - dane[1] < 0)
                    {
                        dane[1] -= Gracz.Zycie() - dane[1];
                    }
                    //energia
                    dane[2] = los.Next(0 , mocAtaku);
                    if (Gracz.Energia() - dane[2] < 0)
                    {
                        dane[2] -= Gracz.Energia() - dane[2];
                    }
                    //drewno
                    dane[3] = los.Next(0, mocAtaku / 2);
                    if(Ekwipunek.ekwipunek_ilosci[1] - dane[3] < 0 )
                    {
                        dane[3] -= dane[3] - Ekwipunek.ekwipunek_ilosci[1];
                    }
                    //kamień
                    dane[4] = los.Next(0, mocAtaku / 2);
                    if (Ekwipunek.ekwipunek_ilosci[2] - dane[4] < 0)
                    {
                        dane[4] -= dane[4] - Ekwipunek.ekwipunek_ilosci[2];
                    }
                    //skora
                    dane[5] = los.Next(0, mocAtaku / 10);
                    if (Ekwipunek.ekwipunek_ilosci[3] - dane[5] < 0)
                    {
                        dane[5] -= dane[5] - Ekwipunek.ekwipunek_ilosci[3];
                    }
                    //metal
                    dane[6] = los.Next(0, mocAtaku / 10);
                    if (Ekwipunek.ekwipunek_ilosci[4] - dane[6] < 0)
                    {
                        dane[6] -= dane[6] - Ekwipunek.ekwipunek_ilosci[4];
                    }
                    dane[7] = los.Next(0, mocAtaku / 2);
                    Gracz.ZmienZycie(-dane[1]);
                    Gracz.ZmienEnergie(-dane[2]);
                    Gracz.ZmienDoswiadczenie(dane[7]);
                    Ekwipunek.ekwipunek_ilosci[1] -= dane[3];
                    Ekwipunek.ekwipunek_ilosci[2] -= dane[4];
                    Ekwipunek.ekwipunek_ilosci[3] -= dane[5];
                    Ekwipunek.ekwipunek_ilosci[4] -= dane[6];
                }
                else
                {
                    dane[0] = 0;
                }
                return dane;
            }
        }
        class Boss
        {

        }
    }
}
