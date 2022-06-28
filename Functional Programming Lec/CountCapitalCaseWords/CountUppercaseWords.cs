using System;
using System.Linq;

public class CountUppercaseWords
{
    static Func<string, bool> isFirstLetterCapital =
            x => x.Length > 0 && char.IsUpper(x[0]);
    static void Main() =>
        Console.WriteLine(
            String.Join(
                "\r\n",
                Console.ReadLine()
                .Split(" ")
                .Where(isFirstLetterCapital)
                )
            );
}

