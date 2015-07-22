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
        public static Option<int> RawInput1 { get; set; } = Some(123);
        public static Option<int> RawInput2 { get; set; } = Some(123);
        public static int UserIntInput1 { get; set; }
        public static int UserIntInput2 { get; set; }


        static void Main(string[] args)
        {
            Console.WriteLine("C# can be pretend to be functional now! Press ESC to quit");
            do
            {
                Console.Write("Enter an integer: ");
                
                UserIntInput1 = RawInput1.Match(
                    Some: v => v * 2,
                    None: () => 0
                    );

                var userIntInput1 = UserIntInput1;
                if (int.TryParse(Console.ReadLine(), out userIntInput1))
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
