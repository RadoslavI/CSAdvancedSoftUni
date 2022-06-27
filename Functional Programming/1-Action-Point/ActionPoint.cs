using System;
using System.Collections.Generic;
using System.Linq;

public class ActionPoint
{
    static void Main()
    {

        List<string> list = Console.ReadLine().Split(" ").ToList();

        Action<string> printNames = name => Console.WriteLine(name);
        list.ForEach(printNames);

    }
}

