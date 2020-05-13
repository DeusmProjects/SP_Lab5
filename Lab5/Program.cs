using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lab5
{
    internal class Program
    {
        private const int COUNT_ELEMENTS = 200;
        private const int STRING_LENGTH = 32;

        private static Random _rnd;
        private static Stopwatch _sw;

        private static void Main(string[] args)
        {
            _sw = new Stopwatch();
            _rnd = new Random();

            List<string> items = Enumerable.Range(0, COUNT_ELEMENTS).Select(i => RandomString(STRING_LENGTH)).ToList();
            HashFunction.CountElements = COUNT_ELEMENTS;

            List<IHashTable> tables = new List<IHashTable>()
            {
                new ChainsTable(COUNT_ELEMENTS),
                new OrderListTable(COUNT_ELEMENTS)
            };

            tables.ForEach(table =>
            {
                _sw.Start();
                    items.ForEach(table.Put);
                _sw.Stop();
                var addTime = _sw.ElapsedMilliseconds.ToString();
                Console.WriteLine("{0}:", table.Name);
                Console.WriteLine("Добавление {0} элементов = {1}ms", COUNT_ELEMENTS, addTime);
                _sw.Reset();

                _sw.Start();
                    table.Contains(items[_rnd.Next(0, items.Count - 1)]);
                _sw.Stop();
                var containsTime = _sw.ElapsedMilliseconds.ToString();
                Console.WriteLine("Доступ к элементу = {0}ms", containsTime);
                _sw.Reset();

                Console.WriteLine("_________________");
            });

            Console.ReadKey();
        }

        private static string RandomString(int length)
        {
            return string.Join("", Enumerable.Range(0, length).Select(i => (char)_rnd.Next(97, 122)));
        }
    }
}
