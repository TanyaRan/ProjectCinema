using System.Collections.Generic;

namespace TRan.CinemaUniverse.Web.Models.Home
{
    public class HomeViewModel
    {
        public ICollection<MovieViewModel> Movies { get; set; }
    }
}