namespace TestSchool
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using School;

    /// <summary>
    /// Code coverage 96.23%
    /// </summary>
    [TestClass]
    public class TestSchool
    {
        private const string ValidSchoolName = "Telerik Academy";
        private const string InvalidSchoolName = "T";
        private const string CourseName = "HQC";

        [TestMethod]
        public void TestSchoolName()
        {
            School school = new School(ValidSchoolName);
            Assert.AreEqual(ValidSchoolName, school.Name, "School name is not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSchoolErrorIfNameIsNull()
        {
            School school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSchoolNameLength()
        {
            School school = new School(InvalidSchoolName);
        }

        [TestMethod]
        public void TestSchoolWithCourses()
        {
            var courses = new List<Course>
            {
                new Course(CourseName)
            };

            School school = new School(ValidSchoolName, courses);
            Assert.AreEqual(courses[0], school.Courses[0], "Course has not been added to the school.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSchoolErrorAddNullCourse()
        {
            School school = new School(ValidSchoolName);
            school.AddCourse(null);
        }

        [TestMethod]
        public void TestSchoolAddCourse()
        {
            School school = new School(ValidSchoolName);
            Course course = new Course(CourseName);
            school.AddCourse(course);
            Assert.AreEqual(course, school.Courses[0], "Course has not been added to the school.");
        }

        [TestMethod]
        public void TestSchoolRemoveExistingCourse()
        {
            School school = new School(ValidSchoolName);
            Course course = new Course(CourseName);
            school.AddCourse(course);
            var courseName = course.Name;
            school.RemoveCourse(courseName);
            Assert.AreEqual(0, course.Students.Count, "Course has not been removed");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSchoolRemoveNonExistingCourse()
        {
            School school = new School(ValidSchoolName);
            Course course = new Course(CourseName);
            school.AddCourse(course);
            var courseName = course.Name;
            school.RemoveCourse(courseName + "invalid");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSchoolRemoveCourseWhenCourseNameIsEmpty()
        {
            School school = new School(ValidSchoolName);
            school.RemoveCourse(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSchoolRemoveCourseWhenCoursesIsEmpty()
        {
            School school = new School(ValidSchoolName);
            school.RemoveCourse(CourseName);
        }
    }
}
