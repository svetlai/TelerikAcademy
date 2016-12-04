namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    /// <summary>
    /// 96.77% covered.
    /// </summary>
    [TestClass]
    public class TestStudent
    {
        private const int MinId = 10000;
        private const int MaxId = 99999;
        private const string ValidStudentName = "Peter";
        private const string InvalidStudentName = "P";

        [TestMethod]
        public void TestStudentName()
        {
            Student student = new Student(ValidStudentName);
            Assert.AreEqual(ValidStudentName, student.Name, "Student name is not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestStudentErrorIfNameIsNull()
        {
            Student student = new Student(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentNameLength()
        {
            Student student = new Student(InvalidStudentName);
        }

        [TestMethod]
        public void TestStudentIdAutoIncrease()
        {
            Student student = new Student(ValidStudentName);
            var currentID = student.StudentId;
            Student secondStudent = new Student(ValidStudentName);

            Assert.AreEqual(currentID + 1, secondStudent.StudentId, "Auto increasing of id is not correct.");
        }

        [TestMethod]
        public void TestStudenMaxId()
        {
            Student student = new Student(ValidStudentName);
            var currentID = student.StudentId;
            for (int i = currentID; i < MaxId; i++)
            {
                student = new Student(ValidStudentName);
            }

            Assert.AreEqual(MaxId, student.StudentId, "MaxId is not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudenErrorIdOutOfRange()
        {
            Student student = new Student(ValidStudentName);
            var currentID = student.StudentId;
            for (int i = currentID; i <= MaxId + 1; i++)
            {
                student = new Student(ValidStudentName);
            }
        }
    }
}