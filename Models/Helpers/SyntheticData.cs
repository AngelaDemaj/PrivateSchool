using System.IO;

namespace IndividualProject.Models.Helpers
{
    static class SyntheticData
    {
        public static string[] FirstNames =
            File.ReadAllText(@"..\\..\\..\\Resources\\FirstNames.txt")
            .Replace("\r\n", "")
            .Split(',');

        public static string[] LastNames =
            File.ReadAllText(@"..\\..\\..\\Resources\\LastNames.txt")
            .Replace("\r\n", "")
            .Split(',');

        public static string[] CourseNames =
            File.ReadAllText(@"..\\..\\..\\Resources\\CourseNames.txt")
            .Replace("\r\n", "")
            .Split(',');

        public static string[] AssignmentNames =
            File.ReadAllText(@"..\\..\\..\\Resources\\AssignmentNames.txt")
            .Replace("\r\n", "")
            .Split(',');
    }
}
