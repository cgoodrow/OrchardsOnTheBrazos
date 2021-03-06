﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OrchardsOnTheBrazos.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string Address { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<OrchardsOnTheBrazos.Models.Announcements> Announcements { get; set; }

        public System.Data.Entity.DbSet<OrchardsOnTheBrazos.Models.Events> Events { get; set; }

        public System.Data.Entity.DbSet<OrchardsOnTheBrazos.Models.FileDetail> FileDetail { get; set; }

        public System.Data.Entity.DbSet<OrchardsOnTheBrazos.Models.Support> Supports { get; set; }

        public System.Data.Entity.DbSet<OrchardsOnTheBrazos.Models.Info> Infoes { get; set; }

        public System.Data.Entity.DbSet<OrchardsOnTheBrazos.Models.Directory> Directories { get; set; }

        public System.Data.Entity.DbSet<OrchardsOnTheBrazos.Models.DirectoryDetail> DirectoryDetails { get; set; }
    }
}