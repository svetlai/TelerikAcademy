namespace DefensiveProgramming
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DefensiveProgramming.Contracts;

    public class Student
    {
        private string firstName;
        private string lastName;
        private IList<IExam> exams;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = new List<IExam>();
        }

        public Student(string firstName, string lastName, IList<IExam> exams)
            : this(firstName, lastName)
        {
            this.Exams = exams;
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
                    throw new ArgumentNullException("First name must not be left blank.");
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
                    throw new ArgumentNullException("Last name must not be left blank.");
                }

                this.lastName = value;
            }
        }

        public IList<IExam> Exams
        {
            get
            {
                return new List<IExam>(this.exams);
            }

            set
            {
                this.exams = value;
            }
        }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null || this.Exams.Count == 0)
            {
                throw new InvalidOperationException("This student has no exams yet.");
            }

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams == null || this.Exams.Count == 0)
            {
                throw new InvalidOperationException("This student has no exams yet.");
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}
