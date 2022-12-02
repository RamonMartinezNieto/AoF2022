﻿using AdventOfCode2022.Days;

namespace AdventOfCode2022 
{
    internal class Program
    {
        public const int PAD_NUMBER = 44;

        static void Main(string[] args)
        {
            PrintHeader();

            Print(Day1.GetResultPartOne(), Day1.GetResultPartTwo());

            PrintFooter();
            ColorForegroundColor(ConsoleColor.White);
        }

        private static void PrintFooter()
        {
            PrintHeaderBlock(ConsoleColor.DarkYellow);
            Print("\tMerry Christmas!!! :)", ConsoleColor.DarkYellow);
            PrintFooterBlock(ConsoleColor.DarkYellow);
        }

        private static void PrintHeader()
        {
            PrintHeaderBlock(ConsoleColor.DarkRed);
            Print("\tAdvent Of Code 2022 :)", ConsoleColor.Red);
            PrintFooterBlock(ConsoleColor.DarkRed);
        }

        private static void Print(object resultOne, object resultTwo)
        {
            PrintHeaderBlock(ConsoleColor.DarkMagenta);
            PrintResultIndividual(1, 1, resultOne);
            PrintResultIndividual(1, 2, resultTwo);
            PrintFooterBlock(ConsoleColor.DarkMagenta);
        }      
        
        private static void Print(object resultOne)
        {
            PrintHeaderBlock(ConsoleColor.DarkMagenta);
            PrintResultIndividual(1, 1, resultOne);
            PrintFooterBlock(ConsoleColor.DarkMagenta);
        }

        private static void PrintResultIndividual(int day, int exercice, object result)
        {
            var totalCharactersResult = result.ToString().Count();

            ColorForegroundColor(ConsoleColor.DarkMagenta);
            Console.Write("| ");

            ColorForegroundColor(ConsoleColor.Green);
            Console.Write($"Result of the day ");
            ColorForegroundColor(ConsoleColor.Magenta);
            Console.Write($"{day} - {exercice}" );
               
            ColorForegroundColor(ConsoleColor.Green);
            Console.Write($" is ");
            
            ColorForegroundColor(ConsoleColor.Blue);
            Console.Write(result);

            ColorForegroundColor(ConsoleColor.DarkMagenta);
            int totalPad = PAD_NUMBER - (totalCharactersResult + 30);
            Console.Write(("").PadLeft(totalPad));
            Console.WriteLine("|");

            ColorForegroundColor(ConsoleColor.White); 
        }

        private static void PrintHeaderBlock(ConsoleColor color) 
        {
            ColorForegroundColor(color);
            Console.WriteLine(("").PadRight(PAD_NUMBER, '-'));
            PrintEmptyLine(color);
        }
                
        private static void PrintFooterBlock(ConsoleColor color) 
        {
            ColorForegroundColor(color);
            PrintEmptyLine(color);
            Console.WriteLine(("").PadRight(PAD_NUMBER, '-'));
        }

        private static void PrintEmptyLine(ConsoleColor color) 
        {
            ColorForegroundColor(color);
            Console.Write("| ");
            Console.Write(("").PadLeft(PAD_NUMBER - 3));
            Console.WriteLine("|");
        }

        private static void Print(string message, ConsoleColor color)
        {
            ColorForegroundColor(color); 

            Console.WriteLine(message);

            ColorForegroundColor(ConsoleColor.White); 
        }

        private static void ColorForegroundColor(ConsoleColor color)
            => Console.ForegroundColor = color;
    }
}