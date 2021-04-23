using IndividualProject.Models.Helpers;
using IndividualProject.Services;
using System;

namespace IndividualProject.Models
{
    public class Trainer : Person
    {
        public string Subject { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }

        public static void AddTrainers()
        {
            Console.Clear();
            Console.WriteLine("Enter the number of trainers you want to add: ");
            var choice = InputValidator.ValidateInt(1, 10, Console.ReadLine());

            for (int i = 0; i < choice; i++)
            {
                Console.Clear();
                string[] menuArray = { "Manually add trainer", "Add random trainer" };

                var userChoice = Printer.PrintMenu(menuArray, 1, 2);

                switch (userChoice)
                {
                    case 1:
                        AddTrainerManually();
                        break;
                    case 2:
                        AddRandomTrainer();
                        break;
                    default:
                        break;
                }
            }

        }

        public static void AddTrainerManually()
        {
            Console.Clear();
            var courses = SQLService.GetCourses();
            var trainer = new Trainer();

            Console.WriteLine("Enter the firstname");
            trainer.FirstName = InputValidator.ValidateString(Console.ReadLine());
            Console.WriteLine("Enter the lastname");
            trainer.LastName = InputValidator.ValidateString(Console.ReadLine());
            Console.WriteLine("Enter the subject");
            trainer.Subject = InputValidator.ValidateString(Console.ReadLine());
            Console.WriteLine("Choose the course for this trainer");
            var choice = Printer.PrintEntity(courses);

            if (!(choice == courses.Count + 1))
            {
                trainer.CourseId = courses[choice - 1].Id;
                SQLService.AddTrainer(trainer);
            }
        }

        public static void AddRandomTrainer()
        {
            var courses = SQLService.GetCourses();
            var trainer = new Trainer();
            var random = new Random();
            trainer.FirstName = SyntheticData.FirstNames[random.Next(0, SyntheticData.FirstNames.Length)];
            trainer.LastName = SyntheticData.LastNames[random.Next(0, SyntheticData.LastNames.Length)];
            trainer.Subject = "Programming";
            trainer.CourseId = courses[random.Next(0, courses.Count)].Id;

            SQLService.AddTrainer(trainer);
        }
    }
}
