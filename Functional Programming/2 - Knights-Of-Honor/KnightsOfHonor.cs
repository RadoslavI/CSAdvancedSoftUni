using System;
using System.Collections.Generic;
using System.Linq;

public class KnightsOfHonor
{
    static void Main()
    {

        List<string> names = Console.ReadLine().Split().ToList();
        Func<string, string> addPrefix = name => "Sir " + name;

        foreach (var name in names)
        {
            Console.WriteLine(addPrefix(name));
        }


    }
}

