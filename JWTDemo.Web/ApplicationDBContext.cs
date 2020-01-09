using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Web
{
    public class ApplicationDbContext 
        : IdentityDbContext<ApplicationUser, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("User");
            builder.Entity<Role>().ToTable("Role")
                .Ignore(p=>p.ConcurrencyStamp);

            builder.Entity<UserRole>().ToTable("UserRole");
            builder.Entity<UserClaim>().ToTable("UserClaim");
            builder.Entity<UserLogin>().ToTable("UserLogin");
            builder.Entity<RoleClaim>().ToTable("RoleClaim");
            builder.Entity<UserToken>().ToTable("UserToekn");
        }
    }
}
