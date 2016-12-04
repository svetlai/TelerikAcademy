namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        private const int MaxStudentsInCourse = 30;
        private const int MinNameLength = 2;
        private const int MaxNameLength = 50;

        private string name;
        private IList<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>(MaxStudentsInCourse);
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

        public IList<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("Student cannot be null.");
            }

            if (this.students.Count >= MaxStudentsInCourse)
            {
                throw new InvalidOperationException(string.Format("Students in this course cannot exceed {0}.", MaxStudentsInCourse));
            }

            this.students.Add(student);
        }

        public void RemoveStudent(int studentId)
        {
            if (studentId < Student.MinId || studentId > Student.MaxId)
            {
                throw new ArgumentOutOfRangeException(string.Format("Student number must be in the range between {0} and {1}", Student.MinId, Student.MaxId));
            }

            if (this.students.Count == 0)
            {
                throw new InvalidOperationException("There are no students to remove.");
            }

            var studentToDelete = this.students.FirstOrDefault(s => s.StudentId == studentId);

            if (studentToDelete != null)
            {
                this.students.Remove(studentToDelete);
            }
            else
            {
                throw new InvalidOperationException(string.Format("There is no student with id {0}.", studentId));
            }
        }
    }
}
