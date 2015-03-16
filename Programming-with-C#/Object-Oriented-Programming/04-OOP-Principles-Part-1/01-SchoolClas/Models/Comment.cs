namespace SchoolClasses.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        private const string TitleNullExceptionMsg = "Title cannot be empty.";
        private const string ContentsNullExceptionMsg = "Contents cannot be empty.";

        private string title;
        private string contents;
        private Person author;

        public Comment(string title, string contents, Person author)
        {
            this.Title = title;
            this.Contents = contents;
            this.Author = author;
        }

        [Required]
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(TitleNullExceptionMsg);
                }

                this.title = value;
            }
        }

        [Required]
        public string Contents
        {
            get
            {
                return this.contents;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(ContentsNullExceptionMsg);
                }

                this.contents = value;
            }
        }

        [Required]
        public Person Author
        {
            get
            {
                return this.author;
            }

            set
            {
                this.author = value;
            }
        }
    }
}
