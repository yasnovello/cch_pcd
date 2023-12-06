using System;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ConcurrentCollections
{
    class Program
    {
        static ConcurrentDictionary<int, string> dictionary = new ConcurrentDictionary<int, string>();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(Method1);
            Thread t2 = new Thread(Method2);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            foreach (KeyValuePair<int, string> item in dictionary)
            {
                Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
            }

            Console.ReadKey();
        }

        public static void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                dictionary.TryAdd(i, "Added By Method1 " + i);
                Thread.Sleep(100);
            }
        }

        public static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                dictionary.TryAdd(i, "Added By Method2 " + i);
                Thread.Sleep(100);
            }
        }
    }
}