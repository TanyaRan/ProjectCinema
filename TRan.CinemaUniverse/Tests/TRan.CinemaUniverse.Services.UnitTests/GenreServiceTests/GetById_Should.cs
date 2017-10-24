using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Data.Repositories;
using TRan.CinemaUniverse.Data.SaveContext;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Services.UnitTests.GenreServiceTests
{
    [TestFixture]
    public class GetById_Should
    {
        //[TestCase(null)]
        //public void Throw_ArgumentNullException_WhenGenreIsNull(Guid id)
        //{
        //    // Arrange
        //    var mockGenreWrapper = new Mock<IEfDbSetWrapper<Genre>>();
        //    var mockContext = new Mock<IEfSaveContext>();

        //    var genreService = new GenreService(mockGenreWrapper.Object, mockContext.Object);
        //    var mockedGenre = new Mock<Genre>();

        //    // Act and Assert
        //    Assert.That(() => genreService.GetById(id), Throws.ArgumentNullException.With.Message.Contains("id"));
        //}

        [Test]
        public void CallGenreWrapper_GetById_WhenGenreIsValid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockGenreWrapper = new Mock<IEfDbSetWrapper<Genre>>();
            var mockContext = new Mock<IEfSaveContext>();

            var genreService = new GenreService(mockGenreWrapper.Object, mockContext.Object);

            // Act
            genreService.GetById(id);

            // Assert
            mockGenreWrapper.Verify(x => x.GetById(id), Times.Once());
        }

        [Test]
        public void ReturnCorrectGenre_WhenIdIsValid()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockGenreWrapper = new Mock<IEfDbSetWrapper<Genre>>();
            var mockContext = new Mock<IEfSaveContext>();

            var genreService = new GenreService(mockGenreWrapper.Object, mockContext.Object);
            var mockedGenre = new Mock<Genre>().Object;
            mockedGenre.Id = id;

            mockGenreWrapper.Setup(x => x.GetById(id))
                .Returns(mockedGenre);

            // Act
            var result = genreService.GetById(id);

            // Assert
            Assert.AreSame(mockedGenre, result);
        }
    }
}
