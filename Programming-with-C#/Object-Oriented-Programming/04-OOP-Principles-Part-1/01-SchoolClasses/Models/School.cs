namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class School
    {
        private const string NameNullExceptionMsg = "Name cannot be empty.";

        private string name;
        private ICollection<Course> courses;

        public School(string name)
        {
            this.Name = name;
            this.courses = new HashSet<Course>();
        }

        [Required]
        [MinLength(2), StringLength(30)]
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameNullExceptionMsg);
                }

                this.name = value;
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

            sb.AppendLine(this.Name)
                .AppendLine();

            foreach (var course in this.Courses)
            {
                sb.Append(course.ToString());
            }

            return sb.ToString();
        }
    }
}
