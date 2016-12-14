using System;
using System.Numerics;

class Startup
{
    static void Main()
    {
        string[] input = new string[3];

        for (int i = 0; i < input.Length; i++)
        {
            input[i] = Console.ReadLine().Replace("cad", "0")
                                            .Replace("xoz", "1")
                                            .Replace("nop", "2")
                                            .Replace("cyk", "3")
                                            .Replace("min", "4")
                                            .Replace("mar", "5")
                                            .Replace("kon", "6")
                                            .Replace("iva", "7")
                                            .Replace("ogi", "8")
                                            .Replace("yan", "9");
        }

        BigInteger result = 0;
        BigInteger firstNum = BigInteger.Parse(input[0]);
        BigInteger secondNum = BigInteger.Parse(input[2]);

        if (input[1] == "+")
        {
            result = firstNum + secondNum;
        }
        else
        {
            result = firstNum - secondNum;
        }

        string res = result.ToString().Replace("0", "cad")
                                      .Replace("1", "xoz")
                                      .Replace("2", "nop")
                                      .Replace("3", "cyk")
                                      .Replace("4", "min")
                                      .Replace("5", "mar")
                                      .Replace("6", "kon")
                                      .Replace("7", "iva")
                                      .Replace("8", "ogi")
                                      .Replace("9", "yan");

        Console.WriteLine(res);
    }
}