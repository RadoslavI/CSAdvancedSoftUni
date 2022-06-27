using System;


public class Demo
{
    static void Main(string[] args)
    {

        //Action receives <int> -> returns void
        Action<int> printMultiplyNumber = number => number = number * 2;
        printMultiplyNumber(4);

        //Func<receives, returns>
        Func<string, string> nameWithDot = name => name + ".";

        Console.WriteLine(nameWithDot("radkoEpi4batee"));

        //Predicate <receive> -> Returns BOOL(true/false)
        Predicate<int> isOver18 = age => age > 18;

        Console.WriteLine(isOver18(17));
    }
}

