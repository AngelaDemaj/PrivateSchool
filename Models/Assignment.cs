using IndividualProject.Models.Helpers;
using IndividualProject.Services;
using System;

namespace IndividualProject.Models
{
    public class Assignment : Item
    {
        public string Description { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int OralMark { get; set; }
        public int TotalMark { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public static void AddAssignments()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of assignments you want to add: ");
            var choice = InputValidator.ValidateInt(1, 10, Console.ReadLine());

            for (int i = 0; i < choice; i++)
            {
                Console.Clear();
                string[] menuArray = { "Manually add assignment", "Add random assignment" };

                var userChoice = Printer.PrintMenu(menuArray, 1, 2);

                switch (userChoice)
                {
                    case 1:
                        AddAssignmentManually();
                        break;
                    case 2:
                        AddRandomAssignment();
                        break;
                    default:
                        break;
                }
            }

        }

        public static void AddAssignmentManually()
        {
            Console.Clear();
            var courses = SQLService.GetCourses();
            var assignment = new Assignment();

            Console.WriteLine("Enter the title");
            assignment.Title = InputValidator.ValidateString(Console.ReadLine());
            Console.WriteLine("Enter the description");
            assignment.Description = InputValidator.ValidateString(Console.ReadLine());
            Console.WriteLine("Enter the oral mark");
            assignment.OralMark = InputValidator.ValidateInt(0, 25, Console.ReadLine());
            Console.WriteLine("Enter the total mark");
            assignment.TotalMark = InputValidator.ValidateInt(75, 100, Console.ReadLine());
            Console.WriteLine("Enter the submission date");
            assignment.SubmissionDate = InputValidator.ValidateDate(2019, 2040, Console.ReadLine());
            Console.WriteLine("Choose the course for this assignment");
            var choice = Printer.PrintEntity(courses);

            if (!(choice == courses.Count + 1))
            {
                assignment.CourseId = courses[choice - 1].Id;
                SQLService.AddAssignment(assignment);
            }
        }

        public static void AddRandomAssignment()
        {
            var courses = SQLService.GetCourses();
            var assignment = new Assignment();
            var random = new Random();
            assignment.Title = SyntheticData.AssignmentNames[random.Next(0, SyntheticData.AssignmentNames.Length)];
            assignment.Description = "This was a random assignment";
            assignment.SubmissionDate = DateTime.Now.AddDays(random.Next(10, 365));
            assignment.OralMark = random.Next(0, 26);
            assignment.TotalMark = 100 - assignment.OralMark;
            assignment.CourseId = courses[random.Next(0, courses.Count)].Id;

            SQLService.AddAssignment(assignment);
        }
    }
}
