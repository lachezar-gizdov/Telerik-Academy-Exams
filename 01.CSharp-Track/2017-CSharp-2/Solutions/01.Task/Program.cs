using System;
using System.Linq;

class Program
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);

        string[] numSystem = new string[] { "ocaml", "haskell", "scala", "f#", "lisp",
                                            "rust", "ml", "clojure", "erlang", "standardml",
                                            "racket", "elm", "mercury", "commonlisp", "scheme",
                                            "curry" };

        long sum = 1;
        int index = 0;

        //haskell scheme, scala erlang, scala
        //      1 14          2 8       2


        for (int i = 0; i < inputArr.Length; i++)
        {
            for (int j = 0; j < numSystem.Length; j++)
            {
                //if (inputArr[i].IndexOf(numSystem[j]) != -1)
                if(inputArr[i] == numSystem[j])
                {
                    index = j;

                    inputArr[i] = inputArr[i].Replace(numSystem[j], index.ToString());
                }
            }
        }

        for (int i = 0; i < inputArr.Length; i++)
        {
            for (int j = 0; j < numSystem.Length; j++)
            {
                if (inputArr[i].IndexOf(numSystem[j]) != -1)
                {
                    index = j;

                    inputArr[i] = inputArr[i].Replace(numSystem[j], index.ToString());
                }
            }
        }

        for (int i = 0; i < inputArr.Length; i++)
        {
            long num = Int64.Parse(inputArr[i], System.Globalization.NumberStyles.HexNumber);

            sum *= num;
        }

        Console.WriteLine(sum);
    }
}