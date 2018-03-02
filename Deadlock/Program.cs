using System;
using System.Threading;
using static System.Threading.Thread;
using static System.Console;

namespace Deadlock
{
    class Program
    {
        static void Main(string[] args)
        {
            object lock1 = new object();
            object lock2 = new object();

            Thread t1 = new Thread(() =>
            {
                lock(lock1)
                {
                    Sleep(TimeSpan.FromSeconds(1));
                    if(Monitor.TryEnter(lock2,TimeSpan.FromSeconds(5)))
                    {
                        WriteLine("Inside t1");
                    }
                    else
                    {
                        WriteLine("I give up... Let's go home!");
                    }
                }
            });

            Thread t2 = new Thread(() =>
            {
                lock (lock2)
                {
                    Sleep(TimeSpan.FromSeconds(1));
                    lock (lock1)
                    {
                        WriteLine("Inside t2");
                    }
                }
            });
            WriteLine("Entering deadlock. Nothing can get us out of here!");
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            WriteLine("Done");
        }
    }
}
