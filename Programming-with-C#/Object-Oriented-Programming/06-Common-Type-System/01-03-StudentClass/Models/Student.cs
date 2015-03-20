namespace StudentClass.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Student : ICloneable, IComparable
    {
        private const string EmptyNameExceptionMsg = "Name cannot be empty.";
        private const string NameLengthExceptionMsg = "Name must be between 2 and 50 characters long.";

        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string address;
        private string phoneNumber;
        private string email;
        private int course;
        private Specialty specialty;
        private University university;
        private Faculty faculty;

        public Student(string firstName, string lastName, int course, Specialty specialty, University univeristy, Faculty faculty)
            : this(firstName, string.Empty, lastName, string.Empty, string.Empty, string.Empty, string.Empty, course, specialty, univeristy, faculty)
        {
        }

        public Student(string firstName, string middleName, string lastName, string ssn, string address, string phoneNumber, string email, int course, Specialty specialty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
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

                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentException(NameLengthExceptionMsg);
                }

                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }

            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentException(NameLengthExceptionMsg);
                }

                this.middleName = value;
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

                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentException(NameLengthExceptionMsg);
                }

                this.lastName = value;
            }
        }

        public string SSN
        {
            get
            {
                return this.ssn;
            }

            set
            {
                this.ssn = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                this.address = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                this.phoneNumber = value;
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

        public int Course
        {
            get
            {
                return this.course;
            }

            set
            {
                this.course = value;
            }
        }

        public Specialty Specialty
        {
            get
            {
                return this.specialty;
            }

            set
            {
                this.specialty = value;
            }
        }

        public University University
        {
            get
            {
                return this.university;
            }

            set
            {
                this.university = value;
            }
        }

        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }

            set
            {
                this.faculty = value;
            }
        }

        public static bool operator ==(Student first, Student second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !first.Equals(second);
        }

        public override bool Equals(object other)
        {
            var otherStudent = other as Student;
            if (other == null)
            {
                return false;
            }

            return this.FirstName == otherStudent.FirstName
                && this.LastName == otherStudent.LastName
                && this.University == otherStudent.University
                && this.Specialty == otherStudent.Specialty;
        }

        public override int GetHashCode()
        {
            int result = 0;
            for (int i = 0; i < this.FirstName.Length && i < this.LastName.Length; i++)
            {
                result += (int)this.FirstName[i] ^ (int)this.LastName[i] ^ (int)this.Specialty;
            }

            return base.GetHashCode() + result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.FirstName + " " + this.middleName + " " + this.LastName)
                .AppendLine("Specialty: " + this.Specialty + " " + this.Course + " course")
                .AppendLine("University: " + this.University)
                .AppendLine("Faculty: " + this.Faculty)
                .AppendLine("Address: " + this.Address)
                .AppendLine("Email: " + this.Email)
                .AppendLine("Phone number: " + this.PhoneNumber)
                .AppendLine("Social security number: " + this.SSN);

            return sb.ToString();
        }

        public object Clone()
        {
            Student original = this;
            Student newStudent = new Student(original.FirstName, original.MiddleName, original.LastName, original.SSN, original.Address, original.PhoneNumber, original.Email, original.Course, original.Specialty, original.University, original.Faculty);

            return newStudent;
        }

        public int CompareTo(object obj)
        {
            var otherStudent = obj as Student;
            if (this.FirstName.CompareTo(otherStudent.FirstName) <= 0)
            {
                return otherStudent.SSN.CompareTo(this.SSN);
            }

            return this.FirstName.CompareTo(otherStudent.FirstName);
        }
    }
}
