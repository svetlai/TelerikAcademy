namespace StudentsAndWorkers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Helper;
    using StudentsAndWorkers.Models;

    /// <summary>
    /// Problem 2. Students and workers
    /// Define abstract class `Human` with first name and last name. Define new class `Student` which is derived from `Human` and has new field – `grade`. Define class `Worker` derived from `Human` with new property `WeekSalary` and `WorkHoursPerDay` and method `MoneyPerHour()` that returns money earned by hour by the worker. Define the proper constructors and properties for this hierarchy.
    /// Initialize a list of 10 students and sort them by grade in ascending order (use LINQ or `OrderBy()` extension method).
    /// Initialize a list of 10 workers and sort them by money per hour in descending order.
    /// Merge the lists and sort them by first name and last name.
    /// </summary>
    public class StudentsAndWorkersTest
    {
        private const int DaysPerWeek = 5;
        private const int WorkHoursPerDay = 8;

        private static IRandomGenerator randomGenerator;
        private static StringBuilder sb = new StringBuilder();

        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            randomGenerator = new RandomGenerator();

            var students = CreateStudents(10);
            var sortedStudents = SortStudents(students);
            
            var workers = CreateWorkers(10);
            var sortedWorkers = SortWorkers(workers);
 
            var humans = MergeHumansAndWorkers(students, workers);
            var sortedHumans = SortHumans(humans);

            PrintExample(sortedHumans, sortedStudents, sortedWorkers);
        }

        public static ICollection<Student> CreateStudents(int count)
        {
            var students = new List<Student>();

            for (int i = 0; i < count; i++)
            {
                var name = randomGenerator.RandomString(3, 10);
                var grade = randomGenerator.RandomNumber(0, 100);
                var student = new Student(name, name, grade);
                students.Add(student);
            }

            return students;
        }

        public static ICollection<Student> SortStudents(ICollection<Student> students)
        {
            return students.OrderBy(s => s.Grade)
                .ToList();
        }

        public static ICollection<Worker> CreateWorkers(int count)
        {
            var workers = new List<Worker>();

            for (int i = 0; i < count; i++)
            {
                var name = randomGenerator.RandomString(3, 10);
                var weekSalary = randomGenerator.RandomNumber(100, 300);
                var worker = new Worker(name, name, weekSalary, WorkHoursPerDay);
                workers.Add(worker);
            }

            foreach (var worker in workers)
            {
                worker.CalculateMoneyPerHour(DaysPerWeek);
            }

            return workers;
        }

        public static ICollection<Worker> SortWorkers(ICollection<Worker> workers)
        {
            return workers.OrderByDescending(w => w.MoneyPerHour)
                .ToList();
        }

        public static ICollection<Human> MergeHumansAndWorkers(ICollection<Student> students, ICollection<Worker> workers)
        {
            var humans = new List<Human>(students);
            humans.AddRange(workers);

            return humans;
        }

        public static ICollection<Human> SortHumans(ICollection<Human> humans)
        {
            return humans.OrderBy(h => h.FirstName)
              .ThenBy(h => h.LastName)
              .ToList();
        }

        public static void PrintExample(ICollection<Human> humans, ICollection<Student> students, ICollection<Worker> workers)
        {
            sb.AppendLine("Students, sorted by grade: ");

            foreach (var student in students)
            {
                sb.AppendLine(student.ToString());
            }

            sb.AppendLine();

            sb.AppendLine("Workers, sorted by money per hour: ");

            foreach (var worker in workers)
            {
                sb.AppendLine(worker.ToString());
            }

            sb.AppendLine();

            sb.AppendLine("Humans, sorted by name: ");

            foreach (var human in humans)
            {
                sb.AppendLine(human.ToString());
            }

            Console.WriteLine(sb);
        }
    }
}
