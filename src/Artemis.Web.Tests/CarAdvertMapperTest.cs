using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artemis.Common;
using Artemis.Web.Models;

namespace Artemis.Web.Tests
{
    [TestClass]
    public class CarAdvertMapperTest
    {
        [TestMethod]
        public void TestValidMapping()
        {
            var vm = new CarAdvertViewModel();
            vm.Id = 1;
            vm.Title = "Audi";
            vm.Price = 5000;
            vm.Fuel = "gasoline";
            vm.New = true;
            var carAdvert = new CarAdvert();
            var result = vm.MapTo(carAdvert);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestMissingFuel()
        {
            var vm = new CarAdvertViewModel();
            vm.Id = 1;
            vm.Title = "Audi";
            vm.Price = 5000;
            vm.New = true;
            var carAdvert = new CarAdvert();
            var result = vm.MapTo(carAdvert);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestInvalidFuel()
        {
            var vm = new CarAdvertViewModel();
            vm.Id = 1;
            vm.Title = "Audi";
            vm.Price = 5000;
            vm.Fuel = "adsfdasf";
            vm.New = true;
            var carAdvert = new CarAdvert();
            var result = vm.MapTo(carAdvert);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestUsedCar()
        {
            var vm = new CarAdvertViewModel();
            vm.Id = 1;
            vm.Title = "Audi";
            vm.Price = 5000;
            vm.Fuel = "diesel";
            vm.New = false;
            vm.Mileage = 5000;
            vm.FirstRegistration = DateTime.Now;
            var carAdvert = new CarAdvert();
            var result = vm.MapTo(carAdvert);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestInvalidUsedCar()
        {
            var vm = new CarAdvertViewModel();
            vm.Id = 1;
            vm.Title = "Audi";
            vm.Price = 5000;
            vm.Fuel = "diesel";
            vm.New = true;
            vm.Mileage = 5000;
            vm.FirstRegistration = DateTime.Now;
            var carAdvert = new CarAdvert();
            var result = vm.MapTo(carAdvert);
            Assert.IsFalse(result);
        }
    }
}
