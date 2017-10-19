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
    public class GenreCreateViewModel : IMapFrom<Genre>
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
    }
}