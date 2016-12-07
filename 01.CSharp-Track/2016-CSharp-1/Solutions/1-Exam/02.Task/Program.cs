using System;
using System.Collections;
using System.Linq;

class Program
{
    static void Main()
    {
        int c = int.Parse(Console.ReadLine());
        int[] arr = new int[c];
        int count = 1;

        for (int i = 0; i <= arr.Length - 1; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i + 1])
            {
                count++;
            }
            if (arr[i] == arr[i + 1])
            {
                count--;
            }
        }
        if (count < 0)
        {
            count = c;
        }
        Console.WriteLine(count);
    }
}