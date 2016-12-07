using System;

class Startup
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }

        int result = 0;

        for (int i = 0; i < n - 1; i++)
        {
            result = (array[i] % 10) * (array[i + 1] / 10);

            Console.Write("{0} ", result);

        }
        Console.WriteLine();

        for (int i = 0; i < n - 1; i++)
        {
            result = array[i] - array[i + 1];
            Console.Write("{0} ", Math.Abs(result));
        }
        Console.WriteLine();

    }
}