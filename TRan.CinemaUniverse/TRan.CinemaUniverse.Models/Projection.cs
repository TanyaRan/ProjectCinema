﻿using System;
using System.ComponentModel.DataAnnotations;
using TRan.CinemaUniverse.Models.Abstract;

namespace TRan.CinemaUniverse.Models
{
    public class Projection : DataModel
    {
        [Required]
        public DateTime Day { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Range(100, 180)]
        public int Duration { get; set; }

        [Required]
        public Guid MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [Required]
        public Guid LecturerId { get; set; }

        public virtual User Lecturer { get; set; }
    }
}
