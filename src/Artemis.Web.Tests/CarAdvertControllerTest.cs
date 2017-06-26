using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artemis.Web.Controllers;
using NSubstitute;
using Artemis.Common;
using System.Web.Http.Results;
using Artemis.Web.Model;

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
            Assert.IsTrue(result is OkNegotiatedContentResult<CarAdvertContainer>);
        }
    }
}
