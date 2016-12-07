using System;
using System.Collections.Generic;
using System.Numerics;

class OneSystemToAnyOther
{ 
    static void Main()
    {
        string hex = Console.ReadLine();
        long num = Int64.Parse(hex, System.Globalization.NumberStyles.HexNumber);
        Console.WriteLine(num);
    }

    
}