using Pastel;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace IndividualProject.Models.Helpers
{
    static class Printer
    {
        public static int PrintEntity<T>(List<T> entities)
        {
            Console.Clear();
            var counter = 1;
            foreach (var entity in entities)
            {
                if (entity is Person)
                {
                    if (entity is Student)
                    {
                        var person = entity as Student;
                        Console.WriteLine($"{counter}. " + person.FullName.Pastel(Color.Aquamarine)
                            + $" Tuition Fees: {person.TuitionFees} Date Of Birth: {person.DateOfBirth}");
                    }
                    else
                    {
                        var person = entity as Trainer;
                        Console.WriteLine($"{counter}. " + person.FullName.Pastel(Color.Aquamarine)
                            + $" Subject: {person.Subject}");
                    }
                }
                else
                {
                    if (entity is Course)
                    {
                        var item = entity as Course;
                        Console.WriteLine($"{counter}. " + item.Title.Pastel(Color.Aquamarine)
                            + $" Stream: {item.Stream} Type: {item.Type} Start Date: {item.StartDate}" +
                            $" End Date: {item.EndDate}");
                    }
                    else
                    {
                        var item = entity as Assignment;
                        Console.WriteLine($"{counter}. " + item.Title.Pastel(Color.Aquamarine)
                            + $" Description: {item.Description} Submission Date: {item.SubmissionDate}" +
                            $" Total Mark: {item.TotalMark} Oral Mark: {item.OralMark}");
                    }

                }
                counter++;
            }
            Console.WriteLine($"{counter}. Back To Menu");

            return InputValidator.ValidateInt(1, entities.Count + 1, Console.ReadLine());
        }

        public static int PrintMenu(string[] options, int lowerBound, int upperBound)
        {
            for (int i = 1; i <= options.Length; i++)
            {
                Console.WriteLine($"{i}. " + options[i - 1].Pastel(Color.BlueViolet));
            }

            var input = Console.ReadLine();
            var choice = InputValidator.ValidateInt(lowerBound, upperBound, input);

            return choice;
        }
    }
}
