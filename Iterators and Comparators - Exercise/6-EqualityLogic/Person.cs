using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_EqualityLogic
{
    public class Person :IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result==0)
                result = Age.CompareTo(other.Age);
            return result;
        }

        public override int GetHashCode() => Name.GetHashCode() ^ Age.GetHashCode();

        public override bool Equals(object? obj)
        {
            var other = obj as Person;
            if (other == null) return false;
            return Age == other.Age && Name == other.Name;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }


    }
}
