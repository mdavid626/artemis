using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artemis.Web.Controllers;
using NSubstitute;
using Artemis.Common;
using System.Web.Http.Results;
using Artemis.Web.Models;
using AutoMapper;
using Artemis.Web.ViewModels;
using System.Linq;

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
            var carAdvert = new CarAdvert()
            {
                Id = 1,
                Title = "Audi",
                Price = 1500,
                Fuel = FuelType.Diesel,
                IsNew = true
            };
            var vm = Substitute.For<IViewModel<CarAdvert>>();
            vm.Get(Arg.Any<QueryContext>()).Returns(c => new CarAdvert[] { carAdvert });

            var controller = new CarAdvertController(vm, CreateMappings());

            var result = controller.Get() as OkNegotiatedContentResult<CollectionResultDto<CarAdvertDto>>;

            Assert.IsNotNull(result);

            var item = result.Content.Entities.Single();
            Assert.AreEqual(item.Id, 1);
            Assert.AreEqual(item.Title, "Audi");
            Assert.AreEqual(item.Price, 1500);
            Assert.AreEqual(item.Fuel, "diesel");
            Assert.AreEqual(item.New, true);
        }

        [TestMethod]
        public void TestValidGetId()
        {
            var carAdvert = new CarAdvert()
            {
                Id = 1,
                Title = "Audi",
                Price = 1500,
                Fuel = FuelType.Diesel,
                IsNew = true
            };
            var vm = Substitute.For<IViewModel<CarAdvert>>();
            vm.Get(Arg.Any<int>()).Returns(c => carAdvert);
            var controller = new CarAdvertController(vm, CreateMappings());

            var result = controller.Get(1) as OkNegotiatedContentResult<CarAdvertDto>;

            Assert.IsNotNull(result);

            var item = result.Content;
            Assert.AreEqual(item.Id, 1);
            Assert.AreEqual(item.Title, "Audi");
            Assert.AreEqual(item.Price, 1500);
            Assert.AreEqual(item.Fuel, "diesel");
            Assert.AreEqual(item.New, true);
        }
    }
}
