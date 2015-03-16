namespace SchoolClasses
{
    using System;

    using Helper;
    using SchoolClasses.Models;

    /// <summary>
    /// Problem 1. School classes
    /// We are given a `school`. In the school there are classes of students. Each class has a set of teachers. Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have unique text identifier. Teachers have name. Disciplines have name, number of lectures and number of exercises. Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
    /// Your task is to identify the classes (in terms of  OOP) and their attributes and operations, encapsulate their fields, define the class hierarchy and create a class diagram with Visual Studio.
    /// </summary>
    public class SchoolClassesTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            var school = CreateSchool("TilirikAcademy");
            PrintSchool(school);
        }

        public static School CreateSchool(string schoolName)
        {
            var school = new School(schoolName);

            var csharp = new Course("C#");
            var oop = new Course("OOP");
            var html = new Course("HTML");

            var toshoGoshov = new Teacher("Tosho", "Goshov");
            var goshoPeshov = new Teacher("Gosho", "Peshov");
            var mishoToshov = new Teacher("Misho", "Toshov");

            var csharpDiscipline = new Discipline("C#", 20, 20);
            var oopDiscipline = new Discipline("OOP", 10, 10);
            var htmlDiscipline = new Discipline("HTML", 5, 5);

            toshoGoshov.AddDiscipline(csharpDiscipline);
            goshoPeshov.AddDiscipline(csharpDiscipline);
            goshoPeshov.AddDiscipline(oopDiscipline);
            mishoToshov.AddDiscipline(htmlDiscipline);

            var mimiKostova = new Student("Mimi", "Kostova", "123");
            var didiPeshova = new Student("Didi", "Peshova", "567");
            var sisiGoshova = new Student("Sisi", "Goshova", "587");

            csharp.AddTeacher(toshoGoshov);
            csharp.AddTeacher(goshoPeshov);
            oop.AddTeacher(goshoPeshov);
            html.AddTeacher(mishoToshov);

            csharp.AddStudent(mimiKostova);
            oop.AddStudent(mimiKostova);
            html.AddStudent(sisiGoshova);
            html.AddStudent(didiPeshova);

            school.AddCourse(csharp);
            school.AddCourse(oop);
            school.AddCourse(html);

            mimiKostova.AddComment(new Comment("Team Project", "Awesome teammate!", didiPeshova));
            oop.AddComment(new Comment("OOP Principles", "Huh?", sisiGoshova));

            return school;
        }

        public static void PrintSchool(School school)
        {
            Console.WriteLine(school.Name);

            foreach (var course in school.Courses)
            {
                Console.WriteLine(course.Identifier);

                foreach (var teacher in course.Teachers)
                {
                    Console.WriteLine("Teacher: " + teacher.FirstName + " " + teacher.LastName);

                    foreach (var discipline in teacher.Disciplines)
                    {
                        Console.WriteLine("Discipline: " + discipline.Name + " Lectures: " + discipline.NumberOfLectures + " Exercises: " + discipline.NumberOfExercises);
                    }
                }

                foreach (var student in course.Students)
                {
                    Console.WriteLine("Student: " + student.FirstName + " " + student.LastName);

                    foreach (var comment in student.Comments)
                    {
                        Console.WriteLine("Comment: " + comment.Title + " " + comment.Contents + " " + comment.Author);
                    }
                }

                foreach (var comment in course.Comments)
                {
                    Console.WriteLine("Comment: " + comment.Title + " " + comment.Contents + " " + comment.Author);
                }

                Console.WriteLine();
            }
        }
    }
}
