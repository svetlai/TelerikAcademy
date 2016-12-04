namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.DBContext;
    using StudentSystem.Model;
    using StudentSystem.Services.Models;

    public class HomeworksController : ApiController
    {
        private const string NoSuchId = "Invalid id. No homework with such id was found.";
        private IStudentSystemDbContext db;

        public HomeworksController()
            : this(new StudentSystemDBContext())
        {
        }

        public HomeworksController(IStudentSystemDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IQueryable All()
        {
            var homeworks = db.Homeworks.Select(HomeworkModel.FromHomework);
            return homeworks;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var homework = GetHomeworkById(id);
            if (homework == null)
            {
                return BadRequest(NoSuchId);
            }

            return Ok(homework);
        }

        [HttpPost]
        public IHttpActionResult Create(HomeworkModel homework)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newHomework = new Homework
            {
                Contents = homework.Contents,
                TimeSent = homework.TimeSent,
                CourseId = homework.CourseId,
                StudentId = homework.StudentId
            };

            this.db.Homeworks.Add(newHomework);
            this.db.SaveChanges();

            homework.HomeworkId = newHomework.HomeworkId;

            return Ok(newHomework);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Homework homework)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStudent = GetHomeworkById(id);

            if (existingStudent == null)
            {
                return BadRequest(NoSuchId);
            }

            existingStudent.Contents = homework.Contents;
            existingStudent.TimeSent = homework.TimeSent;
            existingStudent.CourseId = homework.CourseId;
            existingStudent.StudentId = homework.StudentId;

            this.db.SaveChanges();

            homework.HomeworkId = existingStudent.HomeworkId;
            return Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingHomeowrk = GetHomeworkById(id);

            if (existingHomeowrk == null)
            {
                return BadRequest(NoSuchId);
            }

            this.db.Homeworks.Remove(existingHomeowrk);
            this.db.SaveChanges();

            return Ok();
        }


        private Homework GetHomeworkById(int id)
        {
            return db.Homeworks
                .Where(h => h.HomeworkId == id)
                .FirstOrDefault();
        }
    }
}
