using System;
using System.Collections.Generic;
using System.Linq;

namespace JungleTrees
{
    public class StartUp
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = input[0];
            int mj = input[1];
            int mh = input[2];

            var dict = new SortedDictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                var tree = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                dict.Add(tree[0], tree[1]);
            }

            int count = 0;
            bool show = false;

            for (int i = 0; i < n - 1; i++)
            {
                int currX = Math.Abs(dict.Keys.ElementAt(i) - dict.Keys.ElementAt(i + 1));
                int currH = Math.Abs(dict.Values.ElementAt(i) - dict.Values.ElementAt(i + 1));

                bool inRageX = Math.Abs(dict.Keys.ElementAt(i) - dict.Keys.ElementAt(i + 1)) <= mj;
                bool inRageH = Math.Abs(dict.Values.ElementAt(i) - dict.Values.ElementAt(i + 1)) <= mh;

                if (inRageX && inRageH)
                {
                    show = true;
                    count++;
                }
                else
                {
                    Console.WriteLine(-1);
                    show = false;
                    break;
                }
            }

            if (show)
            {
                Console.WriteLine(count);
            }
        }
    }
}
