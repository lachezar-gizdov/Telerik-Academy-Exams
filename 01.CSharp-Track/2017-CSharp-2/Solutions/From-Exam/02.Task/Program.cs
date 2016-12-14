using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        long[] hands = new long[n];

        for (int i = 0; i < n; i++)
        {
            hands[i] = long.Parse(Console.ReadLine());
        }

        string binary = Convert.ToString(hands[0], 2);
        string binary1 = Convert.ToString(hands[1], 2);
        string binary2 = Convert.ToString(hands[2], 2);

        Console.WriteLine(binary);
        Console.WriteLine(binary1.PadLeft(52, '0'));
        Console.WriteLine(binary2);
    }
}