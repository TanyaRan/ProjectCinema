﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TRan.CinemaUniverse.Models.Abstract;

namespace TRan.CinemaUniverse.Models
{
    public class WeekOffer : DataModel
    {
        private ICollection<Projection> projections;

        public WeekOffer()
        {
            this.projections = new HashSet<Projection>();
        }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Theme { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

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
