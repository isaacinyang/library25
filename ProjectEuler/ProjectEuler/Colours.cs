using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProjectEuler.ProjectEuler
{
    class Colours
    {
        public static void AllColours()
        {
            // Demonstrate all colors and backgrounds.
            Type type = typeof(ConsoleColor);
            Console.ForegroundColor = ConsoleColor.Black;
            // foreach (var name in Enum.GetNames(type))
            // {
            //     Console.BackgroundColor = (ConsoleColor)Enum.Parse(type, name);
            //     // Console.Write(name);
            //     Console.WriteLine(name);
            //     Console.WriteLine(name);
            //     Console.WriteLine(name);
            //     Console.BackgroundColor = ConsoleColor.Black;
            //     Console.WriteLine("");
            // }
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (var name in Enum.GetNames(type))
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, name);
                Console.WriteLine(name);
            }
            return;
        }
    }
}