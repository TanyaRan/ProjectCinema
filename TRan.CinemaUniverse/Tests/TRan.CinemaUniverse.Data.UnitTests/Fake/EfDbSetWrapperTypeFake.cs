using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Models.Contracts;

namespace TRan.CinemaUniverse.Data.UnitTests.Fake
{
    public class EfDbSetWrapperTypeFake : IDeletable
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
