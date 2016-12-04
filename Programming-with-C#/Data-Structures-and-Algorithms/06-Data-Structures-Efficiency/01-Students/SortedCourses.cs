namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class SortedCourses
    {
        public static void Main()
        {
            const string path = @"../../students.txt";

            var fileContents = ReadFile(path);
            var courses = SortCourses(fileContents);
            PrintCourses(courses);
        }

        public static List<string> ReadFile(string path)
        {
            StreamReader streamReader = new StreamReader(path);

            string line;
            List<string> fileContents = new List<string>();

            while ((line = streamReader.ReadLine()) != null)
            {
                fileContents.Add(line);
            }

            return fileContents;
        }

        public static SortedDictionary<string, SortedDictionary<string, string>> SortCourses(List<string> contents)
        {
            var courses = new SortedDictionary<string, SortedDictionary<string, string>>();

            for (int i = 0; i < contents.Count; i++)
            {
                string[] entry = contents[i].Split('|');

                Student student = new Student
                {
                    FirstName = entry[0].Trim(),
                    LastName = entry[1].Trim()
                };

                string course = entry[2].Trim();

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new SortedDictionary<string, string>());
                }

                courses[course].Add(student.LastName, student.FirstName);
            }

            return courses;
        }

        public static void PrintCourses(SortedDictionary<string, SortedDictionary<string, string>> courses)
        {
            foreach (var course in courses)
            {
                Console.WriteLine("Course {0}: ", course.Key);
                foreach (var student in course.Value)
                {
                    Console.WriteLine("{0}, {1}", student.Value, student.Key);
                }

                Console.WriteLine();
            }
        }
    }
}
