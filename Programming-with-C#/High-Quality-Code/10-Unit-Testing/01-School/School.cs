namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 50;

        private string name;
        private IList<Course> courses;

        public School(string name)
        {
            this.Name = name;
            this.Courses = new List<Course>();
        }

        public School(string name, IList<Course> courses)
            : this(name)
        {
            this.Courses = courses;
        }

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
                    throw new ArgumentNullException("Name cannot be left empty.");
                }

                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Name must be between {0} and {1} characters long.", MinNameLength, MaxNameLength));
                }

                this.name = value;
            }
        }

        public IList<Course> Courses
        {
            get
            {
                return new List<Course>(this.courses);
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The list of courses cannot be empty.");
                }

                this.courses = value;
            }
        }

        public void AddCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course cannot be empty.");
            }

            this.courses.Add(course);
        }

        public void RemoveCourse(string courseName)
        {
            if (string.IsNullOrEmpty(courseName))
            {
                throw new ArgumentNullException("Course name cannot be empty.");
            }

            if (this.courses.Count == 0)
            {
                throw new InvalidOperationException("There are no courses to remove.");
            }

            var courseToDelete = this.courses.FirstOrDefault(c => c.Name == courseName);

            if (courseToDelete != null)
            {
                this.courses.Remove(courseToDelete);
            }
            else
            {
                throw new InvalidOperationException(string.Format("There is no course called {0}.", courseName));
            }
        }
    }
}
