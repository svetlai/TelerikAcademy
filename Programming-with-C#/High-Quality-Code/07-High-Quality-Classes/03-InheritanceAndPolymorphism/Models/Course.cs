namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using InheritanceAndPolymorphism.Common;

    public abstract class Course
    {
        private const int MinCourseNameLength = 2;
        private const int MaxCourseNameLength = 50;

        private string courseName;
        private IList<Student> students;

        public Course(string courseName)
        {
            this.students = new List<Student>();
            this.CourseName = courseName;
        }

        public Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;
        }

        public Course(string courseName, string teacherName, IList<Student> students)
            : this(courseName, teacherName)
        {
            this.Students = students;
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            set
            {
                this.ValidateCourseName(value);
                this.courseName = value;
            }
        }

        public string TeacherName { get; set; }

        public IList<Student> Students 
        { 
            get
            {
                return new List<Student>(this.students);
            }

            set 
            { 
                this.students = value; 
            }
        }

        public void AddStudent(Student student) 
        {
            Validator.ValidateNullObject(student);
            this.students.Add(student);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name + " { Name = ");
            result.Append(this.CourseName);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            result.Append(" }");

            return result.ToString();
        }

        protected string GetStudentsAsString()
        {         
            if (this.Students == null || this.students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.students) + " }";
            }
        }

        private void ValidateCourseName(string value)
        {
            Validator.ValidateEmptyString(value, "Course name");
            Validator.ValidateStringLengthRange(value, "Course name", MinCourseNameLength, MaxCourseNameLength);
        }
    }
}
