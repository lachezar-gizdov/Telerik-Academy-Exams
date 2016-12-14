using System;

class Startup
{
    static void Main()
    {
        string word = Console.ReadLine();
        int n = int.Parse(Console.ReadLine());
        string[] sentences = new string[n];

        for (int i = 0; i < n; i++)
        {
            sentences[i] = Console.ReadLine();
        }

        string jointed = string.Join(" ", sentences);
        string[] splittedByQ = jointed.Split('?');
        string[] splittedByDot = jointed.Split('.');
        string result = "";
        bool choose = true;
        string jointedQ = string.Join(" ", splittedByQ);
        string jointedDot = string.Join(" ", splittedByDot);
        int sum = 0;

        if (jointedQ.IndexOf(word) != -1)
        {
            choose = true;
        }
        else
        {
            choose = false;
        }

        if (choose)
        {
            for (int i = 0; i < splittedByQ.Length; i++)
            {
                if (splittedByQ[i].IndexOf(word) != -1)
                {
                    int index = splittedByQ[i].IndexOf(word);
                    result = splittedByQ[i].Substring(index + word.Length, (splittedByQ[i].Length - index - word.Length)).TrimStart();
                    result = result + "?";
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < splittedByDot.Length; i++)
            {
                if (splittedByDot[i].IndexOf(word) != -1)
                {
                    int index = splittedByDot[i].IndexOf(word);
                    result = splittedByDot[i].Substring(0, splittedByDot[i].Length - index);
                    result = result + "?";
                    break;
                }
            }
        }

        string[] arr2 = result.Split(' ');
        string result2 = string.Join("", arr2).ToUpper();

        char[] arr = result2.ToCharArray();
        for (int i = 0; i < arr.Length - 1; i++)
        {
            sum += arr[i];
        }

        Console.WriteLine(sum);
    }
}