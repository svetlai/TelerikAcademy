namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : ITeacher
    {
        private const string EmptyNameExcMsg = "Name cannot be null or empty.";

        private string name;
        private ICollection<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new HashSet<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(EmptyNameExcMsg);
                }

                this.name = value;
            }
        }

        public ICollection<ICourse> Courses
        {
            get
            {
                return new HashSet<ICourse>(this.courses);
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        //Teacher: Name=(teacher name); Courses=[(course names – comma separated)]
        public override string ToString()
        {
            var output = new StringBuilder();
            output.AppendFormat("Teacher: Name={0}", this.Name);

            if (this.courses.Count > 0)
            {
                output.AppendFormat("; Courses=[");

                foreach (var course in courses)
                {
                    output.AppendFormat("{0}, ", course.Name);

                }

                output.Remove(output.Length - 2, 2);
                output.AppendFormat("]");
            }

            return output.ToString();
        }
    }
}
