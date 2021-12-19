using System;
using System.Collections.Generic;
using System.IO;
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
                        OrderMenu(orders);
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
                Console.WriteLine("1. Добавить \n2. Редактировать\n3. Удалить\n4. Сортировка\n5. Поиск\n0. Назад");
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
                        Add(computers, pristavkas);
                        break;
                    case 2:
                        Edit(computers, pristavkas);
                        break;
                    case 3:
                        DeleteProduct(computers, pristavkas);
                        break;
                    case 4:
                        Program.SortMenu(computers, pristavkas);
                        break;
                    case 5:
                        Program.FindMenu();
                        break;
                    default:
                        break;
                }
            }
        }
        static void Add(List<Computer> computers, List<Pristavka> pristavkas)
        {
            int choose = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить компьютер\n2. Добавить приставку\n0. Назад");
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
                        AddComputer(computers);
                        break;
                    case 2:
                        AddPristavka(pristavkas);
                        break;
                    default:
                        break;
                }
            }
        }
        static void Edit(List<Computer> computers, List<Pristavka> pristavkas)
        {
            int choose = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Редактировать компьютер\n2. Редактировать приставку\n0. Назад");
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
                        EditComputer(computers);
                        break;
                    case 2:
                        EditPristavka(pristavkas);
                        break;
                    default:
                        break;
                }
            }
        }
        static void AddComputer( List<Computer> computers)
        {
            int uniqueId = (computers.Count == 0) ? 0 : Convert.ToInt32(File.ReadAllText("uniqueIdTour"));
            ++uniqueId;
            File.WriteAllText("uniqueIdTour", uniqueId.ToString());
            Computer computer = new Computer();
            computer.Add(uniqueId);
            computers.Add(computer);

            Program.DisplayMessage("Техника добавлена успешна");
            Program.WriteToFileComputer(computers);
        }
        static void AddPristavka(List<Pristavka> pristavkas)
        {
            int uniqueId = (pristavkas.Count == 0) ? 0 : Convert.ToInt32(File.ReadAllText("uniqueIdTour"));
            ++uniqueId;
            File.WriteAllText("uniqueIdTour", uniqueId.ToString());
            Pristavka pristavka = new Pristavka();
            pristavka.Add(uniqueId);
            pristavkas.Add(pristavka);

            Program.DisplayMessage("Приставка добавлена успешна");
            Program.WriteToFilePristavka(pristavkas);
        }
        static void EditComputer(List<Computer> computers)
        {
            Console.Clear();

            int idEditProduct = 0;
            Program.ComputerTable(computers);

            Console.Write("Введите id редактироваемого компьютера\n>");
            try
            {
                idEditProduct = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Program.DisplayMessage(ex.Message);
            }

            if (idEditProduct < 0 || idEditProduct >= computers.Count)
            {
                Console.WriteLine($"Компа с id - {idEditProduct} нету");
                return;
            }

            while (true)
            {
                Console.Clear();
                int choose = 0;
                Program.ComputerTable(computers);
                Console.WriteLine("Что редактируем?");
                Console.WriteLine($"1) Название\n2) Цена\n3) Оперативная память\n4) Видео карта \n5) Процессор\n0) Назад");
                Console.Write(">");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Program.DisplayMessage(ex.Message);
                }

                for (int i = 0; i < computers.Count; i++)
                {
                    if (computers[i].Id == idEditProduct)
                    {
                        idEditProduct = i;
                        break;
                    }
                }

                if (choose > 0 && choose <= 5)
                {
                    EditTourFieldComputer(computers, idEditProduct, --choose);
                }
                else
                {
                    return;
                }
            }
        }
        static void EditTourFieldComputer(List<Computer> computers, int idEditProduct, int idField)
        {
            switch (idField)
            {
                case 0:
                    Console.Write($"Старые данные {computers[idEditProduct].Name}\nНовые данные: ");
                    computers[idEditProduct].Name = Console.ReadLine();
                    break;
                case 1:
                    Console.Write($"Старые данные {computers[idEditProduct].Price}\nНовые данные: ");
                    try
                    {
                        computers[idEditProduct].Price = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Program.DisplayMessage(ex.Message);
                    }
                    break;
                case 2:
                    Console.Write($"Старые данные {computers[idEditProduct].OperationMemory}\nНовые данные: ");
                    try
                    {
                        computers[idEditProduct].OperationMemory = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Program.DisplayMessage(ex.Message);
                    }
                    break;
                case 3:
                    Console.Write($"Старые данные {computers[idEditProduct].GraphicCart}\nНовые данные: ");
                    computers[idEditProduct].GraphicCart = Console.ReadLine();
                    break;
                case 4:
                    Console.Write($"Старые данные {computers[idEditProduct].CPU}\nНовые данные: ");
                    computers[idEditProduct].CPU = Console.ReadLine();
                    break;
            }

            Program.WriteToFileComputer(computers);
        }

        static void EditPristavka(List<Pristavka> pristavkas)
        {
            Console.Clear();

            int idEditProduct = 0;
            Program.PristavkaTable(pristavkas);

            Console.Write("Введите id редактироваемого приставки\n>");
            try
            {
                idEditProduct = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Program.DisplayMessage(ex.Message);
            }

            if (idEditProduct < 0 || idEditProduct >= pristavkas.Count)
            {
                Console.WriteLine($"Компа с id - {idEditProduct} нету");
                return;
            }

            while (true)
            {
                Console.Clear();
                int choose = 0;
                Program.PristavkaTable(pristavkas);
                Console.WriteLine("Что редактируем?");
                Console.WriteLine($"1) Название\n2) Цена\n3) Оперативная память\n4) Цвет \n5) Дисковод\n0) Назад");
                Console.Write(">");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Program.DisplayMessage(ex.Message);
                }

                for (int i = 0; i < pristavkas.Count; i++)
                {
                    if (pristavkas[i].Id == idEditProduct)
                    {
                        idEditProduct = i;
                        break;
                    }
                }

                if (choose > 0 && choose <= 5)
                {
                    EditTourFieldPristavka(pristavkas, idEditProduct, --choose);
                }
                else
                {
                    return;
                }
            }
        }
        static void EditTourFieldPristavka(List<Pristavka> pristavkas, int idEditProduct, int idField)
        {
            switch (idField)
            {
                case 0:
                    Console.Write($"Старые данные {pristavkas[idEditProduct].Name}\nНовые данные: ");
                    pristavkas[idEditProduct].Name = Console.ReadLine();
                    break;
                case 1:
                    Console.Write($"Старые данные {pristavkas[idEditProduct].Price}\nНовые данные: ");
                    try
                    {
                        pristavkas[idEditProduct].Price = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Program.DisplayMessage(ex.Message);
                    }
                    break;
                case 2:
                    Console.Write($"Старые данные {pristavkas[idEditProduct].OperationMemory}\nНовые данные: ");
                    try
                    {
                        pristavkas[idEditProduct].OperationMemory = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Program.DisplayMessage(ex.Message);
                    }
                    break;
                case 3:
                    Console.Write($"Старые данные {pristavkas[idEditProduct].Color}\nНовые данные: ");
                    pristavkas[idEditProduct].Color = Console.ReadLine();
                    break;
                case 4:
                    Console.Write($"Старые данные {pristavkas[idEditProduct].Discovod}\nНовые данные: ");
                    pristavkas[idEditProduct].Discovod = Convert.ToBoolean(Console.ReadLine());
                    break;
            }

            Program.WriteToFilePristavka(pristavkas);
        }
        static void DeleteProduct(List<Computer> computers, List<Pristavka> pristavkas)
        {
            int idDeleteProduct = 0;
            bool first = false;
            Program.ProductTable(computers, pristavkas);
            Console.Write("ID удаляемого тура: ");

            try
            {
                idDeleteProduct = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Program.DisplayMessage(ex.Message);
            }


            foreach (Computer computer in computers)
            {
                if (computer.Id == idDeleteProduct)
                {
                    first = true;
                    computers.RemoveAt(idDeleteProduct);
                    Program.WriteToFileComputer(computers);
                }
            }

            if(!first)
            {
                foreach (Pristavka pristavka in pristavkas)
                {
                    if (pristavka.Id == idDeleteProduct)
                    {
                        pristavkas.RemoveAt(idDeleteProduct);
                        Program.WriteToFilePristavka(pristavkas);
                    }
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

        static void OrderMenu(List<Order> orders)
        {

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
