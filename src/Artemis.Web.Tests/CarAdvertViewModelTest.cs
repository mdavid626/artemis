using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artemis.Common;
using Artemis.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace Artemis.Web.Tests
{
    [TestClass]
    public class CarAdvertViewModelTest
    {
        private ICollection<ValidationResult> Validate(object obj)
        {
            var errors = new List<ValidationResult>();
            Validator.TryValidateObject(obj, new ValidationContext(obj), errors);
            return errors;
        }

        [TestMethod]
        public void TestValidMapping()
        {
            var vm = new CarAdvertDto();
            vm.Id = 1;
            vm.Title = "Audi";
            vm.Price = 5000;
            vm.Fuel = "gasoline";
            vm.New = true;

            var errors = Validate(vm);

            Assert.IsFalse(errors.Any());
        }

        [TestMethod]
        public void TestMissingFuel()
        {
            var vm = new CarAdvertDto();
            vm.Id = 1;
            vm.Title = "Audi";
            vm.Price = 5000;
            vm.New = true;

            var errors = Validate(vm);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void TestInvalidFuel()
        {
            var vm = new CarAdvertDto();
            vm.Id = 1;
            vm.Title = "Audi";
            vm.Price = 5000;
            vm.Fuel = "adsfdasf";
            vm.New = true;

            var errors = Validate(vm);

            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void TestUsedCar()
        {
            var vm = new CarAdvertDto();
            vm.Id = 1;
            vm.Title = "Audi";
            vm.Price = 5000;
            vm.Fuel = "diesel";
            vm.New = false;
            vm.Mileage = 5000;
            vm.FirstRegistration = DateTime.Now;

            var errors = Validate(vm);

            Assert.IsFalse(errors.Any());
        }

        [TestMethod]
        public void TestInvalidUsedCar()
        {
            var vm = new CarAdvertDto();
            vm.Id = 1;
            vm.Title = "Audi";
            vm.Price = 5000;
            vm.Fuel = "diesel";
            vm.New = true;
            vm.Mileage = 5000;
            vm.FirstRegistration = DateTime.Now;

            var errors = Validate(vm);

            Assert.IsTrue(errors.Any());
        }
    }
}
