using System;
using System.Collections.Generic;
using System.Linq;

public class AppliedArithmetics
{
    static void Main()
    {

        List<int> numbers =  Console.ReadLine().Split().Select(int.Parse).ToList();
        string command = Console.ReadLine();

        Func<List<int>, List<int>> add = list => list.Select(number => number += 1).ToList();

        Func<List<int>, List<int>> multiply = list => list.Select(number => number *= 2).ToList();

        Func<List<int>, List<int>> subtract = list => list.Select(number => number -= 1).ToList();

        Action<List<int>> printList = list => Console.WriteLine(String.Join(" ", list));

        while (command != "end")
        {
            switch (command)
            {
                case "add":
                    numbers = add(numbers);
                    break;

                case "multiply":
                    numbers = multiply(numbers);
                    break;

                case "subtract":
                    numbers = subtract(numbers);
                    break;

                case "print":
                    printList(numbers);
                    break;
            }


            command = Console.ReadLine();
        }

    }
}

