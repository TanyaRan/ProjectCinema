using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRan.CinemaUniverse.Models.Abstract;

namespace TRan.CinemaUniverse.Models
{
    public class Movie : DataModel
    {
        private ICollection<Actor> actors;
        private ICollection<Projection> projections;

        public Movie()
        {
            this.actors = new HashSet<Actor>();
            this.projections = new HashSet<Projection>();
        }

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

        [StringLength(250, MinimumLength = 10)]
        public string Award { get; set; }

        [StringLength(3000, MinimumLength = 10)]
        public string FilmingStory { get; set; }

        public Guid? GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<Actor> Actors
        {
            get
            {
                return this.actors;
            }
            set
            {
                this.actors = value;
            }
        }

        public virtual ICollection<Projection> Projections
        {
            get
            {
                return this.projections;
            }
            set
            {
                this.projections = value;
            }
        }
    }
}
