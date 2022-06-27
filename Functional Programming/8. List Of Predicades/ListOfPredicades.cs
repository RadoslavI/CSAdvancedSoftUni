using System;
using System.Collections.Generic;
using System.Linq;

public class ListOfPredicades
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();

        List<int> numbers = new List<int>();
        for (int number = 0; number < n; number++)
        {
            numbers.Add(number);
        }

        List<int> printNumbers = new List<int>();

        foreach (var number in numbers)
        {
            bool Divisible = true;
            foreach (var divider in dividers)
            {

                Predicate<int> isDivisible = number => number % divider == 0;
                if (!isDivisible(number))
                {
                    Divisible = false;
                    break;
                }

            }
            if (Divisible)
            {
                printNumbers.Add(number);
            }
        }

        Console.WriteLine(String.Join(" ", printNumbers));
    }
}

