namespace StudentSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return s => new StudentModel
                {
                    StudentId = s.StudentId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    StudentNumber = s.StudentNumber,
                    StudentStatus = s.StudentStatus
                };
            }
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

        //public virtual ICollection<Course> Courses
        //{
        //    get
        //    {
        //        return this.courses;
        //    }

        //    set
        //    {
        //        this.courses = value;
        //    }
        //}

        //public virtual ICollection<Homework> Homework
        //{
        //    get
        //    {
        //        return this.homework;
        //    }

        //    set
        //    {
        //        this.homework = value;
        //    }
        //}
    }
}
