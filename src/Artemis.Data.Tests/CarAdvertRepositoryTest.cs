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
                    Title = "Audi",
                    Price = 1500,
                    IsNew = true
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
                Assert.AreEqual(firstItem.Price, carAdvert.Price);
                Assert.AreEqual(firstItem.IsNew, carAdvert.IsNew);
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
                    Title = "Audi",
                    Price = 1500,
                    IsNew = true
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
                Assert.AreEqual(item.Price, carAdvert.Price);
                Assert.AreEqual(item.IsNew, carAdvert.IsNew);
            }
        }

        [TestMethod]
        public void TestValidCreate()
        {
            using (var connection = Effort.DbConnectionFactory.CreateTransient())
            {
                // arrange
                var dbContext = new CarAdvertDbContext(connection, false);

                var dbContextProvider = Substitute.For<IDbContextProvider>();
                dbContextProvider.Provide().Returns(p => dbContext);

                using (var unitOfWork = new DbContextUnitOfWork(dbContextProvider))
                {
                    var carAdvert = new CarAdvert()
                    {
                        Title = "Audi",
                        Price = 1500,
                        IsNew = true
                    };

                    var repository = new CarAdvertRepository(unitOfWork);

                    // act
                    repository.Create(carAdvert);
                    unitOfWork.Commit();

                    // assert
                    var item = dbContext.CarAdverts.Single();
                    Assert.AreEqual(item.Title, carAdvert.Title);
                    Assert.AreEqual(item.Price, carAdvert.Price);
                    Assert.AreEqual(item.IsNew, carAdvert.IsNew);
                }
            }
        }

        [TestMethod]
        public void TestValidUpdate()
        {
            using (var connection = Effort.DbConnectionFactory.CreateTransient())
            {
                // arrange
                var dbContext = new CarAdvertDbContext(connection, false);
                var carAdvert = new CarAdvert()
                {
                    Title = "Audi",
                    Price = 1500,
                    IsNew = true
                };
                dbContext.CarAdverts.Add(carAdvert);
                dbContext.SaveChanges();

                var dbContextProvider = Substitute.For<IDbContextProvider>();
                dbContextProvider.Provide().Returns(p => dbContext);

                using (var unitOfWork = new DbContextUnitOfWork(dbContextProvider))
                {
                    var repository = new CarAdvertRepository(unitOfWork);
                    var carAdvertToUpdate = repository.Get(carAdvert.Id);

                    // act
                    carAdvertToUpdate.Title = "Audi2";
                    carAdvertToUpdate.Price = 1600;
                    repository.Update(carAdvert);

                    unitOfWork.Commit();

                    // assert
                    var item = dbContext.CarAdverts.Single();
                    Assert.AreEqual(item.Title, "Audi2");
                    Assert.AreEqual(item.Price, 1600);
                    Assert.AreEqual(item.IsNew, true);
                }
            }
        }

        [TestMethod]
        public void TestValidDelete()
        {
            using (var connection = Effort.DbConnectionFactory.CreateTransient())
            {
                // arrange
                var dbContext = new CarAdvertDbContext(connection, false);
                var carAdvert = new CarAdvert()
                {
                    Title = "Audi",
                    Price = 1500,
                    IsNew = true
                };
                dbContext.CarAdverts.Add(carAdvert);
                dbContext.SaveChanges();

                var dbContextProvider = Substitute.For<IDbContextProvider>();
                dbContextProvider.Provide().Returns(p => dbContext);

                using (var unitOfWork = new DbContextUnitOfWork(dbContextProvider))
                {
                    var repository = new CarAdvertRepository(unitOfWork);
                    var carAdvertToDelete = repository.Get(carAdvert.Id);

                    // act
                    repository.Delete(carAdvertToDelete);
                    unitOfWork.Commit();

                    // assert
                    var isAny = dbContext.CarAdverts.Any();
                    Assert.IsFalse(isAny);
                }
            }
        }
    }
}
