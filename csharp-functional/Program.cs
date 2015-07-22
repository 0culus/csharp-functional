using System;
using LanguageExt;
using static LanguageExt.Prelude;

namespace csharp_functional
{
    /// <summary>
    /// A simple and hacky console application for playing with new C# 6 features as well as 
    /// language-ext. See https://github.com/louthy/language-ext
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# can be pretend to be functional now! Press ESC to quit");
            int userIntInput1;
            int userIntInput2;

            do
            {
                Console.Write("Enter an integer: ");

                Console.WriteLine(int.TryParse(Console.ReadLine(), out userIntInput1)
                    ? "One down..."
                    : "Get some glasses! It said INTEGER you dummy!");

                Console.Write("Enter another integer: ");


                Console.WriteLine(int.TryParse(Console.ReadLine(), out userIntInput2)
                    ? "Ok, now let's make a tuple"
                    : "Get some glasses! It said INTEGER you dummy!");

                var itsATuple = tuple(userIntInput1, userIntInput2);
                var mapItsATuple = map(itsATuple,
                    (first, second) => "Here's your tuple: (" + first + ", " + second + ")");
                Console.WriteLine(mapItsATuple);

                Console.Write("Another tupling. Enter your name [ <first> space <last> ]: ");

                var splitName = Console.ReadLine()?.Split(Convert.ToChar(" "));
                var nameTuple = tuple(splitName?[0], splitName?[1]);

                Console.WriteLine("Now we use map to print out what you entered: ");

                var printableName = map(nameTuple, (first, last) => "Hello, " + first + " " + last);
                Console.WriteLine(printableName);


            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
