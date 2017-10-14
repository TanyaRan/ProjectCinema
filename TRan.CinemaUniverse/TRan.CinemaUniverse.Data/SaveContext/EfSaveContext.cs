using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRan.CinemaUniverse.Data.SaveContext
{
    public class EfSaveContext : IEfSaveContext
    {
        private readonly CinemaSqlDbContext context;

        public EfSaveContext(CinemaSqlDbContext context)
        {
            this.context = context;
        }

        public void Complete()
        {
            this.context.SaveChanges();
        }
    }
}
