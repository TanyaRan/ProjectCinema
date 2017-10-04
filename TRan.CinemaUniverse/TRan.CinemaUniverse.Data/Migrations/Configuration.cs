namespace TRan.CinemaUniverse.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
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
        }

        private void SeedAdmin(CinemaSqlDbContext context)
        {
            const string AdministratorUserName = "tran@cinema.com";
            const string AdministratorPassword = "12#$qwER";

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User { UserName = AdministratorUserName, Email = AdministratorUserName, EmailConfirmed = true };
                userManager.Create(user, AdministratorPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
