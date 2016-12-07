using System;
using System.Numerics;

class Program
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        long sum = 9;

        if (n < 10)
        {
            sum = n;
            Console.WriteLine(sum);
        }
        else if (n < 100 && n >= 10)
        {
            for (long i = 10; i <= n; i++)
            {
                sum += 2;
            }
            Console.WriteLine(sum);
        }
        else if (n < 1000 && n >= 100)
        {
            for (long i = 11; i <= 100; i++)
            {
                sum += 2;
            }

            for (long i = 100; i <= n; i++)
            {
                sum += 3;
            }
            Console.WriteLine(sum);
        }

        else if (n < 10000 && n >= 1000)
        {
            for (long i = 10; i < 100; i++)
            {
                sum += 2;
            }

            for (long i = 100; i < 1000; i++)
            {
                sum += 3;
            }

            for (long i = 1000; i <= n; i++)
            {
                sum += 4;
            }
            Console.WriteLine(sum);
        }

        else if (n < 100000 && n >= 10000)
        {
            for (long i = 10; i < 100; i++)
            {
                sum += 2;
            }

            for (long i = 100; i < 1000; i++)
            {
                sum += 3;
            }

            for (long i = 1000; i < 10000; i++)
            {
                sum += 4;
            }
            for (long i = 10000; i <= n; i++)
            {
                sum += 5;
            }
            Console.WriteLine(sum);
        }
        else if (n < 1000000 && n >= 100000)
        {
            for (long i = 10; i < 100; i++)
            {
                sum += 2;
            }

            for (long i = 100; i < 1000; i++)
            {
                sum += 3;
            }

            for (long i = 1000; i < 10000; i++)
            {
                sum += 4;
            }
            for (long i = 10000; i < 100000; i++)
            {
                sum += 5;
            }
            for (long i = 100000; i <= n; i++)
            {
                sum += 6;
            }
            Console.WriteLine(sum);
        }
    }
}