namespace StudentSystem.Services.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using StudentSystem.DBContext;
    using StudentSystem.Services.Models;
    using StudentSystem.Model;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class CoursesController : ApiController
    {
        private const string NoSuchId = "Invalid id. No course with such id was found.";
        private IStudentSystemDbContext db;

        public CoursesController()
            : this(new StudentSystemDBContext())
        {
        }

        public CoursesController(IStudentSystemDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IQueryable All()
        {
            var courses = db.Courses.Select(CourseModel.FromCourse);
            return courses;
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var course = GetCourseById(id);
            if (course == null)
            {
                return BadRequest(NoSuchId);
            }

            return Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseModel course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCourse = new Course
            {
                CourseName = course.CourseName,
                Description = course.Description,
                Materials = course.Materials
            };

            this.db.Courses.Add(newCourse);
            this.db.SaveChanges();

            course.CourseId = newCourse.CourseId;

            return Ok(newCourse);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCourse = GetCourseById(id);

            if (existingCourse == null)
            {
                return BadRequest(NoSuchId);
            }

            existingCourse.CourseName = course.CourseName;
            existingCourse.Description = course.Description;
            existingCourse.Materials = course.Materials;
            this.db.SaveChanges();

            course.CourseId = existingCourse.CourseId;
            return Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingCourse = GetCourseById(id);

            if (existingCourse == null)
            {
                return BadRequest(NoSuchId);
            }

            this.db.Courses.Remove(existingCourse);
            this.db.SaveChanges();

            return Ok();
        }


        private Course GetCourseById (int id)
        {
            return db.Courses
                .Where(c => c.CourseId == id)
                .FirstOrDefault();
        }
    }
}
