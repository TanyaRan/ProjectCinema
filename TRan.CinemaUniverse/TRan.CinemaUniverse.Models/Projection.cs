using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Models.Abstract;

namespace TRan.CinemaUniverse.Models
{
    public class Projection : DataModel
    {
        [Required]
        public DateTime Day { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        public Guid? MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public Guid? LecturerId { get; set; }

        public virtual User Lecturer { get; set; }
    }
}
