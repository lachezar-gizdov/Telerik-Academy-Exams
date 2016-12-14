using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split('x').Select(int.Parse).ToArray();
        int row = dimensions[0];
        int col = dimensions[1];
        int snackyLenght = 3;

        char[,] matrix = new char[row, col];

        for (int i = 0; i < row; i++)
        {
            char[] input = Console.ReadLine().ToCharArray();

            for (int j = 0; j < col; j++)
            {
                matrix[i, j] = input[j];
            }
        }

        string[] rout = Console.ReadLine().Split(',').ToArray();
        int rowIndex = 0;
        int colIndex = 0;

        for (int i = 0; i < row; i++)
        {
            if (matrix[0, i] == 's')
            {
                colIndex = i;
                break;
            }
        }

        for (int i = 0; i < rout.Length; i++)
        {
            if (rout[i] == "d")
            {
                rowIndex++;

                if (rowIndex >= row)
                {
                    Console.WriteLine("Snacky will be lost into the depths with length {0}", snackyLenght);
                    break;
                }

                if (matrix[rowIndex, colIndex] == '*')
                {
                    snackyLenght++;
                    matrix[rowIndex, colIndex] = '.';
                }
            }

            if (rout[i] == "u")
            {
                rowIndex--;

                if (matrix[rowIndex, colIndex] == '*')
                {
                    snackyLenght++;
                    matrix[rowIndex, colIndex] = '.';
                }
            }

            if (rout[i] == "l")
            {
                colIndex--;

                if (colIndex < 0)
                {
                    colIndex = col - Math.Abs(colIndex);
                }

                if (matrix[rowIndex, colIndex] == '*')
                {
                    snackyLenght++;
                    matrix[rowIndex, colIndex] = '.';
                }
            }

            if (rout[i] == "r")
            {
                colIndex++;

                if (colIndex > col)
                {
                    colIndex = col - Math.Abs(colIndex);
                }

                if (matrix[rowIndex, colIndex] == '*')
                {
                    snackyLenght++;
                    matrix[rowIndex, colIndex] = '.';
                }
            }

            if ((i + 1) % 5 == 0)
            {
                snackyLenght--;
            }

            if (matrix[rowIndex, colIndex] == '#')
            {
                Console.WriteLine("Snacky will hit a rock at [{0},{1}]", rowIndex, colIndex);
                break;
            }

            if (snackyLenght <= 0)
            {
                Console.WriteLine("Snacky will starve at [{0},{1}]", rowIndex, colIndex);
                break;
            }

            if (matrix[rowIndex, colIndex] == 's')
            {
                Console.WriteLine("Snacky will get out with length {0}", snackyLenght);
                break;
            }

            if (i == rout.Length - 1)
            {
                Console.WriteLine("Snacky will be stuck in the den at [{0},{1}]", rowIndex, colIndex);
            }
        }

    }
}