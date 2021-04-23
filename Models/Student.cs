using IndividualProject.Models.Helpers;
using IndividualProject.Services;
using System;
using System.Collections.Generic;

namespace IndividualProject.Models
{
    public class Student : Person
    {
        public DateTime DateOfBirth { get; set; }
        public decimal TuitionFees { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Assignment> Assignments { get; set; } = new List<Assignment>();

        public static void AddStudents()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of students you want to add: ");
            var choice = InputValidator.ValidateInt(1, 10, Console.ReadLine());

            for (int i = 0; i < choice; i++)
            {
                Console.Clear();
                string[] menuArray = { "Manually add student", "Add random student" };

                var userChoice = Printer.PrintMenu(menuArray, 1, 2);

                switch (userChoice)
                {
                    case 1:
                        AddStudentManually();
                        break;
                    case 2:
                        AddRandomStudent();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void AddStudentManually()
        {
            Console.Clear();
            var student = new Student();

            Console.WriteLine("Enter the firstname");
            student.FirstName = InputValidator.ValidateString(Console.ReadLine());
            Console.WriteLine("Enter the lastname");
            student.LastName = InputValidator.ValidateString(Console.ReadLine());
            Console.WriteLine("Enter the date of birth");
            student.DateOfBirth = InputValidator.ValidateDate(1920, 2003, Console.ReadLine());
            Console.WriteLine("Enter the tuition fees");
            student.TuitionFees = InputValidator.ValidateInt(0, 100000, Console.ReadLine());

            SQLService.AddStudent(student);
        }

        public static void AddRandomStudent()
        {
            var student = new Student();
            var random = new Random();
            student.FirstName = SyntheticData.FirstNames[random.Next(0, SyntheticData.FirstNames.Length)];
            student.LastName = SyntheticData.LastNames[random.Next(0, SyntheticData.LastNames.Length)];
            student.DateOfBirth = new DateTime(1990, 1, 1).AddDays(random.Next(-5000, 5000));
            student.TuitionFees = random.Next(0, 2500);

            SQLService.AddStudent(student);
        }
    }
}
