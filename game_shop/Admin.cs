using System;
using System.Collections.Generic;
using System.Text;

namespace game_shop
{
    class Admin
    {
        public static void Menu(List<User> users, List<Pristavka> pristavkas, List<Computer> computers)
        {
            int choose = 0;

            while (true)
            {
                Console.WriteLine("1. Товар\n2. Заказы\n3. Сделки\n4. Пользователи\n5. Профиль\n0. Назад");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                switch (choose)
                {
                    case 0:
                        return;
                    case 1:
                        ProductMenu();
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:
                        ProfilMenu(users);
                        break;
                }
            }
        }
        static void ProductMenu()
        {
            //таблица
            int choose = 0;
            while (true)
            {
                Console.WriteLine("1. Добавить товар\n2. Сортировка по цене\n3. Поиск\n4. Редактирование\n5. Удаление\n0. Назад");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                switch (choose)
                {
                    case 0:
                        return;
                    case 1:

                        break;
                    case 2:
                        //Sort.Price(pristavkas, computers);
                        break;
                    case 3:
                        //Find.
                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    default:
                        break;
                }
            }
        }
        static void UsersMenu()
        {

        }
        static void ProfilMenu(List<User> users)
        {
            foreach(User user in users)
            {
                if(user.Access == "admin")
                {
                    Console.WriteLine($"Логин: {user.Login}\nПароль: {user.Password}\nДата регистрации: {user.date}");
                    Console.ReadLine();
                }
            }
        }
    }
}
