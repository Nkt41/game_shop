using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game_shop
{
    class Table
    {
        readonly string[] titles;
        readonly List<int> lengths;
        readonly List<string[]> rows = new List<string[]>();

        public Table(params string[] titles)
        {
            this.titles = titles;
            lengths = titles.Select(t => t.Length).ToList();
        }

        public void AddRow(params object[] row)
        {
            try
            {
                if (row.Length != titles.Length)
                {
                    throw new Exception($"Added row length [{row.Length}] is not equal to title row length [{titles.Length}]");
                }
                rows.Add(row.Select(o => o.ToString()).ToArray());
                for (int i = 0; i < titles.Length; i++)
                {
                    if (rows.Last()[i].Length > lengths[i])
                    {
                        lengths[i] = rows.Last()[i].Length;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Print()
        {
            lengths.ForEach(l => Console.Write("+-" + new string('-', l) + '-'));
            Console.WriteLine("+");

            string line = "";
            for (int i = 0; i < titles.Length; i++)
            {
                line += "| " + titles[i].PadRight(lengths[i]) + ' ';
            }
            Console.WriteLine(line + "|");

            lengths.ForEach(l => Console.Write("+-" + new string('-', l) + '-'));
            Console.WriteLine("+");

            foreach (var row in rows)
            {
                line = "";
                for (int i = 0; i < row.Length; i++)
                {
                    if (int.TryParse(row[i], out int n))
                    {
                        line += "| " + row[i].PadLeft(lengths[i]) + ' ';
                    }
                    else
                    {
                        line += "| " + row[i].PadRight(lengths[i]) + ' ';
                    }
                }
                Console.WriteLine(line + "|");
            }

            lengths.ForEach(l => Console.Write("+-" + new string('-', l) + '-'));
            Console.WriteLine("+");
        }
    }
}
