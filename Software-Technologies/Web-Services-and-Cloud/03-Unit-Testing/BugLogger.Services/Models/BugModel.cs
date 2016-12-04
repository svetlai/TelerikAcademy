namespace BugLogger.Services.Models
{
    using System;
    using System.Linq.Expressions;

    using BugLogger.Model;

    public class BugModel
    {
        public static Expression<Func<Bug, BugModel>> FromBug
        {
            get
            {
                return b => new BugModel
                {
                    Id = b.Id,
                    Status = b.Status,
                    Text = b.Text,
                    LogDate = b.LogDate
                };
            }
        }
		
        public int Id { get; set; }

        public Status Status { get; set; }

        public string Text { get; set; }

        public DateTime LogDate { get; set; }
    }
}