namespace StudentSystem.Model
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homework;
        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homework = new HashSet<Homework>();
        }

        [Key]
        public int StudentId { get; set; }

        [MinLength(2), MaxLength(20)]
        [Required]
        public string FirstName { get; set; }

        [MinLength(2), MaxLength(20)]
        [Required]
        public string LastName { get; set; }

        public string StudentNumber { get; set; }

        public StudentStatus StudentStatus { get; set; }

        public virtual ICollection<Course> Courses 
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
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
