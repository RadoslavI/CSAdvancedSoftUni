using System;

namespace Box1
{
    public class StartUp
    {
        static void Main()
        {

            var personInfo = Console.ReadLine().Split();
            var fullname = $"{personInfo[0]} {personInfo[1]}";
            var city = $"{personInfo[2]}";

            string[] nameAndBeer = Console.ReadLine().Split();
            string name = nameAndBeer[0];
            int numberOfLiters = int.Parse(nameAndBeer[1]);

            string[] numbersInput = Console.ReadLine().Split();
            int intNum = int.Parse(numbersInput[0]);
            var doubleNum = double.Parse(numbersInput[1]);

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullname, city);
            Tuple<string, int> secondTuple = new Tuple<string, int>(name, numberOfLiters);
            Tuple<int, double> thirdTuple = new Tuple<int, double>(intNum, doubleNum);
            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
