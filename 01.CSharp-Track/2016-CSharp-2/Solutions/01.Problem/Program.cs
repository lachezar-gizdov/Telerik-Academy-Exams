using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Problem
{
    class Program
    {
        static void Main()
        {

            var firstInput = Console.ReadLine();
            char operation = char.Parse(Console.ReadLine());
            var secondInput = Console.ReadLine();
            BigInteger sum = 0;
            BigInteger sum2 = 0;

            foreach (char digit in firstInput)
            {
                sum = (digit - 'a') + sum * 26;
            }
            foreach (char digit in secondInput)
            {
                sum2 = (digit - '0') + sum2 * 7;
            }

            BigInteger result = 0;

            if (operation == '+')
            {
                result = sum + sum2;
            }
            else
            {
                result = sum - sum2;
            }

            BigInteger result1 = 0;

            string bin = String.Empty;

            while (result != 0)
            {
                result1 = result % 9;
                bin = result1 + bin;
                result = result / 9;
            }

            Console.WriteLine(bin);
        }
    }
}
