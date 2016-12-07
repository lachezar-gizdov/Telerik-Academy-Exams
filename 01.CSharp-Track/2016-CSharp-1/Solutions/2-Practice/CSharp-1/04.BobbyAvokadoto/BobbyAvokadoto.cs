using System;

class BobbyAvokadoto
{
    static void Main()
    {
        uint head = uint.Parse(Console.ReadLine());
        uint combs = uint.Parse(Console.ReadLine());
        uint bestComb = 0;
        int bestCount = 0;

        for (int i = 0; i < combs; i++)
        {
            uint comb = uint.Parse(Console.ReadLine());

            if ((head & comb) == 0)
            {
                int currentCount = 0;
                for (int j = 0; j < 32; j++)
                {
                    currentCount += (int)((comb >> j) & 1);
                }

                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                    bestComb = comb;
                }
            }
        }
        Console.WriteLine(bestComb);
    }
}
