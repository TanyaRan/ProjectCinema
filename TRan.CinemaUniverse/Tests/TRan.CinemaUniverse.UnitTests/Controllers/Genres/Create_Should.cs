using AutoMapper;
using Moq;
using NUnit.Framework;
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
    public class Create_Should
    {
        [OneTimeSetUp]
        public void InitAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Genre, GenreCreateViewModel>();
            });
        }

        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            // var genresVM = new GenreCreateViewModel();
            var mockedGenreService = new Mock<IGenreService>();
            var mockedMapper = new Mock<IMapper>();
            var genresController = new GenresController(mockedGenreService.Object, mockedMapper.Object);

            // Act and Assert
            genresController
                .WithCallTo(gc => gc.Create())
                .ShouldRenderDefaultView()
                .WithModel<GenreCreateViewModel>();
        }

        [Test]
        public void RedirectToActionAll_IfModelIsValid()
        {
            // Arrange
            var name = "Crime";
            var genresVM = new GenreCreateViewModel()
            { Name = name };

            var mockedGenreService = new Mock<IGenreService>();
            var mockedMapper = new Mock<IMapper>();
            var genresController = new GenresController(mockedGenreService.Object, mockedMapper.Object);

            // Act and Assert
            genresController
                .WithCallTo(c => c.Create(genresVM))
                .ShouldRedirectTo(c => c.All(1));
        }
    }
}
