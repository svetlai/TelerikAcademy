namespace SoftwareAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course : ICourse
    {
        private const string EmptyNameExcMsg = "Name cannot be null or empty.";

        private string name;
        private ITeacher teacher;
        private ICollection<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new HashSet<string>();
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
                    throw new ArgumentNullException(EmptyNameExcMsg);
                }

                this.name = value;
            }
        }

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }

            set
            {
                this.teacher = value;
            }
        }

        public ICollection<string> Topics
        {
            get
            {
                return new HashSet<string>(this.topics);
            }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        //(course type): Name=(course name); Teacher=(teacher name); Topics=[(course topics – comma separated)]; Lab=(lab name – when applicable); Town=(town name – when applicable);
        public override string ToString()
        {
            var output = new StringBuilder();

            string courseType = this.GetType().Name.ToString();
            output.AppendFormat("{0}: Name={1};", courseType, this.Name);

            if (this.Teacher != null)
            {
                output.AppendFormat(" Teacher={0};", this.Teacher.Name);
            }

            if (this.topics.Count > 0)
            {
                output.AppendFormat(" Topics=[{0}];", string.Join(", ", this.topics));
            }

            return output.ToString();
        }
    }
}
