using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using etkinlikSitesi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EtkinlikSitesi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
      
        public string AdiSoyadi { get; set; }
        public string Adres { get; set; }

 
        public string TelefonNo { get; set; }

        public virtual ICollection <Kayit> Kayit { get; set; }
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
        
        public DbSet<Etkinlik> Etkinlik { get; set; }
        public DbSet<Kayit> Kayit { get; set; }
        public DbSet<EtkinlikTuru> EtkinlikTuru { get; set; }
        public IEnumerable ApplicationUser { get; internal set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Etkinlik>().ToTable("Etkinlik");
            modelBuilder.Entity<Kayit>().ToTable("Kayit");
            modelBuilder.Entity<EtkinlikTuru>().ToTable("EtkinlikTuru");
        }
    }
}