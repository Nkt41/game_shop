using System;
using System.Collections.Generic;
using System.Text;

namespace game_shop
{
    class Sort
    {
        /// <summary>
        /// Bobble sort
        /// </summary>
        /// <param name="pristavkas"></param>
        /// <param name="computers"></param>
        static void Price(List<Pristavka> pristavkas, List<Computer> computers)
        {
            for (int i = 0; i < pristavkas.Count; i++)
            {
                for (int j = 0; j < pristavkas.Count - 1; j++)
                {
                    if(pristavkas[j].Price < pristavkas[j + 1].Price)
                    {
                        Pristavka pristavka;
                        pristavka = pristavkas[j];
                        pristavkas[j] = pristavkas[j + 1];
                        pristavkas[j + 1] = pristavka;
                    }
                }
            }

            for (int i = 0; i < computers.Count; i++)
            {
                for (int j = 0; j < computers.Count - 1; j++)
                {
                    if(computers[j].Price < computers[j + 1].Price)
                    {
                        Computer computer;
                        computer = computers[j];
                        computers[j] = computers[j + 1];
                        computers[j + 1] = computer;
                    }
                }
            }
        }
    }
}
