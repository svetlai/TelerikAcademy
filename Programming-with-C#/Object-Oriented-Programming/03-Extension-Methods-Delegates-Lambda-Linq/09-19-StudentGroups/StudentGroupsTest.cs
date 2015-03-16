namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Helper;

    /// <summary>
    /// Problem 9. Student groups
    ///   Create a class `Student` with properties `FirstName`, `LastName`, `FN`, `Tel`, `Email`, `Marks` (a List<int>), `GroupNumber`.
    ///   Create a `List<Student>` with sample students. Select only the students that are from group number 2.
    ///   Use LINQ query. Order the students by FirstName.
    /// Problem 10. Student groups extensions
    ///   Implement the previous using the same query expressed with extension methods.
    /// Problem 11. Extract students by email
    ///   Extract all students that have email in `abv.bg`.
    ///   Use `string` methods and LINQ.
    /// Problem 12. Extract students by phone
    ///   Extract all students with phones in Sofia. Use LINQ.
    /// Problem 13. Extract students by marks
    ///   Select all students that have at least one mark `Excellent` (`6`) into a new anonymous class that has properties – `FullName` and `Marks`. Use LINQ.
    /// Problem 14. Extract students with two marks
    ///   Write down a similar program that extracts the students with exactly two marks "`2`". Use extension methods.
    /// Problem 15. Extract marks 
    ///   Extract all `Marks` of the students that enrolled in 2006. (The students from 2006 have 06 as their 5-th and 6-th digit in the FN).
    /// Problem 16.* Groups
    ///   Create a class `Group` with properties `GroupNumber` and `DepartmentName`.
    ///   Introduce a property `Group` in the `Student` class.
    ///   Extract all students from "Mathematics" department.
    ///   Use the `Join` operator.
    /// Problem 18. Grouped by GroupName
    ///   Create a program that extracts all students grouped by `GroupName` and then prints them to the console. Use LINQ.
    /// Problem 19. Grouped by GroupName extensions
    ///   Rewrite the previous using extension methods.
    /// </summary>
    public class StudentGroupsTest
    {
        private static StringBuilder sb = new StringBuilder();

        private static List<Student> students = new List<Student>
            {
                new Student("Pesho", "Goshov", "012306", "02/95500000", "me@abv.bg", 1, new List<int> { 2, 6 }),
                new Student("Pesho", "Peshov", "012005", "02/95500001", "me@yahoo.com", 2, new List<int> { 2, 2, 3 }),
                new Student("Gosho", "Peshov", "012006", "064/9550002", "meme@abv.bg", 2, new List<int> { 2, 6, 3 }),
                new Student("Marin", "Nikolov", "012307", "071/9550003", "meme@gmail.com", 3, new List<int> { 5, 2, 3 }),
                new Student("Geri", "Nikolova", "012407", "071/9550003", "geri@gmail.com", 3, new List<int> { 2, 2, 3 }),
            };

        private static List<Group> groups = new List<Group>
            {
                new Group(1, "C#"),
                new Group(2, "OOP"),
                new Group(3, "Mathematics")
            };

        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestStudentsGroupsLinq();
            TestStudentsGroupsExtensions();
            TestStudentsByEmail();
            TestStudentsByPhone();
            TestStudentsByExcellentMark();
            TestStudentsByPoorMark();
            TestStudentsMarksByYearOfEnrollment();
            TestStudentsInMathemathics();
            TestGroupsByGroupNameLinq();
            TestGroupsByGroupNameExpressions();

            Console.WriteLine(sb);
        }

        // Problem 9
        public static void TestStudentsGroupsLinq()
        {
            var secondGroupStudents = Student.GetSecondGroupLinq(students);

            sb.AppendLine("09. Student groups: ");

            foreach (var student in secondGroupStudents)
            {
                sb.AppendLine(student.FirstName + " " + student.LastName + ", Group: " + student.GroupNumber);
            }
        }

        // Problem 10
        public static void TestStudentsGroupsExtensions()
        {
            sb.AppendLine("\n10. Student groups extensions: ");

            var secondGroupStudentsExtension = Student.GetSecondGroupExtensionMethods(students);

            foreach (var student in secondGroupStudentsExtension)
            {
                sb.AppendLine(student.FirstName + " " + student.LastName + ", Group: " + student.GroupNumber);
            }
        }

        // Problem 11
        public static void TestStudentsByEmail()
        {
            sb.AppendLine("\n11. Students by email: ");

            var studentsByEmail = Student.ExtractStudentsByEmail(students);

            foreach (var student in studentsByEmail)
            {
                sb.AppendLine(student.FirstName + " " + student.LastName + ", Email: " + student.Email);
            }
        }

        // Problem 12
        public static void TestStudentsByPhone()
        {
            sb.AppendLine("\n12. Students by phone: ");

            var studentsByPhone = Student.ExtractStudentsByPhone(students);

            foreach (var student in studentsByPhone)
            {
                sb.AppendLine(student.FirstName + " " + student.LastName + ", Phone: " + student.PhoneNumber);
            }
        }

        // Problem 13
        public static void TestStudentsByExcellentMark()
        {
            sb.AppendLine("\n13. Students by excellent mark: ");

            var studentsByExcellentMark = Student.ExtractStudentsByExcellentMark(students);

            foreach (var student in studentsByExcellentMark)
            {
                sb.AppendLine(student.FullName + ", Marsk: " + string.Join(", ", student.Marks));
            }
        }

        // Problem 14
        public static void TestStudentsByPoorMark()
        {
            sb.AppendLine("\n14. Students by poor mark: ");

            var studentsByPoorMark = Student.ExtractStudentsByCountOfMarks(students, 2, 2);

            foreach (var student in studentsByPoorMark)
            {
                sb.AppendLine(student.FullName + ", Marks: " + string.Join(", ", student.Marks));
            }
        }

        // Problem 15
        public static void TestStudentsMarksByYearOfEnrollment()
        {
            sb.AppendLine("\n15. Students' marks by year of enrollment: ");

            var marksByYearOfEnrollment = Student.ExtractStudentsByYearOfEnrollment(students);

            sb.AppendLine(string.Join(", ", marksByYearOfEnrollment));
        }

        // Problem 16
        public static void TestStudentsInMathemathics()
        {
            sb.AppendLine("\n16. Students in Mathematics: ");

            var studentsByGroup = Student.ExtractStudentsByGroup(students, groups, "Mathematics", 3);

            foreach (var student in studentsByGroup)
            {
                sb.AppendLine(student.FirstName + " " + student.LastName);
            }
        }

        // Problem 18
        public static void TestGroupsByGroupNameLinq()
        {
            sb.AppendLine("\n18. Students grouped by group name - LINQ: ");

            var groupsOfStudents = Student.ExtractStudentsGroupedByGroupNameLinq(students);

            foreach (var group in groupsOfStudents)
            {
                string groupName = groups.FirstOrDefault(g => g.GroupNumber.Equals(group.Key))
                    .DepartmentName;

                sb.AppendLine(groupName + ": " + group.Value);
            }
        }

        // Problem 19
        public static void TestGroupsByGroupNameExpressions()
        {
            sb.AppendLine("\n19. Students grouped by group name - expressions: ");

            var groupsOfStudentsExpressions = Student.ExtractStudentsGroupedByGroupNameExpressions(students);

            foreach (var group in groupsOfStudentsExpressions)
            {
                string groupName = groups.FirstOrDefault(g => g.GroupNumber.Equals(group.Key))
                    .DepartmentName;

                sb.AppendLine(groupName + ": " + group.Value);
            }
        }
    }
}
