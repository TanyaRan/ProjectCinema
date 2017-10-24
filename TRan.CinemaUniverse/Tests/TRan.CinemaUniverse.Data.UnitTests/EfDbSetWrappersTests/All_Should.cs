using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Data.Repositories;
using TRan.CinemaUniverse.Data.UnitTests.Fake;

namespace TRan.CinemaUniverse.Data.UnitTests.EfDbSetWrappersTests
{
    [TestFixture]
    public class All_Should
    {
        private IQueryable<EfDbSetWrapperTypeFake> GetData()
        {
            var data = new List<EfDbSetWrapperTypeFake>()
            {
                new EfDbSetWrapperTypeFake(),
                new EfDbSetWrapperTypeFake()
            }.AsQueryable();

            return data;
        }

        [Test]
        public void CallDbContext_DbSet()
        {
            // Arrange
            var data = this.GetData();

            var dbSetMock = new Mock<IDbSet<EfDbSetWrapperTypeFake>>();
            dbSetMock.Setup(s => s.Provider).Returns(data.Provider);
            dbSetMock.Setup(s => s.Expression).Returns(data.Expression);
            dbSetMock.Setup(s => s.ElementType).Returns(data.ElementType);
            dbSetMock.Setup(s => s.GetEnumerator()).Returns(data.GetEnumerator());

            //var dbContextMock = new Mock<CinemaSqlDbContext>();
            //dbContextMock
            //    .Setup(c => c.Set<EfDbSetWrapperTypeFake>()).Returns(dbSetMock.Object);
            //var repository = new EfDbSetWrapper<EfDbSetWrapperTypeFake>(dbContextMock.Object);

            // Act
            // var result = repository.All;

            // Assert
            //dbContextMock.Verify(c => c.Set<EfDbSetWrapperTypeFake>(), Times.Once);
        }
    }
}
