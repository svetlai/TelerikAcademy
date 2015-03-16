namespace StudentsAndWorkers.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Human
    {
        private const string NameNullExceptionMsg = "Name cannot be empty.";

        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        [Required]
        [MinLength(3), StringLength(15)]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameNullExceptionMsg);
                }

                this.firstName = value;
            }
        }

        [Required]
        [MinLength(3), StringLength(15)]
        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NameNullExceptionMsg);
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
