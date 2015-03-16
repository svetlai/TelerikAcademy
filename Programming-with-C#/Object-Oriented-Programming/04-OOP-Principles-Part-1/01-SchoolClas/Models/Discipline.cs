namespace SchoolClasses.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using SchoolClasses.Contracts;

    public class Discipline : IHaveComments
    {
        private const string NameNullExceptionMsg = "Name cannot be empty.";
        private const string NegativeLecturesExceptionMsg = "Number of lectures cannot be negative.";
        private const string NegativeExercisesExceptionMsg = "Number of exercises cannot be negative.";

        private string name;
        private int numberOfLectures;
        private int numberOfExercises;
        private ICollection<Comment> comments;

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
            this.Comments = new List<Comment>();
        }

        [Required]
        [MinLength(2), StringLength(30)]
        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameNullExceptionMsg);
                }

                this.name = value;
            }
        }

        [Required]
        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeLecturesExceptionMsg);
                }

                this.numberOfLectures = value;
            }
        }

        [Required]
        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeExercisesExceptionMsg);
                }

                this.numberOfExercises = value;
            }
        }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                this.comments = value;
            }
        }

        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
        }

        public void RemoveComment(Comment comment)
        {
            this.Comments.Remove(comment);
        }
    }
}
