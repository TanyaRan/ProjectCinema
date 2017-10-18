using System.Collections.Generic;

namespace TRan.CinemaUniverse.Web.ViewModels.Home
{
    public class HomeViewModel
    {
        public ICollection<MovieViewModel> Movies { get; set; }
    }
}