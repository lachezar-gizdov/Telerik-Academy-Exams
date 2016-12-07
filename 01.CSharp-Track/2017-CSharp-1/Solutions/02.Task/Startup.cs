using System;

class Startup
{
    static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();

        for (int i = 0; i < input.Length;)
        {
            if (input[i] == '^')
            {
                Console.WriteLine("Jump, Jump, DJ Tomekk kommt at {0}!", i);
                break;
            }

            if ((input[i] - '0') % 2 == 0)
            {
                i += (input[i] - '0');
                if (i < 0 || i >= input.Length)
                {
                    Console.WriteLine("Fell off the dancefloor at {0}!", i);
                    break;
                }
            }
            if ((input[i] - '0') % 2 != 0)
            {
                i -= (input[i] - '0');
                if (i < 0 || i >= input.Length)
                {
                    Console.WriteLine("Fell off the dancefloor at {0}!", i);
                    break;
                }
            }

            else if (input[i] - '0' == 0)
            {
                Console.WriteLine("Too drunk to go on after {0}!", i);
                break;
            }
        }
    }
}