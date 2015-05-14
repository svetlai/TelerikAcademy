namespace NewsSite.Web.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Like
    {
        [Key]
        public int Id { get; set; }

        public int Value { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
