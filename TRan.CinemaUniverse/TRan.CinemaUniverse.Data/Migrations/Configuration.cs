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
            this.SeedActors(context);
            this.SeedMovies(context);
        }

        private void SeedAdmin(CinemaSqlDbContext context)
        {
            const string AdministratorUserName = "admin@cinema.com";
            const string AdministratorPassword = "Admin1!";

            const string LecturerUserName = "lecturer@cinema.com";
            const string Lecturer1UserName = "ivanov@cinema.com";
            const string Lecturer2UserName = "petrov@cinema.com";
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

                lecturer = new User { UserName = Lecturer1UserName, Email = Lecturer1UserName, EmailConfirmed = true };
                userManager.Create(lecturer, LecturerPassword);
                userManager.AddToRole(lecturer.Id, "Lecturer");

                lecturer = new User { UserName = Lecturer2UserName, Email = Lecturer1UserName, EmailConfirmed = true };
                userManager.Create(lecturer, LecturerPassword);
                userManager.AddToRole(lecturer.Id, "Lecturer");

                role = new IdentityRole { Name = "User" };
                roleManager.Create(role);
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

        private void SeedActors(CinemaSqlDbContext context)
        {
            if (!context.Actors.Any())
            {
                var actor = new Actor() { Name = "Tom Hanks", ImageUrl = "https://cdn.amctheatres.com/production/2/cast-crew/33400/33430/profile/a14CNByTYALAPSGlwlmfHILpEIW.jpg" };
                context.Actors.Add(actor);

                actor = new Actor() { Name = "Julia Roberts", ImageUrl = "https://en.wikipedia.org/wiki/Julia_Roberts_filmography#/media/File:Julia_Roberts_2011_Shankbone_3.JPG" };
                context.Actors.Add(actor);

                actor = new Actor() { Name = "Johny Depp", ImageUrl = "http://www.moviescene.nl/ckfinder/userfiles/images/Moviescene/berichten/2014/april/johny-depp.jpg" };
                context.Actors.Add(actor);

                actor = new Actor() { Name = "Sandra Bullok", ImageUrl = "https://static1.squarespace.com/static/5732285a9f72668963041be2/t/5744add1e321402cfdf9baa2/1464118747940/" };
                context.Actors.Add(actor);

                actor = new Actor() { Name = "Hugh Grant", ImageUrl = "https://24smi.org/public/media/news/2015/03/10/1425990628-hyu-grant.jpg" };
                context.Actors.Add(actor);

                actor = new Actor() { Name = "Meryl Streep", ImageUrl = "https://images-production.global.ssl.fastly.net/uploads/photos/file/227663/most-oscars-meryl-streep.jpg?auto=compress&crop=top&fit=clip&h=500&q=55&w=698" };
                context.Actors.Add(actor);
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
