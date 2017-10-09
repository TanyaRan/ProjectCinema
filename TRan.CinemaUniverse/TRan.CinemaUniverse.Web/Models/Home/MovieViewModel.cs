using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TRan.CinemaUniverse.Web.Models.Home
{
    public class MovieViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Director { get; set; }

        public string ImageUrl { get; set; }
    }
}