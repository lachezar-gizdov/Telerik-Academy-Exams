using System;

class Feathers
{
    static void Main()
    {
        double birdsCount = double.Parse(Console.ReadLine());
        double feathersCount = double.Parse(Console.ReadLine());
        double avgFeathers = feathersCount / birdsCount;
        double result = 0;

        if (birdsCount != 0)
        {
            if (birdsCount % 2 == 0)
            {
                result = avgFeathers * 123123123123;
            }
            else
            {
                result = avgFeathers / 317;
            }
            Console.WriteLine("{0:F4}", result);
        }
        else
        {
            Console.WriteLine("{0:F4}", birdsCount);
        }

    }
}