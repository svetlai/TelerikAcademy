namespace Countries.Models.ToDo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ToDoTask
    {
        public ToDoTask()
        {
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime DateModified { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
