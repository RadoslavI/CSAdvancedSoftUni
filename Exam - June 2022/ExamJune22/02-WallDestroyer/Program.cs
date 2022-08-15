using System;
using System.Linq;

namespace _02_WallDestroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[,] matrix = new string[n, n];
            int[] startIndex = new int[2];
            int countHoles = 1;
            int countRods = 0;
            bool isElectrocuted = false;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine().ToString();

                for (int i = 0; i < n; i++)
                {
                    matrix[row, i] = input[i].ToString();
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] == "V")
                    {
                        startIndex[0] = row;
                        startIndex[1] = col;
                        matrix[row,col] = "*";
                    }
                }
            }

            string command = Console.ReadLine();



            while(command != "End")
            {
                if (command == "down")
                {
                    if (startIndex[0] + 1 < n)
                    {
                        startIndex[0]++;
                        if (matrix[startIndex[0], startIndex[1]] == "R")
                        {
                            Console.WriteLine("Vanko hit a rod!");
                            countRods++;
                            startIndex[0]--;
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "C")
                        {
                            countHoles++;
                            isElectrocuted = true;
                            matrix[startIndex[0], startIndex[1]] = "E";
                            break;
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "*")
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{startIndex[0]}, {startIndex[1]}]!");
                        }
                        else
                        {
                            matrix[startIndex[0], startIndex[1]] = "*";
                            countHoles++;
                        }
                    }
                }
                else if (command == "up")
                {
                    if (startIndex[0] - 1 >= 0)
                    {
                        startIndex[0]--;
                        if (matrix[startIndex[0], startIndex[1]] == "R")
                        {
                            countRods++;
                            Console.WriteLine("Vanko hit a rod!");
                            startIndex[0]++;
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "C")
                        {
                            countHoles++;
                            isElectrocuted = true;
                            matrix[startIndex[0], startIndex[1]] = "E";
                            break;
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "*")
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{startIndex[0]}, {startIndex[1]}]!");

                        }
                        else
                        {
                            matrix[startIndex[0], startIndex[1]] = "*";
                            countHoles++;
                        }
                    }
                }
                else if (command == "left")
                {
                    if (startIndex[1] - 1 >= 0)
                    {
                        startIndex[1]--;
                        if (matrix[startIndex[0], startIndex[1]] == "R")
                        {
                            countRods++;
                            Console.WriteLine("Vanko hit a rod!");
                            startIndex[1]++;
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "C")
                        {
                            countHoles++;
                            isElectrocuted = true;
                            matrix[startIndex[0], startIndex[1]] = "E";
                            break;
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "*")
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{startIndex[0]}, {startIndex[1]}]!");

                        }
                        else
                        {
                            matrix[startIndex[0], startIndex[1]] = "*";
                            countHoles++;
                        }
                    }
                }
                else if (command == "right")
                {
                    if (startIndex[1] + 1 < n)
                    {
                        startIndex[1]++;
                        if (matrix[startIndex[0], startIndex[1]] == "R")
                        {
                            countRods++;
                            Console.WriteLine("Vanko hit a rod!");
                            startIndex[1]--;
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "C")
                        {
                            countHoles++;
                            isElectrocuted = true;
                            matrix[startIndex[0], startIndex[1]] = "E";
                            break;
                        }
                        else if (matrix[startIndex[0], startIndex[1]] == "*")
                        {
                            Console.WriteLine($"The wall is already destroyed at position [{startIndex[0]}, {startIndex[1]}]!");
                        }
                        else
                        {
                            matrix[startIndex[0], startIndex[1]] = "*";
                            countHoles++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {countHoles} hole(s).");
                PrintMatrix(n, matrix);
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {countHoles} hole(s) and he hit only {countRods} rod(s)." );
                matrix[startIndex[0], startIndex[1]] = "V";
                PrintMatrix(n, matrix);
            }
        }

        public static void PrintMatrix(int lenght, string[,] matrix)
        {
            for (int row = 0; row < lenght; row++)
            {
                for (int col = 0; col < lenght; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
