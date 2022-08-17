using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _1_BlackSmith
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] steel = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] carbon = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queueSteel = new Queue<int>(steel);
            Stack<int> stackCarbon = new Stack<int>(carbon);

            //sword name => count
            SortedDictionary<string, int> swords = new SortedDictionary<string, int>()
            {
                {"Broadsword", 0},
                {"Sabre", 0},
                {"Katana", 0},
                {"Shamshir", 0},
                {"Gladius", 0}
            };

            int countSwords = 0;
            while (queueSteel.Count > 0 && stackCarbon.Count > 0)
            {
                int currSteel = queueSteel.Peek();
                int currCarbon = stackCarbon.Peek();
                int sum = currCarbon + currSteel;

                if (sum == 70)
                {
                    swords["Gladius"]++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    countSwords++;
                }
                else if (sum == 80)
                {
                    swords["Shamshir"]++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    countSwords++;
                }
                else if (sum == 90)
                {
                    swords["Katana"]++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    countSwords++;
                }
                else if (sum == 110)
                {
                    swords["Sabre"]++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    countSwords++;
                }
                else if (sum == 150)
                {
                    swords["Broadsword"]++;
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    countSwords++;
                }
                else
                {
                    queueSteel.Dequeue();
                    stackCarbon.Pop();
                    stackCarbon.Push(currCarbon + 5);
                }
            }

            if (countSwords > 0)
            {
                Console.WriteLine($"You have forged {countSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (queueSteel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {String.Join(", ", queueSteel.Select(x => x.ToString()))}");
            }

            if (stackCarbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {String.Join(", ", stackCarbon.Select(x => x.ToString()))}");
            }


            foreach (var item in swords)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
