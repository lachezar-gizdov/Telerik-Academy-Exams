using System;

namespace WoodenBoard
{
    public class StartUp
    {
        public static void Main()
        {
            var word = Console.ReadLine();
            var shortestPalindrome = GetShortestPalindrome(word);

            Console.WriteLine(shortestPalindrome.Length - word.Length);
        }

        private static char[] GetShortestPalindrome(string wordInput)
        {
            var word = wordInput.ToCharArray();
            var len = word.Length;
            var doublePlusSentinelLen = (len << 1) + 1;

            const char sentinel = (char)8;
            var reversedWord = Reverse(word);
            var palindromicBase = new char[doublePlusSentinelLen];

            Array.Copy(reversedWord, 0, palindromicBase, 0, len);
            palindromicBase[len] = sentinel;
            Array.Copy(word, 0, palindromicBase, len + 1, len);

            var table = new int[doublePlusSentinelLen + 1];
            computeTable(table, doublePlusSentinelLen, palindromicBase);

            var longestPalindromicSuffix = Math.Min(len, table[doublePlusSentinelLen]);
            var numCharsToAppend = len - longestPalindromicSuffix;
            var shortestPalindromeLen = len + numCharsToAppend;
            var shortestPalindrome = new char[shortestPalindromeLen];

            for (var i = 0; i < len; i++)
            {
                shortestPalindrome[i] = word[i];
            }

            for (int i = len, j = 0; i < shortestPalindromeLen; i++, j++)
            {
                shortestPalindrome[i] = word[numCharsToAppend - j - 1];
            }

            return shortestPalindrome;
        }

        private static void computeTable(int[] table, int len, char[] word)
        {
            table[0] = -1;

            for (var i = 0; i < len; ++i)
            {
                var k = table[i];

                while (k >= 0 && word[k] != word[i])
                {
                    k = table[k];
                }

                table[i + 1] = k + 1;
            }
        }

        private static char[] Reverse(char[] text)
        {
            var len = text.Length;
            var str = new char[len];
            Array.Copy(text, 0, str, 0, len);

            for (int leftIndex = 0, rightIndex = len - 1; leftIndex < rightIndex; leftIndex++, rightIndex--)
            {
                Swap(str, leftIndex, rightIndex);
            }

            return str;
        }

        private static void Swap(char[] array, int index1, int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}