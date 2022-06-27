using System;
using System.Collections.Generic;
using System.Linq;

public class PartyReservationFilterModule
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        List<string> names = Console.ReadLine().Split().ToList();

        Console.WriteLine(names
            .First(name => name.Select(symbol => (int) symbol).Sum() >= n));

    }
}

