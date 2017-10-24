using AutoMapper;
using Moq;
using NUnit.Framework;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Services.Contracts;
using TRan.CinemaUniverse.Web.Areas.Administration.Controllers;
using TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Genres;

namespace TRan.CinemaUniverse.UnitTests.Controllers.Genres
{
    [TestFixture]
    public class All_Should
    {
        [OneTimeSetUp]
        public void InitAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Genre, GenreEditViewModel>();
            });
        }

        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var page = 1;
            var mockedGenreService = new Mock<IGenreService>();
            var mockedMapper = new Mock<IMapper>();
            var genresController = new GenresController(mockedGenreService.Object, mockedMapper.Object);

            // Act and Assert
            genresController
                .WithCallTo(gc => gc.All(page))
                .ShouldRenderDefaultView()
                .WithModel<IPagedList<GenreEditViewModel>>();
        }

        [Test]
        public void CallGenreService_GetAll_WhenInvoked()
        {
            // Arrange
            var page = 1;
            var mockedGenreService = new Mock<IGenreService>();
            var mockedMapper = new Mock<IMapper>();
            var genresController = new GenresController(mockedGenreService.Object, mockedMapper.Object);

            // Act
            genresController.All(page);

            // Assert
            mockedGenreService.Verify(s => s.GetAll(), Times.Once);
        }
    }
}
