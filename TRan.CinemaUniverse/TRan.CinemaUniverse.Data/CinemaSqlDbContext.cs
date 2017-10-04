using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRan.CinemaUniverse.Models;

namespace TRan.CinemaUniverse.Data
{
    public class CinemaSqlDbContext : IdentityDbContext<User>
    {
        public CinemaSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CinemaSqlDbContext Create()
        {
            return new CinemaSqlDbContext();
        }
    }
}
