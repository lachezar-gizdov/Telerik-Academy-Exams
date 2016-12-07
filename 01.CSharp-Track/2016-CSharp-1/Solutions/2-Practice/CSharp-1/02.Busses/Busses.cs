using System;

class Busses
{
    static void Main()
    {
        int busCount = int.Parse(Console.ReadLine());
        int[] bussesSpeeds = new int[busCount];
        int groups = 1;
        int currBusSpeed = 0;
        int nextBusSpeed = 0;

        currBusSpeed = int.Parse(Console.ReadLine());

        for (int i = 1; i < busCount; i++)
        {
            nextBusSpeed = int.Parse(Console.ReadLine());
            if (currBusSpeed < nextBusSpeed)
            {
                continue;
            }
            else
            {
                currBusSpeed = nextBusSpeed;
                groups++;
            }
        }

        //Console.WriteLine("Groups: {0}", groups);
        Console.WriteLine(groups);
    }
}
