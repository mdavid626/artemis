using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Linq;
using Artemis.Common;

namespace Artemis.Data.Tests
{
    [TestClass]
    public class CarAdvertRepositoryTest
    {
        [TestMethod]
        public void TestValidGet()
        {
            using (var connection = Effort.DbConnectionFactory.CreateTransient())
            {
                // arrange
                var dbContext = new CarAdvertDbContext(connection, false);
                var carAdvert = new CarAdvert()
                {
                    Title = "Audi"
                };
                dbContext.CarAdverts.Add(carAdvert);
                dbContext.SaveChanges();

                var unitOfWork = Substitute.For<IUnitOfWork>();
                unitOfWork.ProvideContext<CarAdvertDbContext>().Returns(p => dbContext);
                var repository = new CarAdvertRepository(unitOfWork);

                // act
                var items = repository.Get().ToList();
                var firstItem = items.FirstOrDefault();

                // assert
                Assert.AreEqual(firstItem.Title, carAdvert.Title);
            }
        }

        [TestMethod]
        public void TestValidGetById()
        {
            using (var connection = Effort.DbConnectionFactory.CreateTransient())
            {
                // arrange
                var dbContext = new CarAdvertDbContext(connection, false);
                var carAdvert = new CarAdvert()
                {
                    Title = "Audi"
                };
                dbContext.CarAdverts.Add(carAdvert);
                dbContext.SaveChanges();

                var unitOfWork = Substitute.For<IUnitOfWork>();
                unitOfWork.ProvideContext<CarAdvertDbContext>().Returns(p => dbContext);
                var repository = new CarAdvertRepository(unitOfWork);

                // act
                var item = repository.Get(carAdvert.Id);

                // assert
                Assert.AreEqual(item.Title, carAdvert.Title);
            }
        }
    }
}
