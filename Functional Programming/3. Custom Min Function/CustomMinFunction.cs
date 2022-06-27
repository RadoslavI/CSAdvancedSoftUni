using System;
using System.Collections.Generic;
using System.Linq;

public class CustomMinFunction
{
    static void Main()
    {

        List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();

        Func<List<int>, int> getMinElement =  nums => nums.Min();

        Console.WriteLine(getMinElement(nums));
    }
}

