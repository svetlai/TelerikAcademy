namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using System.Data.Entity;

    using StudentSystem.DBContext;
    using StudentSystem.Model;
    using StudentSystem.DBContext.Migrations;

    public class StudentSystemEntryPoint
    {
        public static void Main()
        {
            StudentSystemDBContext studentSystemDBContext = new StudentSystemDBContext();

            Student student = new Student()
            {
                FirstName = "Pepi",
                LastName = "Peshova",
                StudentStatus = StudentStatus.Online
            };

            studentSystemDBContext.Students.Add(student);
            studentSystemDBContext.SaveChanges();

            Console.WriteLine("Student added successfully.");

            Course databases = new Course()
            {
                CourseName = "Databases"
            };

            Course dsa = new Course()
            {
                CourseName = "Data Structures and Algorithms"
            };

            studentSystemDBContext.Courses.Add(databases);
            studentSystemDBContext.Courses.Add(dsa);
            studentSystemDBContext.SaveChanges();

            Console.WriteLine("Course added successfully.");

            var pepi = studentSystemDBContext.Students.FirstOrDefault(s => s.FirstName == "Pepi");

            pepi.Courses.Add(databases);
            pepi.Courses.Add(dsa);
            studentSystemDBContext.SaveChanges();

            foreach (var course in pepi.Courses)
            {
                Console.WriteLine("Maria has signed up for: {0}", course.CourseName);
            }

            Homework dsaHomework = new Homework()
            {
                Contents = "Lots of tasks",
                TimeSent = DateTime.Now
            };

            dsa.Homework.Add(dsaHomework);
            pepi.Homework.Add(dsaHomework);
            studentSystemDBContext.SaveChanges();

            Console.WriteLine("Homework added succesfully.");

            var courses =
                (from c in studentSystemDBContext.Courses
                 where c.CourseName == "Databases" && c.CourseId != 25
                 select c);

            foreach (var course in courses)
            {
                studentSystemDBContext.Courses.Remove(course);
            }

            studentSystemDBContext.SaveChanges();

            Console.WriteLine("Courses deleted succesfully.");
        }
    }
}
