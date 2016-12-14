using System;

class Dealer
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        ulong[] hands = new ulong[n];
        ulong maxValue = 4503599627370495UL;
        ulong or = 0;
        ulong xor = 0;

        string[] cards = { "As", "Ks", "Qs", "Js", "Ts", "9s", "8s", "7s", "6s", "5s", "4s", "3s", "2s",
                               "Ah", "Kh", "Qh", "Jh", "Th", "9h", "8h", "7h", "6h", "5h", "4h", "3h", "2h",
                               "Ad", "Kd", "Qd", "Jd", "Td", "9d", "8d", "7d", "6d", "5d", "4d", "3d", "2d",
                               "Ac", "Kc", "Qc", "Jc", "Tc", "9c", "8c", "7c", "6c", "5c", "4c", "3c", "2c", };

        for (int i = 0; i < n; i++)
        {
            hands[i] = ulong.Parse(Console.ReadLine());
            or = or | hands[i];
            xor = xor ^ hands[i];
        }

        if (or == maxValue)
        {
            Console.WriteLine("Full deck");
        }
        else
        {
            Console.WriteLine("Wa wa!");
        }

        string printCopies = Convert.ToString((long)xor, 2).PadLeft(52, '0');

        for (int i = printCopies.Length - 1; i >= 0; i--)
        {

            if (printCopies[i] == '0')
            {
                Console.Write("{0} ", cards[i]);
            }
        }
        Console.WriteLine();
    }
}