using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRan.CinemaUniverse.Models.Abstract;

namespace TRan.CinemaUniverse.Models
{
    public class Movie : DataModel
    {
        [Required]
        [StringLength(100, MinimumLength =2)]
        [Index(IsUnique = true)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Director { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10)]
        public string ImageUrl { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string StarActor { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string StarActress { get; set; }

        [StringLength(100, MinimumLength = 10)]
        public string Award { get; set; }

        [StringLength(1000, MinimumLength = 10)]
        public string FilmingStory { get; set; }

        public Guid? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
