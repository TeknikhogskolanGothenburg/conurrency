using System;
using System.Threading;
using static System.Console;

namespace Conc01
{
    class Program
    {
        static void PrintNumbers()
        {
            WriteLine("Starting...");
            for(int i = 0; i < 10; i++)
            {
                WriteLine(i);
            }
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(PrintNumbers);
            t.Start();
            PrintNumbers();
        }
    }
}
