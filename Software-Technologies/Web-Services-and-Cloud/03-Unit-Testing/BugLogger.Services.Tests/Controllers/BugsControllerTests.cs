namespace BugLogger.Services.Tests.Controllers
{
    using BugLogger.Data;
    using BugLogger.Data.Repositories;
    using BugLogger.Model;
    using BugLogger.Services.Controllers;
    using BugLogger.Services.Models;
    using BugLogger.Services.Tests.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;
    using Telerik.JustMock;

    [TestClass]
    public class BugsControllerTests
    {
        //[TestMethod]
        //public void GetAllShouldReturnACollectionOfBugs()
        //{
        //    var fakeData = new FakeUoW();

        //    var fakeRepo = new FakeRepository<BugModel>();

        //    var bugs = fakeRepo.Entities = new List<BugModel>()
        //    {
        //        new BugModel()
        //        {
        //            Text = "New bug - test",
        //            Status = Status.Pending,
        //            LogDate = DateTime.Now
        //        },

        //        new BugModel()
        //        {
        //            Text = "New bug - test 2",
        //            Status = Status.Pending,
        //            LogDate = DateTime.Now
        //        }
        //    };

        //    fakeRepo.Entities = bugs;

        //    var controller = new BugsController(fakeData);
        //    //var controller = new BugsController(fakeRepo);

        //    var result = controller.All();

        //    CollectionAssert.AreEqual(bugs.ToList<BugModel>(), result.ToList<BugModel>());
        //}

        //[TestMethod]
        //public void CreateShouldAddBugToRepo()
        //{
        //    var fakeData = new FakeUoW();

        //    var fakeRepo = new FakeRepository<BugModel>();

        //    fakeRepo.IsSaveCalled = false;

        //    fakeRepo.Entities = new List<BugModel>();
        //    var bug = new BugModel
        //        {
        //            Text = "New bug - test"
        //        };
            
        //    //fakeRepo.Entities.Add(bug);
        //    var controller = new BugsController(fakeData);
        //    //var controller = new BugsController(fakeRepo);
        //    this.SetupController(controller);
        //    controller.Create(bug);

        //    //Assert.AreEqual(fakeRepo.Entities.Count, 1);
        //    //Assert.AreEqual(fakeRepo.Entities.First().Id, bug.Id);
        //    //Assert.IsNotNull(fakeRepo.Entities.First().LogDate);
        //    //Assert.IsNotNull(fakeRepo.Entities.First().Status);
        //    Assert.IsTrue(fakeRepo.IsSaveCalled);
        //}

        //[TestMethod]
        //public void GetAllShouldReturnACollectionOfBugsWithMock()
        //{
        //    var repo = Mock.Create<IRepository<Bug>>();

        //    var expected = new List<Bug>()
        //    {
        //        new Bug()
        //        {
        //            Text = "Bug 1"
        //        }
        //    };

        //    Mock.Arrange(() => repo.All())
        //        .Returns(() => expected.AsQueryable());

        //    var data = Mock.Create<BugLoggerData>();

        //    Mock.Arrange(() => data.Bugs)
        //        .Returns(() => repo);

        //    var controller = new BugsController(data);
        //    //this.SetupController(controller);

        //    var actual = controller.All();

        //    CollectionAssert.AreEquivalent(expected, actual.ToList());
        //}

        //public void CreateShouldAddBugToDbWithMock()
        //{
        //    var repo = Mock.Create<IRepository<Bug>>();

        //    var expected = new List<Bug>()
        //    {
        //        new Bug()
        //        {
        //            Text = "Bug 1"
        //        }
        //    };

        //    //Mock.Arrange(() => repo.Add(Arg.Is<Bug>))
        //    //    .Returns(() => true);

        //    var data = Mock.Create<BugLoggerData>();

        //    Mock.Arrange(() => data.Bugs)
        //        .Returns(() => repo);

        //    var controller = new BugsController(data);
        //    //this.SetupController(controller);

        //    var actual = controller.All();

        //    CollectionAssert.AreEquivalent(expected, actual.ToList());
        //}
        private void SetupController(ApiController controller)
        {
            string serverUrl = "http://test-url.com";

            //Setup the Request object of the controller
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(serverUrl)
            };
            controller.Request = request;

            //Setup the configuration of the controller
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
            controller.Configuration = config;

            //Apply the routes of the controller
            controller.RequestContext.RouteData =
                new HttpRouteData(
                    route: new HttpRoute(),
                    values: new HttpRouteValueDictionary
                    {
                        { "controller", "bugs" }
                    });
        }


    }
}
