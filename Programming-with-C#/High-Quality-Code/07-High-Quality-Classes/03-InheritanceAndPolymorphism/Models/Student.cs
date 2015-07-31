namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Text;

    using InheritanceAndPolymorphism.Common;

    public class Student
    {
        private const int NameMinLength = 2;
        private const int NameMaxLength = 30;
        private const int StudentNumberLength = 5;
        private const string EmptyStringExceptionMsg = "{0} must not be left blank.";
        private const string StringLengthExceptionMsg = "{0} must be between {1} and {2} symbols long.";

        private string firstName;
        private string lastName;
        private string studentNumber;
        private string fullName;

        public Student()
        {
        }

        public Student(string firstName, string lastName, string studentNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FullName = this.FirstName + " " + this.LastName;
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
                this.ValidateName(value, "First name");               
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
                this.ValidateName(value, "Last name");
                this.lastName = value;
            }
        }

        public string FullName 
        {
            get 
            {
                return this.fullName;
            }

            private set
            {
                this.fullName = value;
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
                this.ValidateStudentNumber(value, "Student number");
                this.studentNumber = value;
            }
        }

        public override string ToString()
        {
            return this.FullName + ", SN: " + this.StudentNumber;
        }

        private void ValidateName(string value, string property) 
        {
            Validator.ValidateEmptyString(value, property);
            Validator.ValidateStringLengthRange(value, property, NameMinLength, NameMaxLength);
        }

        private void ValidateStudentNumber(string value, string property)
        {
            Validator.ValidateEmptyString(value, property);
            Validator.ValidateExactStringLength(value, property, StudentNumberLength);
            Validator.ValidateStringOfDigit(value, property);
        }
    }
}
