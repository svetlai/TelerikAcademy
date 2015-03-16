namespace StudentsAndWorkers.Models
{
    using System;

    public class Worker : Human
    {
        private const string NegativeWeekSalaryExceptionMsg = "Week salary cannot be negative.";
        private const string NegativeWorkHoursExceptionMsg = "Work hours per day cannot be negative.";

        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            private set 
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeWeekSalaryExceptionMsg);
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeWorkHoursExceptionMsg);
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour { get; private set; }

        public void CalculateMoneyPerHour(int daysPerWeek)
        {
            this.MoneyPerHour = (this.WeekSalary / daysPerWeek) / (decimal)this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            var name = base.ToString();
            return string.Format("{0}, Money per hour: {1}", name, this.MoneyPerHour);
        }
    }
}
