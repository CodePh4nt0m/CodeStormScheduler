using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeStormScheduler.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class CodeStormDbContext : IdentityDbContext<ApplicationUser>
    {
        public CodeStormDbContext()
            : base("CodeStormConnection", throwIfV1Schema: false)
        {
        }

        public static CodeStormDbContext Create()
        {
            return new CodeStormDbContext();
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<SharedEvent> SharedEvents { get; set; }

    }
}