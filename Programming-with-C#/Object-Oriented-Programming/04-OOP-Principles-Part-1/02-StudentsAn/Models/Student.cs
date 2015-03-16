namespace StudentsAndWorkers.Models
{
    using System;

    public class Student : Human
    {
        private const string NegativeGradeExceptionMsg = "Grade cannot be negative.";
        private const string GradeOverHundredExceptionMsg = "Grade cannot be more than 100.";

        private int grade;

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeGradeExceptionMsg);
                }

                if (value > 100)
                {
                    throw new ArgumentException(GradeOverHundredExceptionMsg);
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            var name = base.ToString();
            return string.Format("{0}, Grade: {1}", name, this.Grade);
        }
    }
}
