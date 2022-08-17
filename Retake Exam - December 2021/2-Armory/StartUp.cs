using System;
using System.Drawing;

namespace TruffleHunter
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n,n];

            for (int row = 0; row < n; row++)
            {
                char[] currRow = Console.ReadLine().Replace(" ", string.Empty).ToCharArray();
                for (int i = 0; i < n; i++)
                {
                    matrix[row, i] = currRow[i];
                }
            }

            int countBlack = 0;
            int countWhite = 0;
            int countSummer = 0;
            int eatenCount = 0;

            string command = Console.ReadLine();

            while (command != "Stop the hunt")
            {
                string commandName = command.Split()[0];
                int row = int.Parse(command.Split()[1]);
                int col = int.Parse(command.Split()[2]);

                if (commandName == "Collect")
                {
                    char truffel = matrix[row, col];

                    matrix[row, col] = '-';

                    switch (truffel)
                    {
                        case 'B':
                            countBlack++;
                            break;
                        case 'W':
                            countWhite++;
                            break;
                        case 'S':
                            countSummer++;
                            break;
                    }

                }
                else if (commandName == "Wild_Boar")
                {
                    string direction = command.Split()[3];

                    switch (direction)
                    {
                        case "up":
                            while (isValidRow(row, n))
                            {
                                if (BoarEat(row, col, matrix))
                                {
                                    eatenCount++;
                                }

                                row -= 2;
                            }
                            break;
                        case "down":
                            while (isValidRow(row, n))
                            {
                                if (BoarEat(row, col, matrix))
                                {
                                    eatenCount++;
                                }

                                row += 2;
                            }
                            break;
                        case "left":
                            while (isValidCol(col, n))
                            {
                                if (BoarEat(row, col, matrix))
                                {
                                    eatenCount++;
                                }

                                col -= 2;
                            }
                            break;
                        case "right":
                            while (isValidCol(col, n))
                            {
                                if (BoarEat(row, col, matrix))
                                {
                                    eatenCount++;
                                }

                                col += 2;
                            }
                            break;
                    }
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {countBlack} black, {countSummer} summer, and {countWhite} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenCount} truffles.");

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool BoarEat(int row, int col, char[,] matrix)
        {
            var currSymbol = matrix[row, col];
            if (currSymbol == 'S' || currSymbol == 'B' || currSymbol == 'W')
            {
                matrix[row, col] = '-';
                return true;
            }
            return false;
        }

        public static bool isValidRow(int row, int size)
        {
            return row >= 0 && row < size;
        }
        public static bool isValidCol(int col, int size)
        {
            return col >= 0 && col < size;
        }
    }
}
