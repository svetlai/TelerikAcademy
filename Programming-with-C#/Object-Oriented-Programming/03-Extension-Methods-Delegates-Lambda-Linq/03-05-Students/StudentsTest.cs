namespace Students
{
    using System;
    using System.Linq;
    using System.Text;

    using Helper;

    /// <summary>
    /// Problem 3. First before last
    ///   Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
    ///   Use LINQ query operators.
    /// Problem 4. Age range
    ///   Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.
    /// Problem 5. Order students
    ///   Using the extension methods `OrderBy()` and `ThenBy()` with lambda expressions sort the students by first name and last name in descending order.
    ///   Rewrite the same with LINQ.
    /// </summary>
    public class StudentsTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestFirstBeforeLast();
        }

        // Problem 3
        public static Student[] GetFirstBeforeLastName(Student[] students)
        {
            var newCollection = from student in students
                                where student.FirstName.CompareTo(student.LastName) < 0
                                select student;

            return newCollection.ToArray();

            // return students.Where(s => (s.FirstName.CompareTo(s.LastName)) < 0)
            //     .ToArray();
        }

        // Problem 4
        public static Student[] GetAgeRange(Student[] students, int minAge, int maxAge)
        {
            var newCollection = from student in students
                                where student.Age >= minAge && student.Age <= maxAge
                                select student;

            return newCollection.ToArray();

            // return students.Where(s => s.Age >= minAge && s.Age <= maxAge)
            //    .ToArray();
        }

        // Problem 5
        public static Student[] SortWithExtensionMethods(Student[] students)
        {
            return students.OrderByDescending(s => s.FirstName)
                .ThenByDescending(s => s.LastName).ToArray();
        }

        // Problem 5
        public static Student[] SortWithLINQ(Student[] students)
        {
            var newCollection = from student in students
                                orderby student.FirstName descending, student.LastName descending
                                select student;

            return newCollection.ToArray();
        } 

        public static void TestFirstBeforeLast()
        {
            var sb = new StringBuilder();

            var students = new Student[]
            {
                new Student("Pesho", "Goshov", 18),
                new Student("Pesho", "Peshov", 18),
                new Student("Gosho", "Peshov", 21),
                new Student("Marin", "Nikolov", 32),
            };

            sb.AppendLine("03. First before last: ");

            var firstBeforeLast = GetFirstBeforeLastName(students);

            foreach (var student in firstBeforeLast)
            {
                sb.AppendLine(student.FirstName + " " + student.LastName);
            }

            sb.AppendLine("\n04. Age range: ");

            var ageRange = GetAgeRange(students, 18, 24);

            foreach (var student in ageRange)
            {
                sb.AppendLine(student.FirstName + " " + student.LastName + " " + student.Age);
            }

            sb.AppendLine("\n05. Order students ");

            var ordered = SortWithExtensionMethods(students);

            foreach (var student in ordered)
            {
                sb.AppendLine(student.FirstName + " " + student.LastName);
            }

            Console.WriteLine(sb);
        }
    }
}
