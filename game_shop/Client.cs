using System;
using System.Collections.Generic;
using System.Text;

namespace game_shop
{
    class Client
    {
        static void Menu()
        {
            while (true)
            {
                int choose = 0;
                Console.WriteLine("1. Сортировка\n2.Поиск\n3. Оформление заказа\n0. Назад");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Program.DisplayMessage(ex.ToString());
                }

                switch (choose)
                {
                    case 0:
                        return;
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                }
            }

        }
    }
}
