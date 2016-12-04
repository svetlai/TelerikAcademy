namespace Countries.Models.ToDo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Category
    {
        private ICollection<ToDoTask> toDos;
        public Category()
        {
            this.toDos = new HashSet<ToDoTask>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ToDoTask> ToDos
        {
            get
            {
                return this.toDos;
            }
            set
            {
                this.toDos = value;
            }
        }
    }
}
