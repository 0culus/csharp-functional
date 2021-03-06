﻿using System;
using LanguageExt;
using static LanguageExt.Prelude;
// ReSharper disable RedundantAssignment
// ReSharper disable RedundantArgumentName

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

            do
            {
                Console.Write("Enter an integer: ");

                var optional = Some(1337); // because we're l33t functional programmers
                var userIntInput1 = optional.Match(
                    Some: v => v,
                    None: () => 0);

                Console.WriteLine(int.TryParse(Console.ReadLine(), out userIntInput1)
                    ? "One down..."
                    : "Integers only.");

                Console.Write("Enter another integer: ");


                var userIntInput2 = optional.Match(
                    Some: v => v,
                    None: () => 0);
                Console.WriteLine(int.TryParse(Console.ReadLine(), out userIntInput2)
                    ? "Ok, now let's make a tuple"
                    : "OK, seriously? I asked for an integer.");

                // TODO: OK, so on the language-ext readme, they give this example:
                // var name = tuple("Paul","Louth");
                // var res = name.Map((first, last) => "Hello \{first} \{last}");
                //
                // however, there is an error about unknown escapes for \{? 
                var itsATuple = tuple(userIntInput1, userIntInput2);
                var mapItsATuple = map(itsATuple,
                    (first, second) => "Here's your tuple: (" + first + ", " + second + ")");
                Console.WriteLine(mapItsATuple);

                Console.Write("Another tupling. Enter your name [ <first> space <last> ]: ");

                var splitName = Console.ReadLine()?.Split(Convert.ToChar(" "));
                var nameTuple = tuple(splitName?[0], splitName?[1]);

                Console.WriteLine("Now we use map to print out what you entered: ");

                var mapName = map(nameTuple, (first, last) => "Hello, " + first + " " + last);
                Console.WriteLine(mapName);


            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
