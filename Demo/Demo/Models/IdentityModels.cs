using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;

namespace Demo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string PostalAddress { get; set; }
        public virtual MyUserInfo MyUserInfo { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
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

        public System.Data.Entity.DbSet<MyUserInfo> MyUserInfo { get; set; }
        public System.Data.Entity.DbSet<Product> Product { get; set; }

        public System.Data.Entity.DbSet<Order> Order { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Size { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public DateTime AddedOn { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }

    public class MyUserInfo {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}