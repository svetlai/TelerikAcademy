namespace StudentGroups
{
    using System.Collections.Generic;
    using System.Linq;

    public static class StudentQueries
    {
        // Problem 9
        public static List<Student> GetSecondGroupLinq(List<Student> students)
        {
            var selectedStudents = from student in students
                                   where student.GroupNumber == 2
                                   orderby student.FirstName
                                   select student;

            return selectedStudents
                .ToList<Student>();
        }

        // Problem 10
        public static List<Student> GetSecondGroupExtensionMethods(List<Student> students)
        {
            return students.Where(s => s.GroupNumber == 2)
                .OrderBy(s => s.FirstName)
                .ToList<Student>();
        }

        // Problem 11
        public static List<Student> ExtractStudentsByEmail(List<Student> students)
        {
            var selectedStudents = from student in students
                                   where student.Email.EndsWith("abv.bg")
                                   select student;

            return selectedStudents
                .ToList<Student>();
        }

        // Problem 12
        public static List<Student> ExtractStudentsByPhone(List<Student> students)
        {
            var selectedStudents = from student in students
                                   where student.PhoneNumber.StartsWith("02/")
                                   select student;

            return selectedStudents
                .ToList<Student>();
        }

        // Problem 13
        public static List<dynamic> ExtractStudentsByExcellentMark(List<Student> students)
        {
            var selectedStudents = from student in students
                                   where student.Marks.Contains(6)
                                   select new
                                   {
                                       FullName = student.FirstName + " " + student.LastName,
                                       Marks = student.Marks
                                   };

            return selectedStudents
                .ToList<dynamic>();
        }

        // Problem 14
        public static List<dynamic> ExtractStudentsByCountOfMarks(List<Student> students, int mark, int numberOfMarks)
        {
            var selectedStudents = students
                .Where(s => s.Marks.Count(m => m == mark) == numberOfMarks)
                .Select(s => new
                {
                    FullName = s.FirstName + " " + s.LastName,
                    Marks = s.Marks
                });

            return selectedStudents
                .ToList<dynamic>();
        }

        // Problem 15
        public static List<int> ExtractStudentsByYearOfEnrollment(List<Student> students)
        {
            var selectedStudentsMarks = students
                .Where(s => s.FN.Substring(4, 2) == "06")
                .Select(s => s.Marks);

            var marks = new List<int>();

            foreach (var mark in selectedStudentsMarks)
            {
                marks.AddRange(mark);
            }

            return marks;
        }

        // Problem 16
        public static List<Student> ExtractStudentsByGroup(List<Student> students, List<Group> groups, string departmentName, int groupNumber = 0)
        {
            var selectedStudents = from student in students
                                   join gr in groups on student.GroupNumber equals gr.GroupNumber
                                   where gr.DepartmentName == departmentName || gr.GroupNumber == groupNumber
                                   select student;

            return selectedStudents
                .ToList<Student>();
        }

        // Problem 18
        public static Dictionary<int, string> ExtractStudentsGroupedByGroupNameLinq(List<Student> students)
        {
            var groupedStudents = from student in students
                                  group student by student.GroupNumber;

            var grouped = new Dictionary<int, string>();

            foreach (var group in groupedStudents)
            {
                var currentGorup = new List<string>();

                foreach (var student in group)
                {
                    currentGorup.Add(student.FirstName + " " + student.LastName);
                }

                grouped.Add(group.Key, string.Join(", ", currentGorup));
            }

            return grouped;
        }

        // Problem 19
        public static Dictionary<int, string> ExtractStudentsGroupedByGroupNameExpressions(List<Student> students)
        {
            var groupedStudents = students.GroupBy(s => s.GroupNumber);

            var grouped = new Dictionary<int, string>();

            foreach (var group in groupedStudents)
            {
                var currentGorup = new List<string>();

                foreach (var student in group)
                {
                    currentGorup.Add(student.FirstName + " " + student.LastName);
                }

                grouped.Add(group.Key, string.Join(", ", currentGorup));
            }

            return grouped;
        }
    }
}
