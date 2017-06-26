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
            vm.New = false;
            var carAdvert = new CarAdvert();
            var result = vm.MapTo(carAdvert);
            Assert.IsTrue(result);
        }
    }
}
