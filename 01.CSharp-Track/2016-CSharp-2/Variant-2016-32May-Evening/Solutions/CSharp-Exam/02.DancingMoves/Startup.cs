using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        bool exit = true;
        double currSum = 0;
        double sum = 0;
        int startIndex = 0;
        double numberOfMoves = 0;

        while (exit)
        {
            string movesString = Console.ReadLine();

            if (movesString == "stop")
            {
                exit = false;
                break;
            }
            numberOfMoves++;
            string[] movesArr = movesString.Split(' ').ToArray();
            int count = int.Parse(movesArr[0]);
            int step = int.Parse(movesArr[2]);
            int counter = 0;
            if (movesArr[1] == "right")
            {
                for (int i = startIndex + step; counter < count; i += step)
                {
                    if (i >= array.Length)
                    {
                        i = array.Length - i;
                    }

                    currSum += array[i];
                    startIndex = i;
                    counter++;
                }

                sum += currSum;
                currSum = 0;
            }
            else if (movesArr[1] == "left")
            {
                for (int i = startIndex - step; counter < count; i -= step)
                {
                    if (i < 0)
                    {
                        i = array.Length - startIndex - step;
                        startIndex = array.Length;
                    }

                    currSum += array[i];
                    startIndex -= step;
                    counter++;
                }
                sum += currSum;
                currSum = 0;
            }
        }
        Console.WriteLine("{0:F1}", sum / numberOfMoves );
    }
}