using IndividualProject.Models.Helpers;
using IndividualProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IndividualProject.Models.Menu
{
    class Menu
    {
        public static void MainMenu()
        {
            Console.Clear();
            string[] menuArray = { "Student Menu", "Trainer Menu",
                "Assignment Menu", "Course Menu", "Calendar", "Exit Application"};

            var choice = Printer.PrintMenu(menuArray, 1, 6);

            switch (choice)
            {
                case 1:
                    StudentMenu();
                    break;
                case 2:
                    TrainerMenu();
                    break;
                case 3:
                    AssignmentMenu();
                    break;
                case 4:
                    CourseMenu();
                    break;
                case 5:
                    CalendarMenu();
                    break;
                case 6:
                    Environment.Exit(1);
                    break;
                default:
                    break;
            }
        }

        public static void StudentMenu()
        {
            Console.Clear();
            string[] menuArray = { "Add Student", "Student List",
                "Students in multiple courses", "Return to Main Menu" };

            var choice = Printer.PrintMenu(menuArray, 1, 4);
            var students = SQLService.GetStudents();
            var courses = SQLService.GetCourses();
            var studentCourses = SQLService.GetStudentCourses();

            switch (choice)
            {
                case 1:
                    Student.AddStudents();
                    MainMenu();
                    break;
                case 2:
                    var studentIndex = Printer.PrintEntity(students);
                    if (!(studentIndex == students.Count + 1))
                        StudentSubMenu(students[studentIndex - 1]);
                    MainMenu();
                    break;
                case 3:
                    foreach (var course in courses)
                    {
                        foreach (var student in students)
                        {
                            if (studentCourses.Any(sc => sc.CourseId == course.Id &&
                                sc.StudentId == student.Id))
                            {
                                course.Students.Add(student);
                            }
                        }
                    }

                    var studentIds = courses
                        .SelectMany(x => x.Students)//pare olous toys students apo ta courses kai valtous se mia lista
                        .GroupBy(s => s.Id)//omadopoihse autous tous students me vash to id
                        .Where(s => s.Count() > 1)//pare mono tis eggrafes pou uparxoyn panw apo mia fora
                        .Select(y => new { Id = y.Key, Counter = y.Count() })
                        //ftiaxnw mia lista apo anonymous object me 2 properties
                        //to key einai to Id toy mathith kai to counter to posa mathimata eixe o mathiths
                        .ToList();//kane auta lista

                    var studentList = students
                        .Where(x => studentIds.Select(y => y.Id).Contains(x.Id))//filtrare th lista me toys mathites me vash ta ids
                                                                                //poy vrhkes sthn prohgoumenh lista
                        .ToList();

                    Console.WriteLine("Students with many courses");
                    var counter = 1;

                    foreach (var student in studentList)
                    {
                        Console.WriteLine($"{counter}. {student.FullName}");
                        counter++;
                    }
                    Console.ReadKey();
                    MainMenu();
                    break;
                case 4:
                    MainMenu();
                    break;
                default:
                    break;
            }
        }

        public static void TrainerMenu()
        {
            Console.Clear();
            string[] menuArray = { "Add Trainer", "Trainer List", "Return to Main Menu" };

            var choice = Printer.PrintMenu(menuArray, 1, 3);
            var trainers = SQLService.GetTrainers();

            switch (choice)
            {
                case 1:
                    Trainer.AddTrainers();
                    MainMenu();
                    break;
                case 2:
                    Printer.PrintEntity(trainers);
                    MainMenu();
                    break;
                case 3:
                    MainMenu();
                    break;
                default:
                    break;
            }
        }

        public static void CourseMenu()
        {
            Console.Clear();
            string[] menuArray = { "Add Course", "Course List", "Return to Main Menu" };

            var choice = Printer.PrintMenu(menuArray, 1, 3);
            var courses = SQLService.GetCourses();

            switch (choice)
            {
                case 1:
                    Course.AddCourses();
                    MainMenu();
                    break;
                case 2:
                    var courseIndex = Printer.PrintEntity(courses);
                    if (!(courseIndex == courses.Count + 1))
                        CourseSubMenu(courses[courseIndex - 1]);
                    MainMenu();
                    break;
                case 3:
                    MainMenu();
                    break;
                default:
                    break;
            }
        }

        public static void AssignmentMenu()
        {
            Console.Clear();
            string[] menuArray = { "Add Assignment", "Assignment List", "Return to Main Menu" };

            var choice = Printer.PrintMenu(menuArray, 1, 3);
            var assignments = SQLService.GetAssignments();

            switch (choice)
            {
                case 1:
                    Assignment.AddAssignments();
                    MainMenu();
                    break;
                case 2:
                    Printer.PrintEntity(assignments);
                    MainMenu();
                    break;
                case 3:
                    MainMenu();
                    break;
                default:
                    break;
            }
        }

        public static void CalendarMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter a date");
            var date = InputValidator.ValidateDate(2019, 2022, Console.ReadLine());

            while (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Invalid Date. Choose a day not in weekend");
                date = InputValidator.ValidateDate(2019, 2022, Console.ReadLine());
            }

            var daysOfWeek = new List<DateTime>();
            daysOfWeek.Add(date);

            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    daysOfWeek.Add(date.AddDays(1));
                    daysOfWeek.Add(date.AddDays(2));
                    daysOfWeek.Add(date.AddDays(3));
                    daysOfWeek.Add(date.AddDays(4));
                    break;
                case DayOfWeek.Tuesday:
                    daysOfWeek.Add(date.AddDays(1));
                    daysOfWeek.Add(date.AddDays(2));
                    daysOfWeek.Add(date.AddDays(3));
                    daysOfWeek.Add(date.AddDays(-1));
                    break;
                case DayOfWeek.Wednesday:
                    daysOfWeek.Add(date.AddDays(1));
                    daysOfWeek.Add(date.AddDays(2));
                    daysOfWeek.Add(date.AddDays(-1));
                    daysOfWeek.Add(date.AddDays(-2));
                    break;
                case DayOfWeek.Thursday:
                    daysOfWeek.Add(date.AddDays(1));
                    daysOfWeek.Add(date.AddDays(-1));
                    daysOfWeek.Add(date.AddDays(-2));
                    daysOfWeek.Add(date.AddDays(-3));
                    break;
                case DayOfWeek.Friday:
                    daysOfWeek.Add(date.AddDays(-1));
                    daysOfWeek.Add(date.AddDays(-2));
                    daysOfWeek.Add(date.AddDays(-3));
                    daysOfWeek.Add(date.AddDays(-4));
                    break;
                default:
                    break;
            }

            var assignments = SQLService.GetAssignments();
            var studentAssignments = SQLService.GetStudentAssignments();
            var students = SQLService.GetStudents();

            foreach (var student in students)
            {
                foreach (var assignment in assignments)
                {
                    if (studentAssignments.Any(sa => sa.AssignmentId == assignment.Id &&
                        sa.StudentId == student.Id))
                    {
                        student.Assignments.Add(assignment);
                    }
                }
            }

            //thelw mono ta assignments poy anhkoyn sthn evdomada poy moy edwse o xrhsths
            var assignmentList = assignments
                .Where(x => daysOfWeek.Contains(x.SubmissionDate))
                .ToList();

            var studentList = students
                .Where(x => x.Assignments.Intersect(assignmentList).Count() > 0)
                .ToList();

            Console.WriteLine("Students that have an assignment in this week are:");

            var counter = 1;
            foreach (var student in studentList)
            {
                Console.WriteLine($"{counter}. {student.FullName}");
                counter++;
            }
            Console.ReadKey();
        }

        public static void StudentSubMenu(Student student)
        {
            var courses = SQLService.GetCourses();

            var assignmentIds = SQLService.GetStudentAssignments()
                .Where(sa => sa.StudentId == student.Id)
                .Select(sa => sa.AssignmentId)
                .ToList();

            var studentAssignments = SQLService.GetAssignments()
                .Where(a => assignmentIds.Contains(a.Id))
                .ToList();

            foreach (var assignment in studentAssignments)
            {
                assignment.Course = courses
                    .FirstOrDefault(c => c.Id == assignment.CourseId);
            }

            var counter = 1;

            Console.WriteLine($"Assignments for {student.FullName}");
            foreach (var assignment in studentAssignments)
            {
                Console.WriteLine($"{counter}. {assignment.Title} Course: {assignment.Course.Title}");
                counter++;
            }
            Console.ReadKey();
        }

        public static void CourseSubMenu(Course course)
        {
            var studentIds = SQLService.GetStudentCourses()
                .Where(sc => sc.CourseId == course.Id)
                .Select(sc => sc.StudentId)
                .ToList();

            var students = SQLService.GetStudents();
            var trainers = SQLService.GetTrainers();
            var assignments = SQLService.GetAssignments();

            foreach (var assignment in assignments)
            {
                if (assignment.CourseId == course.Id)
                {
                    course.Assignments.Add(assignment);
                }
            }

            foreach (var trainer in trainers)
            {
                if (trainer.CourseId == course.Id)
                {
                    course.Trainers.Add(trainer);
                }
            }

            foreach (var student in students)
            {
                if (studentIds.Contains(student.Id))
                {
                    course.Students.Add(student);
                }
            }

            Console.Clear();
            string[] menuArray = { "Students per course", "Trainers per course",
                "Assignments per course"};

            var choice = Printer.PrintMenu(menuArray, 1, 3);
            var counter = 1;

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Students in course {course.Title}");
                    foreach (var student in course.Students)
                    {
                        Console.WriteLine($"{counter}. {student.FullName}");
                        counter++;
                    }
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine($"Trainers in course {course.Title}");
                    foreach (var trainer in course.Trainers)
                    {
                        Console.WriteLine($"{counter}. {trainer.FullName}");
                        counter++;
                    }
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine($"Assignments in course {course.Title}");
                    foreach (var assignment in course.Assignments)
                    {
                        Console.WriteLine($"{counter}. {assignment.Title}");
                        counter++;
                    }
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
        }
    }
}
