namespace _11._2.Salaries
{
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            this.Subordinates = new List<Employee>();
        }

        public Employee(int Id)
            : this()
        {
            this.Id = Id;
            //this.Salary = 1;
        }

        public List<Employee> Subordinates { get; set; }

        public int Id { get; set; }

        public decimal Salary { get; set; }

    }
}
