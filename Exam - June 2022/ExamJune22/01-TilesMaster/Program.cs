using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01_TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue grayTiles = new Queue();
            Stack whiteTiles = new Stack();
            Dictionary<string, int> table = new Dictionary<string, int>();
            Dictionary<int, int> counter = new Dictionary<int, int>();
            Dictionary<string, int> result = new Dictionary<string, int>();

            table.Add("Sink", 40);
            counter.Add(40, 0);

            table.Add("Oven", 50);
            counter.Add(50, 0);

            table.Add("Countertop", 60);
            counter.Add(60, 0);

            table.Add("Wall", 70);
            counter.Add(70, 0);

            table.Add("Floor", 0);
            counter.Add(0, 0);

            int floorTilesCount = 0;

            string[] FirstLine = Console.ReadLine().Split(' ');
            string[] SecondLine = Console.ReadLine().Split(' ');

            foreach (var item in SecondLine)
            {
                grayTiles.Enqueue(int.Parse(item));
            }

            foreach (var item in FirstLine)
            {
                whiteTiles.Push(int.Parse(item));
            }

            while (true)
            {
                if (whiteTiles.Count == 0 || grayTiles.Count == 0)
                {
                    break;
                }
                int currGray = (int)grayTiles.Peek();
                int currWhite = (int)whiteTiles.Peek();

                if (currGray == currWhite)
                {
                    int newTile = currWhite + currGray;
                    if (table.ContainsValue(newTile))
                    {
                        grayTiles.Dequeue();
                        whiteTiles.Pop();
                        counter[newTile]++;
                    }
                    else
                    {
                        grayTiles.Dequeue();
                        whiteTiles.Pop();
                        counter[0]++;
                    }
                }
                else
                {
                    currWhite /= 2;
                    whiteTiles.Pop();
                    whiteTiles.Push(currWhite);

                    grayTiles.Dequeue();
                    grayTiles.Enqueue(currGray);
                }
            }

            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles.ToArray())}");
            }

            if (grayTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grayTiles.ToArray())}");
            }

            foreach (var room in table)
            {
                foreach (var count in counter)
                {
                    if (room.Value == count.Key)
                    {
                        result.Add(room.Key, count.Value);
                    }
                }
            }

            var newResult = result.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            foreach (var item in newResult.Where(x => x.Value != 0))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

        }
    }
}
