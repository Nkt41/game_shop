﻿using System;
using System.Collections.Generic;
using System.Text;

namespace game_shop
{
    class Client
    {
        public static void Menu(List<User> users, List<Pristavka> pristavkas, List<Computer> computers, List<Order> orders)
        {
            while (true)
            {
                int choose = 0;
                Console.WriteLine($"1) Просмотр Товара\n2) Мои покупки\n3) Изменить логин или пароль\n0) Назад");
                try
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Program.DisplayMessage(ex.ToString());
                }
                switch (choose)
                {
                    case 0:
                        return;
                    case 1:
                        Program.SortMenu(computers, pristavkas);
                        break;
                    case 2:
                        Program.FindMenu();
                        break;
                    case 3:

                        break;
                    default:
                        break;
                }
            }

        }
        static void ProductMenu(List<Computer> computers, List<Pristavka> pristavkas, List<Order> orders)
        {
            while (true)
            {
                Console.Clear();
                int choose = 0;
                Program.ProductTable(computers, pristavkas);
                Console.WriteLine($"1) Сортировка\n2) Поиск\n3) Сделать заказ\n0) Назад");
                Console.Write(">");
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
                        Program.SortMenu(computers, pristavkas);
                        break;
                    case 2:
                        Program.FindMenu();
                        break;
                    case 3:
                        if (computers.Count != 0 || pristavkas.Count != 0)
                        {
                            // MakeOrder(tours, users, orders, name);
                        }
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }
            }
        }
        static void MyOrder(List<User> users, List<Order> orders)
        {/*
            bool IsHave = false;
            User user = new User();
            user = Program.GetUser(users, login);

            while (true)
            {
                Console.Clear();
                int choose = 0;
                foreach (Trip ticket in tickets)
                {
                    if (ticket.IdUser == user.Id)
                    {
                        IsHave = true;
                        var tablePrinter = new TablePrinter("Id клиент", "Id экускурсии", "Дата отправления", "Фамилия", "Имя", "Номер телефона", "Адрес");
                        tablePrinter.AddRow(ticket.IdUser, ticket.IdTour, ticket.departureDate, user.Surname, user.Name, user.PhoneNumber, user.Address);
                        tablePrinter.Print();
                    }
                }

                if (!IsHave)
                {
                    Console.WriteLine("Спико пуст\n");
                }

                Console.WriteLine($"0) Назад");
                Console.Write(">");
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
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }
            }*/
        }
        static void MakeOrder(List<Computer> computers, List<Pristavka> pristavkas, List<Order> orders, List<User> users, string login)
        {
            List<Order> orderTour = new List<Order>();

            while (true)
            {
                Console.Clear();
                int choose = 0;

                TableSeparatorCatalog();
                Program.ProductTable(computers, pristavkas);
                TableSeparatorBasket(orderTour.Count);
                OrderTourTable(orderTour);

                Console.WriteLine($"1) Добавить товар\n2) Удалить товар\n3) Подтвердить заказ\n0) Назад");
                Console.Write(">");
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
                        OrderAdd(orders, computers, pristavkas, ref orderTour, users, login);
                        break;
                    case 2:
                        OrderDelete(ref orderTour);
                        break;
                    case 3:
                        ConfirmOrder(orders, orderTour, users, login);
                        break;
                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }
            }
        }
        static void OrderAdd(List<Order> orders, List<Computer> computers, List<Pristavka> pristavkas, ref List<Order> orderTours, List<User> users, string login)
        {
            Console.Clear();
            User user = new User();

            int id = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if(login == users[i].Login)
                {
                    id = i;
                    break;
                }
            }
            user = Program.GetUser(users, id);
            try
            {
                Program.ProductTable(computers, pristavkas);
                Console.Write("Введите id добавляемого товара\n>");
                int numAddTour = Convert.ToInt32(Console.ReadLine());

                bool first = false;
                int i = 0;
                for (i = 0; i < computers.Count; i++)
                {
                    if (computers[i].Id == numAddTour)
                    {
                        first = true;
                        numAddTour = i;
                        break;
                    }
                }
                for (i = 0; i < pristavkas.Count; i++)
                {
                    if (pristavkas[i].Id == numAddTour)
                    {
                        numAddTour = i;
                        break;
                    }
                }

                Order order = new Order();
                if (first)
                {
                    order.Id = computers[i].Id;
                    order.Name = computers[i].Name;
                    order.Price = computers[i].Price;
                }
                else
                {
                    order.Id = pristavkas[i].Id;
                    order.Name = pristavkas[i].Name;
                    order.Price = pristavkas[i].Price;
                }

                orderTours.Add(order);
            }
            catch (Exception ex)
            {
                Program.DisplayMessage(ex.Message);
            }
        }

        static void OrderDelete(ref List<Order> orderTours)
        {
            Console.Clear();
            OrderTourTable(orderTours);

            Console.Write("Введите id удаляемой экскурсии\n>");
            try
            {
                int numDeleteProduct = Convert.ToInt32(Console.ReadLine());

                for (int i = 0; i < orderTours.Count; i++)
                {
                    if (orderTours[i].Id == numDeleteProduct)
                    {
                        numDeleteProduct = i;
                        break;
                    }
                }
                orderTours.RemoveAt(numDeleteProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ConfirmOrder(List<Order> orders, List<Order> orderTours, List<User> users, string login)
        {
            int idUser = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Login == login)
                {
                    idUser = i;
                    break;
                }
            }
            int id = 0;
            for (int i = 0; i < users.Count; i++)
            {
                if (login == users[i].Login)
                {
                    id = i;
                    break;
                }
            }
            User user = new User();
            user = Program.GetUser(users, id);

            if (orderTours.Count == 0)
            {
                Program.DisplayMessage("Корзина пуста");
                return;
            }

            if (user.Address == null)
            {
                users[idUser].Add();
                user = users[idUser];
            }
            else
            {
                Console.WriteLine("Ваши данные:");
                Console.WriteLine($"Фамилия: {user.Surname}\nИмя: {user.Name}\nТелефон: {user.PhoneNumber}\nАдрес: {user.Address}");
                Console.Write("\nРедактировать?\n1. Да\n2. Нет\n>");
                try
                {
                    int choose = Convert.ToInt32(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            users[idUser].Add();
                            break;
                        case 2:
                            break;
                        default:
                            Console.WriteLine("Некорректный ввод");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Program.DisplayMessage(ex.Message);
                }
            }

            for (int i = 0; i < orderTours.Count; i++)
            {
                orders.Add(orderTours[i]);
            }
            orderTours.Clear();
            Program.DisplayMessage("Заказ успешно оформлен");

            Program.WriteToFileOrder(orders);
            Program.WriteToFileUser(users);
        }
        static void OrderTourTable(List<Order> orderTours)
        {
            if (orderTours.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }

            List<Tour> tours = new List<Tour>();
            Tour tour;
            foreach (Tour tourData in orderTours)
            {
                tour = new Tour();
                tour.Id = tourData.Id;
                tour.Cost = tourData.Cost;
                tour.Name = tourData.Name;
                tour.Hostel = tourData.Hostel;
                tour.Country = tourData.Country;
                tour.Duration = tourData.Duration;
                tours.Add(tour);
            }
            Program.TourTable(tours);
        }
        static void TableSeparatorCatalog() => Console.WriteLine(new string('-', 20) + " Каталог " + new string('-', 20));
        static void TableSeparatorBasket(int count) => Console.WriteLine(new string('-', 20) + $" Корзина ({count}) " + new string('-', 20));
        
    }
}
