namespace StudentSystem.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        public Homework()
        {
        }

        [Key]
        public int HomeworkId { get; set; }

        [Column("Homework Contents")]
        public string Contents { get; set; }

        public DateTime TimeSent { get; set; }
        
        public int CourseId { get; set; }
        
        public virtual Course Course { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

    }
}
