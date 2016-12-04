namespace StudentSystem.DBContext
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using StudentSystem.Model;
    using StudentSystem.DBContext.Migrations;

    public class StudentSystemDBContext : DbContext, IStudentSystemDbContext
    {
        public StudentSystemDBContext()
            : base("name=StudentSystemDBContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemDBContext, Configuration>());
        }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
