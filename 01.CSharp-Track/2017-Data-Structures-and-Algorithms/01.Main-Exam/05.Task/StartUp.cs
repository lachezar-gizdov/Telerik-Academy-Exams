using System;
using System.Collections.Generic;
using System.Linq;

namespace CokiSkoki
{
    public class StartUp
    {
        private static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            MaxJumps(nums);
        }

        private static void MaxJumps(int[] nums)
        {
            var tempList = new List<int>();
            var jumps = new List<int>();
            for (var index = 0; index < nums.Length - 1; index++)
            {
                var currentNum = nums[index];
                for (var j = 1 + index; j < nums.Length; j++)
                {
                    var nextNum = nums[j];

                    if (currentNum >= nextNum)
                    {
                        continue;
                    }

                    tempList.Add(nextNum);
                    currentNum = nextNum;
                }

                jumps.Add(tempList.Count);
                tempList.Clear();
            }
            Console.WriteLine(jumps.Max());
            jumps.Add(0);
            Console.WriteLine(string.Join(" ", jumps));
        }
    }
}
