using System;
using System.Collections.Generic;
using System.Linq;

public class ReverseAndExclude
{
    static void Main(string[] args)
    {
        Console.WriteLine(30%3);
        List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
        int n = int.Parse(Console.ReadLine());
        List<int> numbersToPrint = new List<int>();
        numbers.Reverse();

        for (int i = 0; i < numbers.Count; i++)
        {
            Predicate<int> isDivisible = number => number % n == 0;
            if (!isDivisible(numbers[i]))
            {
                numbersToPrint.Add(numbers[i]);
            }

        }
        Console.WriteLine(String.Join(" ", numbersToPrint));

    }
}

