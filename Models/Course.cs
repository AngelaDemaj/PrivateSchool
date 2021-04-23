using IndividualProject.Models.Helpers;
using IndividualProject.Services;
using System;
using System.Collections.Generic;

namespace IndividualProject.Models
{
    public class Course : Item
    {
        public string Stream { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Trainer> Trainers { get; set; } = new List<Trainer>();
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public static void AddCourses()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of courses you want to add: ");
            var choice = InputValidator.ValidateInt(1, 10, Console.ReadLine());

            for (int i = 0; i < choice; i++)
            {
                Console.Clear();
                string[] menuArray = { "Manually add course", "Add random course" };

                var userChoice = Printer.PrintMenu(menuArray, 1, 2);

                switch (userChoice)
                {
                    case 1:
                        AddCourseManually();
                        break;
                    case 2:
                        AddRandomCourse();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void AddCourseManually()
        {
            Console.Clear();
            var course = new Course();

            Console.WriteLine("Enter the title");
            course.Title = InputValidator.ValidateString(Console.ReadLine());
            Console.WriteLine("Enter the stream");
            course.Stream = InputValidator.ValidateString(Console.ReadLine());
            Console.WriteLine("Enter the type");
            course.Type = InputValidator.ValidateString(Console.ReadLine());
            Console.WriteLine("Enter the start date");
            course.StartDate = InputValidator.ValidateDate(2019, 2040, Console.ReadLine());
            Console.WriteLine("Enter the end date");
            course.EndDate = InputValidator.ValidateDate(2019, 2040, Console.ReadLine());

            SQLService.AddCourse(course);
        }

        public static void AddRandomCourse()
        {
            var course = new Course();
            var random = new Random();
            course.Title = SyntheticData.CourseNames[random.Next(0, SyntheticData.CourseNames.Length)];
            course.Type = "Full-Time";
            course.Stream = "C#";
            course.StartDate = new DateTime(2020, 01, 01).AddDays(random.Next(1, 365));
            course.EndDate = new DateTime(2021, 10, 12).AddDays(random.Next(1, 365));

            SQLService.AddCourse(course);
        }
    }
}
