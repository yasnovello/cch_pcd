using System;
using System.Collections.Generic;
using System.Threading;
namespace ConcurrentCollections
{
    class Program
    {
        static Dictionary<int, string> dictionary = new Dictionary<int, string>();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(Method1);
            Thread t2 = new Thread(Method2);
            t1.Start();
            t2.Start();

            Console.ReadKey();
        }

        public static void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                dictionary.Add(i, "Added By Method1 " + i);
                Thread.Sleep(100);
            }
        }

        public static void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                dictionary.Add(i, "Added By Method2 " + i);
                Thread.Sleep(100);
            }
        }
    }
}