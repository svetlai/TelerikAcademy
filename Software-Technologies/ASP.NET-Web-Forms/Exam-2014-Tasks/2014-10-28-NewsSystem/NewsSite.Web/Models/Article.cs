namespace NewsSite.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article
    {
        private ICollection<Like> likes;

        public Article()
        {
            this.likes = new HashSet<Like>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100), MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MinLength(2)]
        public string Content { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateCreated { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
