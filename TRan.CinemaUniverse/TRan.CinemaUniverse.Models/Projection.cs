using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TRan.CinemaUniverse.Models.Abstract;

namespace TRan.CinemaUniverse.Models
{
    public class Projection : DataModel
    {
        private ICollection<Comment> comments;

        public Projection()
        {
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Range(100, 180)]
        [DataType(DataType.Duration)]
        public int Duration { get; set; }

        [Required]
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [Required]
        public Guid LecturerId { get; set; }

        public virtual User Lecturer { get; set; }

        public Guid? WeekOfferId { get; set; }

        public WeekOffer WeekOffer { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
