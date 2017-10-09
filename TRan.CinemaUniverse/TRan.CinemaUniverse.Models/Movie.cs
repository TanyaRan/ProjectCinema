using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Models.Abstract;

namespace TRan.CinemaUniverse.Models
{
    public class Movie : DataModel
    {
        [Required]
        [StringLength(100, MinimumLength =2)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 2)]
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

        public virtual Genre Genre { get; set; }
    }
}
