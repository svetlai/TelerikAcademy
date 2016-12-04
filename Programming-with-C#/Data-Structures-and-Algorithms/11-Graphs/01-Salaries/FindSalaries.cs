namespace _11._2.Salaries
{
    using System;
    using System.Collections.Generic;

    public class FindSalaries
    {
        static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

        static HashSet<int> visited = new HashSet<int>();

        public static void Main()
        {
            int C = int.Parse(Console.ReadLine());

            for (int i = 0; i < C; i++)
            {
                var line = Console.ReadLine();

                if (!employees.ContainsKey(i))
                {
                    //employees[i] = new Employee(i);
                    var employee = new Employee(i);
                    employees.Add(i, employee);
                }

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        if (!employees.ContainsKey(j))
                        {
                            employees[j] = new Employee(j);
                            //var employee = new Employee(j);
                            //employees.Add(j, employee);
                        }

                        employees[i].Subordinates.Add(employees[j]);
                        //employees[i].Salary += employees[j].Salary;
                    }
                }

            }
            decimal allSalaries = 0;
            foreach (var employee in employees.Values)
            {
                DFS(employee);
                allSalaries += employee.Salary;
            }

            Console.WriteLine(allSalaries);
        }

        public static void DFS(Employee node)
        {
            if (node.Subordinates.Count == 0)
            {
                node.Salary = 1;
                return;
            }

            if (!visited.Contains(node.Id))
            {
                visited.Add(node.Id);

                //int salary = 0;
                foreach (var subordinate in node.Subordinates)
                {
                    DFS(subordinate);
                    node.Salary += subordinate.Salary;
                }

                //node.Salary = salary;
            }
        }
    }
}
