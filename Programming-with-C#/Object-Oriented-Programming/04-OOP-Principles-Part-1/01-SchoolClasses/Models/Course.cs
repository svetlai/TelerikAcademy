namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using SchoolClasses.Contracts;

    public class Course : IHaveComments
    {
        private const string NameNullExceptionMsg = "Name cannot be empty.";

        private Guid id;
        private string name;
        private ICollection<Student> students;
        private ICollection<Teacher> teachers;
        private ICollection<Comment> comments;

        public Course(string name)
        {
            this.Id = Guid.NewGuid();
            this.name = name;
            this.Students = new HashSet<Student>();
            this.Teachers = new HashSet<Teacher>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public Guid Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.id = value;
            }
        }

        [Required]
        [MaxLength(50)]
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

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }

            private set
            {
                this.students = value;
            }
        }

        public virtual ICollection<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }

            private set
            {
                this.teachers = value;
            }
        }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                this.comments = value;
            }
        }

        public virtual School School { get; set; }

        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.Students.Remove(student);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            this.Teachers.Remove(teacher);
        }

        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            this.Comments.Remove(comment);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Course: " + this.Name);

            foreach (var teacher in this.Teachers)
            {
                sb.Append(teacher.ToString());
            }

            foreach (var student in this.Students)
            {
                sb.Append(student.ToString());
            }

            foreach (var comment in this.Comments)
            {
                sb.Append(comment.ToString());
            }

            sb.AppendLine();

            return sb.ToString();
        }
    }
}
