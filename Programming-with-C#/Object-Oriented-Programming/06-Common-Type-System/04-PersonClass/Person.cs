namespace PersonClass
{
    using System;
    using System.Text;

    public class Person
    {
        private const string EmptyNameExceptionMsg = "Name cannot be empty.";
        private const string NameLengthExceptionMsg = "Name must be between 2 and 50 characters long.";
        private const string NegativeAgeExceptionMsg = "Age cannot be negative.";

        private string name;
        private int? age;

        public Person(string name)
            : this(name, null)
        {
        }

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
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

        public int? Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(NegativeAgeExceptionMsg);
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Name: " + this.Name)
                .Append("Age: ");

            if (this.Age == null)
            {
                sb.AppendLine("Not Specified");
            }
            else
            {
                sb.AppendLine(this.Age.ToString());
            }

            return sb.ToString();
        }
    }
}
