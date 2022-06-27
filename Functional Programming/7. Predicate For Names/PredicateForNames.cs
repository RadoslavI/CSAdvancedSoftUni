using System;
using System.Collections.Generic;
using System.Linq;

public class PredicateForNames
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        List<string> names = Console.ReadLine().Split().ToList();
        Predicate<char[]> validName = name => name.Length <= n;
        List<string> printNames = new List<string>();


        foreach (var name in names)
        {
            char[] currName = name.ToCharArray();
            if (validName(currName))
            {
                printNames.Add(name);
            }
        }

        foreach (var name in printNames)
        {
            Console.WriteLine(name);
        }

    }
}

