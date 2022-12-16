using DocumentsWeb.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DocumentsWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<Workflow> Workflows { get; set; }


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
                new IdentityRole("Admin") { Id = "admin", NormalizedName = "admin".ToUpper()  },
                new IdentityRole("Writer") { Id = "writer", NormalizedName = "writer".ToUpper() },
                new IdentityRole("Reviewer") { Id = "reviewer", NormalizedName = "reviewer".ToUpper() },
                new IdentityRole("Approved") { Id = "approved", NormalizedName = "approved".ToUpper() },
            };
            modelBuilder.Entity<IdentityRole>().HasData(seedRoles);

            var admin = new User
            {
                Id = "admin",
                FirstName = "Osman",
                LastName = "Fayed",
                UserName = "omf02@aub.edu.lb",
                EmailConfirmed = true,
            };
            admin.NormalizedUserName = admin.UserName.ToUpperInvariant();
            admin.Email = admin.UserName;
            admin.NormalizedEmail = admin.NormalizedUserName;

            //set user password
            PasswordHasher<User> ph = new PasswordHasher<User>();
            admin.PasswordHash = ph.HashPassword(admin, "Pass123$");

            modelBuilder.Entity<User>().HasData(admin);

            var adminRole = new IdentityUserRole<string>
            {
                UserId = "admin",
                RoleId = "admin",
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(adminRole);

            var defaultWorkflow = new Workflow
            {
                Id = 1,
                Name = "Default",
            };
            modelBuilder.Entity<Workflow>().HasData(defaultWorkflow);
            modelBuilder.Entity<WorkflowStep>().HasData(new WorkflowStep
            {
                Id = 1,
                Order = 1,
                Action = WorkflowAction.AddReviewer,
                Value = "*",
                WorkflowId = defaultWorkflow.Id
            });
        }
    }
}