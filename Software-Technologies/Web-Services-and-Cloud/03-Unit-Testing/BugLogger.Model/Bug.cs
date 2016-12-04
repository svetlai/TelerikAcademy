namespace BugLogger.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        [Key]
        public int Id { get; set; }

        public Status Status { get; set; }

        public string Text { get; set; }

        [DataType("datetime")]
        public DateTime LogDate { get; set; }
    }
}
