using System;
using System.Collections.Generic;
using System.Linq;

public class FindEvensOrOdds
{ 
    static void Main()
    {
        string input = Console.ReadLine();
        int startNumber = int.Parse(input.Split()[0]);
        int endNumber = int.Parse(input.Split()[1]);

        List<int> numbers = new List<int>();
        for (int number = startNumber; number < endNumber; number++)
        {
            numbers.Add(number);
        }
        Predicate<int> isEven = number => number % 2 == 0;
        string type = Console.ReadLine();

        if (type == "even")
        {
            foreach (var number in numbers)
            {
                if (isEven(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
        else if (type == "odd")
        {
            foreach (var number in numbers)
            {
                if (!isEven(number))
                {
                    Console.Write(number + " ");
                }
            }
        }
    }
}

