using System;
using static System.Console;

namespace Lambda01
{
    class Program
    {
        static Func<int, double> FuncFactory(int p)
        {
            double Inner(int b)
            {
                return Math.Pow(b, p);
            }
            return Inner;
        }

        static void Main(string[] args)
        {
            var Square = FuncFactory(2);
            WriteLine(Square(3));
            WriteLine(Square(4));
            WriteLine(Square(5));

            var Cube = FuncFactory(3);
            WriteLine(Cube(3));
            WriteLine(Cube(4));
            WriteLine(Cube(5));

            WriteLine(Square(3));
            WriteLine(Square(4));
            WriteLine(Square(5));
        }
    }
}
