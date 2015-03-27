namespace StudentClass
{
    using System;
    using System.Text;

    using Helper;
    using StudentClass.Models;

    public class StudentClassTest
    {
        public static void Main()
        {
            HelperMethods.DisplayTaskDescription(Constants.PathToTaskDescription);

            TestStudentClass();
        }

        private static void TestStudentClass()
        {
            var sb = new StringBuilder();

            var peshoStudent = new Student("Pesho", "Peshov", 4, 222, Specialty.QA, University.TilirikUniversity, Faculty.SoftwareFaculty);
            var goshoStudent = new Student("Gosho", "Goshov", 2, 123, Specialty.MobileDevelopment, University.TilirikUniversity, Faculty.SoftwareFaculty);
            var oneMorePeshoStudent = new Student("Pesho", "Goshov", 2, 456, Specialty.MobileDevelopment, University.TilirikUniversity, Faculty.SoftwareFaculty);
            var anotherPeshoStudent = peshoStudent.Clone();

            sb.AppendLine(peshoStudent.ToString())
             .AppendLine(goshoStudent.ToString())
             .AppendLine("Pesho equals Gosho?")
             .AppendFormat("Equals: {0}", peshoStudent.Equals(goshoStudent))
             .AppendLine()
             .AppendFormat("==: {0}", peshoStudent == goshoStudent)
             .AppendLine()
             .AppendFormat("!=: {0}", peshoStudent != goshoStudent)
             .AppendLine()
             .AppendLine("\nPesho cloned: ")
             .AppendLine(anotherPeshoStudent.ToString())
             .AppendLine("Compare Pesho & Gosho: " + peshoStudent.CompareTo(goshoStudent).ToString())
             .AppendLine("Compare Pesho & one more Pesho student: " + peshoStudent.CompareTo(oneMorePeshoStudent).ToString())
             .AppendLine("Compare Pesho & Pesho copy: " + peshoStudent.CompareTo(anotherPeshoStudent).ToString());
           
            Console.WriteLine(sb);
        }
    }
}
