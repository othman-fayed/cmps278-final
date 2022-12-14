using DocumentsWeb.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DocumentsWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(b =>
            {
                b.Property(x => x.FirstName);
                b.Property(x => x.LastName);

            });

            //seed roles
            var seedRoles = new List<IdentityRole>
            {
                new IdentityRole("Admin") { Id = "admin" },
                new IdentityRole("Writer") { Id = "writer" },
                new IdentityRole("Reviewer") { Id = "reviewer" },
            };
            modelBuilder.Entity<IdentityRole>().HasData(seedRoles);

            var admin = new User
            {
                Id = "admin",
                FirstName = "Osman",
                LastName = "Fayed",
                UserName = "omf02@aub.edu.lb",
            };
            admin.NormalizedUserName = admin.UserName.ToUpperInvariant();
            admin.Email = admin.UserName;

            admin.NormalizedEmail = admin.NormalizedUserName;

            modelBuilder.Entity<User>().HasData(admin);

            var adminRole = new IdentityUserRole<string>
            {
                UserId = "admin",
                RoleId = "admin",
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(adminRole);


        }
    }
}