using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem5
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> numbers = new List<int>();
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (input == "-1 -1")
                {
                    break;
                }

                string combined = input.Replace(" ", string.Empty);
                numbers.Add(int.Parse(combined));
            }

            numbers.Sort();
            int index = 0;

            while (index < numbers.Count - 1)
            {
                int number = numbers[index];
                int[] result = number.ToString().Select(o => Convert.ToInt32(o)).ToArray();
                int output = result
                                .Select((t, i) => t * Convert.ToInt32(Math.Pow(10, result.Length - i - 1)))
                                .Sum();

                if (numbers[index] == numbers[index + 1] || numbers[index] == output)
                {
                    numbers.RemoveAt(index);
                }
                else
                    index++;
                count++;
            }

            Console.WriteLine(count);
        }
    }
}
