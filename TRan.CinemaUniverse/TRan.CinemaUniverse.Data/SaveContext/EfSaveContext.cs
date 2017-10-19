namespace TRan.CinemaUniverse.Data.SaveContext
{
    public class EfSaveContext : IEfSaveContext
    {
        private readonly CinemaSqlDbContext context;

        public EfSaveContext(CinemaSqlDbContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
