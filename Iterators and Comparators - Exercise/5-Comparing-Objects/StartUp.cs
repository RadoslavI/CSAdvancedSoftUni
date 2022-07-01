using System;
using System.Collections.Generic;
using System.Linq;

namespace _5_Comparing_Objects
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new List<Person>();
            string[] tokens = Console.ReadLine().Split().ToArray();

            while (tokens[0] != "END")
            {
                string personName = tokens[0];
                int personAge = int.Parse(tokens[1]);
                string personTown = tokens[2];

                people.Add(new Person(personName, personAge, personTown));

                tokens = Console.ReadLine().Split().ToArray();
            }

            var index = int.Parse(Console.ReadLine()) - 1;
            var equal = 0;
            var notEqual = 0;

            foreach (var person in people)
            {
                if (people[index].CompareTo(person) == 0)
                {
                    equal++;
                }
                else
                    notEqual++;
            }

            if (equal <= 1)
                Console.WriteLine("No matches"); 
            else
                Console.WriteLine($"{equal} {notEqual} {people.Count}");
            
        }

    }
}
