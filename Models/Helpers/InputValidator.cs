using System;
using System.Text.RegularExpressions;

namespace IndividualProject.Models.Helpers
{
    static class InputValidator
    {
        public static int ValidateInt(int lowerBound, int upperBound, string input)
        {
            var isInt = int.TryParse(input, out var choice);

            if (isInt && choice >= lowerBound && choice <= upperBound)
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Incorrect Number, enter a correct number");
                while (!int.TryParse(Console.ReadLine(), out choice) ||
                    choice < lowerBound ||
                    choice > upperBound)
                {
                    Console.WriteLine("Incorrect Number, enter a correct number");
                }
            }
            return choice;
        }

        public static string ValidateString(string input)
        {
            while (!Regex.IsMatch(input, "^[a-zA-Z]+$"))
            {
                Console.WriteLine("Incorrect input");
                input = Console.ReadLine();
            }
            return input;
        }

        public static DateTime ValidateDate(int lowerBound, int upperBound, string input)
        {
            DateTime date;
            while (!DateTime.TryParse(input, out date) || date.Year > upperBound || date.Year < lowerBound)
            {
                Console.WriteLine("Input a correct date");
                input = Console.ReadLine();
            }
            return date;
        }
    }
}
