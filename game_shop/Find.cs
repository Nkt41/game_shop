using System;
using System.Collections.Generic;
using System.Text;

namespace game_shop
{
    class Find
    {
        public static void KeyWord(List<Computer> computers, List<Pristavka> pristavkas)
        {
            string word;
            bool bookAvailable = false;

            Console.Write("Введите ключевое слово: ");
            word = Console.ReadLine();

            Table table = new Table("id", "Название", "Страна", "Длительность", "Отель", "Цена");

            for (int i = 0; i < computers.Count; i++)
            {
                for (int j = 0; j < computers[i].Name.Length; j++)
                {
                    if (computers[i].Name[j] == word[0])
                    {
                        int count = 0;
                        for (int k = 0; k < word.Length; k++)
                        {
                            if (computers[i].Name[k + j] == word[k])
                            {
                                count++;
                            }
                            else
                            {
                                count = 0;
                            }
                        }

                        if (count == word.Length)
                        {
                            table.AddRow(computers[i].Id, computers[i].Name, computers[i].GraphicCart, computers[i].CPU, computers[i].OperationMemory, computers[i].Price);
                            bookAvailable = true;
                            break;
                        }
                        else
                        {
                            count = 0;
                        }
                    }
                }
            }

            if (bookAvailable)
            {
                table.Print();
            }
            else
            {
                Console.Write("Данного экскурсии в каталоге нету");
            }

            Console.ReadLine();
        }

        public static void SearchCountry(List<Computer> computers, List<Pristavka> pristavkas)
        {
            string country, word = "";
            bool bookAvailable = false;

            Table table = new Table("id", "Название", "Видео карта", "ЦП", "ОЗУ", "Цена");


            Console.Write("Введите название: ");
            country = Console.ReadLine();

            for (int i = 0; i < computers.Count; i++)
            {
                for (int j = 0; j < computers[i].Name.Length; j++)
                {
                    if (computers[i].Name[j] != ' ')
                    {
                        word += computers[i].Name[j];
                    }
                    if (computers[i].Name[j] == ' ' || (j + 1) >= computers[i].Name.Length)
                    {
                        if (String.Equals(word, country) == true)
                        {
                            table.AddRow(computers[i].Id, computers[i].Name, computers[i].GraphicCart, computers[i].CPU, computers[i].OperationMemory, computers[i].Price);
                            bookAvailable = true;
                        }
                        word = "";
                    }
                }
            }
            if (bookAvailable)
            {
                table.Print();
            }
            else
            {
                Console.WriteLine($"Товара по введённым данным \'{country}\' нету в каталоге");
            }

            Console.ReadLine();
        }

        public static void Price(List<Computer> computers, List<Pristavka> pristavkas)
        {
            double minPrice, maxPrice;
            bool bookAvailable = false;

            Table table = new Table("id", "Название", "Видео карта", "ЦП", "ОЗУ", "Цена");

            Console.Write("Минимальная цена: ");
            minPrice = Convert.ToDouble(Console.ReadLine());
            Console.Write("Максимальная цена: ");
            maxPrice = Convert.ToDouble(Console.ReadLine());

            for (int i = 0; i < computers.Count; i++)
            {
                if (computers[i].Price >= minPrice && computers[i].Price <= maxPrice)
                {
                    table.AddRow(computers[i].Id, computers[i].Name, computers[i].GraphicCart, computers[i].CPU, computers[i].OperationMemory, computers[i].Price);
                    bookAvailable = true;
                }
            }

            if (bookAvailable)
            {
                table.Print();
            }
            else
            {
                Console.WriteLine("Товар в данном диапозоне отсутствуюет");
            }

            Console.ReadLine();
        }
    }
}

