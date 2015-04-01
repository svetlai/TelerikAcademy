namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        private const string EmptyNameExceptionMsg = "Name cannot be left empty.";
        private const string NameLengthExceptionMsg = "Name must be between 2 and 50 characters long.";
        private const string NullPilotExceptionMsg = "Pilot cannot be null.";
        private const string NullTargetsExceptionMsg = "List of targets cannot be null.";

        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IList<string> targets;

        public Machine(string name, double healthPoints, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
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

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(NullPilotExceptionMsg);
                }

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get 
            {
                return this.attackPoints;
            }

            protected set
            {
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get 
            {
                return this.defensePoints;
            }

            protected set
            {
                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get 
            {
                return this.targets;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(NullTargetsExceptionMsg);
                }

                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            string targets = this.Targets.Count > 0 ? string.Join(", ", this.Targets) : "None";

            sb.AppendLine("- " + this.Name)
                .AppendFormat(" *Type: {0}", this.GetType().Name.ToString())
                    .AppendLine()
                .AppendFormat(" *Health: {0}", this.HealthPoints)
                    .AppendLine()
                .AppendFormat(" *Attack: {0}", this.AttackPoints)
                    .AppendLine()
                .AppendFormat(" *Defense: {0}", this.DefensePoints)
                    .AppendLine()
                .AppendLine(string.Format(" *Targets: {0}", targets));
                    
            return sb.ToString();
        }
    }
}
