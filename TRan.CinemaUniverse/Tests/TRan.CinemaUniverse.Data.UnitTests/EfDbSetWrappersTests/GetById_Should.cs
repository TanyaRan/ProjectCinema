using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Data.UnitTests.Fake;

namespace TRan.CinemaUniverse.Data.UnitTests.EfDbSetWrappersTests
{
    [TestFixture]
    public class GetById_Should
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
        public void CallDbSetFind_WhenInvoked()
        {
            //var id = Guid.NewGuid();

            //var dbSetMock = new Mock<IDbSet<EfDbSetWrapperTypeFake>>();
            //var dbContextMock = new Mock<>
        }
    }
}
