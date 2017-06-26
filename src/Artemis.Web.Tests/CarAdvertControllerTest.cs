using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artemis.Web.Controllers;
using NSubstitute;
using Artemis.Common;
using System.Web.Http.Results;
using Artemis.Web.Models;

namespace Artemis.Web.Tests
{
    [TestClass]
    public class CarAdvertControllerTest
    {
        [TestMethod]
        public void TestValidGet()
        {
            var repository = Substitute.For<ICarAdvertRepository>();
            repository.Get().Returns(c => new CarAdvert[0]);
            var controller = new CarAdvertController(repository);

            var result = controller.Get();

            Assert.IsTrue(result is OkNegotiatedContentResult<CollectionResult<CarAdvertViewModel>>);
        }

        [TestMethod]
        public void TestValidGetId()
        {
            var carAdvert = new CarAdvert()
            {
                Id = 1,
                Title = "Audi"
            };
            var repository = Substitute.For<ICarAdvertRepository>();
            repository.Get(Arg.Any<int>()).Returns(c => carAdvert);
            var controller = new CarAdvertController(repository);

            var result = controller.Get(1) as OkNegotiatedContentResult<CarAdvertViewModel>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id, carAdvert.Id);
            Assert.AreEqual(result.Content.Title, carAdvert.Title);
        }
    }
}
