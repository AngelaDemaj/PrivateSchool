using IndividualProject.Models;
using IndividualProject.Models.LinkTables;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IndividualProject.Services
{
    public static class SQLService
    {
        public static string connectionString = @"Server=.;Database=PrivateSchool;Trusted_Connection=True;";

        public static List<Student> GetStudents()
        {
            var students = new List<Student>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Students", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            DateOfBirth = reader.GetDateTime(3),
                            TuitionFees = reader.GetDecimal(4)
                        });
                    }
                    reader.Close();
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }

            return students;
        }

        public static List<Trainer> GetTrainers()
        {
            var trainers = new List<Trainer>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Trainers", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        trainers.Add(new Trainer
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Subject = reader.GetString(3),
                            CourseId = reader.GetInt32(4)
                        });
                    }
                    reader.Close();
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }

            return trainers;
        }

        public static List<Course> GetCourses()
        {
            var courses = new List<Course>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Courses", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        courses.Add(new Course
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Stream = reader.GetString(2),
                            Type = reader.GetString(3),
                            StartDate = reader.GetDateTime(4),
                            EndDate = reader.GetDateTime(5)
                        });
                    }
                    reader.Close();
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }

            return courses;
        }

        public static List<Assignment> GetAssignments()
        {
            var assignments = new List<Assignment>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM Assignments", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        assignments.Add(new Assignment
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            SubmissionDate = reader.GetDateTime(3),
                            OralMark = reader.GetInt32(4),
                            TotalMark = reader.GetInt32(5),
                            CourseId = reader.GetInt32(6)
                        });
                    }
                    reader.Close();
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }

            return assignments;
        }

        public static List<StudentAssignment> GetStudentAssignments()
        {
            var studentAssignments = new List<StudentAssignment>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM StudentAssignments", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        studentAssignments.Add(new StudentAssignment
                        {
                            Id = reader.GetInt32(0),
                            StudentId = reader.GetInt32(1),
                            AssignmentId = reader.GetInt32(2)
                        });
                    }
                    reader.Close();
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }

            return studentAssignments;
        }

        public static List<StudentCourse> GetStudentCourses()
        {
            var studentCourses = new List<StudentCourse>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("SELECT * FROM StudentCourses", connection);
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        studentCourses.Add(new StudentCourse
                        {
                            Id = reader.GetInt32(0),
                            StudentId = reader.GetInt32(1),
                            CourseId = reader.GetInt32(2)
                        });
                    }
                    reader.Close();
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }

            return studentCourses;
        }

        public static void AddStudent(Student student)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("INSERT INTO Students (FirstName, LastName, DateOfBirth, TuitionFees)" +
                        $" VALUES ('{student.FirstName}', '{student.LastName}', '{student.DateOfBirth:yyyy-MM-dd}', {student.TuitionFees})", connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }

        public static void AddTrainer(Trainer trainer)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("INSERT INTO Trainers (FirstName, LastName, Subject, CourseId)" +
                        $" VALUES ('{trainer.FirstName}', '{trainer.LastName}', '{trainer.Subject}', {trainer.CourseId})", connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }

        public static void AddCourse(Course course)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("INSERT INTO Courses (Title, Stream, Type, StartDate, EndDate)" +
                        $" VALUES ('{course.Title}', '{course.Stream}', '{course.Type}', '{course.StartDate:yyyy-MM-dd}', '{course.EndDate:yyyy-MM-dd}')", connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }

        public static void AddAssignment(Assignment assignment)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var command =
                        new SqlCommand("INSERT INTO Assignments (Title, Description, SubmissionDate, OralMark, TotalMark, CourseId)" +
                        $" VALUES ('{assignment.Title}', '{assignment.Description}', '{assignment.SubmissionDate:yyyy-MM-dd}', {assignment.OralMark}, {assignment.TotalMark}, {assignment.CourseId})", connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }
    }
}
