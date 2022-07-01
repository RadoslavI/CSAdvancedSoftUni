using System;
using System.Linq;

namespace _4_Froggy
{
    public class StartUp
    {
        static void Main()
        {
            var lake = new Lake(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
