using System;
using System.Collections.Generic;
using System.Text;

namespace game_shop
{
    class Sort
    {
        /// <summary>
        /// Bubble sort
        /// </summary>
        public static void PriceIncrease(List<Computer> computers, List<Pristavka> pristavkas)
        {
            Computer computer;
            Pristavka pristavka;

            int count = computers.Count;

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count - 1; j++)
                {
                    if (computers[j].Price > computers[j + 1].Price)
                    {
                        computer = computers[j];
                        computers[j] = computers[j + 1];
                        computers[j + 1] = computer;

                        pristavka = pristavkas[j];
                        pristavkas[j] = pristavkas[j + 1];
                        pristavkas[j + 1] = pristavka;
                    }
                }
            }
        }
        /// <summary>
        /// Quicksort
        /// </summary>
        public static void PriceDecrease(List<Computer> computers, List<Pristavka> pristavkas, int start, int end)
        {
            Computer computer;
            Pristavka pristavka;

            if (start < end)
            {
                int left = start, right = end;
                double middle = computers[(left + right) / 2].Price;

                do
                {
                    while (computers[left].Price > middle) left++;
                    while (computers[right].Price < middle) right--;

                    if (left <= right)
                    {
                        computer = computers[left];
                        computers[left] = computers[right];
                        computers[right] = computer;

                        pristavka = pristavkas[left];
                        pristavkas[left] = pristavkas[right];
                        pristavkas[right] = pristavka;

                        left++;
                        right--;
                    }
                } while (left <= right);

                PriceDecrease(computers, pristavkas, start, right);
                PriceDecrease(computers, pristavkas, left, end);
            }
        }
        /// <summary>
        /// Shell sort
        /// </summary>
        public static void IdIncrease(List<Computer> computers, List<Pristavka> pristavkas)
        {
            Computer computer;
            Pristavka pristavka;

            int increment = 3, count = computers.Count;

            while (increment > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    int j = i;
                    computer = computers[i];
                    pristavka = pristavkas[i];

                    while ((j >= increment) && (computers[j - increment].Id > computer.Id))
                    {
                        computers[j] = computers[j - increment];
                        pristavkas[j] = pristavkas[j - increment];
                        j -= increment;
                    }
                    computers[j] = computer;
                }

                if (increment > 1)
                    increment /= 2;
                else if (increment == 1)
                    break;
            }
        }

        public static void NameIncrease(List<Computer> computers, List<Pristavka> pristavkas)
        {
            Computer computer;
            Pristavka pristavka;

            for (int i = 0; i < computers.Count; i++)
            {
                for (int j = 0; j < computers.Count - 1; j++)
                {
                    if (IsCheckIncrease(computers[j].Name, computers[j + 1].Name))
                    {
                        computer = computers[j];
                        computers[j] = computers[j + 1];
                        computers[j + 1] = computer;

                        pristavka = pristavkas[j];
                        pristavkas[j] = pristavkas[j + 1];
                        pristavkas[j + 1] = pristavka;
                    }
                }
            }
        }

        protected static bool IsCheckIncrease(string s1, string s2)
        {
            for (int i = 0; i < (s1.Length > s2.Length ? s2.Length : s1.Length); i++)
            {
                if (s1.ToCharArray()[i] < s2.ToCharArray()[i]) return false;
                if (s1.ToCharArray()[i] > s2.ToCharArray()[i]) return true;
            }
            return false;
        }
    }
    
}
