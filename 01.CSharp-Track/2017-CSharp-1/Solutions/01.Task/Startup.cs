using System;

class Startup
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());
        int thirdDigit = input % 10;
        int firstDigit = input / 100;
        int secondDigit = (input / 10) % 10;
        double result = 1;

        if (thirdDigit == 0)
        {
            result = firstDigit * secondDigit;
        }
        else if (thirdDigit > 0 && thirdDigit <= 5)
        {
            result = ((double)firstDigit * (double)secondDigit) / (double)thirdDigit;
        }
        else if (thirdDigit > 5)
        {
            result = ((double)firstDigit + (double)secondDigit) * (double)thirdDigit;
        }

        Console.WriteLine("{0:F2}", result);
    }
}