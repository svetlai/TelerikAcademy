namespace SchoolClasses.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using SchoolClasses.Contracts;

    public class Course : IHaveComments
    {
        private string identifier;
        private ICollection<Student> students;
        private ICollection<Teacher> teachers;
        private ICollection<Comment> comments;

        public Course(string identifier)
        {
            this.Identifier = identifier;
            this.Students = new HashSet<Student>();
            this.Teachers = new HashSet<Teacher>();
            this.Comments = new HashSet<Comment>();
        }

        // TODO: unique
        [Required]
        [MaxLength(50)]
        public string Identifier
        {
            get
            {
                return this.identifier;
            }

            private set
            {
                this.identifier = value;
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
    }
}
