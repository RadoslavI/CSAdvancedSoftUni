using System;
using System.Collections.Generic;

namespace Box1
{
    internal class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                var input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            var box = new Box<double>(list);
            var elementToCompare = double.Parse(Console.ReadLine());
            var count = box.CountOfGreaterElements(list, elementToCompare);
            Console.WriteLine(count);
    
        }
    }
}
