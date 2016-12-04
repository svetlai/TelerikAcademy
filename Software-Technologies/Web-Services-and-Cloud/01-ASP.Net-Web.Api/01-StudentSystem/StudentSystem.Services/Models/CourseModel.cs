namespace StudentSystem.Services.Models
{
    using StudentSystem.Model;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class CourseModel
    {
        public static Expression<Func<Course, CourseModel>> FromCourse
        {
           get 
            {
                return c => new CourseModel
                {
                    CourseId = c.CourseId,
                    CourseName = c.CourseName,
                    Description = c.Description,
                    Materials = c.Materials
                };
            }

        }

        [Key]
        public int CourseId { get; set; }

        [ConcurrencyCheck, 
            MinLength(3, ErrorMessage="Course name must be at least 3 characters long.")]
        public string CourseName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public string Materials { get; set; }

    }
}