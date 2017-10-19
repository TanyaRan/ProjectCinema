using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TRan.CinemaUniverse.Models;
using TRan.CinemaUniverse.Web.Infrastructure;

namespace TRan.CinemaUniverse.Web.Areas.Administration.ViewModels
{
    public class GenreViewModel : IMapFrom<Genre>
    {
        //[HiddenInput]
        //public Guid Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        // TODO: ViewModel needs this ??[Index(IsUnique = true)] 
        public string Name { get; set; }
    }
}