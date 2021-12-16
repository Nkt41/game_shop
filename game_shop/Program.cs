﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace game_shop
{

    [Serializable]
    class User
    {
        public int Id { get; set; }
        string login;
        string password;
        public string Name { get; set; }
        public string Access { get; set; }
        string phoneNumber;
        public string Address { get; set; }
        DateTime registrationDate = new DateTime();

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if(value.Length != 9)
                {
                    Console.Write("Номер телефона должне состоять из \'оператора\' и \'номера абонента\': 00 000-00-00");
                    PhoneNumber = Console.ReadLine();
                }
                else
                {
                    phoneNumber = "+375 " + $"{ulong.Parse(string.Concat(value)):(00 000-00-00)}";
                }
            }
        }
    }

    [Serializable]
    class Order : Tovar
    {

    }

    [Serializable]
    abstract class Tovar
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        
    }
    [Serializable]
    class Vnytrenosty : Tovar
    {
        public int OperationMemory { get; set; }

        public void Add()
        {
            Console.Write("Название: ");
            Name = Console.ReadLine();
            Console.Write("Цена: ");
            Price = Convert.ToDouble(Console.ReadLine());
            Console.Write("ОЗУ: ");
            OperationMemory = Convert.ToInt32(Console.ReadLine());
        }
    }
    [Serializable]
    class Computer : Vnytrenosty, ICommnad
    {
        public string GraphicCart { get; set; }
        public string CPU { get; set; }
        void ICommnad.Add()
        {
            Add();
            Console.Write("Видео карта: ");
            GraphicCart = Console.ReadLine();
            Console.Write("Процессор: ");
            CPU = Console.ReadLine();
        }

    }
    [Serializable]
    class Pristavka : Vnytrenosty, ICommnad
    {
        public string Color { get; set; }
        public bool Discovod { get; set; }
        void ICommnad.Add()
        {
            Add();
            Console.Write("Цвет: ");
            Color = Console.ReadLine();
            Console.Write("Дисковод (true / false): ");
            Discovod = Convert.ToBoolean(Console.ReadLine());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Магазин игровой электроники";

            List<User> users = new List<User>();
            List<Pristavka> pristavkas = new List<Pristavka>();
            List<Computer> computers = new List<Computer>();
            List<Order> orders = new List<Order>();

            /*            try
                        {

                            Computer computer = new Computer();
                            computer.Id = 1;
                            computer.Name = "Комп-1";
                            computer.Price = 199.99;
                            computer.OperationMemory = 8;
                            computer.GraphicCart = "GTX Geforse 670 2GB";
                            computer.CPU = "intel icore 5";
                            computers.Add(computer);
                            WriteToFileComputer(computers);

                            Console.ReadLine();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);  
                        }*/

/*            try
            {

                Pristavka pristavka = new Pristavka();
                pristavka.Id = 2;
                pristavka.Name = "Название";
                pristavka.Price = 980;
                pristavka.Color = "nigger";
                pristavka.Discovod = true;
                pristavka.OperationMemory = 8;
                pristavkas.Add(pristavka);
                WriteToFilePristavka(pristavkas);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }*/

            GetRecord(users, computers, pristavkas);

            if (users.Count == 0)
            {
                Registration(users, "admin");
            }

            Menu(users, computers, pristavkas, orders);
        }
        static void Menu(List<User> users, List<Computer> computers, List<Pristavka> pristavkas, List<Order> orders)
        {
   
            int choose = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Вход - Администратора\n2. Вход - Пользователь\n0. Выход");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }          

                switch (choose)
                {
                    case 0:
                        return;
                    case 1:
                        if(IsLogin(users, "admin"))
                        {
                            Admin.Menu(users, pristavkas, computers, orders);
                        }
                        else
                        {
                            DisplayMessage("Некорректный пароль");
                        }
                        break;
                    case 2:
                        PreMenuUser(users, computers, pristavkas);
                        break;
                    default:
                        DisplayMessage("Некорректный ввод");
                        break;

                }
            }
        }
        static bool IsLogin(List<User> users, string access)
        {
            Console.Clear();
            string login = "", password = "";
            Console.Write("Login: ");
            login = Console.ReadLine();
            Console.Write("Passwrod: ");
            password = Console.ReadLine();

            foreach(User user in users)
            {
                if(user.Login == login && user.Password == password && user.Access == access)
                {
                    DisplayMessage("Вход выполнен успешно");
                    return true;
                }    
            }
            
            return false;
        }
        static void Registration(List<User> users, string access)
        {
            User user = new User();
            Console.WriteLine($"Регистрация \'{access}\'");
                     
            Console.Write("Логин: ");
            user.Login = Console.ReadLine();
            Console.Write("Пароль: ");
            user.Password = Console.ReadLine();
            Console.Write("Имя: ");
            user.Name = Console.ReadLine();
            int uniqueId = (users.Count == 0) ? users.Count : Convert.ToInt32(File.ReadAllText("uniqueId"));
            ++uniqueId;
            File.WriteAllText("uniqueId", uniqueId.ToString());
            user.Id = uniqueId;
            user.Access = access;
            user.RegistrationDate = DateTime.Now;

            users.Add(user);

            DisplayMessage("Регистрация прошла успешна");

            WriteToFileUser(users);
        }

        static void PreMenuUser(List<User> users, List<Computer> computers, List<Pristavka> pristavkas)
        {
            while (true)
            {
                int choose = 0;
                Console.Clear();
                Console.WriteLine("1. Вход\n2. Регистрация\n0. Назад\n>");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    DisplayMessage(ex.Message);
                }
                switch (choose)
                {
                    case 0:
                        return;
                    case 1:
                        if (IsLogin(users, "user"))
                        {
                            Client.Menu();
                        }
                        else
                        {
                            DisplayMessage("Неправильный логин или пароль");
                        }
                        break;
                    case 2:
                        Registration(users, "user");
                        break;
                    default:
                        DisplayMessage("Некорректный ввод");
                        break;
                }
            }
        }

        public static void SortMenu(List<Computer> computers, List<Pristavka> pristavkas)
        {
            while (true)
            {
                int choose = 0;
                Console.Clear();
                Console.WriteLine("1. Сортировка по цене (возрастание)\n2. Сортировка по цене (убывание)\n3. Сортировка по Id (возрастание)\n4. Сортировка по названию\n0. Назад\n>");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    DisplayMessage(ex.Message);
                }
                switch (choose)
                {
                    case 0:
                        return;
                    case 1:
                        Sort.PriceIncrease(computers, pristavkas);
                        break;
                    case 2:
                        Sort.PriceDecrease(computers, pristavkas, 0, (computers.Count > pristavkas.Count) ? computers.Count - 1 : pristavkas.Count - 1);
                        break;
                    case 3:
                        Sort.IdIncrease(computers, pristavkas);
                        break;
                    case 4:
                        Sort.NameIncrease(computers, pristavkas);
                        break;
                    default:
                        DisplayMessage("Некорректный ввод");
                        break;
                }
            }
        }
        public static void FindMenu()
        {

        }
        public static User GetUser(List<User> users, int id)
        {
            foreach (User user in users)
            {
                if(user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }
        public static void EditDataUser(List<User> users, int id)
        {
            User user = new User();
            foreach (User userData in users)
            {
                if (userData.Id == id)
                {
                    user = userData;
                }
            }
            while (true)
            {
                Console.Clear();
                int choose = 0;
                Console.WriteLine("1. Изменить логин\n2. Изменить пароль\n0. Назад");
                Console.Write(">");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Program.DisplayMessage(ex.Message);
                }
                Console.Clear();
                switch (choose)
                {
                    case 0:
                        return;
                    case 1:
                        Console.Write($"Страный логин: {user.Login}\nНовый логин: ");
                        user.Login = Console.ReadLine();
                        DisplayMessage("Логин успешно изменён");
                        break;
                    case 2:
                        Console.Write($"Страный пароль: {user.Password}\nНовый пароль: ");
                        user.Password = Console.ReadLine();
                        DisplayMessage("Пароль успешно изменён");
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }

                Program.WriteToFileUser(users);
            }
        }
        public static void ProductTable(List<Computer> computers, List<Pristavka> pristavkas)
        {
            if(computers.Count == 0 && pristavkas.Count == 0)
            {
                Console.Write("Список пуст");
                return;
            }

            var table = new Table("Id", "Название", "Цена", "Оперативная память", "Видеокарта", "Процессор", "Цвет", "Дисковод");

            foreach (Computer computer in computers)
            {
                table.AddRow(computer.Id, computer.Name, computer.Price + " BYN", computer.OperationMemory + " ГБ", computer.GraphicCart, computer.CPU, "-", "-");
            }
            foreach (Pristavka pristavka in pristavkas)
            {
                table.AddRow(pristavka.Id, pristavka.Name, pristavka.Price + " BYN", pristavka.OperationMemory + " ГБ", "-", "-", pristavka.Color, (pristavka.Discovod == true) ? "Есть" : "Отсуствует");
            }

            table.Print();
        }

        public static void UserTable(List<User> users)
        {
            var table = new Table("Id", "Логин", "Пароль", "Имя", "Номер телефона", "Адрес");

            foreach (User user in users)
            {
                table.AddRow(user.Id, user.Login + $" ({user.Access})", user.Password, user.Name, user.PhoneNumber ?? "null", user.Address ?? "null");
            }
            table.Print();
        }

        static void GetRecord(List<User> users, List<Computer> computers, List<Pristavka> pristavkas)
        {
            string[] paths = { "users", "pristavkas", "computers" };
            try
            {
                for (int i = 0; i < paths.Length; i++)
                {
                    using (Stream stream = File.Open(paths[i] + ".bin", FileMode.OpenOrCreate))
                    {
                        BinaryFormatter binary = new BinaryFormatter();

                        if (File.Exists(paths[i] + ".bin") && stream.Length != 0)
                        {
                            switch (paths[i])
                            {
                                case "users":
                                    var elemsUser = (List<User>)binary.Deserialize(stream);
                                    users.AddRange(elemsUser);
                                    break;
                                case "pristavkas":
                                    var elemsPristavka = (List<Pristavka>)binary.Deserialize(stream);
                                    pristavkas.AddRange(elemsPristavka);
                                    break;
                                case "computers":
                                    var elemsComputers = (List<Computer>)binary.Deserialize(stream);
                                    computers.AddRange(elemsComputers);
                                    break;
                                default:
                                    Console.WriteLine("Ошибка название файла");
                                    break;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void WriteToFileUser(List<User> users)
        {
            string path = "users";
            var elems = users;

            try
            {
                using (Stream stream = File.Open(path + ".bin", FileMode.Open))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    binary.Serialize(stream, elems);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void WriteToFilePristavka(List<Pristavka> pristavkas)
        {
            string path = "pristavkas";
            var elems = pristavkas;

            try
            {
                using (Stream stream = File.Open(path + ".bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    binary.Serialize(stream, elems);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void WriteToFileComputer(List<Computer> computers)
        {
            string path = "computers";
            var elems = computers;

            try
            {
                using (Stream stream = File.Open(path + ".bin", FileMode.OpenOrCreate))
                {
                    BinaryFormatter binary = new BinaryFormatter();
                    binary.Serialize(stream, elems);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(400);
            Console.Clear();
        }
    }
}