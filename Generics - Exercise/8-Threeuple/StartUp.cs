using System;

namespace threeupleasd
{
    public class StartUp
    {
        static void Main()
        {
            String fullname = " ";
            String address = " ";
            String town = " ";



            var personInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (personInfo.Length == 4)
            {
                 fullname = $"{personInfo[0]} {personInfo[1]}";
                 address = $"{personInfo[2]}";
                 town = $"{personInfo[3]}";
            }
            else if (personInfo.Length == 5)
            {
                 fullname = $"{personInfo[0]} {personInfo[1]}";
                 address = $"{personInfo[2]}";
                 town = $"{personInfo[3]} {personInfo[4]}";
            }

            string[] drunkStatus = Console.ReadLine().Split();
            string name = drunkStatus[0];
            int litersOfBeer = int.Parse(drunkStatus[1]);
            bool drunk = (drunkStatus[2] == "drunk");

            string[] bankInfo = Console.ReadLine().Split();
            string holder = bankInfo[0];
            var balance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];


            Threeuple<string, string, string> firstTuple = new Threeuple<string, string, string>(fullname, address, town);
            var secondTuple = new Threeuple<string, int, bool>(name, litersOfBeer, drunk);
            var thirdTuple = new Threeuple<string, double, string>(holder, balance, bankName);
            Console.WriteLine(firstTuple);
            Console.WriteLine(secondTuple);
            Console.WriteLine(thirdTuple);

        }
    }
}
