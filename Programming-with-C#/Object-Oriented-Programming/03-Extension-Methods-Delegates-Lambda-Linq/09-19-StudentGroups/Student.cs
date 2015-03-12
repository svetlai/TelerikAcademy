namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private const string EmptyNameExceptionMsg = "Name cannot be empty.";
        private const string NegativeAgeExceptionMsg = "Age cannot be negative.";
        private const string NegativeGroupNumberExceptionMsg = "Group number cannot be negative.";

        private string firstName;
        private string lastName;
        private string fn;
        private string tel;
        private string email;
        private IEnumerable<int> marks;
        private int groupNumber;

        public Student(string firstName, string lastName, int groupNumber)
            : this(firstName, lastName, null, null, null, groupNumber, null)
        {
        }

        public Student(string firstName, string lastName, string fn, string phoneNumber, string email, int groupNumber)
            : this(firstName, lastName, fn, phoneNumber, email, groupNumber, null)
        {
            this.Marks = new List<int>();
        }

        public Student(string firstName, string lastName, string fn, string phoneNumber, string email, int groupNumber, IList<int> marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.GroupNumber = groupNumber;
            this.Marks = marks;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(EmptyNameExceptionMsg);
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(EmptyNameExceptionMsg);
                }

                this.lastName = value;
            }
        }

        public string FN
        {
            get
            {
                return this.fn;
            }

            set
            {
                this.fn = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.tel;
            }

            set
            {
                this.tel = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public IEnumerable<int> Marks
        {
            get
            {
                return this.marks;
            }

            set
            {
                this.marks = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(NegativeGroupNumberExceptionMsg);
                }

                this.groupNumber = value;
            }
        }

        public Group Group { get; set; }
    }
}
