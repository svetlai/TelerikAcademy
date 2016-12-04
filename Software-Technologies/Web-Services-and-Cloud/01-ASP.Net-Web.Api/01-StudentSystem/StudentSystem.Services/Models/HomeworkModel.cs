namespace StudentSystem.Services.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq.Expressions;

    using StudentSystem.Model;

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return h => new HomeworkModel
                {
                    HomeworkId = h.HomeworkId,
                    Contents = h.Contents,
                    TimeSent = h.TimeSent,
                    CourseId = h.CourseId,
                    StudentId = h.StudentId
                };
            }       
        }

        [Key]
        public int HomeworkId { get; set; }

        [Column("Homework Contents")]
        public string Contents { get; set; }

        public DateTime TimeSent { get; set; }

        public int CourseId { get; set; }

        //public virtual Course Course { get; set; }

        public int StudentId { get; set; }

        //public virtual Student Student { get; set; }
    }
}