using System;
using System.Threading;
using static System.Threading.Thread;
using static System.Console;

namespace Conc02
{
    class Program
    {
        static void PrintNumbers1()
        {
            WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                WriteLine($"1 second delay: {i}");
                Sleep(TimeSpan.FromSeconds(1));
            }
        }

        static void PrintNumbers2()
        {
            WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                WriteLine($"2 second delay: {i}");
                Sleep(TimeSpan.FromSeconds(2));
            }
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(PrintNumbers1);
            t1.Start();
            Thread t2 = new Thread(PrintNumbers2);
            t2.Start();


            WriteLine("All threads done. Now it's my turn");
            PrintNumbers1();
        }
    }
}

