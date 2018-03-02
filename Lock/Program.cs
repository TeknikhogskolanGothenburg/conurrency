using System;
using System.Threading;
using static System.Threading.Thread;
using static System.Console;

namespace DataRace
{
    class Program
    {
        static private int count;
        static private object countLock = new object();

        static void Increment()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock(countLock)
                {
                    count++;
                }
            }
        }

        static void Decrement()
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (countLock)
                {
                    count--;
                }
            }
        }

        static void Main(string[] args)
        {
            count = 0;
            Thread t1 = new Thread(Increment);
            Thread t2 = new Thread(Decrement);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            WriteLine(count);
        }
    }
}
