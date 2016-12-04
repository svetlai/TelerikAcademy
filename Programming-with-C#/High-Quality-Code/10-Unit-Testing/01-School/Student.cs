namespace School
{
    using System;

    public class Student
    {
        public const int MinId = 10000;
        public const int MaxId = 99999;

        private const int MinNameLength = 2;
        private const int MaxNameLength = 50;
        
        private static int idCounter;

        private string name;
        private int studentId;

        static Student()
        {
            idCounter = MinId;
        }

        public Student(string name)
        {
            this.Name = name;
            this.StudentId = idCounter;
            idCounter++;
        }

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
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                if (value.Length < MinNameLength || value.Length > MaxNameLength)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Name must be between {0} and {1} characters long.", MinNameLength, MaxNameLength));
                }

                this.name = value;
            }
        }

        public int StudentId
        {
            get
            {
                return this.studentId;
            }

            private set
            {
                if (value < MinId || value > MaxId)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Student number must be in the range between {0} and {1}", MinId, MaxId));
                }

                this.studentId = value;
            }
        }
    }
}
