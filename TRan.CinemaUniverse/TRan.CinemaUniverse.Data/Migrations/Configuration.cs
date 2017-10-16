namespace TRan.CinemaUniverse.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TRan.CinemaUniverse.Data;
    using TRan.CinemaUniverse.Models;

    public sealed class Configuration : DbMigrationsConfiguration<CinemaSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CinemaSqlDbContext context)
        {
            this.SeedAdmin(context);
            this.SeedGenres(context);
            this.SeedMovies(context);
        }

        private void SeedAdmin(CinemaSqlDbContext context)
        {
            const string AdministratorUserName = "admin@cinema.com";
            const string AdministratorPassword = "Admin1!";

            const string LecturerUserName = "lecturer@cinema.com";
            const string LecturerPassword = "Lecturer1!";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var admin = new User { UserName = AdministratorUserName, Email = AdministratorUserName, EmailConfirmed = true };
                userManager.Create(admin, AdministratorPassword);

                userManager.AddToRole(admin.Id, "Admin");

                role = new IdentityRole { Name = "Lecturer" };
                roleManager.Create(role);
                var lecturer = new User { UserName = LecturerUserName, Email = LecturerUserName, EmailConfirmed = true };
                userManager.Create(lecturer, LecturerPassword);

                userManager.AddToRole(lecturer.Id, "Lecturer");
            }
        }

        private void SeedGenres(CinemaSqlDbContext context)
        {
            if (!context.Genres.Any())
            {
                var genre = new Genre() { Name = "Comedy" };
                context.Genres.Add(genre);

                genre = new Genre() { Name = "Romance" };
                context.Genres.Add(genre);

                genre = new Genre() { Name = "Action" };
                context.Genres.Add(genre);

                genre = new Genre() { Name = "Drama" };
                context.Genres.Add(genre);

                genre = new Genre() { Name = "Animation" };
                context.Genres.Add(genre);

                genre = new Genre() { Name = "Adventure" };
                context.Genres.Add(genre);
            }
        }

        private void SeedMovies(CinemaSqlDbContext context)
        {            
            if (!context.Movies.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var movie = new Movie()
                    {
                        Title = "Movie " + i,
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed sit amet lobortis nibh. Nullam bibendum, tortor quis porttitor fringilla, eros risus consequat orci, at scelerisque mauris dolor sit amet nulla. Vivamus turpis lorem, pellentesque eget enim ut, semper faucibus tortor. Aenean malesuada laoreet lorem.",
                        Director = "Ivanov",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTUwNjUxMTM4NV5BMl5BanBnXkFtZTgwODExMDQzMTI@._V1_SY1000_CR0,0,674,1000_AL_.jpg",
                        CreatedOn = DateTime.Now
                    };

                    context.Movies.Add(movie);
                }
            }
        }
    }
}
