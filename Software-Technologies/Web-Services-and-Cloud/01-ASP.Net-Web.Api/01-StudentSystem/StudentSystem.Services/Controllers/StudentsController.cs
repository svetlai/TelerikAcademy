namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.DBContext;
    using StudentSystem.Model;

    public class StudentsController : ApiController
    {
        private const string NoSuchId = "Invalid id. No student with such id was found.";
        private IStudentSystemDbContext db;

        public StudentsController()
            : this(new StudentSystemDBContext())
        {
        }

        public StudentsController(IStudentSystemDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IQueryable All()
        {
            var students = db.Students.Select(StudentModel.FromStudent);
            return students;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = GetStudentById(id);
            if (student == null)
            {
                return BadRequest(NoSuchId);
            }

            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Create(StudentModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                StudentNumber = student.StudentNumber,
                StudentStatus = student.StudentStatus
            };

            this.db.Students.Add(newStudent);
            this.db.SaveChanges();

            student.StudentId = newStudent.StudentId;

            return Ok(newStudent);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStudent = GetStudentById(id);

            if (existingStudent == null)
            {
                return BadRequest(NoSuchId);
            }
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.StudentNumber = student.StudentNumber;
                existingStudent.StudentStatus = student.StudentStatus;

            this.db.SaveChanges();

            student.StudentId = existingStudent.StudentId;
            return Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = GetStudentById(id);

            if (existingStudent == null)
            {
                return BadRequest(NoSuchId);
            }

            this.db.Students.Remove(existingStudent);
            this.db.SaveChanges();

            return Ok();
        }


        private Student GetStudentById (int id)
        {
            return db.Students
                .Where(s => s.StudentId == id)
                .FirstOrDefault();
        }
    }
}
