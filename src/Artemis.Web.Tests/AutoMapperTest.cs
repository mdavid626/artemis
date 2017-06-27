using Artemis.Common;
using Artemis.Web.Models;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Web.Tests
{
    [TestClass]
    public class AutoMapperTest
    {
        [TestMethod]
        public void TestMapDtoToCarAdvert_NewCar()
        {
            var mapper = AutoMapperConfig.Create();
            var dto = new CarAdvertDto()
            {
                Id = 1,
                Title = "Audi",
                Price = 1500,
                Fuel = "gasoline",
                New = true
            };

            var carAdvert = mapper.Map<CarAdvert>(dto);

            Assert.AreEqual(carAdvert.Id, 1);
            Assert.AreEqual(carAdvert.Title, "Audi");
            Assert.AreEqual(carAdvert.Price, 1500);
            Assert.AreEqual(carAdvert.Fuel, FuelType.Gasoline);
            Assert.AreEqual(carAdvert.IsNew, true);
        }

        [TestMethod]
        public void TestMapDtoToCarAdvert_UsedCar()
        {
            var mapper = AutoMapperConfig.Create();
            var dto = new CarAdvertDto()
            {
                Id = 1,
                Title = "Audi",
                Price = 1500,
                Fuel = "gasoline",
                New = false,
                Mileage = 15000,
                FirstRegistration = DateTime.Now
            };

            var carAdvert = mapper.Map<CarAdvert>(dto);

            Assert.AreEqual(carAdvert.Id, 1);
            Assert.AreEqual(carAdvert.Title, "Audi");
            Assert.AreEqual(carAdvert.Price, 1500);
            Assert.AreEqual(carAdvert.Fuel, FuelType.Gasoline);
            Assert.AreEqual(carAdvert.IsNew, false);
            Assert.AreEqual(carAdvert.Mileage, 15000);
            Assert.AreEqual(carAdvert.FirstRegistration, DateTime.Now.Date);
        }

        [TestMethod]
        public void TestMapCarAdvertToDto_NewCar()
        {
            var mapper = AutoMapperConfig.Create();
            var carAdvert = new CarAdvert()
            {
                Id = 1,
                Title = "Audi",
                Price = 1500,
                Fuel = FuelType.Diesel,
                IsNew = true
            };

            var dto = mapper.Map<CarAdvertDto>(carAdvert);

            Assert.AreEqual(dto.Id, 1);
            Assert.AreEqual(dto.Title, "Audi");
            Assert.AreEqual(dto.Price, 1500);
            Assert.AreEqual(dto.Fuel, "diesel");
            Assert.AreEqual(dto.New, true);
        }

        [TestMethod]
        public void TestMapCarAdvertToDto_UsedCar()
        {
            var mapper = AutoMapperConfig.Create();
            var carAdvert = new CarAdvert()
            {
                Id = 1,
                Title = "Audi",
                Price = 1500,
                Fuel = FuelType.Diesel,
                IsNew = false,
                Mileage = 14000,
                FirstRegistration = DateTime.Now
            };

            var dto = mapper.Map<CarAdvertDto>(carAdvert);

            Assert.AreEqual(dto.Id, 1);
            Assert.AreEqual(dto.Title, "Audi");
            Assert.AreEqual(dto.Price, 1500);
            Assert.AreEqual(dto.Fuel, "diesel");
            Assert.AreEqual(dto.New, false);
            Assert.AreEqual(dto.Mileage, 14000);
            Assert.AreEqual(dto.FirstRegistration, DateTime.Now.Date);
        }

        [TestMethod]
        [ExpectedException(typeof(AutoMapperMappingException))]
        public void TestMapDtoToCarAdvert_NewCar_InvalidFuel()
        {
            var mapper = AutoMapperConfig.Create();
            var dto = new CarAdvertDto()
            {
                Id = 1,
                Title = "Audi",
                Price = 1500,
                Fuel = "invalid",
                New = true
            };

            var carAdvert = mapper.Map<CarAdvert>(dto);
        }
    }
}
