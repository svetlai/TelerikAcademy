namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Infrastructure;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// 93.75% code coverage
    /// </summary>
    [TestClass]
    public class CarsControllerTests
    {
        private ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new JustMockCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = string.Empty,
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = string.Empty,
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A4", model.Model);
            Assert.AreEqual(2005, model.Year);
        }

        [TestMethod]
        public void DetailShouldReturnCarView()
        {
            var result = (Car)this.GetModel(() => this.controller.Details(1));
            Assert.AreEqual("A4", result.Model);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DetailShouldThrowAnException()
        {
            var result = (Car)this.GetModel(() => this.controller.Details(-1));
        }

        [TestMethod]
        public void SearchShouldReturnCollection()
        {
            var result = (ICollection<Car>)this.GetModel(() => this.controller.Search("BMW"));
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void SortByMakeShouldReturnSortedCollection()
        {
            var sortedCars = (IView)this.controller.Sort("make");
            Assert.AreEqual("Opel", ((List<Car>)sortedCars.Model)[3].Make);
        }

        [TestMethod]
        public void SortByYearShouldReturnSortedCollection()
        {
            var sortedCars = (IView)this.controller.Sort("year");
            Assert.AreEqual("330d", ((List<Car>)sortedCars.Model)[0].Model);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortByNullShouldThrowException()
        {
            var result = (ICollection<Car>)this.GetModel(() => this.controller.Sort(string.Empty));
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
