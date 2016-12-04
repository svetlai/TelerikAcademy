namespace StudentSystem.DBContext
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using StudentSystem.Model;

    public class StudentSystemDBContext : DbContext
    {
        public StudentSystemDBContext()
            : base("name=StudentSystemDBContext")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }
    }
}
