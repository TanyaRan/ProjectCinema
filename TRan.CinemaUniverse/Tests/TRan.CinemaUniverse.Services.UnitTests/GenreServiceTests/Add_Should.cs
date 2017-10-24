﻿using Moq;
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
    public class Add_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WhenGenreIsNull()
        {
            // Arrange
            var mockGenreWrapper = new Mock<IEfDbSetWrapper<Genre>>();
            var mockContext = new Mock<IEfSaveContext>();

            var genreService = new GenreService(mockGenreWrapper.Object, mockContext.Object);
            var mockedGenre = new Mock<Genre>();

            // Act and Assert
            Assert.That(() => genreService.Add(null), Throws.ArgumentNullException.With.Message.Contains("genre"));
        }

        [Test]
        public void CallGenreWrapper_Add_WhenGenreIsValid()
        {
            // Arrange
            var mockGenreWrapper = new Mock<IEfDbSetWrapper<Genre>>();
            var mockContext = new Mock<IEfSaveContext>();

            var genreService = new GenreService(mockGenreWrapper.Object, mockContext.Object);
            var mockedGenre = new Mock<Genre>();

            // Act
            genreService.Add(mockedGenre.Object);

            // Assert
            mockGenreWrapper.Verify(x => x.Add(mockedGenre.Object), Times.Once());
        }

        [Test]
        public void Call_SaveContextCommit_WhenGenreIsValid()
        {
            // Arrange
            var mockGenreWrapper = new Mock<IEfDbSetWrapper<Genre>>();
            var mockContext = new Mock<IEfSaveContext>();

            var genreService = new GenreService(mockGenreWrapper.Object, mockContext.Object);
            var mockedGenre = new Mock<Genre>();

            // Act
            genreService.Add(mockedGenre.Object);

            // Assert
            mockContext.Verify(x => x.Commit(), Times.Once());
        }
    }
}
