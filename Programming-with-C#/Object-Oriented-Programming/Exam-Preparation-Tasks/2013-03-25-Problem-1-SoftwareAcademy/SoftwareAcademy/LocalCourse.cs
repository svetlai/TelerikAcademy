namespace SoftwareAcademy
{
    using System;
    using System.Text;

    public class LocalCourse : Course, ILocalCourse
    {
        private const string NullLabExcMsg = "Lab cannot be null.";
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(NullLabExcMsg);
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0} Lab={1}", base.ToString(), this.Lab);
            
            return output.ToString();
        }
    }
}
