using System;

class Startup
{
    static void Main()
    {
        string result = string.Empty;
        while (true)
        {
            string startIndex2 = Console.ReadLine();
            if (startIndex2 == "end")
            {
                break;
            }
            else
            {
                int startIndex = int.Parse(startIndex2);
                string end = String.Empty;
                int skip = int.Parse(Console.ReadLine());
                char[] inputString = Console.ReadLine().ToCharArray();

                if (skip < 0)
                {
                    for (int i = startIndex; i >= 0;)
                    {
                        string temp = inputString[i].ToString();
                        result = result + temp;
                        i -= Math.Abs(skip);
                    }
                }

                else if (startIndex >= 0)
                {
                    for (int i = startIndex; i < inputString.Length;)
                    {
                        string temp = inputString[i].ToString();
                        result = result + temp;
                        i += skip;
                    }
                }
                else
                {
                    for (int i = inputString.Length - Math.Abs(startIndex); i < inputString.Length;)
                    {
                        string temp = inputString[i].ToString();
                        result = result + temp;
                        i += skip;
                    }
                }
                if (startIndex < 0 && skip < 0)
                {
                    for (int i = inputString.Length - Math.Abs(startIndex); i >= 0;)
                    {
                        string temp = inputString[i].ToString();
                        result = result + temp;
                        i -= Math.Abs(skip);
                    }
                }
                
            }
        }
        Console.WriteLine(result);
    }
}