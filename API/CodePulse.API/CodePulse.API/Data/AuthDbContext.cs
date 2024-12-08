using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CodePulse.API.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "388e3c13-8df9-4171-ae77-48aaa66e90a0";
            var writerRoleId = "eaad93dc-28cd-4403-8b93-da8574828468";

            //Roles
            var roles = new List<IdentityRole>
            {
                new()
                {
                    Id = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
                    ConcurrencyStamp = readerRoleId
                },
                new()
                {
                    Id = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                    ConcurrencyStamp = writerRoleId
                }
            };
            //SEED ROLES
            builder.Entity<IdentityRole>().HasData(roles);

            //USER TYPES
            var adminUserId = "53226e7e-1380-41fe-8c1c-c897a61a554f";
            var admin = new IdentityUser()
            {
                Id = adminUserId,
                UserName = "admin@codepulse.com",
                Email = "admin@codepulse.com",
                NormalizedEmail = "admin@codepulse.com".ToUpper(),
                NormalizedUserName = "admin@codepulse.com".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, "Admin@123");

            builder.Entity<IdentityUser>().HasData(admin);

            //Give Users Roles
            var adminRoles = new List<IdentityUserRole<string>>()
            {
                new()
                {
                    UserId = adminUserId,
                    RoleId = readerRoleId,
                },
                new()
                {
                    UserId = adminUserId,
                    RoleId = writerRoleId,
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);

        }
    }
}
