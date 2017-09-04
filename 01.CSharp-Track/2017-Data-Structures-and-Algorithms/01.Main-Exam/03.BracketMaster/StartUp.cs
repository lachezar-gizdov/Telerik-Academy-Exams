using System;

namespace BracketMaster
{
    public class StartUp
    {
        public static void Main()
        {
            uint n = uint.Parse(Console.ReadLine());

            // Solution 1 for 20/100 @BGCoder
            Console.WriteLine(FindWays(n));
        }

        private static long FindWays(uint n)
        {
            if ((n & 1) != 0)
            {
                return 0;
            }

            return Catalan(n / 2);
        }

        private static long Catalan(uint n)
        {
            long c = BinomialCoeff(2 * n, n);
            return c / (n + 1);
        }

        private static long BinomialCoeff(uint n, uint k)
        {
            long res = 1;

            if (k > n - k)
            {
                k = n - k;
            }

            for (int i = 0; i < k; ++i)
            {
                res *= (n - i);
                res /= (i + 1);
            }

            return res;
        }
    }
}