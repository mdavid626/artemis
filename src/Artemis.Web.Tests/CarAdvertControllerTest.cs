using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artemis.Web.Controllers;
using NSubstitute;
using Artemis.Common;
using System.Web.Http.Results;
using Artemis.Web.Models;
using AutoMapper;

namespace Artemis.Web.Tests
{
    [TestClass]
    public class CarAdvertControllerTest
    {
        private IMapper CreateMappings()
        {
            return AutoMapperConfig.Create();
        }

        [TestMethod]
        public void TestValidGet()
        {
            var repository = Substitute.For<IRepository<CarAdvert>>();
            repository.Get().Returns(c => new CarAdvert[0]);
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var controller = new CarAdvertController(repository, unitOfWork, CreateMappings());

            var result = controller.Get();

            Assert.IsTrue(result is OkNegotiatedContentResult<CollectionResultDto<CarAdvertDto>>);
        }

        [TestMethod]
        public void TestValidGetId()
        {
            var carAdvert = new CarAdvert()
            {
                Id = 1,
                Title = "Audi"
            };
            var repository = Substitute.For<IRepository<CarAdvert>>();
            repository.Get(Arg.Any<int>()).Returns(c => carAdvert);
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var controller = new CarAdvertController(repository, unitOfWork, CreateMappings());

            var result = controller.Get(1) as OkNegotiatedContentResult<CarAdvertDto>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id, carAdvert.Id);
            Assert.AreEqual(result.Content.Title, carAdvert.Title);
        }
    }
}
