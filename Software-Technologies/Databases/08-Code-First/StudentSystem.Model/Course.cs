namespace StudentSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        private ICollection<Student> students;
        private ICollection<Homework> homework;
        public Course()
        {
            this.students = new HashSet<Student>();
            this.homework = new HashSet<Homework>();
        }

        [Key]
        public int CourseId { get; set; }

        [ConcurrencyCheck, 
            MinLength(3, ErrorMessage="Course name must be at least 3 characters long.")]
        public string CourseName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public string Materials { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }

        public virtual ICollection<Homework> Homework
        {
            get
            {
                return this.homework;
            }

            set
            {
                this.homework = value;
            }
        }
    }
}
