namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    using InheritanceAndPolymorphism.Models;

    public class CoursesExamples
    {
        public static void Main()
        {
            TestCourses();
        }

        private static void TestCourses() 
        { 
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);

            localCourse.Students = new List<Student>() 
            { 
                new Student("Peter", "Petrov", "12345"),
                new Student("Maria", "Petrova", "12346"),
                new Student("Gosho", "Petrov", "12347")
            };

            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.AddStudent(new Student("Milena", "Petrova", "12348"));
            localCourse.AddStudent(new Student("Todor", "Petrov", "12349"));

            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development",
                "Mario Peshev",
                new List<Student>() 
            {  
                new Student("Mimi", "Petrovs", "54321"),
                new Student("Poli", "Petrova", "54320"),
                new Student("Stamat", "Petrov", "54327") 
            });

            Console.WriteLine(offsiteCourse);
        }
    }
}
