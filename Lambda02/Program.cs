using System;
using System.Threading;
using static System.Console;

namespace Lambda02
{
    class Program
    {

        static void Main(string[] args)
        {
            int f2(int x) => x * 2;
            WriteLine(f2(3));

            Func<int, int> f3 = (int x) =>
            {
                WriteLine("Hej hej");
                return x * 2;
            };

            WriteLine(f3(6));

            Thread t = new Thread(() => 
            {
                for(int i = 0; i < 10; i++)
                {
                    WriteLine(i);
                }
            });
            t.Start();
            t.Join();
            WriteLine("Done");
        }
    }
}
