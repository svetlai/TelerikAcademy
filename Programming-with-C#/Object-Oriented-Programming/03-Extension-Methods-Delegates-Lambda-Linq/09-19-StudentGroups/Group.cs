namespace StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Group
    {
        private const string EmptyNameExceptionMsg = "Name cannot be empty.";
        private const string NegativeGroupNumberExceptionMsg = "Group number cannot be negative.";

        private int groupNumber;
        private string departmentName;

        public Group(int groupNumber, string departmentName)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = departmentName;
        }

        public int GroupNumber 
        {
            get
            {
                return this.groupNumber;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(NegativeGroupNumberExceptionMsg);
                }

                this.groupNumber = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                return this.departmentName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(EmptyNameExceptionMsg);
                }

                this.departmentName = value;
            }
        }
    }
}
