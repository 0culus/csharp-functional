using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;

namespace csharp_functional
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C# can be pretend to be functional now! Press ESC to quit");
            do
            {
                Console.Write("Enter an integer: ");
                var rawInput = Some(123);
                var _userInput = rawInput.Match(
                    Some: v => v * 2,
                    None: () => 0
                    );

                if (int.TryParse(Console.ReadLine(), out _userInput))
                {
                    Console.WriteLine("One down...");
                }
                else
                {
                    Console.WriteLine("Get some glasses! It said INTEGER you dummy!");
                } 


            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
