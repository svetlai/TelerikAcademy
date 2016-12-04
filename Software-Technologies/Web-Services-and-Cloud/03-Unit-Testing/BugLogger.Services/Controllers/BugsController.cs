namespace BugLogger.Services.Controllers
{
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http;
    using System.Net;
    using System;

    using BugLogger.Data;
    using BugLogger.Data.Contracts;
    using BugLogger.Data.Repositories;
    using BugLogger.Model;
    using BugLogger.Services.Models;

    public class BugsController : ApiController
    {
        private const string NoSuchId = "Invalid id. No bug with such id was found.";
        private IBugLoggerData data;
        private IRepository<Bug> repository;

        public BugsController()
            : this(new BugLoggerData())
        {
        }

        public BugsController(IBugLoggerData data)
        {
            this.data = data;
        }

        public BugsController(IRepository<Bug> repo)
        {
            this.repository = repo;
        }


        //[HttpGet]
        //public IQueryable<Bug> All()
        //{
        //    var bugs = this.repository.All();

        //    return bugs;
        //}

        //[HttpGet]
        //public IQueryable<BugModel> All()
        //{
        //    var bugs = this.data
        //        .Bugs
        //        .All()
        //        .Select(BugModel.FromBug);

        //    return bugs;
        //}

        [HttpGet]
        public IHttpActionResult All()
        {
            var bugs = this.data
                .Bugs
                .All()
                .Select(BugModel.FromBug);

            return Ok(bugs);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var bug = GetBugById(id);
            if (bug == null)
            {
                return BadRequest(NoSuchId);
            }

            return Ok(bug);
        }

        [HttpGet]
        public IQueryable GetByCount(int count)
        {
            var bugs = this.data
                .Bugs
                .All()
                .Select(BugModel.FromBug)
                .Take(count);

            return bugs;
        }

        [HttpGet]
        public IQueryable GetByCount(Status status)
        {
            var bugs = this.data
                .Bugs
                .All()
                .Where(b => b.Status == status)
                .Select(BugModel.FromBug);

            return bugs;
        }

        [HttpPost]
        public HttpResponseMessage Create(BugModel bug)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            var newBug = new Bug
            {
                Status = Status.Pending,
                Text = bug.Text,
                LogDate = DateTime.Now
            };

            this.data.Bugs.Add(newBug);
            this.data.SaveChanges();

            bug.Id = newBug.Id;

            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.Created, bug);
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = bug.Id }));
            return response;

            //return Ok(bug);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, BugModel bug)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingBug = this.data.Bugs.Find(id);

            if (existingBug == null)
            {
                return BadRequest(NoSuchId);
            }

            existingBug.Status = bug.Status;
            existingBug.Text = bug.Text;
            existingBug.LogDate = bug.LogDate;

            this.data.SaveChanges();

            bug.Id = existingBug.Id;

            return Ok(bug);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingBug = this.data.Bugs.Find(id);

            if (existingBug == null)
            {
                return BadRequest(NoSuchId);
            }

            this.data.Bugs.Delete(existingBug);
            this.data.SaveChanges();

            return Ok();
        }

        private BugModel GetBugById(int id)
        {
            return this.data
                .Bugs
                .All()
                .Select(BugModel.FromBug)
                .FirstOrDefault(b => b.Id == id);
        }
    }
}
