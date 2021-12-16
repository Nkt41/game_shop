using System;
using System.Collections.Generic;
using System.Text;

namespace game_shop
{
    class Admin
    {
        public static void Menu(List<User> users, List<Pristavka> pristavkas, List<Computer> computers, List<Order> orders)
        {
            int choose = 0, idAdmin = users[0].Id;

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"1. Управление товаром\n2. Управление пользователями\n3. Заказы ({orders.Count})\n4. Профиль\n5. Изменить логин или пароль\n0. Назад");
                // Console.WriteLine("1. Товар\n2. Заказы\n3. Сделки\n4. Пользователи\n5. Профиль\n0. Назад");
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
                        ProductMenu(computers, pristavkas);
                        break;
                    case 2:
                        UsersMenu(users);
                        break;
                    case 3:

                        break;
                    case 4:
                        ProfilMenu(users);
                        break;
                    case 5:
                        Program.EditDataUser(users, idAdmin);
                        break;
                    default:
                        Program.DisplayMessage("Некорректный ввод");
                        break;
                }
            }
        }
        static void ProductMenu(List<Computer> computers, List<Pristavka> pristavkas)
        {
            //таблица
            int choose = 0;
            while (true)
            {
                Console.Clear();
                Program.ProductTable(computers, pristavkas);
                Console.WriteLine("1. Добавить\n2. Редактировать\n3. Удалить\n4. Сортировка\n5. Поиск\n0. Назад");
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

                        break;
                    case 3:
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
        static void UsersMenu(List<User> users)
        {
            while (true)
            {
                int choose = 0;
                Console.Clear();
                Program.UserTable(users);
                Console.WriteLine("1. Редактировать\n2. Удалить\n0. Назад\n>");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Program.DisplayMessage(ex.Message);
                }
                switch (choose)
                {
                    case 0:
                        return;
                    case 1:
                        EditUserMenu(users);
                        break;
                    case 2:
                        DeleteUser(users);
                        break;

                    default:
                        Program.DisplayMessage("Некорректный ввод");
                        break;
                }
            }
        }
        static void EditUserMenu(List<User> users)
        {
            Console.Clear();

            int idEditUser = 0;
            Program.UserTable(users);

            Console.Write("Введите id редактироваемого пользователя\n>");
            try
            {
                idEditUser = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Program.DisplayMessage(ex.Message);
            }

            if (idEditUser < 0 || idEditUser > users.Count)
            {
                Console.WriteLine($"Пользователя с id - {idEditUser} нету");
                return;
            }

            while (true)
            {
                Console.Clear();
                int choose = 0;
                Program.UserTable(users);
                Console.WriteLine("Что редактируем?");
                Console.WriteLine("1. Логин\n2. Пароль\n3. Имя\n4. Номер телефона\n5. Адрес\n0) Назад");
                Console.Write(">");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Program.DisplayMessage(ex.Message);
                }

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Id == idEditUser)
                    {
                        idEditUser = i;
                        break;
                    }
                }

                if (choose > 0 && choose <= 5)
                {
                    UserEditField(users, --choose, idEditUser);
                }
                else
                {
                    return;
                }
            }
        }
        static void UserEditField(List<User> users, int field, int idEditUser)
        {
            switch (field)
            {
                case 0:
                    Console.Write($"Старые данные: {users[idEditUser].Login}\nНовые данные: ");
                    users[idEditUser].Login = Console.ReadLine();
                    break;
                case 1:
                    Console.Write($"Старые данные: {users[idEditUser].Password}\nНовые данные: ");
                    users[idEditUser].Password = Console.ReadLine();
                    break;
                case 2:
                    Console.Write($"Старые данные: {users[idEditUser].Name}\nНовые данные: ");
                    users[idEditUser].Name = Console.ReadLine();
                    break;
                case 3:
                    Console.Write($"Старые данные: {users[idEditUser].PhoneNumber}\nНовые данные: ");
                    users[idEditUser].PhoneNumber = Console.ReadLine();
                    break;
                case 4:
                    Console.Write($"Старые данные: {users[idEditUser].Address}\nНовые данные: ");
                    users[idEditUser].Address = Console.ReadLine();
                    break;
            }

            Program.WriteToFileUser(users);
        }
        static void DeleteUser(List<User> users)
        {
            int idDeleteUser = 0, i = 0;
            User user;
            Program.UserTable(users);
            Console.Write("Введите id удаляемого пользователя\n>");
            try
            {
                idDeleteUser = Convert.ToInt32(Console.ReadLine());
                for (i = 0; i < users.Count; i++)
                {
                    if (users[i].Id == idDeleteUser)
                    {
                        user = users[i];
                        break;
                    }
                }

                users.RemoveAt(i);
            }
            catch (Exception ex)
            {
                Program.DisplayMessage(ex.Message);
            }

            Program.WriteToFileUser(users);
        }
        static void ProfilMenu(List<User> users)
        {
            Console.Clear();
            foreach(User user in users)
            {
                if(user.Access == "admin")
                {
                    Console.WriteLine($"Логин: {user.Login}\nПароль: {user.Password}\nИмя: {user.Name}\nДата регистрации: {user.RegistrationDate}");
                    Console.ReadLine();
                }
            }
        }
    }
}
