using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artemis.Web.Controllers;
using NSubstitute;
using Artemis.Common;
using System.Web.Http.Results;
using Artemis.Web.Models;
using AutoMapper;
using Artemis.Web.ViewModels;

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
            var vm = Substitute.For<IViewModel<CarAdvert>>();
            vm.Get(Arg.Any<QueryContext>()).Returns(c => new CarAdvert[0]);

            var controller = new CarAdvertController(vm, CreateMappings());

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
            var vm = Substitute.For<IViewModel<CarAdvert>>();
            vm.Get(Arg.Any<int>()).Returns(c => carAdvert);
            var controller = new CarAdvertController(vm, CreateMappings());

            var result = controller.Get(1) as OkNegotiatedContentResult<CarAdvertDto>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.Id, carAdvert.Id);
            Assert.AreEqual(result.Content.Title, carAdvert.Title);
        }
    }
}
