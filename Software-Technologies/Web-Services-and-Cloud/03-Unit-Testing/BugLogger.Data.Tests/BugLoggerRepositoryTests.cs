namespace BugLogger.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using BugLogger.Data.Contracts;
    using BugLogger.Data.Repositories;
    using BugLogger.Model;

    [TestClass]
    public class BugLoggerRepositoryTests
    {
        static TransactionScope tran;

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void AddShouldAddBugToDb()
        {
            var bug = this.CreateBug();

            var db = new BugLoggerDbContext();
            var repo = new Repository<Bug>(db);

            repo.Add(bug);
            repo.SaveChanges();

            var bugInDb = db.Bugs.Find(bug.Id);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        public void FindByIdShouldReturnObject()
        {
            var bug = this.CreateBug();

            var db = new BugLoggerDbContext();
            var repo = new Repository<Bug>(db);

            db.Bugs.Add(bug);
            db.SaveChanges();

            var bugInDb = repo.Find(bug.Id);

            Assert.IsNotNull(bugInDb);
            Assert.AreEqual(bug.Text, bugInDb.Text);
        }

        [TestMethod]
        public void AllShouldReturnAllBugs()
        {
            var bug = this.CreateBug();

            var db = new BugLoggerDbContext();
            var repo = new Repository<Bug>(db);

            db.Bugs.Add(bug);
            db.SaveChanges();

            var allBugsCount = db.Bugs.Count();
            var allBugs = repo.All();

            Assert.IsNotNull(allBugs);
            Assert.AreEqual(allBugsCount, allBugs.Count());
        }

        [TestMethod]
        public void UpdateShouldReturnBugWithNewInfo()
        {
            var bug = this.CreateBug();

            var db = new BugLoggerDbContext();
            var repo = new Repository<Bug>(db);

            db.Bugs.Add(bug);
            db.SaveChanges();

            bug.Status = Status.InProces;

            repo.Update(bug);

            var modifiedBug = db.Bugs.FirstOrDefault(b => b.Id == bug.Id);

            Assert.IsNotNull(bug);
            Assert.AreEqual(modifiedBug.Status, bug.Status);
        }

        //[TestMethod]
        public void DeleteBugShouldRemoveBugFromDb()
        {
            var bug = this.CreateBug();

            var db = new BugLoggerDbContext();
            var repo = new Repository<Bug>(db);

            db.Bugs.Add(bug);
            db.SaveChanges();

            repo.Delete(bug);
            var deletedBug = db.Bugs.Find(bug.Id);

            Assert.IsNull(deletedBug);
        }

        //[TestMethod]
        public void DeleteByIdShouldRemoveBugFromDb()
        {
            var bug = this.CreateBug();

            var db = new BugLoggerDbContext();
            var repo = new Repository<Bug>(db);

            db.Bugs.Add(bug);
            db.SaveChanges();

            repo.Delete(bug.Id);
            var deletedBug = db.Bugs.Find(bug.Id);

            Assert.IsNull(deletedBug);
        }
        private Bug CreateBug()
        {
            var bug = new Bug()
            {
                Text = "New bug - test",
                LogDate = DateTime.Now,
                Status = Status.Pending
            };

            return bug;
        }
    }
}
