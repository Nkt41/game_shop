using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace game_shop
{

    [Serializable]
    class User
    {
        string login;
        string password;
        public string Access { get; set; }
        public DateTime date = new DateTime();

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }

    [Serializable]
    class Electronic : ICommnad
    {
        string nameTovar;
        string manufacturTovara;
        int priceTovara;
        public int InStockTovar { get; set; }


        public string NameTovar
        {
            get
            {
                return nameTovar;
            }
            set
            {
                nameTovar = value;
            }
        }
   
        public string ManufacturTovar
        {
            get
            {
                return manufacturTovara;
            }
            set
            {
                manufacturTovara = value;
            }
        }
        public int PriceTovara
        {
            get
            {
                return priceTovara;
            }
            set
            {
                priceTovara = value;
            }
        }
        void ICommnad.Add()
        {

        }
        /*void ICommnad.Edit()
        {

        }
        void ICommnad.Display()
        {

        }*/
/*        public int InStockTovar
        {
            get
            {
                return inStockTovar;
            }
            set
            {
                inStockTovar = value;
            }
        }*/
    }

    [Serializable]
    abstract class Tovar
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        
    }
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
    class Pristavka : Vnytrenosty, ICommnad
    {
        public string Color { get; set; }
        public bool Discovod { get; set; }
        void ICommnad.Add()
        {
            Add();
            Console.Write("Цвет: ");
            Color = Console.ReadLine();
            Discovod = Convert.ToBoolean(Console.ReadLine());
        }
    }

   /* class Metody
    {
        public static void AddOrder()
        {
            string codeOrder = "", FIO = "", phoneNumber = "", productOrder = "", priceOrder = "";
            Console.WriteLine("Ведите номер заказа");
            codeOrder = Console.ReadLine();
            Console.WriteLine("Ведите ФИО");
            FIO = Console.ReadLine();
            Console.WriteLine("Ведите номер телефона");
            phoneNumber = Console.ReadLine();
            Console.WriteLine("Ведите название товара");
            productOrder = Console.ReadLine();
            Console.WriteLine("Ведите стоимость товара");
            priceOrder = Console.ReadLine();
        }

        public static void SortElectronic()
        {

        }

        public static void AddElectronic()
        {
            // название товара, производитель, цена, кол-во в наличии
            string nameProduct = "", manufacturer = "", price = "", inStock = "";
            Console.WriteLine("Введите название товара");
            nameProduct = Console.ReadLine();
            Console.WriteLine("Введите производитель");
            manufacturer = Console.ReadLine();
            Console.WriteLine("Введите цена");
            price = Console.ReadLine();
            Console.WriteLine("Введите кол-во в наличии ");
            inStock = Console.ReadLine();
        }

        public static void Electronics()
        {
            //список товаров 
            int key = 0;
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            Console.WriteLine("|  Код товара  |  Название товара  |  Производитель  |  Цена  |  Количестово в наличии  |");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("1.Добавить товар\n2.Сортировать\n0.Назад");
                key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        AddElectronic();
                        break;
                    case 2:
                        SortElectronic();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Введено неверное значение");
                        break;
                }
            }
        }

        public static void Oreder()
        {
            int key = 0;
            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.WriteLine("|  Номер заказа  |  ФИО  |  Номер телефона  |  Название товара  |  Цена товара  |");
            Console.WriteLine("---------------------------------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("1.Добавить заказ\n0.Назад");
                key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        AddOrder();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Введено неверное значение");
                        break;
                }
            }
        }

        public static void Deal()
        {
            int key;
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|  Код сделки  |  ФИО  |  Номер телефона  |  Название товара  |  Цена товара  |  Дата совершения сделки  |");
            Console.WriteLine("----------------------------------------------------------------------------------------------------------");
            while (true)
            {
                Console.WriteLine("1.Добавить сделку\n0.Назад");
                key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        //AddDeal();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Введено неверное значение");
                        break;
                }
            }
        }


        public static void Admin_Menu()
        {
            int key = 0;
            while (true)
            {
                Console.WriteLine("1.Посмотреть асортимент\n2.Редактировать Товар\n3.Заказы\n4.редактировать заказ.\n5.сделки\n0.Выход в меню");
                key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Electronics();
                        break;
                    case 2:
                        //редактирование 
                        break;
                    case 3:
                        Oreder();
                        break;
                    case 4:
                        //редактирование товара
                        break;
                    case 5:
                        Deal();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Введено не верное значение!");
                        break;
                }
            }
        }

        public static void Guest_Menu()
        {
            int key = 0;
            while (true)
            {
                Console.WriteLine("1.Просмотр Товара\n2.Сделать заказ\n0.Выход в меню");
                key = Convert.ToInt32(Console.ReadLine());
                switch (key)
                {
                    case 1:
                        Electronics();
                        break;
                    case 2:
                        AddOrder();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Введено не верное значение!");
                        break;
                }
            }
        }
    }*/

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Магазин игровой электроники";

            List<User> users = new List<User>();
            List<Pristavka> pristavkas = new List<Pristavka>();
            List<Computer> computers = new List<Computer>();

            GetRecord(users, computers, pristavkas);

            if (users.Count == 0)
            {
                Registration(users, "admin");
            }

           /* foreach (User user in users)
            {
                Console.WriteLine($"Login: {user.Login}\nPasswrod: {user.Password}");
            }
            Console.ReadLine();*/

            Menu(users, computers, pristavkas);
        }
        static void Menu(List<User> users, List<Computer> computers, List<Pristavka> pristavkas)
        {
   
            int choose = 0;
            while (true)
            {
                Console.WriteLine("1. Вход - Админа\n2. Вход - Пользователь\n0. Выход");
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
                            Admin.Menu(users, pristavkas, computers);
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
            Console.WriteLine("Регистрация администратора");
            User user = new User();          
            Console.Write("Логин: ");
            user.Login = Console.ReadLine();
            Console.Write("Пароль: ");
            user.Password = Console.ReadLine();
            user.Access = access;
            user.date = DateTime.Now;
            users.Add(user);

            DisplayMessage("Регистрация прошла успешна");
            WriteToFileUser(users);
        }

        static void PreMenuUser(List<User> users, List<Computer> computers, List<Pristavka> pristavkas)
        {
            int choose = 0;
            try
            {
                choose = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {

            }

            while (true)
            {
                Console.WriteLine("1. Вход\n2. Регистрация\n0. Назад");
                switch (choose)
                {
                    case 0:
                        return;
                    case 1:
                        if (IsLogin(users, "user"))
                        {
 
                        }
                        else
                        {

                        }
                        break;
                    case 2:
                        Registration(users, "user");
                        break;
                    default:

                        break;
                }
            }
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
        static void WriteToFileUser(List<User> users)
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
        static void WriteToFilePristavka(List<Pristavka> pristavkas)
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
        static void WtiteToFileComputer(List<Computer> computers)
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