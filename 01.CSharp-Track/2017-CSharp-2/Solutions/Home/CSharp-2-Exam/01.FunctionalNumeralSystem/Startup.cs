using System;
using System.Linq;
using System.Numerics;

class Starup
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Replace("ocaml", "0")
                                              .Replace("haskell", "1")
                                              .Replace("scala", "2")
                                              .Replace("f#", "3")
                                              .Replace("rust", "5")
                                              .Replace("clojure", "7")
                                              .Replace("erlang", "8")
                                              .Replace("standardml", "9")
                                              .Replace("racket", "A")
                                              .Replace("mercury", "C")
                                              .Replace("commonlisp", "D")
                                              .Replace("scheme", "E")
                                              .Replace("curry", "F")
                                              .Replace("lisp", "4")
                                              .Replace("ml", "6")
                                              .Replace("elm", "B").Split(new[] { ", " }, StringSplitOptions.None).ToArray();
        BigInteger sum = 1;

        for (int i = 0; i < inputArr.Length; i++)
        {
            BigInteger temp = (BigInteger)Convert.ToUInt64(inputArr[i], 16);

            sum *= temp;
        }

        Console.WriteLine(sum);
    }
}