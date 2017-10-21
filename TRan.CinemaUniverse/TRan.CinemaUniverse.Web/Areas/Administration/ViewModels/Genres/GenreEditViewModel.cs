using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels.Genres
{
    public class GenreEditViewModel : IMapFrom<Genre>
    {
        public Guid Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
    }
}