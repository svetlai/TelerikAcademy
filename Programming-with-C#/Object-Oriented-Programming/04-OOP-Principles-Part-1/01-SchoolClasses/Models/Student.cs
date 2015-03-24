namespace SchoolClasses.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class Student : Person
    {
        // private static int idCounter = 0;
        private int classNumber;
        private ICollection<Course> courses;

        public Student(string firstName, string lastName, int classNumber)
            : base(firstName, lastName)
        {
            this.ClassNumber = classNumber;
            this.Courses = new HashSet<Course>();
        }

        //// A workaround for unique class number
        // public Student(string firstName, string lastName)
        //     : base(firstName, lastName)
        // {
        //     this.ClassNumber = idCounter++;
        //     this.Courses = new HashSet<Course>();
        // }

        // Entity Framework - Unique Attribute
        // [Index("ClassNumber", IsUnique = true)]
        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            private set
            {
                this.classNumber = value;
            }
        }

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }

            private set
            {
                this.courses = value;
            }
        }

        public void AddCourse(Course course)
        {
            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            this.Courses.Remove(course);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Student: " + base.ToString() + " " + this.classNumber);

            foreach (var comment in this.Comments)
            {
                sb.Append(comment.ToString());
            }

            return sb.ToString();
        }
    }
}
