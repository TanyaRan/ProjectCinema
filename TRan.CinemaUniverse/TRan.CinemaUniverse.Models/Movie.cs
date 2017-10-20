﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRan.CinemaUniverse.Models.Abstract;

namespace TRan.CinemaUniverse.Models
{
    public class Movie : DataModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(2500, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Director { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 3)]
        public string ImageUrl { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string StarActor { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string StarActress { get; set; }

        [StringLength(250, MinimumLength = 10)]
        public string Award { get; set; }

        [StringLength(3000, MinimumLength = 10)]
        public string FilmingStory { get; set; }

        public Guid? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
