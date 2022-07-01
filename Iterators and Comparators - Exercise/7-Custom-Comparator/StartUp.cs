using System;
using System.Linq;

namespace _7_Custom_Comparator
{
    public class StartUp
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int, int> sortFunction = (x, y)
                => (x % 2 == 0 && y % 2 != 0) ? -1 : 
                (x % 2 != 0 && y % 2 == 0) ? 1 : 
                x > y ? 1 : x < y ? -1 : 0;

            Array.Sort(nums, (x, y) => sortFunction(x, y));
            Console.WriteLine(String.Join(" ", nums));
        }
    }
}
