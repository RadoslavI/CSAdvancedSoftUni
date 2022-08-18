using System;

namespace Problem_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];
            int[] startIndex = new int[2];
            int points = 0;
            bool survived = false;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine().ToString();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col].ToString();
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == "M")
                    {
                        startIndex[0] = row;
                        startIndex[1] = col;
                        matrix[row, col] = "-";
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                if (command == "down")
                {
                    if (startIndex[0] + 1 < n)
                    {
                        startIndex[0]++;
                        if (Char.IsDigit(matrix[startIndex[0], startIndex[1]].ToCharArray()[0]))
                        {
                            points += int.Parse(matrix[startIndex[0], startIndex[1]]);
                            matrix[startIndex[0], startIndex[1]] = "-";
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "S")
                        {
                            matrix[startIndex[0], startIndex[1]] = "-";
                            startIndex = findS(matrix, n);
                            matrix[startIndex[0], startIndex[1]] = "-";
                            points -= 3;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
                else if (command == "up")
                {
                    if (startIndex[0] - 1 >= 0)
                    {
                        startIndex[0]--;
                        if (Char.IsDigit(matrix[startIndex[0], startIndex[1]].ToCharArray()[0]))
                        {
                            points += int.Parse(matrix[startIndex[0], startIndex[1]]);
                            matrix[startIndex[0], startIndex[1]] = "-";
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "S")
                        {
                            matrix[startIndex[0], startIndex[1]] = "-";
                            startIndex = findS(matrix, n);
                            matrix[startIndex[0], startIndex[1]] = "-";
                            points -= 3;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
                else if (command == "left")
                {
                    if (startIndex[1] - 1 >= 0)
                        {
                        startIndex[1]--;
                        if (Char.IsDigit(matrix[startIndex[0], startIndex[1]].ToCharArray()[0]))
                        {
                            points += int.Parse(matrix[startIndex[0], startIndex[1]]);
                            matrix[startIndex[0], startIndex[1]] = "-";
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "S")
                        {
                            matrix[startIndex[0], startIndex[1]] = "-";
                            startIndex = findS(matrix, n);
                            matrix[startIndex[0], startIndex[1]] = "-";
                            points -= 3;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }
                else if (command == "right")
                {
                    if (startIndex[1] + 1 < n)
                    {
                        startIndex[1]++;
                        if (Char.IsDigit(matrix[startIndex[0], startIndex[1]].ToCharArray()[0]))
                        {
                            points += int.Parse(matrix[startIndex[0], startIndex[1]]);
                            matrix[startIndex[0], startIndex[1]] = "-";
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "S")
                        {
                            matrix[startIndex[0], startIndex[1]] = "-";
                            startIndex = findS(matrix, n);
                            matrix[startIndex[0], startIndex[1]] = "-";
                            points -= 3;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Don't try to escape the playing field!");
                    }
                }

                if (points >= 25)
                {
                    survived = true;
                    break;
                }

                command = Console.ReadLine();
            }
            matrix[startIndex[0], startIndex[1]] = "M";

            if (survived)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            PrintMatrix(n, matrix);
        }

        private static int[] findS(string[,] matrix, int n)
        {
            int[] index = new int[2];
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == "S")
                    {
                        index[0] = row;
                        index[1] = col;
                    }
                }
            }
            return index;
        }

        public static void PrintMatrix(int lenght, string[,] matrix)
        {
            for (int row = 0; row < lenght; row++)
            {
                for (int col = 0; col < lenght; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
