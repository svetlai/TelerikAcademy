namespace TestSchool
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School;
    
    /// <summary>
    /// Code coverage 100%
    /// </summary>
    [TestClass]
    public class TestCourse
    {
        private const string ValidCourseName = "HQC";
        private const string InvalidCourseName = "H";
        private const string StudentName = "Peter";
        private const int MaxStudentsInCourse = 30;
        private const int ValidStudentId = 10000;
        private const int InvalidStudentId = 9999;

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseErrorIfNameIsNull()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        public void TestCourseName()
        {
            Course course = new Course(ValidCourseName);
            Assert.AreEqual(ValidCourseName, course.Name, "Course name is not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCourseNameLength()
        {
            Course course = new Course(InvalidCourseName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCourseErrorAddNullStudent()
        {
            Course course = new Course(ValidCourseName);
            course.AddStudent(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseAddStudentsOverMaxLimit()
        {
            Course course = new Course(ValidCourseName);

            for (int i = 0; i <= MaxStudentsInCourse + 1; i++)
            {
                Student student = new Student(StudentName);
                course.AddStudent(student);
            }
        }

        [TestMethod]
        public void TestCourseAddStudent()
        {
            Course course = new Course(ValidCourseName);
            Student student = new Student(StudentName);
            course.AddStudent(student);
            Assert.AreEqual(student, course.Students[0], "Student has not been added to the course.");
        }

        [TestMethod]
        public void TestCourseRemoveExistingStudent()
        {
            Course course = new Course(ValidCourseName);
            Student student = new Student(StudentName);
            var studentID = student.StudentId;
            course.AddStudent(student);
            course.RemoveStudent(studentID);
            Assert.AreEqual(0, course.Students.Count, "Student has not been removed");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseRemoveNonExistingStudent()
        {
            Course course = new Course(ValidCourseName);
            Student student = new Student(StudentName);
            var studentID = student.StudentId;
            course.AddStudent(student);
            course.RemoveStudent(studentID + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestCourseRemoveStudentWhenCourseStudentsIsEmpty()
        {
            Course course = new Course(ValidCourseName);
            course.RemoveStudent(ValidStudentId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RemoveStudentWrongId()
        {
            Course course = new Course(ValidCourseName);
            course.RemoveStudent(InvalidStudentId);
        }
    }
}
