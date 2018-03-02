using System;
using System.Threading;
using static System.Threading.Thread;
using static System.Console;

namespace Conc03
{
    class Program
    {
        static void PrintNumbers()
        {
            WriteLine("Starting...");
            for (int i = 0; i < 10; i++)
            {
                WriteLine(i);
                Sleep(TimeSpan.FromSeconds(1));
            }
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(PrintNumbers);
            t.Start();

            Sleep(TimeSpan.FromSeconds(3));
            t.Abort();
            WriteLine("Aborting thread");

            WriteLine("Restarting thread");
            t = new Thread(PrintNumbers);
            t.Start();

            PrintNumbers();
        }
    }
}
