namespace SoftwareAcademy
{
    using System;
    using System.Text;

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private const string NullTownExcMsg = "Town cannot be null.";

        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NullTownExcMsg);
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0} Town={1}", base.ToString(), this.Town);

            return output.ToString();
        }
    }
}
