using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        double b = double.Parse(Console.ReadLine());
        double f = double.Parse(Console.ReadLine());
        double average = f / b;


        if (b % 2 == 0)
        {
            double result = average * 123123123123;
            Console.WriteLine("{0:F4}", result);
        }
        else
        {
            double result = average / 317;
            Console.WriteLine("{0:F4}", result);
        }
        
    }
}