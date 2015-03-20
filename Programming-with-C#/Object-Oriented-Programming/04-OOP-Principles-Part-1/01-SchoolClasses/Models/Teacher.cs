namespace SchoolClasses.Models
{
    using System.Collections.Generic;

    public class Teacher : Person
    {
        private ICollection<Discipline> disciplines;
        private ICollection<Course> courses;

        public Teacher(string firstName, string lastName)
            : base(firstName, lastName)
        {
            this.Disciplines = new HashSet<Discipline>();
            this.Courses = new HashSet<Course>();
        }

        public virtual ICollection<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }

            private set
            {
                this.disciplines = value;
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

        public void AddDiscipline(Discipline discipline)
        {
            this.Disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            this.Disciplines.Remove(discipline);
        }

        public void AddCourse(Course course)
        {
            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            this.Courses.Remove(course);
        }
    }
}
