using System;
using System.Collections;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        string nBits = Convert.ToString(n, 2);

        for (int i = 0; i < c; i++)
        {
            int comb = int.Parse(Console.ReadLine());
            string combBits = Convert.ToString(comb, 2);

            Console.WriteLine(comb);

            for (int j = 1; j < nBits.Length; j++)
            {

            }
        }
    }
}
