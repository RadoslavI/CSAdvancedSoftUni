using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_1
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] coffee = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[] milk = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> coffeeQueue = new Queue<int>(coffee);
            Stack<int> milkStack = new Stack<int>(milk);

            SortedDictionary<string, int> drinks = new SortedDictionary<string, int>()
            {
                {"Cortado", 0},
                {"Espresso", 0},
                {"Capuccino", 0},
                {"Americano", 0},
                {"Latte", 0}
            };

            while (coffeeQueue.Count > 0 && milkStack.Count > 0)
            {
                int currCoffee = coffeeQueue.Peek();
                int currMilk = milkStack.Peek();
                int sum = currCoffee + currMilk;

                if (sum == 50)
                {
                    drinks["Cortado"]++;
                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                }
                else if (sum == 75)
                {
                    drinks["Espresso"]++;
                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                }
                else if (sum == 100)
                {
                    drinks["Capuccino"]++;
                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                }
                else if (sum == 150)
                {
                    drinks["Americano"]++;
                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                }
                else if (sum == 200)
                {
                    drinks["Latte"]++;
                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                }
                else
                {
                    coffeeQueue.Dequeue();
                    milkStack.Pop();
                    milkStack.Push(currMilk - 5);
                }
            }

            if (coffeeQueue.Count == 0 && milkStack.Count == 0)
            {
                Console.WriteLine($"Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }


            if (coffeeQueue.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {String.Join(", ", coffeeQueue.Select(x => x.ToString()))}");
            }


            if (milkStack.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {String.Join(", ", milkStack.Select(x => x.ToString()))}");
            }

            var printDict = drinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key);

            foreach (var item in printDict)
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
