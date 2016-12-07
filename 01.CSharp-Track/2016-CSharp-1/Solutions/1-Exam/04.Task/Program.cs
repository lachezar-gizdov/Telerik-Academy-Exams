using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        int n = int.Parse(Console.ReadLine());
        char c = char.Parse(Console.ReadLine());

        for (int i = 0; i < c; i++)
        {
            
            for (int j = 0; j < c; j++)
            {
                Console.Write(c);
            }
            Console.Write(" ");
        }
    }
}