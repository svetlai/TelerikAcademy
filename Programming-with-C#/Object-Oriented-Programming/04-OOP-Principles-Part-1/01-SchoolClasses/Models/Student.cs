namespace SchoolClasses.Models
{
    using System.Collections.Generic;

    public class Student : Person
    {
        private string classNumber;
        private ICollection<Course> courses;

        public Student(string firstName, string lastName, string classNumber)
            : base(firstName, lastName)
        {
            this.ClassNumber = classNumber;
            this.Courses = new HashSet<Course>();
        }

        // TODO : unique
        // [Index("ClassNumber", IsUnique = true)]
        public string ClassNumber
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
    }
}
