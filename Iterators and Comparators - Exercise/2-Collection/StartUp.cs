using System;
using System.Linq;

namespace _2_Collection
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listy = null;
            string input = Console.ReadLine();

            while (input != "END")
            {
                var commands = input.Split();

                if (commands[0] == "Create")
                {
                    listy = new ListyIterator<string>(commands.Skip(1).ToArray());
                }
                else if (commands[0] == "Move")
                {
                    Console.WriteLine(listy.Move());
                }
                else if (commands[0] == "Print")
                {
                    listy.Print();
                }
                else if (commands[0] == "HasNext")
                {
                    Console.WriteLine(listy.hasNext());
                }
                else if (commands[0] == "PrintAll")
                {
                    listy.PrintAll();
                }


                input = Console.ReadLine();
            }



        }
    }
}
