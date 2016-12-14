using System;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine().ToCharArray();
        var path = Console.ReadLine().Split(' ');
        int[] myInts = Array.ConvertAll(path, x => int.Parse(x));
        long souls = 0;
        long food = 0;
        long deadlocks = 0;
        long currIndex = 0;
        long jumps = 0;

        if (input[0] == 'x')
        {
            Console.WriteLine("You are deadlocked, you greedy kitty!");
            Console.WriteLine("Jumps before deadlock: 0");
        }
        else
        {
            foreach (var item in myInts)
            {
                jumps++;
                currIndex += item;

                if (currIndex < 0 || currIndex > input.Length - 1)
                {

                    if (currIndex < 0)
                    {
                        while (currIndex <= 0)
                        {
                            currIndex = input.Length - 2 - currIndex;
                        }
                    }
                    if (currIndex > input.Length - 1)
                    {
                        while (currIndex > input.Length - 1)
                        {
                            currIndex = currIndex - input.Length;
                        }
                    }
                }
                if (input[currIndex] == '@')
                {
                    souls++;
                    input[currIndex] = 'c';
                }
                else if (input[currIndex] == '*')
                {
                    food++;
                    input[currIndex] = 'c';
                }
                else if (input[currIndex] == 'x')
                {
                    deadlocks++;
                    if (currIndex % 2 == 0)
                    {
                        souls--;
                    }
                    else
                    {
                        food--;
                    }
                    if (food < 0 && souls < 0)
                    {
                        Console.WriteLine("You are deadlocked, you greedy kitty!");
                        Console.WriteLine("Jumps before deadlock: " + jumps);
                        break;
                    }
                }
            }
            if (food >= 0 && souls >= 0)
            {
                Console.WriteLine("Coder souls collected: " + souls);
                Console.WriteLine("Food collected: " + food);
                Console.WriteLine("Deadlocks: " + deadlocks);
            }
        }
    }
}
}
