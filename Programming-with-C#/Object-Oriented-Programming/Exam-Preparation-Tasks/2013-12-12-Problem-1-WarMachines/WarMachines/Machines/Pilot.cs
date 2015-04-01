namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using WarMachines.Interfaces;

    public class Pilot : IPilot
    {
        private const string EmptyNameExceptionMsg = "Name cannot be left empty.";
        private const string NameLengthExceptionMsg = "Name must be between 2 and 50 characters long.";
        private const string NullMachinesExceptionMsg = "List of machines cannot be null.";

        private string name;
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.Machines = new HashSet<IMachine>();
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
                    throw new ArgumentNullException(EmptyNameExceptionMsg);
                }

                if (value.Length < 2 || value.Length > 50)
                {
                    throw new ArgumentException(NameLengthExceptionMsg);
                }

                this.name = value;
            }
        }

        public ICollection<IMachine> Machines
        {
            get
            {
                return this.machines;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(NullMachinesExceptionMsg);
                }

                this.machines = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.Machines.Add(machine);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            string machinesCount = this.Machines.Count > 0 ? this.Machines.Count.ToString() : "no";
            string singularOrPlural = this.Machines.Count == 1 ? "machine" : "machines";

            sb.AppendLine(string.Format("{0} - {1} {2}", this.Name, machinesCount, singularOrPlural));
            
            if (this.Machines.Count > 0)
            {
                var sortedMachines = this.Machines
                    .OrderBy(m => m.HealthPoints)
                    .ThenBy(m => m.Name);

                foreach (var machine in sortedMachines)
                {
                    sb.AppendLine(machine.ToString());
                }
            }

            return sb.ToString().Trim();
        }
    }
}
