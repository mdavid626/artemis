using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artemis.Data.Tests
{
    [TestClass]
    public class DbContextUnifOfWorkTest
    {
        [TestMethod]
        public void TestCommit()
        {
            var dbContext = Substitute.For<DbContext>();
            var dbContextProvider = Substitute.For<IDbContextProvider>();
            dbContextProvider.Provide().Returns(c => dbContext);
            var uof = new DbContextUnitOfWork(dbContextProvider);

            uof.Commit();

            dbContext.Received().SaveChanges();
        }

        [TestMethod]
        public void TestProvideContext()
        {
            var dbContext = Substitute.For<DbContext>();
            var dbContextProvider = Substitute.For<IDbContextProvider>();
            dbContextProvider.Provide().Returns(c => dbContext);
            var uof = new DbContextUnitOfWork(dbContextProvider);

            var context = uof.ProvideContext<DbContext>();

            Assert.AreEqual(context, dbContext);
        }

        [TestMethod]
        public void TestProvideContext2x()
        {
            var dbContext = Substitute.For<DbContext>();
            var dbContextProvider = Substitute.For<IDbContextProvider>();
            dbContextProvider.Provide().Returns(c => dbContext);
            var uof = new DbContextUnitOfWork(dbContextProvider);

            var context1 = uof.ProvideContext<DbContext>();
            var context2 = uof.ProvideContext<DbContext>();

            Assert.AreEqual(context1, dbContext);
            Assert.AreEqual(context2, dbContext);
        }

        [TestMethod]
        public void TestDisposeWithoutContextCreation()
        {
            var dbContext = Substitute.For<DbContext>();
            var dbContextProvider = Substitute.For<IDbContextProvider>();
            dbContextProvider.Provide().Returns(c => dbContext);
            var uof = new DbContextUnitOfWork(dbContextProvider);

            uof.Dispose();

            dbContext.DidNotReceive().Dispose();
        }

        [TestMethod]
        public void TestDisposeWithContextCreation()
        {
            var dbContext = Substitute.For<DbContext>();
            var dbContextProvider = Substitute.For<IDbContextProvider>();
            dbContextProvider.Provide().Returns(c => dbContext);
            var uof = new DbContextUnitOfWork(dbContextProvider);
            var context = uof.ProvideContext<DbContext>();

            uof.Dispose();

            dbContext.Received().Dispose();
        }
    }
}
