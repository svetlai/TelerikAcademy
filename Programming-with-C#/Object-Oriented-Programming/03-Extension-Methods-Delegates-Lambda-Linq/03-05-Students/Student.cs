namespace Students
{
    using System;
    using System.Linq;

    public class Student
    {
        private const string EmptyNameExceptionMsg = "Name cannot be empty.";
        private const string NegativeAgeExceptionMsg = "Age cannot be negative.";

        private string firstName;
        private string lastName;
        private int? age;
        private string studentNumber;

        public Student(string firstName, string lastName)
            : this(firstName, lastName, null, null)
        {
        }

        public Student(string firstName, string lastName, int age)
            : this(firstName, lastName, age, null)
        {
        }

        public Student(string firstName, string lastName, int? age, string studentNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.StudentNumber = studentNumber;
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

        public int? Age 
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(NegativeAgeExceptionMsg);
                }

                this.age = value;
            }
        }

        public string StudentNumber
        {
            get
            {
                return this.studentNumber;
            }

            set
            {
                this.studentNumber = value;
            }
        }
    }
}
