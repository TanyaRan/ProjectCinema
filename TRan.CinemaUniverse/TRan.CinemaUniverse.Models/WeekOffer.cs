using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TRan.CinemaUniverse.Models.Abstract;

namespace TRan.CinemaUniverse.Models
{
    public class WeekOffer : DataModel
    {
        private ICollection<Movie> movies;

        public WeekOffer()
        {
            this.movies = new HashSet<Movie>();
        }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Theme { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
