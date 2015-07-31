namespace Methods.Models
{
    using System;
    
    using Methods.HelperMethods;

    public class Student
    {
        private const int NameMinLength = 2;
        private const int NameMaxLength = 30;

        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;
        private string otherInfo;

        public Student()
        {
        }

        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
            this.DateOfBirth = DateTime.Parse(this.otherInfo.Substring(this.otherInfo.Length - 10));
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

        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }

            set
            {
                Validator.ValidateEmptyString(value, "Other info");
                this.otherInfo = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            private set
            {
                this.dateOfBirth = value;
            }
        }

        /// <summary>
        /// Compares curent student's age to another one's.
        /// </summary>
        /// <param name="other">Variable of type Student to compare the current student with.</param>
        /// <returns>Returns true if current student is older than <paramref name="other"/> and false otherwise.</returns>
        public bool IsOlderThan(Student other)
        {
            DateTime currentStudentBirthDate = this.DateOfBirth;
            DateTime otherStudentBirthDate = other.DateOfBirth;
            bool isOlder = currentStudentBirthDate < otherStudentBirthDate;

            return isOlder;
        }

        private void ValidateName(string value, string property) 
        {
            Validator.ValidateEmptyString(value, property);
            Validator.ValidateStringLengthRange(value, property, NameMinLength, NameMaxLength);
        }
    }
}
